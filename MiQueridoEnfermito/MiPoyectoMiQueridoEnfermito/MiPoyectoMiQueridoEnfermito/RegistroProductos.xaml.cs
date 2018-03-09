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
    /// Lógica de interacción para RegistroProductos.xaml
    /// </summary>
    public partial class RegistroProductos : Window
    {
        Repositorio.RepositorioDeProductos repositorio;
        bool esNuevo;
        public RegistroProductos()
        {
            InitializeComponent();
            repositorio = new Repositorio.RepositorioDeProductos();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }
        private void HabilitarCajas(bool habilitadas)
        {
            txbCategoria.Clear();
            txbNombre.Clear();
            txbDescripcion.Clear();
            txbCompra.Clear();
            txbVenta.Clear();
            txbCategoria.IsEnabled = habilitadas;
            txbNombre.IsEnabled = habilitadas;
            txbDescripcion.IsEnabled = habilitadas;
            txbCompra.IsEnabled = habilitadas;
            txbVenta.IsEnabled = habilitadas;
        }
        private void HabilitarBotones(bool habilitados)
        {
            btnNuevo.IsEnabled = habilitados;
            btnEditar.IsEnabled = habilitados;
            btnEliminar.IsEnabled = habilitados;
            btnGuardar.IsEnabled = !habilitados;
            btnCancelar.IsEnabled = !habilitados;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(true);
            HabilitarBotones(false);
            esNuevo = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombre.Text) || string.IsNullOrEmpty(txbCompra.Text) || string.IsNullOrEmpty(txbVenta.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                Nproductos a = new Nproductos()
                {
                    Categoria = txbCategoria.Text,
                    Descripcion = txbDescripcion.Text,
                    PrecioCompra = txbCompra.Text,
                    Nombre = txbNombre.Text,
                    PrecioVenta = txbVenta.Text
                };
                if (repositorio.AgregarProducto(a))
                {
                    MessageBox.Show("Guardado con Éxito", "Producto", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar a tu categoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Nproductos original = dtgTabla.SelectedItem as Nproductos;
                Nproductos a = new Nproductos();
                a.Categoria = txbCategoria.Text;
                a.Descripcion = txbDescripcion.Text;
                a.PrecioVenta = txbVenta.Text;
                a.Nombre = txbNombre.Text;
                a.PrecioCompra = txbCompra.Text;
                if (repositorio.ModificarProducto(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("el producto a sido actualizado", "Producto", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar el producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void ActualizarTabla()
        {
            dtgTabla.ItemsSource = null;
            dtgTabla.ItemsSource = repositorio.LeerProducto();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerProducto().Count==0)
            {
                MessageBox.Show("..", "..", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Nproductos a = dtgTabla.SelectedItem as Nproductos;
                    HabilitarCajas(true);
                    txbCategoria.Text = a.Categoria;
                    txbDescripcion.Text = a.Descripcion;
                    txbCompra.Text = a.PrecioCompra;
                    txbNombre.Text = a.Nombre;
                    txbVenta.Text = a.PrecioVenta;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("??", "Producto", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(false);
            HabilitarBotones(true);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerProducto().Count ==0)
            {
                MessageBox.Show("...", "...", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Nproductos a = dtgTabla.SelectedItem as Nproductos;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                    {
                        if (repositorio.EliminarProducto(a))
                        {
                            MessageBox.Show("el producto ha removido", "", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        
                        
                    }
                }
                else
                {
                    MessageBox.Show("??", "Producto", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }
    }
}
