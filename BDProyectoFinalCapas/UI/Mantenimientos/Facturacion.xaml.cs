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
using System.Xml.Linq;

using MODELS;
using BLL;

namespace UI.Mantenimientos
{
    /// <summary>
    /// Lógica de interacción para Facturacion.xaml
    /// </summary>
    public partial class Facturacion : UserControl
    {
        ClassConsulta lg = new ClassConsulta();
        float total;
        XElement DetalleXML = new XElement("DetalleFactura");
        XElement FacturaXML = new XElement("Factura");
        XElement PagosXML = new XElement("Pago");
        XElement mostarxml = new XElement("Informacion");
        public Facturacion()
        {
            InitializeComponent();
            ClassProducto Lg = new ClassProducto();
            comboProducto.ItemsSource = Lg.ListarProducto();
            comboProducto.DisplayMemberPath = "nombreProducto";
            comboProducto.SelectedValuePath = "productoID";

            textBoxFecha.Text = DateTime.Now.ToString("yyyy/MM/dd");

            ClassCliente lista = new ClassCliente();
            comboCliente.ItemsSource = lista.ListarClientes();
            comboCliente.DisplayMemberPath = "nombreCliente";
            comboCliente.SelectedValuePath = "clienteID";

            ClassEmpleado listar = new ClassEmpleado();
            comboEmpleado.ItemsSource = listar.ListarEmpleado();
            comboEmpleado.DisplayMemberPath = "nombreEmpleado";
            comboEmpleado.SelectedValuePath = "empleadoID";
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            XElement info1 = new XElement("Serie", labelLetra.Content);
            XElement info2 = new XElement("Fecha", Convert.ToDateTime(textBoxFecha.Text));
            XElement info3 = new XElement("ClienteId", Convert.ToInt32(comboCliente.SelectedValue));
            XElement info4 = new XElement("EmpleadoId", Convert.ToInt32(comboEmpleado.SelectedValue));
            XElement info5 = new XElement("Total", labelTotalC.Content);
            FacturaXML.Add(new XElement("FinalFactura",
             info1,
             info2,
             info3,
             info4,
             info5
             ));

            XElement pago1 = new XElement("Efectivo", Convert.ToSingle(textEfectivo.Text));
            XElement pago2 = new XElement("Tarjeta", Convert.ToSingle(textTarjeta.Text));
            XElement pago3 = new XElement("Cheque", Convert.ToSingle(textCheque.Text));
            PagosXML.Add(new XElement("DetallesP",
                pago1,
                pago2,
                pago3
                ));
            MessageBox.Show(FacturaXML.ToString());
            MessageBox.Show(PagosXML.ToString());
            lg.sp_xmlF(FacturaXML.ToString(), DetalleXML.ToString(), PagosXML.ToString());
            DetalleXML.RemoveAll();
            PagosXML.RemoveAll();
            FacturaXML.RemoveAll();
            mostarxml.RemoveAll();

            dataGrid1.Columns.Clear();
            labelTotalC.Content = "0.00";
            total = 0;
            textEfectivo.Text = "0.00";
            textTarjeta.Text = "0.00";
            textCheque.Text = "0.00";

        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAgregar_Click(object sender, RoutedEventArgs e)
        {
           
            float descuento=0;
            float subtotal =0;
            descuento = (Convert.ToSingle(textDescuento.Text) * Convert.ToSingle(TextCantidad.Text));
            subtotal = (Convert.ToSingle(textPrecioP.Text) * Convert.ToSingle(TextCantidad.Text)) - descuento;
            MessageBox.Show(""+subtotal);

            total += subtotal;
            labelTotalC.Content = Convert.ToString(total);

            XElement info1 = new XElement("ProductoId", Convert.ToInt32(comboProducto.SelectedValue));
            XElement info2 = new XElement("CantidadP", TextCantidad.Text);
            XElement info3 = new XElement("Subtotal",subtotal);
            DetalleXML.Add(new XElement("Detalles",
                info1,
                info2,
                info3

                ));

            MessageBox.Show(DetalleXML.ToString());

            XElement informacion1 = new XElement("Nombre", textNombreProducto.Text);
            XElement informacion2 = new XElement("Precio",Convert.ToSingle(textPrecioP.Text));
            XElement informacion3 = new XElement("Cantidad", Convert.ToSingle(TextCantidad.Text));
            XElement informacion4 = new XElement("Descuento", Convert.ToSingle(textDescuento.Text));
            XElement informacion5 = new XElement("SubTotal", subtotal);
            mostarxml.Add(new XElement("Listado",
                informacion1,
                informacion2,
                informacion3,
                informacion4,
                informacion5

                ));

            MessageBox.Show(mostarxml.ToString());
            
            dataGrid1.ItemsSource = lg.sp_xmlM(mostarxml.ToString());

            lg.sp_xmlD(Convert.ToInt16(comboProducto.SelectedValue), Convert.ToInt16(TextCantidad.Text));

        }
    }
}
