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
using BLL;
using MODELS;

namespace UI.Mantenimientos
{
    /// <summary>
    /// Lógica de interacción para UserControlTipoProducto.xaml
    /// </summary>
    public partial class UserControlTipoProducto : UserControl
    {
        public UserControlTipoProducto()
        {
            InitializeComponent();
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            ClassTipoP Lg = new ClassTipoP();
            string resp = Lg.NuevoTipo(this.TextNombreTipo.Text);
            if (resp.ToUpper().Contains("Error"))
                MessageBox.Show(resp, "Error al grabar", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                MessageBox.Show(resp, "Se guardo el nuevo registro", MessageBoxButton.OK);
                /*buttonAgregar.Visibility = Visibility.Visible;
                buttonGrabar.Visibility = Visibility.Hidden;
                buttonListar.IsEnabled = true;
                buttonCancelar.IsEnabled = false;*/
            }
        }

        private void ButtonActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (TextTipoId.Text != "")
            {

                string resp = "";
                ClassTipoP Logica = new ClassTipoP();
                TipoP InfoEstado = new TipoP();
                InfoEstado.tipopID = Convert.ToInt32(TextTipoId.Text);
                InfoEstado.NombreTP = TextNombreTipo.Text;
                resp = Logica.ActualizaListado(InfoEstado);
                MessageBox.Show(resp);

                /* MessageBox.Show(TextCodigo.Text);
                 MessageBox.Show(TextNombreEstado.Text);*/
            }
            else
            {
                MessageBox.Show("Marque el registro a modificar", "Error al Editar",
                MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            buttonGuardar.IsEnabled = true;
        }

        private void ButtonListar_Click(object sender, RoutedEventArgs e)
        {
            ClassTipoP list = new ClassTipoP();
            dataGrid1.ItemsSource = list.MostrarTodo();
            buttonActualizar.IsEnabled = true;
            buttonGuardar.IsEnabled = false;
        }

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            TextTipoId.Clear();
            TextNombreTipo.Clear();
            buttonActualizar.IsEnabled = false;
            buttonGuardar.IsEnabled = true;
        }
    }
}
