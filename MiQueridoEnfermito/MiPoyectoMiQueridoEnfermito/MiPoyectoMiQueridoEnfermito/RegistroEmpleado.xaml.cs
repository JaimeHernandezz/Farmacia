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
    /// Lógica de interacción para RegistroEmpleado.xaml
    /// </summary>
    public partial class RegistroEmpleado : Window
    {
        Repositorio.RepositorioDeEmpleado repositorio;
        bool esNuevo;
        public RegistroEmpleado()
        {
            InitializeComponent();
            repositorio = new Repositorio.RepositorioDeEmpleado();
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
            txbEmail.Clear();
            txbMatricula.Clear();
            txbNombre.IsEnabled = habilitadas;
            txbDireccion.IsEnabled = habilitadas;
            txbRfc.IsEnabled = habilitadas;
            txbTelefono.IsEnabled = habilitadas;
            txbEmail.IsEnabled = habilitadas;
            txbMatricula.IsEnabled = habilitadas;
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

                Nempleados a = new Nempleados()
                {
                    Nombre = txbNombre.Text,
                    Direccion = txbDireccion.Text,
                    RFC = txbRfc.Text,
                    Telefono = txbTelefono.Text,
                    Email = txbEmail.Text,
                    Matricula = txbMatricula.Text
                };
                if (repositorio.AgregarEmpleado(a))
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
                Nempleados original = dtgTabla.SelectedItem as Nempleados;
                Nempleados a = new Nempleados();
                a.Nombre = txbNombre.Text;
                a.Direccion = txbDireccion.Text;
                a.RFC = txbRfc.Text;
                a.Telefono = txbTelefono.Text;
                a.Email = txbEmail.Text;
                a.Matricula = txbMatricula.Text;
                if (repositorio.ModificarEmpleado(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("el empleado a sido actualizado", "", MessageBoxButton.OK, MessageBoxImage.Information);
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
            dtgTabla.ItemsSource = repositorio.LeerEmpleado();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerEmpleado().Count ==0)
            {
                MessageBox.Show("...", "...", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Nempleados a = dtgTabla.SelectedItem as Nempleados;
                    HabilitarCajas(true);
                    txbNombre.Text = a.Nombre;
                    txbDireccion.Text = a.Direccion;
                    txbRfc.Text = a.RFC;
                    txbTelefono.Text = a.Telefono;
                    txbEmail.Text = a.Email;
                    txbMatricula.Text = a.Matricula;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("???", "empleado", MessageBoxButton.OK, MessageBoxImage.Question);
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
            if (repositorio.LeerEmpleado().Count ==0)
            {
                MessageBox.Show("....", "...", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Nempleados a = dtgTabla.SelectedItem as Nempleados;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarEmpleado(a))
                        {
                            MessageBox.Show("Tu informacion a sido removido", "empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        
                        
                    }
                }
                else
                {
                    MessageBox.Show("???", "empleado", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }
    }
}
