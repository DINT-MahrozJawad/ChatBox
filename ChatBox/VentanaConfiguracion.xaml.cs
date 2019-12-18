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

            ComboBoxColores1.SelectedItem = Properties.Settings.Default.ColorFondo;
        }

        private void Button_Click_Aceptar(object sender, RoutedEventArgs e)
        {
            ComboBoxColores1.SelectedItem = Properties.Settings.Default.ColorFondo;
            this.Close();
        }

        private void Button_Click_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
