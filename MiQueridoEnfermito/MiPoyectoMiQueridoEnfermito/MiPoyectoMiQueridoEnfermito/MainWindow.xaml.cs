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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiPoyectoMiQueridoEnfermito
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loadprogrssbar();
            pb1.ValueChanged += Pb1_ValueChanged;
        }

        private void Pb1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pb1.Value == 100)

            {
                MiQueridoEnfermito Miventana = new MiQueridoEnfermito();
                Miventana.Show();
                this.Close();

            }
        }
        private void Loadprogrssbar()
        {
            Duration dur = new Duration(TimeSpan.FromSeconds(30));
            DoubleAnimation dblani = new DoubleAnimation(200.0, dur);
            pb1.BeginAnimation(System.Windows.Controls.Primitives.RangeBase.ValueProperty, dblani);


        }
    
    }
}
