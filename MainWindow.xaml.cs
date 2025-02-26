using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Presentacion ps = new Presentacion();
            ps.PresentacionChanged += OpenConsecuencias;
            Main.Children.Add(ps);
        }
        private void OpenConsecuencias(object? sender, EventArgs e) 
        { 
            Main.Children.Clear();
            ConsecuencesLab consecuences = new();
            consecuences.ImageSource = "Images/navespacial.png";
            Main.Children.Add(consecuences);
        }
    }
}