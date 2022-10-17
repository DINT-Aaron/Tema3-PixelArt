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
        public MainWindow()
        {
            InitializeComponent();
            crearGrid(8);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            crearGrid(int.Parse((sender as Button).Tag.ToString()));
        }
    }
}
