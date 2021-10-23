using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Annotations;
using OxyPlot.Wpf;
using static ExtremumScan.MathFunctions;

namespace ExtremumScan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PlotSettings windowSettings;
        public MainWindow()
        {
            InitializeComponent();
            windowSettings = new()
            {

            };
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
