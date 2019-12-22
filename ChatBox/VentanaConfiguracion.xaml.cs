using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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

namespace ChatBox
{
    /// <summary>
    /// Lógica de interacción para VentanaConfiguracion.xaml
    /// </summary>
    public partial class VentanaConfiguracion : Window
    {
        public VentanaConfiguracion()
        {
            InitializeComponent();
            ObservableCollection<string> list = new ObservableCollection<string>();
            
            foreach (PropertyInfo item in typeof(Colors).GetProperties())
            {
                list.Add(item.Name);
            }
            
            ComboBoxColores1.DataContext = list;
            ComboBoxColores2.DataContext = list;
            ComboBoxColores3.DataContext = list;
            ConfiguracionInterna();
        }

        private void Button_Click_Aceptar(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorFondo = ComboBoxColores1.SelectedValue.ToString();
            Properties.Settings.Default.ColorUsuario = ComboBoxColores2.SelectedValue.ToString();
            Properties.Settings.Default.ColorRobot = ComboBoxColores3.SelectedValue.ToString();
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Button_Click_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F)
                ComboBoxColores1.Focus();
            if (e.Key == Key.U)
                ComboBoxColores2.Focus();
            if (e.Key == Key.R)
                ComboBoxColores3.Focus();
               
        }
        private void ConfiguracionInterna()
        {
            ComboBoxColores1.SelectedItem = Properties.Settings.Default.ColorFondo;
            ComboBoxColores2.SelectedItem = Properties.Settings.Default.ColorUsuario;
            ComboBoxColores3.SelectedItem = Properties.Settings.Default.ColorRobot;
        }
    }
}
