using System;
using System.Collections.Generic;

namespace ExtremumScan
{
    public struct OptimizationSettings
    {
        public Func<double,double> func;
        public double a;
        public double b;
        public double eps;
        public bool max;
    }

    public struct OptimizationResult
    {
        public double value;
        public double argument;
        public List<double> listValue;
        public List<double> listLeft;
        public List<double> listRight;
        public List<double> listDistance;
    }

    public static class Optimization
    {    
        public static OptimizationResult Scanning(OptimizationSettings settings)
        {
            Func<double,double> func = settings.func;
            double a = settings.a;
            double b = settings.b;
            double eps = settings.eps;
            bool max = settings.max;

            OptimizationResult result = new OptimizationResult();
            result.listValue = new();
            result.listLeft = new();
            result.listRight = new();
            result.listDistance = new();

            result.listLeft.Add(settings.a);
            result.listRight.Add(settings.b);

            double res = Double.PositiveInfinity;
            double prev;

            double n = b - a;

            do
            {
                prev = res;

                double h = (b - a) / n;
                double min = a;
                double fmin = (max ? -1 : 1) * func(a);

                for (int i = 1; i <= n - 1; i++)
                {
                    double x = i * h + a;
                    double fvalue = (max ? -1 : 1) * func(x);
                    if (fvalue < fmin)
                    {
                        fmin = fvalue;
                        min = x;
                    }
                }

                if (min + h > b) 
                {
                    a = min - h;
                    b = min;
                }
                else
                {
                    a = min;
                    b = min + h;
                }

                res = min;

                result.listValue.Add(fmin);
                result.listLeft.Add(a);
                result.listRight.Add(b);
                result.listDistance.Add(h);
            }
            while (Math.Abs(prev - res) >= eps);

            result.argument = res;
            result.value = func(res);

            return result;
        }
    }
}
