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
    /// Lógica de interacción para UserControlClientes.xaml
    /// </summary>
    public partial class UserControlClientes : UserControl
    {
        public UserControlClientes()
        {
            InitializeComponent();
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            ClassCliente Logica = new ClassCliente();
            string resp;
            resp = Logica.NuevoCliente(TextNombreCliente.Text, TextApellidoCliente.Text, TextNIT.Text);
            if (resp.ToUpper().Contains("ERROR"))
                MessageBox.Show(resp, "Error al crear cliente");
            else
            {
                MessageBox.Show(resp);
                /*buttonAgregar.Visibility = Visibility.Visible;
                buttonGrabar.Visibility = Visibility.Hidden;
                buttonListar.IsEnabled = true;
                buttonCancelar.IsEnabled = false;*/
            }
        }

        private void ButtonListar_Click(object sender, RoutedEventArgs e)
        {
            ClassCliente Logica = new ClassCliente();
            dataGrid1.ItemsSource = Logica.ListarClientes();
            buttonActualizar.IsEnabled = true;
            buttonGuardar.IsEnabled = false;
        }

        private void ButtonActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (TextClienteId.Text != "")
            {

                string resp = "Datos correctamente actualizados";
                ClassCliente Logica = new ClassCliente();
                Cliente InfoEstado = new Cliente();
                InfoEstado.clienteID = Convert.ToInt32(TextClienteId.Text);
                InfoEstado.nombreCliente = TextNombreCliente.Text;
                InfoEstado.apellidoCliente = TextApellidoCliente.Text;
                InfoEstado.NIT = TextNIT.Text;
                resp = Logica.ActualizarCliente(InfoEstado);
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

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            TextNIT.Clear();
            TextClienteId.Clear();
            TextNombreCliente.Clear();
            TextApellidoCliente.Clear();
            buttonActualizar.IsEnabled = false;
            buttonGuardar.IsEnabled = true;
        }
    }
}
