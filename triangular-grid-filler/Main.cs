using ObjLoader.Loader.Data.VertexData;
using ObjLoader.Loader.Loaders;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using Timer = System.Windows.Forms.Timer;

namespace triangular_grid_filler
{
    public partial class Main : Form
    {
        public static int CANVAS_SIZE = 650;
        private ObjLoaderFactory objLoaderFactory;
        private LoadResult loadedObject;
        private DirectBitmap drawArea;
        private DirectBitmap texture;
        private DirectBitmap normalMap;
        private List<Triangle> triangles;
        private List<Normal> normals;

        private Vector3 lightVersor;
        private Polygon cloud;

        private float kd;
        private float ks;
        private int m;

        private (int R, int G, int B) objectColor;
        private (int R, int G, int B) lightColor;
        private Timer? timer;
        private int tickCounter;
        private Timer? cloudTimer;
        private int cloudTickCounter = 0;

        private const string DEFAULT_OBJ_PATH = "../../../models/sphereSmooth.obj";
        private const string DEFAULT_TEXTURE_PATH = "../../../textures/waves.jpg";
        private const string DEFAULT_NORMAL_MAP_PATH = "../../../normal_maps/stone.jpg";
        private Vector3 V001 = new(0, 0, 1);

        public Main()
        {
            InitializeComponent();
            objLoaderFactory = new ObjLoaderFactory();
            drawArea = new(CANVAS_SIZE, CANVAS_SIZE);
            loadedObject = LoadObjFile();
            triangles = ObjMapper.Triangulate(loadedObject.Vertices.ToList(), loadedObject.Groups[0].Faces.ToList());
            normals = loadedObject.Normals.ToList();
            kd = (float)kd_trackbar.Value / 100;
            ks = (float)ks_trackbar.Value / 100;
            m = m_trackbar.Value;
            objectColor = (255, 235, 205);
            FillColorBox(objColorBox, objectColor);
            lightColor = (255, 255, 255);
            FillColorBox(lightColorBox, lightColor);
            lightVersor = new Vector3(1, 0, (float)zLightTrackBar.Value / 10);
            lightVersor = Vector3.Normalize(lightVersor);
            LoadTexture(DEFAULT_TEXTURE_PATH);
            LoadNormalMap(DEFAULT_NORMAL_MAP_PATH);
            tickCounter = 0;
            
            var cloudVertices = new List<Vertex>() { new Vertex(1.3f, .5f, .5f),
                                                     new Vertex(1.2f, .6f, .5f),
                                                     new Vertex(1.0f, -.3f, .5f),
                                                     new Vertex(1.15f, -.7f, .5f)};
            cloud = new Polygon(cloudVertices);
            
            if (rotateLight.Checked)
            {
                timer = new Timer
                {
                    Interval = 10
                };
                timer.Tick += new EventHandler(UpdateLightVector);
                timer.Start();
            }
            else
            {
                timer = null;
            }

            if (cloudsBox.Checked)
            {
                cloudTimer = new Timer
                {
                    Interval = 10
                };
                cloudTimer.Tick += new EventHandler(UpdateCloudPosition);
                cloudTimer.Start();
            }
            else
            {
                cloudTimer = null;
            }

        RedrawAll();
        }

        private void FillColorBox(PictureBox box, (int R, int G, int B) color)
        {
            box.Image?.Dispose();
            Bitmap bitmap = new Bitmap(46, 34);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.FromArgb(color.R, color.G, color.B));
            box.Image = bitmap;
        }

        private LoadResult LoadObjFile(string path = DEFAULT_OBJ_PATH)
        {
            var objLoader = objLoaderFactory.Create();
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return objLoader.Load(fileStream);
        }

        private void RedrawAll()
        {
            Graphics gg = Graphics.FromImage(drawArea.Bitmap);
            gg.Clear(SystemColors.Control);
            gg.Dispose();

            Parallel.ForEach(triangles,
                t => PolygonFiller.FillPolygon(t, t.Points, drawArea, ComputeColor, null));


            //foreach (var t in triangles)
            //{
            //    PolygonFiller.FillPolygon(t, t.Points, drawArea, ComputeColor, null);
            //}

            if (showGrid.Checked)
            {
                using (Graphics g = Graphics.FromImage(drawArea.Bitmap))
                {
                    foreach (var t in triangles)
                    {
                        t.drawTriangle(g);
                    }  
                }
            }

            if(cloud != null && cloudsBox.Checked)
            {
                using (Graphics g = Graphics.FromImage(drawArea.Bitmap))
                {
                    cloud?.Draw(g);
                    PolygonFiller.FillPolygon(null, cloud?.Points, drawArea, null, Color.LightBlue);
                }
                // DrawShadow();
            }

            Canvas.Image = drawArea.Bitmap;

        }

        private void DrawShadow()
        {
            float h1 = lightVersor.Z - cloud.Vertices[0].Z;
            float h2 = cloud.Vertices[0].Z;
            float dh = h2 / h1;

            var newPoints = new List<Vertex>();
            for(int i=0;i<cloud.Points.Count; ++i)
            {
                var dx = cloud.Vertices[i].X - lightVersor.X;
                var dy = cloud.Vertices[i].Y - lightVersor.Y;

                newPoints.Add(new Vertex(cloud.Vertices[i].X + dh * dx, cloud.Vertices[i].Y + dh * dy, 0));
            }

            var shade = new Polygon(newPoints);
            using (Graphics g = Graphics.FromImage(drawArea.Bitmap))
            {
                PolygonFiller.FillPolygon(null, shade.Points, drawArea, null, Color.Gray);
            }
        }

        private float Cos(Vector3 a, Vector3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        private void LoadTexture(string path)
        {
            Image sourceImage = new Bitmap(path);
            texture = new DirectBitmap(CANVAS_SIZE, CANVAS_SIZE);
            using (var g = Graphics.FromImage(texture.Bitmap))
            {
                g.DrawImage(sourceImage, 0, 0);
            }

            Graphics graphics = Graphics.FromImage(drawArea.Bitmap);
            graphics.DrawImage(sourceImage, 0, 0, CANVAS_SIZE, CANVAS_SIZE);
            Canvas.Image = drawArea.Bitmap;
            RedrawAll();
        }

        private void LoadNormalMap(string path)
        {
            Image sourceImage = new Bitmap(path);
            normalMap = new DirectBitmap(CANVAS_SIZE, CANVAS_SIZE);
            using (var g = Graphics.FromImage(normalMap.Bitmap))
            {
                g.DrawImage(sourceImage, 0, 0);
            }
            RedrawAll();
        }

        private List<Vector3> GetNormalVectors(List<int> ind, int x, int y)
        {
            List<Vector3> result = new();

            foreach (int i in ind)
            {
                result.Add(new Vector3(normals[i].X, normals[i].Y, normals[i].Z));
            }
            for (int i = 0; i < result.Count; ++i)
            {
                result[i] = Vector3.Normalize(result[i]);
            }

            if (useNormalMap.Checked)
            {
                var nx = (float)normalMap.GetPixel(x, y).R  * 2 / 255 - 1;
                var ny = (float)normalMap.GetPixel(x, y).G * 2 / 255 - 1;
                var nz = (float)normalMap.GetPixel(x, y).B / 255;

                for (int i = 0; i < result.Count; ++i)
                {
                    var B = result[i] != V001 ? Vector3.Cross(result[i], V001): new Vector3(0, 1, 0);
                    var T = Vector3.Cross(B, result[i]);

                    result[i] = new Vector3(
                        T.X * nx + B.X * ny + result[i].X * nz,
                        T.Y * nx + B.Y * ny + result[i].Y * nz,
                        T.Z * nx + B.Z * ny + result[i].Z * nz);
                }

                for (int i = 0; i < result.Count; ++i)
                {
                    result[i] = Vector3.Normalize(result[i]);
                }
            }

            return result;
        }

        public Color ComputeColor(double x, double y, Triangle t)
        {
            (int R, int G, int B) objColor = (solidRadioBtn.Checked || texture == null) ? objectColor : (texture.GetPixel((int)x, (int)y).R,
                                                                                    texture.GetPixel((int)x, (int)y).G,
                                                                                    texture.GetPixel((int)x, (int)y).B);

            int i1 = t.NormalIds[0];
            int i2 = t.NormalIds[1];
            int i3 = t.NormalIds[2];

            var v1 = t.Points[0];
            var v2 = t.Points[1];
            var v3 = t.Points[2];

            var normals = GetNormalVectors(new List<int>() { i1, i2, i3 }, (int)x, (int)y);
            var N1 = normals[0];
            var N2 = normals[1];
            var N3 = normals[2];


            double w1 = ((v2.Y - v3.Y) * (x - v3.X) + (v3.X - v2.X) * (y - v3.Y)) / ((v2.Y - v3.Y) * (v1.X - v3.X) + (v3.X - v2.X) * (v1.Y - v3.Y));
            double w2 = ((v3.Y - v1.Y) * (x - v3.X) + (v1.X - v3.X) * (y - v3.Y)) / ((v2.Y - v3.Y) * (v1.X - v3.X) + (v3.X - v2.X) * (v1.Y - v3.Y));
            double w3 = 1 - w1 - w2;

            double R, G, B;

            if (interpolateButton.Checked)
            { 
                var R1 = 2 * Cos(N1, lightVersor) * N1 - lightVersor;
                var R2 = 2 * Cos(N2, lightVersor) * N2 - lightVersor;
                var R3 = 2 * Cos(N3, lightVersor) * N3 - lightVersor;

                R =
                    w1 * (Cos(N1, lightVersor) * kd * lightColor.R / 255f * objColor.R / 255f +
                    ks * lightColor.R / 255f * objColor.R / 255f * Math.Pow(Math.Max(Cos(V001, R1), 0), m)) +
                    w2 * (Cos(N2, lightVersor) * kd * lightColor.R / 255f * objColor.R / 255f +
                    ks * lightColor.R / 255f * objColor.R / 255f * Math.Pow(Math.Max(Cos(V001, R2), 0), m)) +
                    w3 * (Cos(N3, lightVersor) * kd * lightColor.R / 255f * objColor.R / 255f +
                    ks * lightColor.R / 255f * objColor.R / 255f * Math.Pow(Math.Max(Cos(V001, R3), 0), m));

                G =
                    w1 * (Cos(N1, lightVersor) * kd * lightColor.G / 255f * objColor.G / 255f +
                    ks * lightColor.G / 255f * objColor.G / 255f * Math.Pow(Math.Max(Cos(V001, R1), 0), m)) +
                    w2 * (Cos(N2, lightVersor) * kd * lightColor.G / 255f * objColor.G / 255f +
                    ks * lightColor.G / 255f * objColor.G / 255f * Math.Pow(Math.Max(Cos(V001, R2), 0), m)) +
                    w3 * (Cos(N3, lightVersor) * kd * lightColor.G / 255f * objColor.G / 255f +
                    ks * lightColor.G / 255f * objColor.G / 255f * Math.Pow(Math.Max(Cos(V001, R3), 0), m));

                B =
                    w1 * (Cos(N1, lightVersor) * kd * lightColor.B / 255f * objColor.B / 255f +
                    ks * lightColor.B / 255f * objColor.B / 255f * Math.Pow(Math.Max(Cos(V001, R1), 0), m)) +
                    w2 * (Cos(N2, lightVersor) * kd * lightColor.B / 255f * objColor.B / 255f +
                    ks * lightColor.B / 255f * objColor.B / 255f * Math.Pow(Math.Max(Cos(V001, R2), 0), m)) +
                    w3 * (Cos(N3, lightVersor) * kd * lightColor.B / 255f * objColor.B / 255f +
                    ks * lightColor.B / 255f * objColor.B / 255f * Math.Pow(Math.Max(Cos(V001, R3), 0), m));

            }
            else
            {
                var normalVersor = 
                    new Vector3((float)(w1 * N1.X + w2 * N2.X + w3 * N3.X), 
                                (float)(w1 * N1.Y + w2 * N2.Y + w3 * N3.Y), 
                                (float)(w1 * N1.Z + w2 * N2.Z + w3 * N3.Z));

                normalVersor = Vector3.Normalize(normalVersor);

                float CosNL = Math.Max(Cos(normalVersor, lightVersor), 0);
                var RVector = 2 * CosNL * normalVersor - lightVersor;

                double VRcos = Math.Pow(Math.Max(0, Cos(V001, RVector)), m);

                R = CosNL * kd * lightColor.R / 255f * objColor.R / 255f + VRcos * ks * lightColor.R / 255f * objColor.R / 255f;
                G = CosNL * kd * lightColor.G / 255f * objColor.G / 255f + VRcos * ks * lightColor.G / 255f * objColor.G / 255f;
                B = CosNL * kd * lightColor.B / 255f * objColor.B / 255f + VRcos * ks * lightColor.B / 255f * objColor.B / 255f;
            }

            R = Math.Min(1, Math.Max(0, R));
            G = Math.Min(1, Math.Max(0, G));
            B = Math.Min(1, Math.Max(0, B));

            return Color.FromArgb((int)Math.Round(R * 255, 0), (int)Math.Round(G * 255, 0), (int)Math.Round(B * 255, 0));
        }

        private void objColorBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                objectColor = (dialog.Color.R, dialog.Color.G, dialog.Color.B);
            }
            FillColorBox(objColorBox, objectColor);
            RedrawAll();
        }

        private void lightColorBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lightColor = (dialog.Color.R, dialog.Color.G, dialog.Color.B);
            }
            FillColorBox(lightColorBox, lightColor);
            RedrawAll();
        }

        private void interpolateButton_CheckedChanged(object sender, EventArgs e)
        {
            RedrawAll();
        }

        private void kd_trackbar_ValueChanged(object sender, EventArgs e)
        {
            kd = (float)kd_trackbar.Value / 100;
            RedrawAll();
        }

        private void ks_trackbar_ValueChanged(object sender, EventArgs e)
        {
            ks = (float)ks_trackbar.Value / 100;
            RedrawAll();
        }

        private void m_trackbar_Scroll(object sender, EventArgs e)
        {
            m = m_trackbar.Value;
            RedrawAll();
        }

        private void showGrid_CheckedChanged(object sender, EventArgs e)
        {
            RedrawAll();
        }

        private void UpdateLightVector(Object o, EventArgs e)
        {
            float MAX = 240;
            if (tickCounter == MAX) tickCounter = 0;
            float x, y, z;
            z = (float)zLightTrackBar.Value / 10;
            x = (float)Math.Cos(tickCounter / MAX * Math.PI * 2);
            y = (float)Math.Sin(tickCounter / MAX * Math.PI * 2);

            lightVersor = new Vector3(x, y, z);
            lightVersor = Vector3.Normalize(lightVersor);

            RedrawAll();
            tickCounter++;
        }

        private void UpdateCloudPosition(Object o, EventArgs e)
        {
            if (cloud != null && cloudsBox.Checked)
            {
                if (cloudTickCounter == 100)
                    cloudTickCounter = 0;

                var cloudVertices = new List<Vertex>() { new Vertex(1.3f - cloudTickCounter * 0.02f, .5f, .5f),
                                                     new Vertex(1.2f - cloudTickCounter * 0.02f, .6f, .5f),
                                                     new Vertex(1.0f - cloudTickCounter * 0.02f, -.3f, .5f),
                                                     new Vertex(1.15f - cloudTickCounter * 0.02f, -.7f, .5f)};
                cloud = new Polygon(cloudVertices);
            }
            RedrawAll();
            cloudTickCounter++;
        }

        private void textureBtn_Click(object sender, EventArgs e)
        {
            timer?.Stop();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            dialog.InitialDirectory = Path.GetFullPath("..\\..\\..\\textures");
            dialog.Title = "Please select an image file.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadTexture(dialog.FileName);
            }
            timer?.Start();
        }

        private void solidRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            RedrawAll();
        }

        private void textureRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            RedrawAll();
        }

        private void objBrowseBtn_Click(object sender, EventArgs e)
        {
            timer?.Stop();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "OBJ Files|*.obj;";
            dialog.InitialDirectory = Path.GetFullPath("..\\..\\..\\models");
            dialog.Title = "Please select an obj file.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                loadedObject = LoadObjFile(dialog.FileName);
                triangles = ObjMapper.Triangulate(loadedObject.Vertices.ToList(), loadedObject.Groups[0].Faces.ToList());
                normals = loadedObject.Normals.ToList();
                RedrawAll();
            }
            timer?.Start();
        }

        private void zLightTrackBar_ValueChanged(object sender, EventArgs e)
        {
            UpdateLightVector(sender, e);
        }

        private void rotateLight_CheckedChanged(object sender, EventArgs e)
        {
            if (rotateLight.Checked)
            {
                timer = new Timer
                {
                    Interval = 10
                };
                timer.Tick += new EventHandler(UpdateLightVector);
                timer.Start();
            }
            else
            {
                timer?.Dispose();
                timer = null;
            }
        }

        private void chooseNormalMapBtn_Click(object sender, EventArgs e)
        {
            timer?.Stop();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            dialog.InitialDirectory = Path.GetFullPath("..\\..\\..\\normal_maps");
            dialog.Title = "Please select an image file.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadNormalMap(dialog.FileName);
            }
            timer?.Start();
        }

        private void useNormalMap_CheckedChanged(object sender, EventArgs e)
        {
            RedrawAll();
        }

        private void cloudsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cloudsBox.Checked)
            {
                cloudTimer = new Timer
                {
                    Interval = 10
                };
                cloudTimer.Tick += new EventHandler(UpdateCloudPosition);
                cloudTimer.Start();
            }
            else
            {
                cloudTimer?.Dispose();
                cloudTimer = null;
            }
        }
    }
}