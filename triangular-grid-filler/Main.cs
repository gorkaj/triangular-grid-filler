using ObjLoader.Loader.Data.VertexData;
using ObjLoader.Loader.Loaders;
using System.Numerics;
using Timer = System.Windows.Forms.Timer;

namespace triangular_grid_filler
{
    public partial class Main : Form
    {
        private ObjLoaderFactory objLoaderFactory;
        private LoadResult loadedObject;
        private Bitmap drawArea;
        //private Int32[] canvasBits;
        private List<Triangle> triangles;
        private List<Normal> normals;

        private Vector3 lightVersor;

        private float kd;
        private float ks;
        private int m;

        private (int R, int G, int B) objectColor;
        private (int R, int G, int B) lightColor;

        Timer timer;
        int tickCounter;

        public static int CANVAS_SIZE = 650;
        private const string DEFAULT_OBJ_PATH = "../../../models/sphere.obj";

        public Main()
        {
            InitializeComponent();
            objLoaderFactory = new ObjLoaderFactory();
            drawArea = new Bitmap(Canvas.Width, Canvas.Height);
            loadedObject = LoadObjFile();
            triangles = Triangulator.Triangulate(loadedObject.Vertices.ToList(), loadedObject.Groups[0].Faces.ToList());
            normals = loadedObject.Normals.ToList();
            kd = (float)kd_trackbar.Value / 100;
            ks = (float)ks_trackbar.Value / 100;
            m = m_trackbar.Value;
            objectColor = (255, 235, 205);
            FillColorBox(objColorBox, objectColor);
            lightColor = (255, 255, 255);
            FillColorBox(lightColorBox, lightColor);
            lightVersor = new Vector3(1, 0, .9F);
            lightVersor = Vector3.Normalize(lightVersor);
            //canvasBits = new Int32[CANVAS_SIZE * CANVAS_SIZE];
            tickCounter = 0;
            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(UpdateLightVector);
            timer.Start();
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
            //drawArea.Dispose();
            //drawArea = new Bitmap(Canvas.Width, Canvas.Height);
            // Graphics g = Graphics.FromImage(drawArea);

            //Parallel.ForEach(triangles,
            //   t => TriangleFiller.FillTriangle(t, Color.FromArgb(objectColor.R, objectColor.G, objectColor.B), drawArea, ComputeColor));
            foreach (var t in triangles)
            {
                TriangleFiller.FillTriangle(t, Color.FromArgb(objectColor.R, objectColor.G, objectColor.B), drawArea, ComputeColor);
            }

            if (showGrid.Checked)
            {
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    foreach (var t in triangles)
                    {
                        t.drawTriangle(g);
                    }  
                }
            }

            Canvas.Image = drawArea;
            //Canvas.Refresh();
        }

        private float Cos(Vector3 a, Vector3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        private Color ColorFromRGB(int R, int G, int B)
        {
            return Color.FromArgb(R, G, B);
        }

        private (int R, int G, int B) RGBFromColor(Color c)
        {
            return (c.R, c.G, c.B);
        }

        private Vector3 GetNormalVersor(int x, int y)
        {
            float _x, _y, _z, _radius;
            _radius = CANVAS_SIZE / 2;
            _x = x - CANVAS_SIZE / 2;
            _y = y - CANVAS_SIZE / 2;
            _z = (float)Math.Sqrt(_radius * _radius - _x * _x - _y * _y);
            Vector3 normalVersor = new Vector3(_x, _y, _z);
            normalVersor = Vector3.Normalize(normalVersor);
            return normalVersor;
        }

        public Color ComputeColor(double x, double y, Triangle t)
        {
            int i1 = t.NormalIds[0];
            int i2 = t.NormalIds[1];
            int i3 = t.NormalIds[2];

            var v1 = t.Points[0];
            var v2 = t.Points[1];
            var v3 = t.Points[2];

            var N1 = new Vector3(normals[i1].X, normals[i1].Y, normals[i1].Z);
            var N2 = new Vector3(normals[i2].X, normals[i2].Y, normals[i2].Z);
            var N3 = new Vector3(normals[i3].X, normals[i3].Y, normals[i3].Z);

            double w1 = ((v2.Y - v3.Y) * (x - v3.X) + (v3.X - v2.X) * (y - v3.Y)) / ((v2.Y - v3.Y) * (v1.X - v3.X) + (v3.X - v2.X) * (v1.Y - v3.Y));
            double w2 = ((v3.Y - v1.Y) * (x - v3.X) + (v1.X - v3.X) * (y - v3.Y)) / ((v2.Y - v3.Y) * (v1.X - v3.X) + (v3.X - v2.X) * (v1.Y - v3.Y));
            double w3 = 1 - w1 - w2;

            if (interpolateButton.Checked)
            { 
                var R1 = 2 * Cos(N1, lightVersor) * N1 - lightVersor;
                var R2 = 2 * Cos(N2, lightVersor) * N2 - lightVersor;
                var R3 = 2 * Cos(N3, lightVersor) * N3 - lightVersor;

                var R =
                    w1 * Cos(N1, lightVersor) * kd * lightColor.R / 255 * objectColor.R / 255 + 
                    ks * lightColor.R / 255 * objectColor.R / 255 * Math.Pow(Math.Max(Cos(new Vector3(0, 0, 1), R1), 0), m) +
                    w2 * Cos(N2, lightVersor) * kd * lightColor.R / 255 * objectColor.R / 255 + 
                    ks * lightColor.R / 255 * objectColor.R / 255 * Math.Pow(Math.Max(Cos(new Vector3(0, 0, 1), R2), 0), m) +
                    w3 * Cos(N3, lightVersor) * kd * lightColor.R / 255 * objectColor.R / 255 + 
                    ks * lightColor.R / 255 * objectColor.R / 255 * Math.Pow(Math.Max(Cos(new Vector3(0, 0, 1), R3), 0), m);

                var G = 
                    w1 * Cos(N1, lightVersor) * kd * lightColor.G / 255 * objectColor.G / 255 + 
                    ks * lightColor.G / 255 * objectColor.G / 255 * Math.Pow(Math.Max(Cos(new Vector3(0, 0, 1), R1), 0), m) +
                    w2 * Cos(N2, lightVersor) * kd * lightColor.G / 255 * objectColor.G / 255 +
                    ks * lightColor.G / 255 * objectColor.G / 255 * Math.Pow(Math.Max(Cos(new Vector3(0, 0, 1), R2), 0), m) +
                    w3 * Cos(N3, lightVersor) * kd * lightColor.G / 255 * objectColor.G / 255 + 
                    ks * lightColor.G / 255 * objectColor.G / 255 * Math.Pow(Math.Max(Cos(new Vector3(0, 0, 1), R3), 0), m);

                var B =
                    w1 * Cos(N1, lightVersor) * kd * lightColor.B / 255 * objectColor.B / 255 + 
                    ks * lightColor.B / 255 * objectColor.B / 255 * Math.Pow(Math.Max(Cos(new Vector3(0, 0, 1), R1), 0), m) +
                    w2 * Cos(N2, lightVersor) * kd * lightColor.B / 255 * objectColor.B / 255 + 
                    ks * lightColor.B / 255 * objectColor.B / 255 * Math.Pow(Math.Max(Cos(new Vector3(0, 0, 1), R2), 0), m) +
                    w3 * Cos(N3, lightVersor) * kd * lightColor.B / 255 * objectColor.B / 255 + 
                    ks * lightColor.B / 255 * objectColor.B / 255 * Math.Pow(Math.Max(Cos(new Vector3(0, 0, 1), R3), 0), m);

                R = Math.Min(1, Math.Max(0, R));
                G = Math.Min(1, Math.Max(0, G));
                B = Math.Min(1, Math.Max(0, B));

                return Color.FromArgb((int)Math.Round(R * 255, 0), (int)Math.Round(G * 255, 0), (int)Math.Round(B * 255, 0));

            }
            else
            {
                var normalVersor = new Vector3((float)(w1 * N1.X + w2 * N2.X + w3 * N3.X), (float)(w1 * N1.Y + w2 * N2.Y + w3 * N3.Y), (float)(w1 * N1.Z + w2 * N2.Z + w3 * N3.Z));

                // var normalVersor = GetNormalVersor((int)x, (int)y);

                double R, G, B;
                float CosNL = Cos(normalVersor, lightVersor);
                var RVector = 2 * CosNL * normalVersor - lightVersor;

                double VRcos = Math.Pow(Math.Max(0, Cos(new Vector3(0, 0, 1), RVector)), m);

                R = CosNL * kd * lightColor.R / 255 * objectColor.R / 255 + VRcos * ks * lightColor.R / 255 * objectColor.R / 255;
                G = CosNL * kd * lightColor.G / 255 * objectColor.G / 255 + VRcos * ks * lightColor.G / 255 * objectColor.G / 255;
                B = CosNL * kd * lightColor.B / 255 * objectColor.B / 255 + VRcos * ks * lightColor.B / 255 * objectColor.B / 255;

                R = Math.Min(1, Math.Max(0, R));
                G = Math.Min(1, Math.Max(0, G));
                B = Math.Min(1, Math.Max(0, B));

                return Color.FromArgb((int)Math.Round(R * 255, 0), (int)Math.Round(G * 255, 0), (int)Math.Round(B * 255, 0));
            }
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
            z = 0.9F;
            x = (float)Math.Cos(tickCounter / MAX * Math.PI * 2);
            y = (float)Math.Sin(tickCounter / MAX * Math.PI * 2);

            lightVersor = new Vector3(x, y, z);
            lightVersor = Vector3.Normalize(lightVersor);

            RedrawAll();
            tickCounter++;
        }
    }
}