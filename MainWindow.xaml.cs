using System;
using System.Data;
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
using System.Runtime.InteropServices;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button button)
                {
                    button.Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
  
            string str = (string)((Button)sender).Content;

            
            if (str == "AC")
            {
                textLabel.Text = ""; 
            }
            else if (str == "=")
            {
                CalculateResult(); 
            }
            else if (str == "+" || str == "-" || str == "*" || str == "/")
                {
               
                if (!string.IsNullOrEmpty(textLabel.Text) && !textLabel.Text.EndsWith(" "))
                {
                    textLabel.Text += $" {str} ";
                }
            }
            else
            {
                
                textLabel.Text += str;
            }
        }

        private void CalculateResult()
        {
            
            string[] parts = textLabel.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            
            if (parts.Length != 3)
            {
                textLabel.Text = "Ошибка";
                return;
            }

           
            if (!double.TryParse(parts[0], out double num1) || !double.TryParse(parts[2], out double num2))
            {
                textLabel.Text = "Ошибка ввода";
                return;
            }


            string operation = parts[1];


            switch (operation)
            {
                case "+":
                    textLabel.Text = (num1 + num2).ToString();
                    break;
                case "-":
                    textLabel.Text = (num1 - num2).ToString();
                    break;
                case "*":
                    textLabel.Text = (num1 * num2).ToString();
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        textLabel.Text = "Деление на 0";
                    }
                    else
                    {
                        textLabel.Text = (num1 / num2).ToString();
                    }
                    break;
                default:
                    textLabel.Text = "Ошибка";
                    break;
            }


        }
    }
}