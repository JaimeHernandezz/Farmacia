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
    /// Lógica de interacción para RegistroClientes.xaml
    /// </summary>
    public partial class RegistroClientes : Window
    {
        Repositorio.RepositorioDeCliente repositorio;
        bool esNuevo;
        public RegistroClientes()
        {
            InitializeComponent();
            repositorio = new Repositorio.RepositorioDeCliente();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }
        private void HabilitarCajas(bool habilitadas)
        {
            txbNombre.Clear();
            txbDireccion.Clear();
            txbRfc.Clear();
            txbTelefono.Clear();
            txbEstacionamiento.Clear();
            txbDireccion.IsEnabled = habilitadas;
            txbRfc.IsEnabled = habilitadas;
            txbEstacionamiento.IsEnabled = habilitadas;
            txbNombre.IsEnabled = habilitadas;
            txbTelefono.IsEnabled = habilitadas;
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
            if (string.IsNullOrEmpty(txbNombre.Text) || string.IsNullOrEmpty(txbRfc.Text) || string.IsNullOrEmpty(txbTelefono.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                Nclientes a = new Nclientes()
                {
                    Direccion = txbDireccion.Text,
                    RFC = txbRfc.Text,
                    Estacionamiento = txbEstacionamiento.Text,
                    Nombre = txbNombre.Text,
                    Telefono = txbTelefono.Text
                };
                if (repositorio.AgregarCliente(a))
                {
                    MessageBox.Show("informacion guardada con Éxito", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar el empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Nclientes original = dtgTabla.SelectedItem as Nclientes;
                Nclientes a = new Nclientes();
                a.Direccion = txbDireccion.Text;
                a.RFC = txbRfc.Text;
                a.Estacionamiento = txbEstacionamiento.Text;
                a.Nombre = txbNombre.Text;
                a.Telefono = txbTelefono.Text;
                if (repositorio.ModificarCliente(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("el nombre a sido actualizado", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar el empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }
        private void ActualizarTabla()
        {
            dtgTabla.ItemsSource = null;
            dtgTabla.ItemsSource = repositorio.LeerCliente();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerCliente().Count == 0)
            {
                MessageBox.Show("...", "...", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Nclientes a = dtgTabla.SelectedItem as Nclientes;
                    HabilitarCajas(true);
                    txbDireccion.Text = a.Direccion;
                    txbRfc.Text = a.RFC;
                    txbEstacionamiento.Text = a.Estacionamiento;
                    txbNombre.Text = a.Nombre;
                    txbTelefono.Text = a.Telefono;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("???", "Cliente", MessageBoxButton.OK, MessageBoxImage.Question);
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
            if (repositorio.LeerCliente().Count ==0)
            {
                MessageBox.Show("....", "...", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Nclientes a = dtgTabla.SelectedItem as Nclientes;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarCliente(a))
                        {
                            MessageBox.Show("Tu informacion a sido removido", "Clientes", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("???", "Cliente", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }
    }
}
