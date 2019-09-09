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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

using BLL;
using MODELS;

namespace UI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassUsuario u = new ClassUsuario();
            comboBoxUsuario.ItemsSource = u.MostrarTodo();
            comboBoxUsuario.DisplayMemberPath = "nombreTipoL";
            comboBoxUsuario.SelectedValuePath = "tlID";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassLogin Logica = new ClassLogin();

            string resp;

            resp = Logica.Ingresar(TextBoxUsuario.Text, TextBoxClave.Password,Convert.ToInt32( comboBoxUsuario.SelectedValue));
            Logica.verificar();
            var ver = Logica.verificar();
            if (resp.ToUpper().Contains("ERROR"))
                MessageBox.Show(resp, "Error al ingresar");
            else
            {
               
                if (resp=="Bienvenido1"){
                    MessageBox.Show("Bienvenido digitador");
                    Menu nuevo = new Menu(); //crea el nuevo formulario
                    nuevo.Show(); //enseña el nuevo formulario
                    this.Close(); //cierra el formulario actualmente abierto*

                    }
                 else if(resp=="Bienvenido2")
                {
                    MessageBox.Show("Binevenido Administrador");
                }
                 else if (resp == "Bienvenido3")
                {
                    MessageBox.Show("Binevenido Empleado");
                }
                else { 
                    MessageBox.Show("Datos incorrectos");}
            }

        }

        private void ButtonCerrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
