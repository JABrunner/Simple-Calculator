using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator2
{
    public partial class Form1 : Form
    {
            Double result = 0;
            String operationPerformed = "";
            bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void buttonClicked(object sender, EventArgs e)
        {
            //Retreiving value from buttons clicked and sending them to text box
            if ((textBoxResult.Text == "0") || isOperationPerformed)
                textBoxResult.Clear();
            isOperationPerformed = false;
            Button button = (Button)sender;

            //Limit decimal point to be used once
            if (button.Text == ".")
            {
                if (!textBoxResult.Text.Contains("."))
                    textBoxResult.Text = textBoxResult.Text + button.Text;
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + button.Text;
            }
        }

        private void operatorCliicked(object sender, EventArgs e)
        {
            //Retrieving operands and converting them into values on button click and sending text box
            Button button = (Button)sender;

            if (result != 0)
            {
                //adds more values to preview window
                btnEquals.PerformClick();

                operationPerformed = button.Text;
                result = Double.Parse(textBoxResult.Text);
                isOperationPerformed = true;
                OperationInProgress.Text = result + " " + operationPerformed;
            }

            else
            {


                operationPerformed = button.Text;
                result = Double.Parse(textBoxResult.Text);
                isOperationPerformed = true;
                OperationInProgress.Text = result + " " + operationPerformed;
            }
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            //Clears out any stored values
            textBoxResult.Text = "0";
            result = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clears out value being displayed
            textBoxResult.Text = "0";
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            //Calculate values and pass them to text box
            switch(operationPerformed)
            {
                case "+":
                    textBoxResult.Text = (result + Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "-":
                    textBoxResult.Text = (result - Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "*":
                    textBoxResult.Text = (result * Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "/":
                    textBoxResult.Text = (result / Double.Parse(textBoxResult.Text)).ToString(); 
                    break;
                default:
                    break;
            }

            //update Result text box to include next value
            result = Double.Parse(textBoxResult.Text);
            OperationInProgress.Text = "";
        }
    }
}
