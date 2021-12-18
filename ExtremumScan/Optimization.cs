using ExtremumScan.MathFunctions;
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

        public List<double> listPoint;
    }

    public static class Optimization
    {
        public static OptimizationResult Scanning(OptimizationSettings settings)
        {
            IFunction func = settings.func;
            double a = settings.a;
            double b = settings.b;
            double eps = settings.eps;

            OptimizationResult result = new OptimizationResult();
            result.listValue = new();
            result.listLeft = new();
            result.listRight = new();
            result.listPoint = new();

            double res = Double.PositiveInfinity;
            double prev;

            double q = 10;

            result.listValue.Add(func.Calculate(a));
            result.listLeft.Add(a);
            result.listRight.Add(b);
            result.listPoint.Add(a);

            do
            {
                prev = res;

                double deltaX = (b - a) / (q - 1);
                double min = a;
                double fmin = func.Calculate(a);

                for (int i = 0; i <= q - 1; i++)
                {
                    double x = i * deltaX + a;
                    double fvalue = func.Calculate(x);
                    if (fvalue < fmin)
                    {
                        fmin = fvalue;
                        min = x;
                    }
                }

                if(min == a)
                {
                    a = min;
                    b = min + deltaX;
                }
                else if(min == b)
                {
                    b = min;
                    a = min - deltaX;
                }
                else
                {
                    a = min - deltaX;
                    b = min + deltaX;
                    deltaX = (b - a) / (q - 1);
                }

                result.listPoint.Add(min);
                result.listValue.Add(fmin);
                result.listLeft.Add(a);
                result.listRight.Add(b);

                res = min;
            }
            while (Math.Abs(prev - res) >= eps);

            result.argument = res;
            result.value = func.Calculate(res);

            return result;
        }
    }
}
