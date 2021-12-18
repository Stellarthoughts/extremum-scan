using ExtremumScan.MathFunctions;
using System;
using System.Globalization;
using System.Windows;

namespace ExtremumScan
{
    public partial class MainWindow : Window
    {
        
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            IFunction functionSelected = functionSelector.getChoice();
            string extremumModeSelected = extremumSelector.getChoice();
            bool algVisualSetting = (bool) cbVisualize.IsChecked;
            double aSelected;
            double bSelected;
            double epsSelected;

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
            catch (FormatException)
            {
                btnCalculate.Content = "Ошибка!";
                return;
            }
            btnCalculate.Content = "Построить";

            OptimizationSettings optSettings = new()
            {
                func = extremumModeSelected == "min" ? functionSelected : new FunctionNegative(functionSelected),
                a = aSelected,
                b = bSelected,
                eps = epsSelected,
            };

            OptimizationResult optResult = Optimization.Scanning(optSettings);
            if (extremumModeSelected == "max")
                optResult.value *= -1;

            PlotSettings plotSettings = new()
            {
                func = functionSelected,
                a = aSelected,
                b = bSelected,
                eps = epsSelected,
                optRes = optResult,
                algVisual = algVisualSetting,
                max = (extremumModeSelected == "min" ? false : true)
            };

            PlotMaker.RemakePlot(plotSettings, MainViewModel.MyModel);
        }

        private double DoubleParse(string d)
        {
            double res;
            try
            {
                res = Double.Parse(d, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new FormatException("Incorrect data");
            }
            return res;
        }
    }
}
