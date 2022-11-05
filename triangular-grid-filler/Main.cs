using ObjLoader.Loader.Loaders;

namespace triangular_grid_filler
{
    public partial class Main : Form
    {
        private ObjLoaderFactory objLoaderFactory;
        private LoadResult loadedObject;
        private Bitmap drawArea;
        //private Int32[] canvasBits;
        private List<Triangle> triangles;

        private float kd;
        private float ks;
        private int m;

        private (int R, int G, int B) objectColor;

        public static int CANVAS_SIZE = 650;
        private const string DEFAULT_OBJ_PATH = "../../../models/sphere.obj";

        public Main()
        {
            InitializeComponent();
            objLoaderFactory = new ObjLoaderFactory();
            drawArea = new Bitmap(Canvas.Width, Canvas.Height);
            loadedObject = LoadObjFile();
            triangles = Triangulator.Triangulate(loadedObject.Vertices.ToList(), loadedObject.Groups[0].Faces.ToList());
            kd = kd_trackbar.Value / 100;
            ks = ks_trackbar.Value / 100;
            m = m_trackbar.Value;
            objectColor = (255, 235, 205);
            FillColorBox(objColorBox);
            //canvasBits = new Int32[CANVAS_SIZE * CANVAS_SIZE];
            RedrawAll();
        }

        private void FillColorBox(PictureBox box)
        {
            box.Image?.Dispose();
            Bitmap bitmap = new Bitmap(46, 34);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.FromArgb(objectColor.R, objectColor.G, objectColor.B));
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

        private void objColorBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                objectColor = (dialog.Color.R, dialog.Color.G, dialog.Color.B);
            }
            FillColorBox(objColorBox);
            RedrawAll();
        }
    }
}