using System; 
 using System.Collections.Generic; 
using System.Linq; 
 using System.Text; 
 using System.Threading; 
 using System.Windows; 
 using System.Windows.Controls; 
 using System.Windows.Data; 
 using System.Windows.Documents; 
 using System.Windows.Input; 
 using System.Windows.Media; 
 using System.Windows.Media.Imaging; 
 using System.Windows.Navigation; 
 using System.Windows.Shapes; 
 using System.Threading.Tasks;

namespace AlarmTimer
{
    /// <summary> 
    /// Interaction logic for MainWindow.xaml 
    /// </summary> 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            ButtonStart.IsEnabled = false;
            Slider_Duration.IsEnabled = false;


            TimeSpan duration = TimeSpan.FromSeconds(this.Slider_Duration.Value);


            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += timer_Tick;


            LabelCountdown.Content = Convert.ToInt32(duration.TotalSeconds);


            try
            {
                await StartTimerAsync(duration);
            }
            finally
            {
                timer.Stop();
                ButtonStart.IsEnabled = true;
                Slider_Duration.IsEnabled = true;
                LabelCountdown.Content = 0;
            }
        }


        void timer_Tick(object sender, EventArgs e)
        {
            LabelCountdown.Content = ((int)LabelCountdown.Content-1);
        }


        private async Task StartTimerAsync(TimeSpan timerDuration)
        {
            await Task.Delay(timerDuration);


            System.Windows.MessageBox.Show("Timer expired!");
        }
    }
}