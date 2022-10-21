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
        bool dibujoEmpezado = false;
        public MainWindow()
        {
            InitializeComponent();
            CrearGrid(8);
            color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
        }

        private void CrearGrid(int n)
        {
            zonaDibujoGrid.Children.Clear();
            dibujoEmpezado = false;
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
            if (dibujoEmpezado)
            {
                if (MessageBox.Show("¿Desea borrar el dibujo y crear uno nuevo?",
                    "Crear nuevo",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    CrearGrid(int.Parse((sender as Button).Tag.ToString()));
                }
            }
            else
            {
                CrearGrid(int.Parse((sender as Button).Tag.ToString()));
            }
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                (sender as Border).Background = color;
                dibujoEmpezado = true;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Border).Background = color;
            dibujoEmpezado = true;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as RadioButton).Tag.ToString().Equals("Personalizado"))
            {
                colorPersonalizadoTextBox.IsEnabled = true;
                if (colorPersonalizadoTextBox.Text.Length == 6)
                {
                    CambiarColor("#" + colorPersonalizadoTextBox.Text.ToString());
                }
                else if (colorPersonalizadoTextBox.Text.Length == 7)
                {
                    CambiarColor(colorPersonalizadoTextBox.Text.ToString());
                }

            }
            else
            {
                colorPersonalizadoTextBox.IsEnabled = false;
                CambiarColor((sender as RadioButton).Tag.ToString());
            }
        }

        private void ColorPersonalizadoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*if (colorPersonalizadoTextBox.Text.ToString().Substring(0, 1) == "#" && colorPersonalizadoTextBox.Text.Length == 7)
            {
                CambiarColor(colorPersonalizadoTextBox.Text.ToString());
            }
            else if (colorPersonalizadoTextBox.Text.ToString().Substring(0, 1) != "#" && colorPersonalizadoTextBox.Text.Length == 6)
            {
                CambiarColor("#" + colorPersonalizadoTextBox.Text.ToString());
            }*/

            if (colorPersonalizadoTextBox.Text.Length == 6)
            {
                if (colorPersonalizadoTextBox.Text.StartsWith("#"))
                {
                    if (colorPersonalizadoTextBox.Text.Length == 7)
                    {
                        CambiarColor(colorPersonalizadoTextBox.Text.ToString());
                    }
                }
                else
                {
                    CambiarColor("#"+colorPersonalizadoTextBox.Text.ToString());
                }
            }
        }
        private void CambiarColor(string colorString)
        {
            try
            {
                color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorString));
            }
            catch (FormatException)
            {
                MessageBox.Show("El color introducido no es válido.\nDebe ser un valor hexadecimal de 6 cifras.\n[RRGGBB] o [#RRGGBB]", "Color no válido", MessageBoxButton.OK, MessageBoxImage.Error);
                colorPersonalizadoTextBox.Text = "";
            }
        }

        private void RellenarButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Border borde in zonaDibujoGrid.Children)
            {
                borde.Background = color;
                dibujoEmpezado = true;
            }
        }
    }
}
