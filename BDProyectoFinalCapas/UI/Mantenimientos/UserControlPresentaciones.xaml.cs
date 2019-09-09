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
    /// Lógica de interacción para UserControlPresentaciones.xaml
    /// </summary>
    public partial class UserControlPresentaciones : UserControl
    {
        public UserControlPresentaciones()
        {
            InitializeComponent();
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            ClassPresentacion Lg = new ClassPresentacion();
            string resp = Lg.NuevaPresentacion(this.TextNombrePres.Text);
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

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            buttonActualizar.IsEnabled = false;
            buttonGuardar.IsEnabled = true;
        }

        private void ButtonActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (TextPresId.Text != "")
            {

                string resp = "";
                ClassPresentacion Logica = new ClassPresentacion();
                Presentacion InfoEstado = new Presentacion();
                InfoEstado.PresentacionID = Convert.ToInt32(TextPresId.Text);
                InfoEstado.NombrePres = TextNombrePres.Text;
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
            ClassPresentacion list = new ClassPresentacion();
            dataGrid1.ItemsSource = list.MostrarTodo();
            buttonActualizar.IsEnabled = true;
            buttonGuardar.IsEnabled = false;
        }
    }
}
