using System;
using System.Collections.Generic;
using System.IO;
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

namespace ChatBox
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            listaPrincipal = new ListBox();
            InitializeComponent();
        }

        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            listaPrincipal.Items.Clear();
        }

        private void NewCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (listaPrincipal.Items.Count > 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void SalirCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void SalirCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string ruta = "chat.txt";
            if (!File.Exists(ruta))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(ruta))
                {
                    for (int i = 0; i < listaPrincipal.Items.Count; i++)
                    {
                        sw.WriteLine(listaPrincipal.Items.GetItemAt(i));
                    }
                }
            }
        }

        private void SaveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (listaPrincipal.Items.Count > 0)
            {
                e.CanExecute = true;
            }
        }

        private void ConfiguracionCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            VentanaConfiguracion ventana = new VentanaConfiguracion();
            ventana.ShowDialog();
        }

        private void ConfiguracionCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ComprobarConexionCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ComprobarConexionCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
