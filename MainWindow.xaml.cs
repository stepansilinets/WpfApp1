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

            foreach(UIElement el in MainRoot.Children)
            {
                if(el is Button)
                {
                    ((Button) el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)(e.OriginalSource)).Content;

            if (str == "AC")
                textLabel.Text = "";

            else if (str == "=")
            {
                string[] a = textLabel.Text.Split();

                int[] num1 = toBin(Convert.ToInt32(a[0]));
                int[] num2 = toBin(Convert.ToInt32(a[2]));
                string sign = a[1];

                if (sign == "+")
                {
                    textLabel.Text = Add(num1, num2);
                }
                else if (sign == "-")
                {
                    textLabel.Text = Difference(num1, num2);
                }

            }
            else if ((str == "+") || (str == "-") || (str == "*") || (str == "/"))
            {
                textLabel.Text += $" {str} ";
            }
            else
                textLabel.Text += str;
        }
        public string Add(int[] num1, int[] num2)
        {
            int n = 0;
            int[] result = new int[8];

            for (int i = 0; i < 8; i++)
            {
                if ((num1[i] == 0 && num2[i] == 0) || (num2[i] == 0 && num1[i] == 0))
                {
                    if (n == 1)
                    {
                        result[i] = 1;
                        n = 0;
                    }
                    else
                    {
                        result[i] = 0;
                    }
                }
                else if ((num1[i] == 1 && num2[i] == 0) || (num1[i] == 0 && num2[i] == 1))
                {
                    if (n == 0)
                    {
                        result[i] = 1;
                    }
                    else
                    {
                        result[i] = 0;
                        n = 1;
                    }
                }
                else if (num1[i] == 1 && num2[i] == 1)
                {
                    if (n == 1)
                    {
                        result[i] = 1;
                    }
                    else
                    {
                        result[i] = 0;
                        n = 1;
                    }
                }
            }
            string str = "";
            for (int i = 0; i < 8; i++)
            {
                str = str.Insert(0, Convert.ToString(result[i]));
            }
            return str;
        }

        public string Difference(int[] num1, int[] num2)
        {
            for (int i = 0; i < 8; i++)
            {
                if (num2[i] == 0)
                {
                    num2[i] = 1;
                }
                else if (num2[i] == 1)
                {
                    num2[i] = 0;
                }
            }

            string str = Add(num2, new int[8] { 1, 0, 0, 0, 0, 0, 0, 0 });

            int[] array = new int[8];
            for (int i = 0; i < 8; i++)
            {
                array[i] = str[7-i] - 48;
            }

            return Add(num1, array);
        }
        public void Multiply(int[] num1, int[] num2)
        {

        }
        public void Division()
        {

        }
        public int[] toBin(int a)
        {
            int[] b = new int[8];
            for(int i = 0; i<8; i++)
            {
                if (a % 2 == 0)
                {
                    b[i] = 0;
                }
                else
                {
                    b[i] = 1;
                }
                a /= 2;
            }
            return b;
        }
    }
}