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

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double Numero1 = 0, Numero2 = 0;
        char Operador;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton== MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState= WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void VaciarVariable(object sender, RoutedEventArgs e)
        {
            txtResultado.Text = "0";
        }

        private void btnBorrarTodo_Click(object sender, RoutedEventArgs e)
        {
            Numero1 = 0;
            Numero2= 0;
            Operador = '\0';
            txtResultado.Text = "0";
        }

        private void btnBorrarUno_Click(object sender, RoutedEventArgs e)
        {
            if (txtResultado.Text.Length > 1 )
            {
                txtResultado.Text = txtResultado.Text.Substring(0,txtResultado.Text.Length - 1);
            }
            else
            {
                txtResultado.Text= "0"; 
            }
        }
        private void btnInvertir_Click(object sender, RoutedEventArgs e)
        {
            Numero1=double.Parse(txtResultado.Text);
            Numero1 *= -1;
            txtResultado.Text = Numero1.ToString();
        }
        private void AgregarNumero_Click(object sender, RoutedEventArgs e)
        {
            //se llama el boton seleccionado en la variable var
            var boton = ((Button)sender);
            //se verifica se el texbox est vacio o no
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "";
            }
            //se agrega el numero
            txtResultado.Text += boton.Content;
        }

        private void btnPunto_Click(object sender, RoutedEventArgs e)
        {
            if (!txtResultado.Text.Contains("."))
            {
                txtResultado.Text += ".";
            }
        }

        private void Operador_Click(object sender, RoutedEventArgs e)
        {
            var boton = ((Button)sender);

            //asignamos el contenido del texbox a la primero variable
            Numero1 = double.Parse(txtResultado.Text);

            //se asigna el tag de cada boton a la variable operador
            Operador = Convert.ToChar(boton.Tag);
            //se verifica el tipo de operacion en caso de no 
            //necesitar otra varible aparece el resultado direccto 
            if(Operador == '²')
            {
                Numero1 = Math.Pow(Numero1,2);
                txtResultado.Text = Numero1.ToString();
            }else if(Operador == '√')
            {
                Numero1 = Math.Sqrt(Numero1);
                txtResultado.Text = Numero1.ToString();
            }
            else
            {
                txtResultado.Text = "0";
            }
        }


        private void btnIgual_Click(object sender, RoutedEventArgs e)
        {
            Numero2 = double.Parse(txtResultado.Text);

            switch (Operador)
            {
                case '+':

                    txtResultado.Text = (Numero1 + Numero2).ToString();
                    Numero1 = Convert.ToDouble(txtResultado.Text);
                    break;
                case '-':
                    txtResultado.Text = (Numero1 - Numero2).ToString();
                    Numero1 = Convert.ToDouble(txtResultado.Text);
                    break;
                case 'x':
                    txtResultado.Text = (Numero1 * Numero2).ToString();
                    Numero1 = Convert.ToDouble(txtResultado.Text);
                    break;
                case '/':
                    if (txtResultado.Text != "0")
                    {
                        txtResultado.Text = (Numero1 / Numero2).ToString();
                        Numero1 = Convert.ToDouble(txtResultado.Text);
                    }
                    else
                    {
                        MessageBox.Show("No es posible la divison entre cero!!!!");
                    }
                    break;
            }

        }

    }
}
