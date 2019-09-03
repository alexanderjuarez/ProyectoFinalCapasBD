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
    /// Lógica de interacción para UserControlProveedores.xaml
    /// </summary>
    public partial class UserControlProveedores : UserControl
    {
        public UserControlProveedores()
        {
            InitializeComponent();
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            ClassProveedor Logica = new ClassProveedor();
            string resp;
            resp = Logica.NuevoProveedor(TextNombrePro.Text, TextDirProveedor.Text, Convert.ToInt32(TextTelProveedor.Text), TextCorreo.Text);
            if (resp.ToUpper().Contains("ERROR"))
                MessageBox.Show(resp, "Error al registrar el proveedor");
            else
            {
                MessageBox.Show(resp);
                /*buttonAgregar.Visibility = Visibility.Visible;
                buttonGrabar.Visibility = Visibility.Hidden;
                buttonListar.IsEnabled = true;
                buttonCancelar.IsEnabled = false;*/
            }
        }

        private void ButtonActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (TextProveedorId.Text != "")
            {

                string resp = "Datos correctamente actualizados";
                ClassProveedor Logica = new ClassProveedor();
                Proveedor InfoEstado = new Proveedor();
                InfoEstado.proveedorID = Convert.ToInt32(TextProveedorId.Text);
                InfoEstado.nombreProveedor = TextNombrePro.Text;
                InfoEstado.direccionProveedor = TextDirProveedor.Text;
                InfoEstado.telefonoProveedor = Convert.ToInt32(TextTelProveedor.Text);
                InfoEstado.correoProveedor = TextCorreo.Text;
                resp = Logica.ActualizarProveedor(InfoEstado);
                MessageBox.Show(resp);

                /*MessageBox.Show(TextCodigo.Text);
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
            ClassProveedor Logica = new ClassProveedor();
            dataGrid1.ItemsSource = Logica.ListarProveedor();
            buttonActualizar.IsEnabled = true;
            buttonGuardar.IsEnabled = false;
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            TextProveedorId.Clear();
            TextNombrePro.Clear();
            TextDirProveedor.Clear();
            TextTelProveedor.Clear();
            TextCorreo.Clear();
            buttonActualizar.IsEnabled = false;
            buttonGuardar.IsEnabled = true;
        }
    }
}
