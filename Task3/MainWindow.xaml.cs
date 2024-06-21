using System.Media;
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

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SoundPlayer player = new();

        public MainWindow()
        {
            InitializeComponent();
            mediaElement.Source = new Uri("video1.mp4", UriKind.Relative); 
        }

        private void FileSoundButton_Click(object sender, RoutedEventArgs e)
        {
                player.SoundLocation = "sound.wav"; 
                player.Load();
                player.Play();
        }

        private void SystemSoundButton_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = TimeSpan.FromSeconds(0);
            mediaElement.Play();
        }
    }
}