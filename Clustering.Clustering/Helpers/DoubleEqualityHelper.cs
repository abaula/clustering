using System;

namespace Clustering.Clustering.Helpers
{
    public static class DoubleEqualityHelper
    {
        private const double Tolerance = 0.000001;

        public static bool Equal(double a, double b)
        {
            return Math.Abs(a - b) < Tolerance;
        }
    }
}
