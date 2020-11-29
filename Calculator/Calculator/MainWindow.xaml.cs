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
using Toolsbox.ShuntingYard;


namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ShuntingYardSimpleMath SY = new ShuntingYardSimpleMath();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                TB.Text += button.Content + " ";  

            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            var text = TB.Text.Trim();

            List<String> ss = text.Split(' ').ToList();
            Double res = SY.Execute(ss, null);
            TB.Text = res + " ";


        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                Double hey;
                if (TB.Text.Length > 1 && Double.TryParse(TB.Text[TB.Text.Length - 2] + "", out hey))
                {
                    TB.Text = TB.Text.Substring(0, TB.Text.Length - 1);
                    TB.Text += button.Content + " ";

                }
                else
                {
                    TB.Text += button.Content + " ";
                }

            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            TB.Text = "";

        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (TB.Text.Length > 0)
            {
                TB.Text = TB.Text.Substring(0, TB.Text.Length - 1);
            }
        }


    }
}




// String text = "Edvin Hasic";
// string[] namnen = text.split(' ');
// var talen = MyTextBlock.Text.split('+');
// var tal1 = Convert.ToInt32(talen[0]);
// var tal2 = Convert.ToInt32(talen[1]);