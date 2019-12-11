using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            ObservableCollection<StackPanel> list = new ObservableCollection<StackPanel>();
            
            foreach (var item in typeof(Colors).GetProperties())
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Horizontal;
                sp.Margin = new Thickness(10);

                Rectangle rectangle = new Rectangle();
                Brush b = (Brush) new BrushConverter().ConvertFromString(item.Name);
                rectangle.Fill = b;
                rectangle.Margin = new Thickness(0, 0, 10, 0);
                rectangle.Width = 10;
                rectangle.Height = 10;
                sp.Children.Add(rectangle);
                TextBlock textBlock = new TextBlock
                {
                    Text = item.Name
                };
                sp.Children.Add(textBlock);
                list.Add(sp);
            }


            ComboBoxColores1.DataContext = list;
            ComboBoxColores2.DataContext = list;
            ComboBoxColores3.DataContext = list;
        }

        private void Button_Click_Aceptar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
