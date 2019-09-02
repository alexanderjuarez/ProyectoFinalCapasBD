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

        }

        private void ButtonActualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonListar_Click(object sender, RoutedEventArgs e)
        {
            ClassTipoP list = new ClassTipoP();
            dataGrid1.ItemsSource = list.MostrarTodo();
            buttonActualizar.IsEnabled = true;
        }

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
