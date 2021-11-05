using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        Stack<double> st;
        public string mathOperator;
        public double val1, val2;
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnNumberSelect(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string pressed = btn.Text; //validating button by assigning to a string variable
            double num;
            //if the current state is 0 in output then we remove the 0 when pressing the button
            if (output.Text == "0" || currentState < 0)//first currentstate is 1
            {
                output.Text = "";//clearing the text value of the output
                if (currentState < 0)
                {
                    currentState *= -1;
                }
            }

            output.Text += pressed; //called when currentstate is > 0 and output aquires pressed.

            if (double.TryParse(output.Text, out num))
            {
                output.Text = num.ToString("N0");
                if (currentState == 1)
                {
                    val1 = num;
                }
                else
                {
                    val2 = num;
                }
            }

        }

        public void OnBackspace(object sender, EventArgs e)
        {
            currentState = 1;
            output.Text = output.Text.Remove(output.Text.Length - 1, 1);
        }

        public void OnClear(object sender, EventArgs e)
        {
            currentState = 1;
            val1 = 0;
            val2 = 0;
            output.Text = "0";
        }

        public void OnOperatorSelect(object sender, EventArgs e)
        {
            currentState = -2;
            Button btn = (Button)sender;
            string pressed = btn.Text;
            mathOperator = pressed;
        }


        public void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                double result = CalculatorOperators.Calculate(val1, val2, mathOperator);

                output.Text = result.ToString();
                val1 = result;
                currentState = -1;
            }
        }
    }
}
