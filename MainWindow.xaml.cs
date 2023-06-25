using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private string currentNumber = string.Empty;
        private string operation = string.Empty;
        private double result = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string number = (string)((Button)sender).Content;
            currentNumber += number;
            resultTextBox.Text = currentNumber;
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            string op = (string)((Button)sender).Content;
            if (!string.IsNullOrEmpty(currentNumber))
            {
                if (!string.IsNullOrEmpty(operation))
                {
                    Calculate();
                }

                operation = op;
                result = double.Parse(currentNumber);
                currentNumber = string.Empty;
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            if (!string.IsNullOrEmpty(currentNumber) && !string.IsNullOrEmpty(operation))
            {
                double number = double.Parse(currentNumber);
                switch (operation)
                {
                    case "+":
                        result += number;
                        break;
                    case "-":
                        result -= number;
                        break;
                    case "*":
                        result *= number;
                        break;
                    case "/":
                        result /= number;
                        break;
                }

                currentNumber = string.Empty;
                operation = string.Empty;
                resultTextBox.Text = result.ToString();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = string.Empty;
            operation = string.Empty;
            result = 0;
            resultTextBox.Text = "0";
        }
    }
}