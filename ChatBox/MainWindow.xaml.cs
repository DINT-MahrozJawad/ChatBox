using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Mensaje> Lista { get; set; }
        Robot robot;
        public MainWindow()
        {
            Lista = new ObservableCollection<Mensaje>();
            InitializeComponent();
            listaPrincipal.DataContext = Lista;
            MensajeUsuario.Focus();
            robot = new Robot();
        }

        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Lista.Clear();
        }

        private void NewCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (Lista.Count > 0)
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
            string txt = "";
            
            for (int i = 0; i < Lista.Count; i++)
            {
                if (Lista.ElementAt(i).Emisor == "Robot")
                    txt += "Robot: " + Lista.ElementAt(i).Msg + "\n";
                else
                    txt += "Usuario: " + Lista.ElementAt(i).Msg + "\n";
            }
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                    File.WriteAllText(saveFileDialog.FileName, txt);
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se ha podido guradar el fichero por " + ex, "ChatBox", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void SaveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (Lista.Count > 0)
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
            robot.ComprobarConexionAsync();
        }

        private async void ImagenEnviarCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string mensaje = MensajeUsuario.Text;
            Mensaje m = new Mensaje("Usuario", mensaje);
            
            Lista.Add(m);

            MensajeUsuario.Text = "";
            m = new Mensaje("Robot", "Procesando");
            Lista.Add(m);
            string respuesta = "No soy robot";
            try
            {
                respuesta = await robot.RespuestaRobotAsync(mensaje);
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido conectar con el robot", "ChatBox", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                Lista.RemoveAt(Lista.Count - 1);
                m = new Mensaje("Robot", respuesta);
                Lista.Add(m);
            }
            
            scroll.ScrollToEnd();
        }

        private void ImagenEnviarCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (MensajeUsuario.Text != "")
            {
                e.CanExecute = true;
            }
            else
                e.CanExecute = false;
        }
    }
}
