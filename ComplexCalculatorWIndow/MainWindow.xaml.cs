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
using ComplexCalculator;

namespace ComplexCalculatorWIndow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox textBox = null;
        public MainWindow()
        {
            InitializeComponent();
            this.imaginaryPartInput.GotFocus += new RoutedEventHandler(GetF);
            this.realPartInput.GotFocus += new RoutedEventHandler(GetF);
        }

        ComplexNum num1 = new ComplexNum(0, 0);
        ComplexNum num2 = new ComplexNum(0, 0);
        ComplexNum result = new ComplexNum(0, 0);
        char znak = '+';
        private void GetF(object sender, EventArgs e)
        {
            textBox = sender as TextBox;
        }

        private void zeroButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null) textBox.SelectedText += (sender as Button).Content;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != string.Empty)
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            resultOutputWindow.Text = string.Empty;
            realPartInput.Clear();
            imaginaryPartInput.Clear();
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            num1 = new ComplexNum(Convert.ToDouble(realPartInput.Text), Convert.ToDouble(imaginaryPartInput.Text));
            znak = (sender as Button).Content.ToString()[0];
            imaginaryPartInput.Clear();
            realPartInput.Clear();
        }

        private void equalsButton_Click(object sender, RoutedEventArgs e)
        {
            ComplexCalculator.Operations calc = new ComplexCalculator.Operations();
            if (string.IsNullOrWhiteSpace(imaginaryPartInput.Text))
            {
                num2 = new ComplexNum(Convert.ToDouble(realPartInput.Text), 0);
            }
            else
                num2 = new ComplexNum(Convert.ToDouble(realPartInput.Text), Convert.ToDouble(imaginaryPartInput.Text));
            switch (znak)
            {
                case '+': result = calc.Sum(num1, num2);
                    break;
                case '-': result = calc.Dif(num1, num2);
                    break;
                case '*': result = calc.Prod(num1, num2);
                    break;
                case '/': result = calc.Div(num1, num2);
                    break;
                case 'x': result = calc.Pow(num1, (int)num2.real);
                    break;
            }
            imaginaryPartInput.Clear();
            realPartInput.Clear();
            string a = "";
            if (result.imaginary < 0)
            {
                 a = result.real.ToString();
            }
            else
            {  a = result.real.ToString() + "+"; }
            string b = result.imaginary.ToString() + 'i';
            string output = a + b;
            resultOutputWindow.Text = output;
        }
    }
}
