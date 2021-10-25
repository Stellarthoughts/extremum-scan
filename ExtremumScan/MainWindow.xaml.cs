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
        private RBSelector<Func<double,double>> functionSelector;
        private RBSelector<string> extremumSelector;

        public MainWindow()
        {
            InitializeComponent();
            functionSelector = new(
                new List<RadioButton> {rbFunc1, rbFunc2, rbFunc3, rbFunc4, rbFunc5, rbFunc6},
                new List<Func<double,double>> {Function1, Function2, Function3, Function4, Function5, Function6}
                );
            extremumSelector = new(
                new List<RadioButton> {rbExtMin, rbExtMax},
                new List<string> {"min", "max"}
                );
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
