using Microsoft.Win32;
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

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isWindowLoaded = false;
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            isWindowLoaded = true;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri imageUri = new Uri(openFileDialog.FileName);
                BitmapImage bitmapImage = new BitmapImage(imageUri);
                inkCanvas.Background = new ImageBrush(bitmapImage);
            }
        }

        private void InkCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorComboBox.Text);
            inkCanvas.DefaultDrawingAttributes.Width = penSizeSlider.Value;
            inkCanvas.DefaultDrawingAttributes.Height = penSizeSlider.Value;
        }
    }
}