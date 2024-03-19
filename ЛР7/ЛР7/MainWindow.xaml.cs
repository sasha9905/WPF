using System.Windows;
using System.Windows.Media;
using System.Speech.Synthesis;
using Microsoft.Win32;
using System.Windows.Controls;

namespace ЛР7
{
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        PromptBuilder promptBuilder = new PromptBuilder();

        PromptRate promptRate = PromptRate.Medium;
        PromptVolume promptVolume = PromptVolume.Default;

        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void downloading(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "WAV files (*.wav)|*.wav|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                mediaPlayer.Open(new System.Uri(openFileDialog.FileName));
            }
            mediaPlayer.Play();
        }

        private void Btn_Say_Click(object sender, RoutedEventArgs e)
        {
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            PromptStyle promptStyle = new PromptStyle
            {
                Volume = promptVolume,
				Rate = promptRate
            };

            promptBuilder.StartStyle(promptStyle);
            promptBuilder.AppendText(Box_Input.Text);
            promptBuilder.EndStyle();

            speechSynthesizer.Speak(promptBuilder);
          
            promptBuilder.ClearContent();
            speechSynthesizer.Dispose();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();

            promptBuilder.AppendText(Box_Input.Text);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "WAV files (*.wav)|*.wav|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                speechSynthesizer.SetOutputToWaveFile(saveFileDialog.FileName);
            }
            speechSynthesizer.Speak(promptBuilder);

            speechSynthesizer.Dispose();
            promptBuilder.ClearContent();
        }

        private void Btn_Say_File_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Box_Input.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void Speed_change(object sender, SelectionChangedEventArgs e)
        {
            switch(speed.SelectedIndex)
            {
                case 0:
                    promptRate = PromptRate.NotSet; break;
                case 1:
                    promptRate = PromptRate.ExtraSlow; break;
                case 2:
                    promptRate = PromptRate.Slow; break;
                case 3:
                    promptRate = PromptRate.Medium; break;
                case 4:
                    promptRate = PromptRate.Fast; break;
                case 5:
                    promptRate = PromptRate.ExtraFast; break;
                default:
                    break;
            }
        }

        private void Volume_change(object sender, SelectionChangedEventArgs e)
        {
            switch(volume.SelectedIndex)
            {
                case 0:
                    promptVolume = PromptVolume.Default; break;
                case 1:
                    promptVolume = PromptVolume.ExtraSoft; break;
                case 2:
                    promptVolume = PromptVolume.Soft; break;
                case 3:
                    promptVolume = PromptVolume.Medium; break;
                case 4:
                    promptVolume = PromptVolume.Loud; break;
                case 5:
                    promptVolume = PromptVolume.ExtraLoud; break;
                default:
                    break;
            }
        }
    }
}
