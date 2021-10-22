using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Annotations;
using OxyPlot.Wpf;
using static ExtremumScan.MyMath;

namespace ExtremumScan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OptimizationSettings settings = new OptimizationSettings()
            {
                func = Function1,
                a = 0,
                b = Math.PI,
                eps = 0.00001,
                max = true
            };
            double value = Optimization.Scanning(settings);
            
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
    }
 
    public class MainViewModel
    {
        public MainViewModel()
        {
        }

        public static PlotModel MyModel { get; private set; }
    }
}
