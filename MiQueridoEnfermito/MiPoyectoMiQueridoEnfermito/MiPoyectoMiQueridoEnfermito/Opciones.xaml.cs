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
    /// Lógica de interacción para Opciones.xaml
    /// </summary>
    public partial class Opciones : Window
    {
        public Opciones()
        {
            InitializeComponent();
        }

        private void btnCategoria_Click(object sender, RoutedEventArgs e)
        {
            NuevaCategoria Miventana = new NuevaCategoria();
            Miventana.Owner = this;
            Miventana.ShowDialog();

        }

        private void btnProducto_Click(object sender, RoutedEventArgs e)
        {
            RegistroProductos Miventana = new RegistroProductos();
            Miventana.Owner = this;
            Miventana.ShowDialog();
        }

        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {
            RegistroClientes Miventana = new RegistroClientes();
            Miventana.Owner = this;
            Miventana.ShowDialog();
        }

        private void btnEmpleado_Click(object sender, RoutedEventArgs e)
        {
            RegistroEmpleado Miventana = new RegistroEmpleado();
            Miventana.Owner = this;
            Miventana.ShowDialog();
        }
    }
}
