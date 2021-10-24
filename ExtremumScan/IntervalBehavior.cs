using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExtremumScan
{
    public partial class MainWindow : Window
    {

        private void slA_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            double val = slider.Value;
            tbA.Text = val.ToString();
        }

        private void slB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            double val = slider.Value;
            tbB.Text = val.ToString();
        }

        private double Parse(string d)
        {
            double res;
            try
            {
                res = Double.Parse(d, CultureInfo.InvariantCulture);
            }
            catch(Exception ex)
            {
                res = 0;
            }
            return res;
        }
    }
}
