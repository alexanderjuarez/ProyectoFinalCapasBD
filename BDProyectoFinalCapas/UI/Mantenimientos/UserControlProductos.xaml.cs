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
        }

        private void UserControlProductos_Load(object sender, EventArgs e)
        {
         
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
