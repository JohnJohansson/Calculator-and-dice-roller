using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App10.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {
        public Calculator()
        {
            InitializeComponent();
        }

        /*the vars */
        //The first nummer that you put into the calculator
        private decimal firstNumber;
        // The operator sign you use like plus or minus
        private string operatorSign;
        // A bool that can be true or false
        private bool isOperatorClicked;


        /*checks if a number button was clicked like 1 2 or 3*/
        public void Number_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (outputBox.Text == "0" || isOperatorClicked)
            {
                isOperatorClicked = false;
                outputBox.Text = button.Text;
            }
            else
            {
                outputBox.Text += button.Text;
            }
        }
        /*checks if the clear is clicked and if it is clears the numbers and replaces it with zero*/
        private void Clear_Clicked(object sender, EventArgs e)
        {
            outputBox.Text = "0";
            isOperatorClicked = false;
            firstNumber = 0;
        }
        /*checks if del is clicked and delets the last number*/
        private void Del_Clicked(object sender, EventArgs e)
        {
            string number = outputBox.Text;
            if (number != "0")
            {
                number = number.Remove(number.Length - 1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    outputBox.Text = "0";
                }
                else
                {
                    outputBox.Text = number;
                }
            }
        }
        /*checks if the common operations are clicked like like plus minus / and multiplies */
        public void CommonOperation_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            operatorSign = button.Text;
            firstNumber = Convert.ToDecimal(outputBox.Text);
        }
        /*checks if the procentage is clicked and tells it what to do with it*/

        private async void Percentage_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number = outputBox.Text;
                if (number != "0")
                {
                    decimal percentValue = Convert.ToDecimal(number);
                    string result = (percentValue / 100).ToString("0.##");
                    outputBox.Text = result;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
        //checks if the equal is clicked
        private void Equal_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal secondNumber = Convert.ToDecimal(outputBox.Text);
                string results = Calculate(firstNumber, secondNumber).ToString("0.##");
                outputBox.Text = results;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
        /*calculates the first and second number togheter*/
        public decimal Calculate(decimal numberOne, decimal numberTwo)
        {
            //a var in the form of decimal makes the result be 0 untill an operator is used
            decimal result = 0;

            // if the operator is plus
            if (operatorSign == "+")
            {
                result = numberOne + numberTwo;
            }
            // if the operator is minus
            else if (operatorSign == "-")
            {
                result = numberOne - numberTwo;
            }
            //If the operator is multipli
            else if (operatorSign == "*")
            {
                result = numberOne * numberTwo;
            }
            // if the operator is divided
            else if (operatorSign == "/")
            {
                result = numberOne / numberTwo;
            }
            // if the operator is MOD
            else if (operatorSign == "MOD")
            {
                result = numberOne % numberTwo;
            }
            // if the operator is power of 
            else if (operatorSign == "x^y")
            {
                result = (decimal)Math.Pow((double)numberOne, (double)numberTwo);
            }
            return result;
        }
        /*Plus minus sign changes betwen negative and positive*/
        private void PlusMinus_Btn(object sender, EventArgs e)
        {
           decimal result = decimal.Parse(outputBox.Text);
            result = result * -1;
            outputBox.Text = result.ToString();
        }
        //squaroot button to calculate the root of something
        // Puts the nummber from the outputBox into the decimal var numberOne
       // if its bigger then zero divide it by three and put it in the var product
       // then do a for loop and calculate some more 
        private async void Squaroot_Btn(object sender, EventArgs e)
        {
            try
            {
                decimal numberOne = decimal.Parse(outputBox.Text);
                if (numberOne > 0)
                {
                    decimal result = numberOne / 3;
                    int i;
                    for (i = 0; i < 32; i++)
                        result = (result + numberOne / result) / 2;
                    outputBox.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
        // The square Button gives the power of two x^2
        private void SquareBtn(object sender, EventArgs e)
        {
            decimal result = (decimal)Math.Pow((double.Parse(outputBox.Text)), 2);
            outputBox.Text = result.ToString();
        }

        // The cube button gives the power of three x^3
        private void CubeBtn(object sender, EventArgs e)
        {
            decimal result = (decimal)Math.Pow((double.Parse(outputBox.Text)), 3);
            outputBox.Text = result.ToString();
        }

        // Get the fraction of one you can get fraktions with just using the / button but this one always uses one as base
        private void FractionBtn(object sender, EventArgs e)
        {
            decimal result = Convert.ToDecimal(outputBox.Text);
            result = 1 / result;
            outputBox.Text = result.ToString();
        }
        // log is used for logarithms, it lets you know how many times you have to 
        // multiply you number by itshelfe to reach your original number
        // 10 is the basic that calculators use
        private void LogBtn(object sender, EventArgs e)
        {
            decimal result = (decimal)Math.Log10(double.Parse(outputBox.Text));
            outputBox.Text = result.ToString();
        }

        //To get PI
        private void PiBtn(object sender, EventArgs e)
        {
            double result = Math.PI;
            outputBox.Text = result.ToString();
        }
        //exponent button, it will make the number a power of ten
        private void ExponetinalBtn(object sender, EventArgs e)
        {
            double result = Math.Exp(double.Parse(outputBox.Text));
            outputBox.Text = result.ToString();
        }

        //Sin Cos and Tan are all used in Trigonometry.
        //They are used to figure out a number from an angle in a triangle with a right angle.
        private void SinBtn(object sender, EventArgs e)
        {
            decimal result = (decimal)Math.Sin(double.Parse(outputBox.Text));
            outputBox.Text = result.ToString();
        }

        private void CosBtn(object sender, EventArgs e)
        {

            decimal result = (decimal)Math.Cos(double.Parse(outputBox.Text));
            outputBox.Text = result.ToString();
        }
        private void TanBtn(object sender, EventArgs e)
        {
            decimal result = (decimal)Math.Tan(double.Parse(outputBox.Text));
            outputBox.Text = result.ToString();
        }

        // SinH, CosH and TanH is used to calculate a hyperbolic angle
        private void SinHBtn(object sender, EventArgs e)
        {
            decimal result = (decimal)Math.Sinh(double.Parse(outputBox.Text));
            outputBox.Text = result.ToString();
        }
        private void CoshHBtn(object sender, EventArgs e)
        {
           decimal result = (decimal)Math.Cosh(double.Parse(outputBox.Text));
            outputBox.Text = result.ToString();
        }
        private void TanHBtn(object sender, EventArgs e)
        {
            decimal result = (decimal)Math.Tanh(double.Parse(outputBox.Text));
            outputBox.Text = result.ToString();
        }

    }
}
