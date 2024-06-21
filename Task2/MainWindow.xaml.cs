using System.IO;
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
using System.Windows.Threading;
using System;
using Microsoft.Win32;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] imageFiles;
        private int currentIndex = 0;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectPathButton_Click(object sender, RoutedEventArgs e)
        {
            string path = "";
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            if (openFolderDialog.ShowDialog() == true)
            {
                path = openFolderDialog.FolderName;
            }

            if (Directory.Exists(path))
            {
                imageFiles = Directory.GetFiles(path,"*.jpg");

                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(0.3);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            else
                MessageBox.Show("Папка не найдена, попробуйте снова");
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (imageFiles.Length == 0) return;

            var bitmap = new BitmapImage(new Uri(imageFiles[currentIndex], UriKind.Absolute));
            imageCarousel.Source = bitmap;

            currentIndex++;
            if (currentIndex >= imageFiles.Length)
            {
                currentIndex = 0; // Начать сначала, если достигнут конец массива
            }
        }
    }
}