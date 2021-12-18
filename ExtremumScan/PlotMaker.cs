using ExtremumScan.MathFunctions;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using System;
using System.Collections.Generic;

namespace ExtremumScan
{
    public struct PlotSettings
    {
        public IFunction func;
        public double a;
        public double b;
        public double eps;
        public bool max;
        public OptimizationResult optRes;
        public bool algVisual;
    }

    public class PlotMaker
    {
        public static void RemakePlot(PlotSettings settings, PlotModel model)
        {
            model.Series.Clear();
            model.Annotations.Clear();
            model.Series.Add(new FunctionSeries(settings.func.Calculate, settings.a, settings.b, 0.0001));

            if (settings.algVisual)
            {
                List<double> value = settings.optRes.listValue;
                List<double> point = settings.optRes.listPoint;
                List<double> left = settings.optRes.listLeft;
                List<double> right = settings.optRes.listRight;
                IFunction func = settings.func;
                for (int i = 0; i < left.Count - 1; i++)
                {
                    var lArrow = new ArrowAnnotation()
                    {
                        StartPoint = new DataPoint(left[i], func.Calculate(left[i])),
                        EndPoint = new DataPoint(left[i + 1], func.Calculate(left[i]))
                    };
                    var rArrow = new ArrowAnnotation()
                    {
                        StartPoint = new DataPoint(right[i], func.Calculate(right[i])),
                        EndPoint = new DataPoint(right[i + 1], func.Calculate(right[i]))
                    };
                    var lLine = new ArrowAnnotation()
                    {
                        StartPoint = new DataPoint(left[i + 1], func.Calculate(left[i])),
                        EndPoint = new DataPoint(left[i + 1], func.Calculate(left[i + 1])),
                        HeadLength = 0,
                        HeadWidth = 0
                    };
                    var rLine = new ArrowAnnotation()
                    {
                        StartPoint = new DataPoint(right[i + 1], func.Calculate(right[i])),
                        EndPoint = new DataPoint(right[i + 1], func.Calculate(right[i + 1])),
                        HeadLength = 0,
                        HeadWidth = 0
                    };
                    model.Annotations.Add(lArrow);
                    model.Annotations.Add(rArrow);
                    model.Annotations.Add(lLine);
                    model.Annotations.Add(rLine);
                }

                model.Series.Add(new FunctionSeries(func.Calculate, left[left.Count - 1], right[right.Count - 1], settings.eps / 100)
                {
                    Color = OxyColors.Red
                });
                /* var valuesLine = new ArrowAnnotation()
                {
                    StartPoint = new DataPoint(, settings.optRes.value),
                    EndPoint = new DataPoint(, settings.optRes.value),
                    HeadLength = 0,
                    HeadWidth = 0,
                    Color = OxyColors.Red
                };
                model.Annotations.Add(valuesLine); */
            }

            var pointExtremum = new PointAnnotation()
            {
                X = settings.optRes.argument,
                Y = settings.optRes.value,
                Fill = OxyColors.Red,
                Size = 4,
                Text = String.Format("X = {0}\nY = {1}", settings.optRes.argument, settings.optRes.value),
                TextVerticalAlignment = settings.max ? VerticalAlignment.Bottom : VerticalAlignment.Top
            };
            model.Annotations.Add(pointExtremum);

            model.ResetAllAxes();
            model.InvalidatePlot(true);
        }
    }
}
