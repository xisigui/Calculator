using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Regular_Calculator : ContentPage
    {
        int currentState = 1;
        string mathOperator, numberText = "";
        double firstNumber = 0, secondNumber = 0;
        public Regular_Calculator()
        {
            InitializeComponent();
            OnClear(this, null);
        }
        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.resultText.Text == "0")
                this.resultText.Text = "";

            if (currentState < 0)
                currentState *= -1;

            if (numberText == "invalid")
                numberText = "";

            this.resultText.Text += pressed;
            numberText += pressed;

            double number;
            if (double.TryParse(numberText, out number))
            {
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        void OnSelectDot(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            this.resultText.Text += pressed;
            numberText += pressed;
        }

        void OnSelectOperator(object sender, EventArgs e)
        {
            if (this.resultText.Text != "0" && numberText != "")
            {
                currentState = -2;
                numberText = "";
                Button button = (Button)sender;
                string pressed = button.Text;
                mathOperator = pressed;
                if (mathOperator == "pow")
                    this.resultText.Text += "^";
                else
                    this.resultText.Text += pressed;
            }
        }

        void OnClear(object sender, EventArgs e)
        {
            numberText = "";
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }

        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2 || mathOperator == "sqrt" || mathOperator == "%")
            {
                double result = Calculate(firstNumber, secondNumber, mathOperator);

                if (mathOperator == "sqrt" || mathOperator == "%")
                    numberText = "invalid";

                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -2;
                mathOperator = "";
            }
        }

        double Calculate(double value1, double value2, string mathOperator)
        {
            double result = 0;

            switch (mathOperator)
            {
                case "/":
                    result = value1 / value2;
                    break;
                case "x":
                    result = value1 * value2;
                    break;
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;
                case "sqrt":
                    result = Math.Sqrt(value1);
                    break;
                case "pow":
                    result = Math.Pow(value1, value2);
                    break;
                case "%":
                    result = value1 / 100;
                    break;
            }
            return result;
        }
    }
}