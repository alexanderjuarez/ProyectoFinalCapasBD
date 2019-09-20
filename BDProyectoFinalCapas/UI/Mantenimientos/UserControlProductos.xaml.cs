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
    /// Lógica de interacción para UserControlProductos.xaml
    /// </summary>
    public partial class UserControlProductos : UserControl
    {
        public UserControlProductos()
        {
            InitializeComponent();
            ClassProveedor Logica = new ClassProveedor();
            comboProveedor.ItemsSource = Logica.ListarProveedor();
            comboProveedor.DisplayMemberPath = "nombreProveedor";
            comboProveedor.SelectedValuePath = "proveedorID";
    

            ClassTipoP Lg = new ClassTipoP();
            comboTipo.ItemsSource = Lg.MostrarTodo();
            comboTipo.DisplayMemberPath = "NombreTP";
            comboTipo.SelectedValuePath = "tipopID";

            ClassPresentacion Lgc = new ClassPresentacion();
            comboPresentacion.ItemsSource = Lgc.MostrarTodo();
            comboPresentacion.DisplayMemberPath = "NombrePres";
            comboPresentacion.SelectedValuePath = "PresentacionID";


        }

        private void UserControlProductos_Load(object sender, EventArgs e)
        {
         
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            buttonActualizar.IsEnabled = false;
            buttonGuardar.IsEnabled = true;
            TextPresentacion.Clear();
            TextProductoId.Clear();
            TextNombreProduc.Clear();
            TextExistencia.Clear();
            TextDescripcion.Clear();
            TextDescuento.Clear();
            TextProveedor.Clear();
            TextPrecio.Clear();
            TextTipoProducto.Clear();

        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            ClassProducto Logica = new ClassProducto();
            string resp;
            resp = Logica.NuevoProducto(TextNombreProduc.Text,Convert.ToSingle(TextPrecio.Text), TextDescripcion.Text,Convert.ToSingle(TextDescuento.Text),Convert.ToInt32( TextExistencia.Text), Convert.ToInt32(comboTipo.SelectedValue), Convert.ToInt32(comboPresentacion.SelectedValue),Convert.ToInt32( comboProveedor.SelectedValue));
            if (resp.ToUpper().Contains("ERROR"))
                MessageBox.Show(resp, "Error al registrar el proveedor");
            else
            {
                MessageBox.Show(resp);
                /*buttonAgregar.Visibility = Visibility.Visible;
                buttonGrabar.Visibility = Visibility.Hidden;
                buttonListar.IsEnabled = true;
                buttonCancelar.IsEnabled = false;*/
                TextPresentacion.Clear();
                TextProductoId.Clear();
                TextNombreProduc.Clear();
                TextExistencia.Clear();
                TextDescripcion.Clear();
                TextDescuento.Clear();
                TextProveedor.Clear();
                TextPrecio.Clear();
                TextTipoProducto.Clear();
            }
        }

        private void ButtonCancelar_Click_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void ButtonActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (TextProductoId.Text != "")
            {

                string resp = "Datos correctamente actualizados";
                ClassProducto Logica = new ClassProducto();
                Producto InfoEstado = new Producto();
                InfoEstado.productoID = Convert.ToInt32(TextProductoId.Text);
                InfoEstado.nombreProducto = TextNombreProduc.Text;
                InfoEstado.PrecioVenta =Convert.ToSingle(TextPrecio.Text);
                InfoEstado.Descripcion = TextDescripcion.Text;
                InfoEstado.descuentoProducto = Convert.ToSingle(TextDescuento.Text);
                InfoEstado.existenciaProducto = Convert.ToInt32(TextExistencia.Text);
                InfoEstado.tipopID = Convert.ToInt32(comboTipo.SelectedValue);
                InfoEstado.PresentacionID = Convert.ToInt32(comboPresentacion.SelectedValue);
                InfoEstado.proveedorID = Convert.ToInt32(comboProveedor.SelectedValue);
                resp = Logica.ActualizarProducto(InfoEstado);
                MessageBox.Show(resp);

                /*MessageBox.Show(TextCodigo.Text);
                 MessageBox.Show(TextNombreEstado.Text);*/
                TextPresentacion.Clear();
                TextProductoId.Clear();
                TextNombreProduc.Clear();
                TextExistencia.Clear();
                TextDescripcion.Clear();
                TextDescuento.Clear();
                TextProveedor.Clear();
                TextPrecio.Clear();
                TextTipoProducto.Clear();
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
            ClassProducto Logica = new ClassProducto();
            dataGrid1.ItemsSource = Logica.Consulta1();
            buttonActualizar.IsEnabled = true;
            buttonGuardar.IsEnabled = false;
        }
    }
}
