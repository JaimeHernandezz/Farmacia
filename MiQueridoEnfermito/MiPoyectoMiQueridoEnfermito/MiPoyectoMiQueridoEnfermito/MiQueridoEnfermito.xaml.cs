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

namespace MiPoyectoMiQueridoEnfermito
{
    /// <summary>
    /// Lógica de interacción para MiQueridoEnfermito.xaml
    /// </summary>
    public partial class MiQueridoEnfermito : Window
    {
        public MiQueridoEnfermito()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Opciones Miventana = new Opciones();
            Miventana.Owner = this;
            Miventana.ShowDialog();

        }

        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
