using ObjLoader.Loader.Data.VertexData;
using ObjLoader.Loader.Loaders;
using System.Numerics;

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

        private float kd;
        private float ks;
        private int m;

        private (int R, int G, int B) objectColor;
        private (int R, int G, int B) lightColor;

        public static int CANVAS_SIZE = 650;
        private const string DEFAULT_OBJ_PATH = "../../../models/sphere-lab.obj";

        public Main()
        {
            InitializeComponent();
            objLoaderFactory = new ObjLoaderFactory();
            drawArea = new Bitmap(Canvas.Width, Canvas.Height);
            loadedObject = LoadObjFile();
            triangles = Triangulator.Triangulate(loadedObject.Vertices.ToList(), loadedObject.Groups[0].Faces.ToList());
            normals = loadedObject.Normals.ToList();
            kd = kd_trackbar.Value / 100;
            ks = ks_trackbar.Value / 100;
            m = m_trackbar.Value;
            objectColor = (255, 235, 205);
            FillColorBox(objColorBox, objectColor);
            lightColor = (255, 255, 255);
            FillColorBox(lightColorBox, lightColor);
            //canvasBits = new Int32[CANVAS_SIZE * CANVAS_SIZE];
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
            drawArea.Dispose();
            drawArea = new Bitmap(Canvas.Width, Canvas.Height);

            foreach (var t in triangles)
            {
                TriangleFiller.FillTriangle(t.Points, Color.FromArgb(objectColor.R, objectColor.G, objectColor.B), drawArea);
            }

            foreach (var t in triangles)
            {
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    t.drawTriangle(g);
                }
            }

            Canvas.Image = drawArea;
            Canvas.Refresh();
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

        private Color ComputeColor()
        {
            //Point normalVersor = GetNormalVersor(x, y);

            //(int R, int G, int B) objectColor = GetObjectColorAtPos(x, y);
            //float R, G, B;
            //float CosNL = Cos(normalVersor, lightVersor);
            //Point RVector = 2 * CosNL * normalVersor - lightVersor;

            //float VRcos = Pow(Math.Max(0, Cos(VVector, RVector)), M);

            //R = CosNL * kd * lightColor.R / 255 * objectColor.R / 255 + VRcos * ks * lightColor.R / 255 * objectColor.R / 255;
            //G = CosNL * kd * lightColor.G / 255 * objectColor.G / 255 + VRcos * ks * lightColor.G / 255 * objectColor.G / 255;
            //B = CosNL * kd * lightColor.B / 255 * objectColor.B / 255 + VRcos * ks * lightColor.B / 255 * objectColor.B / 255;

            //R = Math.Min(1, Math.Max(0, R));
            //G = Math.Min(1, Math.Max(0, G));
            //B = Math.Min(1, Math.Max(0, B));

            //return RGBToInt((int)Math.Round(R * 255, 0), (int)Math.Round(G * 255, 0), (int)Math.Round(B * 255, 0));
            return Color.Fuchsia;
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
    }
}