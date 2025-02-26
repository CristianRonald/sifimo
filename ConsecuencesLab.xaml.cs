using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace sifimo
{
    /// <summary>
    /// Lógica de interacción para ConsecuencesLab.xaml
    /// </summary>
    public partial class ConsecuencesLab : UserControl
    {
        private DispatcherTimer timer;
        private TimeSpan tiempo, tiempo_r;
        private bool _active = false;

        public static readonly DependencyProperty ImageSourceProperty =
        DependencyProperty.Register("ImageSource", typeof(string), typeof(ConsecuencesLab), new PropertyMetadata(null));
        double velocidadNaveSpacial = 5;
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }


        public ConsecuencesLab()
        {
            InitializeComponent();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            tiempo = tiempo.Add(TimeSpan.FromSeconds(1));
            tiempo_imput.Text = tiempo.ToString(@"hh\:mm\:ss\:fff");
            double _ = TiempoRelativo(tiempo.TotalSeconds, velocidad.Value);
            tiempo_r = TimeSpan.FromSeconds(TiempoRelativo(tiempo.TotalSeconds, velocidad.Value));
            tiempo_relativo.Text = tiempo_r.ToString(@"hh\:mm\:ss\:fff");
        }
        private static double Gamma(double v)
        {
            return (1 / Math.Sqrt(1 - (v * v)));
        }
        private double TiempoRelativo(double t, double v)
        {
            return t / Gamma(v);
        }
        private double MasaRelativo(int m, double v)
        {
            double masa = m * Gamma(v);
            double aux = ((masa * 100) / m) - 100;
            navespacial.Margin = new Thickness(0, aux * 1.5, 0, 0);
            return masa;
        }
        private double LargoRelativo(double L, double v)
        {
            double large = L / Gamma(v);
            navespacial.Height = (large * 100) / L;
            return large;
        }

        private void ActiveSimulacion()
        {
            if (!string.IsNullOrWhiteSpace(masa.Text) && !string.IsNullOrWhiteSpace(largeInput.Text))
            {
                masa_relative.Text = $"m = {MasaRelativo(Int32.Parse(masa.Text), velocidad.Value):F2}kg";
                large_ralative.Text = $"L = {LargoRelativo(Double.Parse(largeInput.Text), velocidad.Value):F2}m";
            }
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            tiempo = TimeSpan.Zero;
            timer.Tick += Timer_Tick;
            timer.Start();
            AnimateImage(velocidadNaveSpacial);
            textButton.Text = "Parar";
        }
        private void DesactiveSimulacion()
        {
            _active = false;
            textButton.Text = "Simular";
            tiempo = TimeSpan.Zero;
            tiempo_r = TimeSpan.Zero;
            timer.Stop();
            navespacial.RenderTransform.BeginAnimation(TranslateTransform.XProperty, null);
            //tiempo_imput.Text = tiempo.ToString(@"hh\:mm\:ss");
            //tiempo_relativo.Text = "00:00:00";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _active = !_active;
                BorderMasa.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FBFFE4"));
                BorderLarge.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FBFFE4"));
                if (string.IsNullOrWhiteSpace(masa.Text))
                {
                    BorderMasa.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                if (string.IsNullOrWhiteSpace(largeInput.Text))
                {
                    BorderLarge.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                if (!string.IsNullOrWhiteSpace(masa.Text) && !string.IsNullOrWhiteSpace(largeInput.Text)) ActiveSimulacion();

            }
            catch (Exception ex)
            {

            }
        }

        private void velocidad_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            VelocidadLuz.Text = $"{velocidad.Value:F1}c";
            velocidadNaveSpacial = 5;
            if (velocidad.Value > 0) velocidadNaveSpacial = 0.4 / velocidad.Value;
            if (!_active) return;
            if (!string.IsNullOrWhiteSpace(masa.Text) && !string.IsNullOrWhiteSpace(largeInput.Text))
            {
                masa_relative.Text = $"m = {MasaRelativo(Int32.Parse(masa.Text), velocidad.Value):F2}kg";
                large_ralative.Text = $"L = {LargoRelativo(Double.Parse(largeInput.Text), velocidad.Value):F2}m";
            }
            ActiveSimulacion();
        }
        private void FinalizarSimulacion(object sender, EventArgs e)
        {
            MessageBox.Show("La simulacion ha finalizado.");
            DesactiveSimulacion();
        }
        private void AnimateImage(double v)
        {
            
            TranslateTransform transform = new TranslateTransform();
            navespacial.RenderTransform = transform;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 690,
                Duration = TimeSpan.FromSeconds(v)
            };
            animation.Completed += FinalizarSimulacion;
            transform.BeginAnimation(TranslateTransform.XProperty, animation);
        }
    }
}
