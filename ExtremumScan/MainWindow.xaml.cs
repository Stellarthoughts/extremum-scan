using System;
using System.Windows;
using OxyPlot;
using System.Windows.Controls;
using System.Collections.Generic;
using OxyPlot.Axes;
using ExtremumScan.MathFunctions;

namespace ExtremumScan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RBSelector<IFunction> functionSelector;
        private RBSelector<string> extremumSelector;

        public MainWindow()
        {
            InitializeComponent();
            functionSelector = new(
                new List<RadioButton> {rbFunc1, rbFunc2, rbFunc3, rbFunc4, rbFunc5, rbFunc6},
                new List<IFunction> {
                    new Function1(), new Function2(), 
                    new Function3(), new Function4(), 
                    new Function5(), new Function6()
                    }
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
