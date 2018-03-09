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
    /// Lógica de interacción para NuevaCategoria.xaml
    /// </summary>
    public partial class NuevaCategoria : Window
    {
        Repositorio.RepositorioDeCategoria repositorio;
        bool esNuevo;
        public NuevaCategoria()
        {
            InitializeComponent();
            repositorio = new Repositorio.RepositorioDeCategoria();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }
        private void HabilitarCajas(bool habilitadas)
        {
            txbICategoria.Clear();
            txbICategoria.IsEnabled = habilitadas;
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
            if (string.IsNullOrEmpty(txbICategoria.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                Ncategoria a = new Ncategoria()
                {
                    TipoDecategoria = txbICategoria.Text
                };
                if (repositorio.AgregarCategoria(a))
                {
                    MessageBox.Show("Guardado con Éxito", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
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
                Ncategoria original = dtgTabla.SelectedItem as Ncategoria;
                Ncategoria a = new Ncategoria();
                a.TipoDecategoria = txbICategoria.Text;
                if (repositorio.ModificarCategoria(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Su ctegoria a sido actualizada", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar a la categoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                    
            }
        }
        private void ActualizarTabla()
        {
            dtgTabla.ItemsSource = null;
            dtgTabla.ItemsSource = repositorio.LeerCategoria();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerCategoria().Count == 0)
            {
                MessageBox.Show("ooooo", "ooooooooo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Ncategoria a = dtgTabla.SelectedItem as Ncategoria;
                    HabilitarCajas(true);
                    txbICategoria.Text = a.TipoDecategoria;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("???", "Categoria", MessageBoxButton.OK, MessageBoxImage.Question);
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
            if (repositorio.LeerCategoria().Count == 0)
            {
                MessageBox.Show("..", "..", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Ncategoria a = dtgTabla.SelectedItem as Ncategoria;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.TipoDecategoria + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarCategoria(a))
                        {
                            MessageBox.Show("La Categoria ha sido removida", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar a la categoria ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                            
                    }
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Categoria", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }
    }
}
