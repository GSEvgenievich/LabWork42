﻿using Microsoft.Win32;
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

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.01);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (mediaElement.Source != null && mediaElement.NaturalDuration.HasTimeSpan)
            {
                TimeSpan ts = mediaElement.NaturalDuration.TimeSpan;
                timeLabel.Content = String.Format("{0:hh\\:mm\\:ss} / {1:hh\\:mm\\:ss}", mediaElement.Position, ts);
            }
            else
            {
                timeLabel.Content = "00:00:00";
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            mediaElement.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            mediaElement.Pause();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timeLabel.Content = "00:00:00";
            mediaElement.Stop();
            mediaElement.Source = null;
        }

        private void OpenNewVideo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files|*.mp3;*.mp4;*.avi;*.wav|All files|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                mediaElement.Source = new Uri(openFileDialog.FileName);
                mediaElement.LoadedBehavior = MediaState.Manual;
                mediaElement.UnloadedBehavior = MediaState.Stop;
            }
        }
    }
}