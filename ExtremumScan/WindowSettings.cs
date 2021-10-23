using System.Windows.Controls;

namespace ExtremumScan
{
    public class PlotSettings
    {
        private TextBox tbA;
        private TextBox tbB;
        private Slider sldA;
        private Slider sldB;
        private TextBox tbEps;

        public OptimizationSettings GetSettings()
        {
            OptimizationSettings settings = new();

            return settings;
        }
    }
}
