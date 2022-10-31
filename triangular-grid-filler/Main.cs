using ObjLoader.Loader.Loaders;

namespace triangular_grid_filler
{
    public partial class Main : Form
    {
        private ObjLoaderFactory objLoaderFactory;
        private LoadResult loadedObject;
        private Bitmap drawArea;
        private List<Triangle> triangles;

        private float kd;
        private float ks;
        private int m;

        public static int CANVAS_SIZE = 650;
        private const string DEFAULT_OBJ_PATH = "../../../objects/sphere.obj";

        public Main()
        {
            InitializeComponent();
            objLoaderFactory = new ObjLoaderFactory();
            drawArea = new Bitmap(Canvas.Width, Canvas.Height);
            loadedObject = LoadObjFile();
            triangles = Triangulator.Triangulate(loadedObject.Vertices.ToList(), loadedObject.Groups[0].Faces.ToList());
            kd = kd_trackbar.Value;
            ks = ks_trackbar.Value;
            m = m_trackbar.Value;
            Draw();
        }

        private LoadResult LoadObjFile(string path = DEFAULT_OBJ_PATH)
        {
            var objLoader = objLoaderFactory.Create();
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return objLoader.Load(fileStream);
        }

        private void Draw()
        {
            drawArea.Dispose();
            drawArea = new Bitmap(Canvas.Width, Canvas.Height);

            //int i = 0;
            //foreach (var vert in loadedObject.Vertices)
            //{
            //    using (Graphics g = Graphics.FromImage(drawArea))
            //    {
            //        var p = Triangulator.MapCoordinatesToCanvas(vert.X, vert.Y, CANVAS_SIZE / 2);
            //        //g.FillEllipse(new SolidBrush(Color.Red), p.X, p.Y, 5, 5);
            //        Font f = new("Loboto", 9);
            //        StringFormat sf = new() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            //        g.DrawString(i.ToString(), f, new SolidBrush(Color.Black), p.X, p.Y, sf);
            //    }
            //    ++i;
            //}

            //var group = loadedObject.Groups[0];
            //foreach(var face in group.Faces)
            //{
            //    using (Graphics g = Graphics.FromImage(drawArea))
            //    {
            //        g.FillEllipse(new SolidBrush(Color.Red), face[0].VertexIndex, 20, 10, 10);
            //    }
            //}

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
    }
}