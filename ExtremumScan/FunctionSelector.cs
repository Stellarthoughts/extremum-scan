using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ExtremumScan
{  
    public class FunctionSelector
    {
        private List<RadioButton> radioButtons;
        private List<Func<double,double>> choices;

        public FunctionSelector(List<RadioButton> rb,List<Func<double, double>> ch)
        {
            radioButtons = rb;
            choices = ch;
        }

        public Func<double,double> getChoice()
        {
            for(int i = 0; i < radioButtons.Count; i++)
            {
                if((bool) radioButtons[i].IsChecked)
                {
                    return choices[i];
                }
            }
            return null;
        }
    }
}
