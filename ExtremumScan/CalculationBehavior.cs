using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;

namespace ExtremumScan
{
    public partial class MainWindow : Window
    {
        public struct PlotSettings
        {
            public Func<double, double> func;
            public double a;
            public double b;
            public double eps;
            public OptimizationResult optRes;
            public bool algVisual;
        }
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            Func<double, double> functionSelected = functionSelector.getChoice();
            string extremumModeSelected = extremumSelector.getChoice();
            bool algVisualSetting = (bool) cbVisualize.IsChecked;
            double aSelected = 0;
            double bSelected = 0;
            double epsSelected = 0.1;

            try
            {
                aSelected = DoubleParse(tbA.Text);
                bSelected = DoubleParse(tbB.Text);
                epsSelected = DoubleParse(tbEps.Text);
                if(bSelected < aSelected)
                {
                    btnCalculate.Content = "Ошибка!";
                    return;
                }
            }
            catch(FormatException ex)
            {
                btnCalculate.Content = "Ошибка!";
                return;
            }
            btnCalculate.Content = "Построить";

            OptimizationSettings optSettings = new()
            {
                func = functionSelected,
                a = aSelected,
                b = bSelected,
                eps = epsSelected,
                max = (extremumModeSelected == "min" ? false : true)
            };

            OptimizationResult optResult = Optimization.Scanning(optSettings);

            PlotSettings plotSettings = new()
            {
                func = functionSelected,
                a = aSelected,
                b = bSelected,
                eps = epsSelected,
                optRes = optResult,
                algVisual = algVisualSetting
            };
            RemakePlot(plotSettings);
        }

        private void RemakePlot(PlotSettings settings)
        {
            PlotModel model = MainViewModel.MyModel;
            model.Series.Clear();
            model.Annotations.Clear();
            model.Series.Add(new FunctionSeries(settings.func, settings.a, settings.b, settings.eps));

            if(settings.algVisual)
            {
                List<double> left = settings.optRes.listLeft;
                List<double> right = settings.optRes.listRight;
                for (int i = 0; i < left.Count - 1; i++)
                {
                    var lArrow = new ArrowAnnotation()
                    {
                        StartPoint = new DataPoint(left[i], settings.optRes.value),
                        EndPoint = new DataPoint(left[i + 1], settings.optRes.value)
                    };
                    var rArrow = new ArrowAnnotation()
                    {
                        StartPoint = new DataPoint(right[i], settings.optRes.value),
                        EndPoint = new DataPoint(right[i + 1], settings.optRes.value)
                    };
                    model.Annotations.Add(lArrow);
                    model.Annotations.Add(rArrow);
                }
            }

            var pointExtremum = new PointAnnotation()
            {
                X = settings.optRes.argument,
                Y = settings.optRes.value,
                Fill = OxyColors.Red,
                Size = 4
            };
            model.Annotations.Add(pointExtremum);

            model.ResetAllAxes();
            model.InvalidatePlot(true);
        }

        private double DoubleParse(string d)
        {
            double res;
            try
            {
                res = Double.Parse(d, CultureInfo.InvariantCulture);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Incorrect data");
            }
            return res;
        }
    }
}
