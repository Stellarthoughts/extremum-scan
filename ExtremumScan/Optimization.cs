using System;
using System.Collections.Generic;

namespace ExtremumScan
{
    public struct OptimizationSettings
    {
        public IFunction func;
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
            IFunction func = settings.func;
            double a = settings.a;
            double b = settings.b;
            double eps = settings.eps;
            bool max = settings.max;

            OptimizationResult result = new OptimizationResult();
            result.listValue = new();
            result.listLeft = new();
            result.listRight = new();
            result.listDistance = new();

            double res = Double.PositiveInfinity;
            double prev;

            double n = Math.Pow(settings.eps, -1);

            result.listValue.Add(func.Calculate(a) * (max ? -1 : 1));
            result.listLeft.Add(a);
            result.listRight.Add(b);

            do
            {
                prev = res;

                double h = (b - a) / n;
                double min = a;
                double fmin = (max ? -1 : 1) * func.Calculate(a);

                for (int i = 1; i <= n - 1; i++)
                {
                    double x = i * h + a;
                    double fvalue = (max ? -1 : 1) * func.Calculate(x);
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

                result.listValue.Add(fmin * (max ? -1 : 1));
                result.listLeft.Add(a);
                result.listRight.Add(b);
                result.listDistance.Add(h);

                res = min;
            }
            while (Math.Abs(prev - res) >= eps);

            result.argument = res;
            result.value = func.Calculate(res);

            return result;
        }
    }
}
