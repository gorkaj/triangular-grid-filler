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
        private List<Vertex> vertices;
        private List<Point> mappedPoints;
        private Pen pen;

        public Triangle()
        {
            vertices = new List<Vertex>();
            mappedPoints = new List<Point>();
            pen = new Pen(new SolidBrush(Color.Black), 1);
        }

        public Triangle(List<Vertex> _vertices)
        {
            vertices = new List<Vertex>();
            mappedPoints = new List<Point>();
            pen = new Pen(new SolidBrush(Color.Black), 1);
            foreach (Vertex v in _vertices)
                this.vertices.Add(v);
        }

        public Triangle(Vertex a, Vertex b, Vertex c)
        {
            vertices = new List<Vertex>();
            mappedPoints = new List<Point>();
            pen = new Pen(new SolidBrush(Color.Black), 1);
            this.vertices.Add(a);
            this.vertices.Add(b);
            this.vertices.Add(c);
            foreach (Vertex v in vertices)
                mappedPoints.Add(Triangulator.MapCoordinatesToCanvas(v.X, v.Y, Main.CANVAS_SIZE / 2));
        }

        public List<Point> Points { get => mappedPoints; set => mappedPoints = value; }

        public void drawTriangle(Graphics g)
        {
            if (vertices.Count != 3)
                return;

            mappedPoints = new List<Point>();
            foreach(Vertex v in vertices)
                mappedPoints.Add(Triangulator.MapCoordinatesToCanvas(v.X, v.Y, Main.CANVAS_SIZE / 2));

            g.DrawLine(pen, mappedPoints[0], mappedPoints[1]);
            g.DrawLine(pen, mappedPoints[1], mappedPoints[2]);
            g.DrawLine(pen, mappedPoints[2], mappedPoints[0]);
        }
    }
}
