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
                List<double> left = settings.optRes.listLeft;
                List<double> right = settings.optRes.listRight;
                List<double> dist = settings.optRes.listDistance;
                for (int i = 0; i < left.Count - 1; i++)
                {
                    var lArrow = new ArrowAnnotation()
                    {
                        StartPoint = new DataPoint(left[i], settings.optRes.listValue[i]),
                        EndPoint = new DataPoint(left[i + 1], settings.optRes.listValue[i])
                    };
                    var rArrow = new ArrowAnnotation()
                    {
                        StartPoint = new DataPoint(right[i], settings.optRes.listValue[i]),
                        EndPoint = new DataPoint(right[i + 1], settings.optRes.listValue[i])
                    };
                    var lLine = new ArrowAnnotation()
                    {
                        StartPoint = new DataPoint(left[i + 1], settings.optRes.listValue[i]),
                        EndPoint = new DataPoint(left[i + 1], settings.optRes.listValue[i + 1]),
                        HeadLength = 0,
                        HeadWidth = 0
                    };
                    var rLine = new ArrowAnnotation()
                    {
                        StartPoint = new DataPoint(right[i + 1], settings.optRes.listValue[i]),
                        EndPoint = new DataPoint(right[i + 1], settings.optRes.listValue[i + 1]),
                        HeadLength = 0,
                        HeadWidth = 0
                    };
                    model.Annotations.Add(lArrow);
                    model.Annotations.Add(rArrow);
                    model.Annotations.Add(lLine);
                    model.Annotations.Add(rLine);
                }

                var valuesLine = new ArrowAnnotation()
                {
                    StartPoint = new DataPoint(left[left.Count - 1], settings.optRes.value),
                    EndPoint = new DataPoint(left[left.Count - 1] + dist[dist.Count - 1], settings.optRes.value),
                    HeadLength = 0,
                    HeadWidth = 0,
                    Color = OxyColors.Red
                };
                model.Annotations.Add(valuesLine);
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
