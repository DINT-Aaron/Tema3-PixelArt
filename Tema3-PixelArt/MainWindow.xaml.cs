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

namespace Tema3_PixelArt
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush color;
        public MainWindow()
        {
            InitializeComponent();
            crearGrid(8);
            color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
        }

        private void crearGrid(int n)
        {
            zonaDibujoGrid.Rows = n;
            zonaDibujoGrid.Columns = n;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Border cuadricula = new Border();
                    cuadricula.Style = (Style)Resources["cuadricula"];
                    zonaDibujoGrid.Children.Add(cuadricula);
                }
            }
        }

        private void CambiarTamaño_Click(object sender, RoutedEventArgs e)
        {
            zonaDibujoGrid.Children.Clear();
            crearGrid(int.Parse((sender as Button).Tag.ToString()));
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                (sender as Border).Background = color;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Border).Background = color;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as RadioButton).Tag.ToString().Equals("Personalizado"))
            {
                colorPersonalizadoTextBox.IsEnabled = true;
                colorPersonalizadoTextBox_TextChanged(sender, e);
            }
            else
            {
                colorPersonalizadoTextBox.IsEnabled = false;
                color = new SolidColorBrush((Color)ColorConverter.ConvertFromString((sender as RadioButton).Tag.ToString()));
            }
        }

        private void colorPersonalizadoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (colorPersonalizadoTextBox.Text.Length == 6 || colorPersonalizadoTextBox.Text.Length == 7)
            {
                if (colorPersonalizadoTextBox.Text.ToString().Substring(0, 1) == "#")
                {
                    color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorPersonalizadoTextBox.Text.ToString()));
                }
                else
                {
                    color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + colorPersonalizadoTextBox.Text.ToString()));
                }
            }
        }
    }
}
