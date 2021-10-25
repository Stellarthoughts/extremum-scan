using System.Windows;
using System.Windows.Controls;

namespace ExtremumScan
{
    public partial class MainWindow : Window
    {

        private void slA_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double val = slA.Value;
            if(val > slB.Value)
            {
                slB.Value = val;
            }
            tbA.Text = val.ToString();
        }

        private void slB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double val = slB.Value;
            if (val < slA.Value)
            {
                slA.Value = val;
            }
            tbB.Text = val.ToString();
        }
    }
}
