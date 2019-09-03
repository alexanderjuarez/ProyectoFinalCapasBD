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

namespace UI
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Item = ListViewMenu.SelectedIndex;

            switch (Item)
            {
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Mantenimientos.UserControlClientes());
                    break;

                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Mantenimientos.UserControlProveedores());
                    break;

                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Mantenimientos.UserControlTipoProducto());
                    break;



                default:
                    break;
            }
        }

    }
}

