using System;

namespace Clustering.Clustering.Model
{
    public class DataPoint
    {
        public DataPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public double GetDistance(DataPoint p)
        {
            return Math.Abs(p.X - X) + Math.Abs(p.Y - Y);
        }
    }
}
