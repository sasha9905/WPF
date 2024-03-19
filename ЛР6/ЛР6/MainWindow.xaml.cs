using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace ЛР6
{

    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                mediaPlayer.Open(new Uri(openFileDialog.FileName));
                Playlist.Items.Add(new Uri(openFileDialog.FileName).ToString());
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mediaPlayer.Open(new Uri(Playlist.SelectedItem.ToString()));
            textBox.Text = Playlist.SelectedItem.ToString();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save_1 = new SaveFileDialog();
            save_1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (save_1.ShowDialog() == true)
            {
                string textout = "";
                foreach (string i in Playlist.Items)
                {
                    textout = textout + i + Environment.NewLine;
                }
                System.IO.File.WriteAllText(save_1.FileName, textout);
            }

        }

        private void Open_file(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open_1 = new OpenFileDialog();
            open_1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (open_1.ShowDialog() == true)
            {
                Playlist.Items.Clear();
                string[] textout = System.IO.File.ReadAllLines(open_1.FileName);
                foreach(string i in textout)
                {
                    Playlist.Items.Add(i);
                }
            }

        }
    }
}
