using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangular_grid_filler
{
    class AETPointer
    {
        public int id;
        public float y, x;
        public float m;
        public AETPointer(int id, float x, float y, float m)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.m = m;
        }
    }

    public static class PolygonFiller
    {
        public static void FillPolygon(Triangle t, DirectBitmap bmap, Func<double, double, Triangle, Color> computeColor)
        {
            var points = t.Points;
            List<int> sortOrder = Enumerable.Range(0, points.Count).ToList();

            sortOrder.Sort((a, b) => points[a].Y == points[b].Y ? points[a].X.CompareTo(points[b].X) : points[a].Y.CompareTo(points[b].Y));
            int n = points.Count;
            int index = 0;

            List<AETPointer> AET = new();
            int maxY = (int)Math.Round((double)points[sortOrder[n - 1]].Y, 0);
            for (int y = (int)Math.Round((double)points[sortOrder[0]].Y, 0); y <= maxY; y++)
            {
                while (index < n && y - 1 == (int)Math.Round((double)points[sortOrder[index]].Y, 0))
                {
                    int prevIndex = sortOrder[index] - 1;
                    int currIndex = sortOrder[index];
                    int nextIndex = sortOrder[index] + 1;
                    if (prevIndex == -1) prevIndex = n - 1;
                    if (nextIndex == n) nextIndex = 0;

                    if (points[prevIndex].Y >= points[currIndex].Y)
                    {
                        float dx = points[currIndex].X - points[prevIndex].X;
                        float dy = points[currIndex].Y - points[prevIndex].Y;

                        if (points[prevIndex].Y != points[currIndex].Y)
                            AET.Add(new AETPointer(prevIndex, points[currIndex].X, points[prevIndex].Y, dx / dy));
                    }
                    else
                    {
                        AET.RemoveAll(pt => pt.id == prevIndex);
                    }

                    if (points[nextIndex].Y >= points[currIndex].Y)
                    {
                        float dx = points[currIndex].X - points[nextIndex].X;
                        float dy = points[currIndex].Y - points[nextIndex].Y;

                        if (points[nextIndex].Y != points[currIndex].Y)
                            AET.Add(new AETPointer(currIndex, points[currIndex].X, points[nextIndex].Y, dx / dy));
                    }
                    else
                    {
                        AET.RemoveAll(pt => pt.id == currIndex);
                    }

                    index++;
                }

                AET.Sort((a, b) => a.x.CompareTo(b.x));
                for (int i = 0; i < AET.Count; i += 2)
                {
                    int x = (int)Math.Round(AET[i].x, 0);
                    int max = (int)Math.Round(AET[i + 1].x, 0);
                    for (x = Math.Max(x, 0); x <= max; x++)
                    {
                        try
                        {
                            bmap.SetPixel(x, y, computeColor(x, y, t));
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                foreach (AETPointer pt in AET) pt.x += pt.m;
            }
        }
    }
}
