using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Annotations;
using OxyPlot.Wpf;
using static ExtremumScan.MathFunctions;
using System.Windows.Controls;
using System.Collections.Generic;

namespace ExtremumScan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FunctionSelector functionSelector;

        public MainWindow()
        {
            InitializeComponent();
            functionSelector = new(
                new List<RadioButton> {rbFunc1, rbFunc2, rbFunc3, rbFunc4, rbFunc5, rbFunc6},
                new List<Func<double,double>> {Function1, Function2, Function3, Function4}
            );
            RemakePlot();
            /*
            OptimizationSettings settings = new()
            {
                func = Function1,
                a = 0,
                b = Math.PI,
                eps = 0.00001,
                max = true
            };
            double value = Optimization.Scanning(settings);*/

            //PlotView plotView = pvFunction;
            //PlotModel plotModel = plotView.ActualModel;
            /*model.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            var arrowAnnotation = new ArrowAnnotation
            {
                StartPoint = new DataPoint(0, 0),
                EndPoint = new DataPoint(10, 10)
            };
            model.MyModel.Annotations.Add(arrowAnnotation);*/
        }

        private void RemakePlot()
        {
            PlotModel model = MainViewModel.MyModel;
            model.Series.Clear();
            model.Annotations.Clear();
            model.InvalidatePlot(true);

            model.Series.Add(new FunctionSeries(Function1, 0, 1, 0.1));
        }
    }

    public class MainViewModel
    {
        public MainViewModel()
        {
            MyModel = new PlotModel();
        }

        public static PlotModel MyModel { get; private set; }
    }
}
