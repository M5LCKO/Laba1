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
using System.Windows.Shapes;

namespace Laba_1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
     static class D
    {
        public static string DATA { get; set; }
    }
public partial class Window2 : Window
    {
        public int num;

     
        public Window2()
        {
            InitializeComponent();
        }

        private static bool IsTextNumeric(string str)
        {
            //Char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            return int.TryParse(str, out _);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextNumeric(((TextBox)sender).Text + e.Text);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            base.OnPreviewKeyDown(e);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                num = Convert.ToInt32(number.Text);
                if (num > 0)
                { Close(); }
                else { MessageBox.Show("Вы забыли указать число или вы указали 0", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            catch
             { MessageBox.Show("Вы забыли указать число или вы указали 0", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
