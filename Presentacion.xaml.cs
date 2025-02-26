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

namespace sifimo
{
    /// <summary>
    /// Lógica de interacción para Presentacion.xaml
    /// </summary>
    public partial class Presentacion : UserControl
    {
        public event EventHandler PresentacionChanged;
        public Presentacion()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            PresentacionChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
