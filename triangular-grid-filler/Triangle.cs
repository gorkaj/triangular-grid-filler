using ObjLoader.Loader.Data.VertexData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangular_grid_filler
{
    public class Triangle
    {
        private List<int> ind;
        private List<Vertex> vertices;
        private List<Point> mappedPoints;
        private Pen pen;

        public Triangle(Vertex a, Vertex b, Vertex c, List<int> ind)
        {
            vertices = new List<Vertex>();
            mappedPoints = new List<Point>();
            pen = new Pen(new SolidBrush(Color.Black), 1);
            this.vertices.Add(a);
            this.vertices.Add(b);
            this.vertices.Add(c);
            foreach (Vertex v in vertices)
                mappedPoints.Add(ObjMapper.MapCoordinatesToCanvas(v.X, v.Y, Main.CANVAS_SIZE / 2));
            this.ind = ind;
        }

        public List<Point> Points { get => mappedPoints; set => mappedPoints = value; }
        public List<int> NormalIds { get => ind; }

        public void drawTriangle(Graphics g)
        {
            if (vertices.Count != 3)
                return;

            mappedPoints = new List<Point>();
            foreach(Vertex v in vertices)
                mappedPoints.Add(ObjMapper.MapCoordinatesToCanvas(v.X, v.Y, Main.CANVAS_SIZE / 2));

            g.DrawLine(pen, mappedPoints[0], mappedPoints[1]);
            g.DrawLine(pen, mappedPoints[1], mappedPoints[2]);
            g.DrawLine(pen, mappedPoints[2], mappedPoints[0]);
        }
    }
}
