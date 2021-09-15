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
using System.Data;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string numbers;
        private void Close_App(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Open_Website(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/renekrizak");
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) //Move Window
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }
            DragMove();
        }

        private void AppendNumber(object sender, RoutedEventArgs e)
        {
            Button srcBtn = (Button)sender;
            string symbol = srcBtn.Content.ToString();
            numbers += symbol;
            DisplayText();
        }

        private void DisplayText()
        {
            expressionBox.Text = numbers;
        }

        private void DeleteLastSymbol(object sender, RoutedEventArgs e)
        {
            numbers = numbers.Remove(numbers.Length - 1);
            if (numbers.Length == 0) numbers = "0";
            DisplayText();
        }

        private void DeleteWholeExpression(object sender, RoutedEventArgs e)
        {
            numbers = "";
            DisplayText();
        }

        private void GetResult(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            var result = dt.Compute(numbers, "");
            numbers = result.ToString();
            DisplayText();
        }

    }
}
