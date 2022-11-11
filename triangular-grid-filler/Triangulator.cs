using ObjLoader.Loader.Data.Elements;
using ObjLoader.Loader.Data.VertexData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangular_grid_filler
{
    public class Triangulator
    {
        public static Point MapCoordinatesToCanvas(float x, float y, int radius)
        {
            return new Point((int)(x * radius) + radius, (int)(y * radius) + radius);
        }

        public static List<Triangle> Triangulate(List<Vertex> vertices, List<Face> faces)
        {
            List<Triangle> triangles = new List<Triangle>();
            
            foreach(var face in faces)
            {
                triangles.Add(new Triangle(vertices[face[0].VertexIndex - 1],
                                            vertices[face[1].VertexIndex - 1],
                                            vertices[face[2].VertexIndex - 1],
                                            new List<int>(){ face[0].NormalIndex - 1, face[1].NormalIndex - 1, face[2].NormalIndex - 1 }));
            }

            return triangles;
        }
    }
}
