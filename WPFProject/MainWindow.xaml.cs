using Microsoft.Win32;
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
using System.Windows.Threading;

namespace WPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer aPlayer = new MediaPlayer();
        int flag = 0;
        int volflag = 0;
        double old = 0;
        DispatcherTimer timer;

        List<Uri> audios = new List<Uri>();
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timer_tick);
            aPlayer.MediaEnded += APlayer_MediaEnded;
            aPlayer.MediaOpened += APlayer_MediaOpened;
            slidervol.Value = 1;
        }

        private void APlayer_MediaOpened(object sender, EventArgs e)
        {
            label_e.Content = aPlayer.NaturalDuration.TimeSpan;
            sliderprog.Maximum = aPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            Mainwindow.Title = aPlayer.Source.OriginalString.Split('\\')[aPlayer.Source.OriginalString.Split('\\').Count() - 1];
            timer.Start();
            flag = 1;
        }

        private void APlayer_MediaEnded(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex < audios.Count - 1)
            {
                aPlayer.Open(audios[listBox.SelectedIndex + 1]);
                aPlayer.Play();
                listBox.SelectedIndex = listBox.SelectedIndex + 1;
            }
            else
            {
                aPlayer.Open(audios[0]);
                aPlayer.Play();
                listBox.SelectedIndex = 0;
            }
        }

        private void timer_tick(object sender, EventArgs e)
        {
            sliderprog.Value = aPlayer.Position.TotalSeconds;
            if (aPlayer.Source != null)
            {
                if (aPlayer.NaturalDuration.HasTimeSpan)
                {
                    label_e.Content = String.Format("{0} / {1}", aPlayer.Position.ToString(@"mm\:ss"), aPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                }
            }
            else
                label_e.Content = "00:00:00";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == true)
            {
                aPlayer.Open(new Uri(openFileDialog1.FileName));
                aPlayer.Play();
                play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/pause.jpg")));
                TaskbarItemInfo.ThumbButtonInfos[0].ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/pause.jpg"));
                listBox.Items.Add(openFileDialog1.SafeFileName);
                audios.Add(new Uri(openFileDialog1.FileName));
                listBox.SelectedItem = openFileDialog1.SafeFileName;
            }
        }
        void PlayCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            if (audios.Count > 0)
            {
                if (flag == 0)
                {
                    aPlayer.Play();
                    flag = 1;
                    play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/pause.jpg")));
                    TaskbarItemInfo.ThumbButtonInfos[0].ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/pause.jpg"));
                }
                else
                {
                    aPlayer.Pause();
                    flag = 0;
                    play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/play-button.png")));
                    TaskbarItemInfo.ThumbButtonInfos[0].ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/play-button.png"));
                }
            }
        }

        private void fast_Click(object sender, RoutedEventArgs e)
        {
            aPlayer.SpeedRatio += 0.1;
        }

        private void slow_Click(object sender, RoutedEventArgs e)
        {
            if (aPlayer.SpeedRatio > 1)
                aPlayer.SpeedRatio -= 0.1;
        }

        private void rewind_Click(object sender, RoutedEventArgs e)
        {
            aPlayer.Stop();
            aPlayer.Play();
            play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/pause.jpg")));
            TaskbarItemInfo.ThumbButtonInfos[0].ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/pause.jpg"));
        }

        private void slidervol_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            aPlayer.Volume = (double)slidervol.Value;
            if (slidervol.Value > 0)
            {
                button_vol.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/vol.png")));
            }
            else
                button_vol.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/mute.jpg")));

        }

        private void sliderprog_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            aPlayer.Position = TimeSpan.FromSeconds(sliderprog.Value);
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == true)
            {
                foreach (var item in openFileDialog1.FileNames)
                {
                    listBox.Items.Add(item.Split('\\')[item.Split('\\').Count() - 1]);
                    audios.Add(new Uri(item));
                }
            }
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                aPlayer.Open(audios[listBox.SelectedIndex]);
                aPlayer.Play();
                play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/pause.jpg")));
                TaskbarItemInfo.ThumbButtonInfos[0].ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/pause.jpg"));
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (volflag == 0)
            {
                old = slidervol.Value;
                slidervol.Value = slidervol.Minimum;
                volflag = 1;
                button_vol.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/mute.jpg")));
            }
            else
            {
                slidervol.Value = old;
                volflag = 0;
                button_vol.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/vol.png")));
            }
        }
    }
}
