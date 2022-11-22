using ObjLoader.Loader.Data.VertexData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangular_grid_filler
{
    public class Polygon
    {
        private List<Vertex> vertices;
        private List<Point> mappedPoints;
        private Pen pen;

        public Polygon(List<Vertex> vert)
        {
            vertices = new List<Vertex>();
            mappedPoints = new List<Point>();
            pen = new Pen(new SolidBrush(Color.AliceBlue), 2);
            for(int i = 0; i < vert.Count; i++)
            {
                vertices.Add(vert[i]);
            }
            foreach (Vertex v in vertices)
                mappedPoints.Add(ObjMapper.MapCoordinatesToCanvas(v.X, v.Y, Main.CANVAS_SIZE / 2));
        }

        public List<Point> Points { get => mappedPoints; set => mappedPoints = value; }
        public List<Vertex> Vertices { get => vertices; set => vertices = value; }

        public void Draw(Graphics g)
        {
            for (int i = 0; i < Points.Count; ++i)
            {
                int next = (i + 1) % Points.Count;
                g.DrawLine(pen, mappedPoints[i], mappedPoints[next]);
            }

        }
    }
}
