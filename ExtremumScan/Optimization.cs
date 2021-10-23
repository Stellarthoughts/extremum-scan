using System;
using static ExtremumScan.MathFunctions;

namespace ExtremumScan
{
    public struct OptimizationSettings
    {
        public Func<double,double> func;
        public double a;
        public double b;
        public double eps;
        public bool max;
        public int state;
    }

    public static class Optimization
    {    
        public static double Scanning(OptimizationSettings settings)
        {
            Func<double,double> func = settings.func;
            double a = settings.a;
            double b = settings.b;
            double eps = settings.eps;
            bool max = settings.max;

            double res = Double.PositiveInfinity;
            double prev;

            int n = 10;
            
            do
            {
                prev = res;

                double h = (b - a) / n;
                double min = a;
                double fmin = (max ? -1 : 1) * func(a);

                for (int i = 1; i <= n; i++)
                {
                    double x = i * h + a;
                    double fvalue = (max ? -1 : 1) * func(x);
                    if (fvalue < fmin)
                    {
                        fmin = fvalue;
                        min = x;
                    }
                }

                b = min;
                a = b - h;

                res = min;
            }
            while (Math.Abs(prev - res) >= eps);

            return res;
        }
    }
}
