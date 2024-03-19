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

namespace ЛР3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public float branches(string arg)
        {
            switch (arg.Substring(0, Math.Min(1, arg.Length)))
            {
                case "+":
                    meaning = meaning + meaning_2;
                    break;
                case "-":
                    meaning = meaning - meaning_2;
                    break;
                case "*":
                    meaning = meaning * meaning_2;
                    break;
                case "/":
                    if (meaning_2 == 0)
                    {
                        break;
                    }
                    else
                    {
                        meaning = meaning / meaning_2;
                    }
                    break;
            }
            return meaning;
        }


        float meaning = 0; float meaning_2 = 0;
        int count = 0;
        bool view = true; bool view_1 = true;
        string action;
        private void Numbers(object sender, RoutedEventArgs e)
        {
            if (count == 346784)
            {
                Input_block.Text = "0"; count = 0;
            }
            // обнуление после '='
            var data = sender as Button;
            if (Input_block.Text != "0" && view == true)
            {
                Input_block.Text = Input_block.Text + data.Content.ToString();
            }
            else
            {
                if (meaning != 0 && view_1 == true)
                {
                    Input_block.Text = meaning.ToString() + " " + action + " " + data.Content.ToString();
                    view_1 = false;
                }
                else if (meaning != 0 && view_1 == false)
                {
                    Input_block.Text = Input_block.Text + data.Content.ToString();
                }
                else
                {
                    Input_block.Text = data.Content.ToString();
                    view = true;
                }
            }
            // работа с выводом
            if (count == 0)
            {
                if (meaning == 0)
                {
                    meaning = float.Parse(data.Content.ToString());
                }
                else
                {
                    meaning = float.Parse(meaning.ToString() + data.Content.ToString());
                }
            }
            else
            {
                if (meaning_2 == 0)
                {
                    meaning_2 = float.Parse(data.Content.ToString());
                }
                else
                {
                    meaning_2 = float.Parse(meaning_2.ToString() + data.Content.ToString());
                }
            }
            // работа с переменными

        }
        private void del(object sender, RoutedEventArgs e)
        {
            Input_block.Text = "0";
            Input_block_1.Items.Clear();
            meaning = 0; meaning_2 = 0; count = 0;
        }
        private void Result(object sender, RoutedEventArgs e)
        {
            if (meaning_2 == 0 && action == "/")
            {
                Input_block.Text = "Здесь вам не пределы!";
            }
            else
            {
                if (Check_box.IsChecked == false)
                {
                    Input_block_1.Items.Add(meaning.ToString() + " " + action + " " + meaning_2.ToString() + " = "
                        + branches(action).ToString());
                    Input_block.Text = meaning.ToString();
                }
                else 
                {
                    branches(action);
                    Input_block.Text = meaning.ToString();
                }
            }
            count = 346784;
            meaning = 0; meaning_2 = 0;
        }
        private void Action(object sender, RoutedEventArgs e)
        {
            var data = sender as Button;
            if (count != 0)
            {
                if (meaning_2 == 0 && action == "/")
                {
                    Input_block.Text = "Здесь вам не пределы!";
                }
                else
                {
                    if (Check_box.IsChecked == false)
                    {
                        Input_block_1.Items.Add(meaning.ToString() + " " + action + " " + meaning_2.ToString() + " = "
                                                + branches(action).ToString());
                        Input_block.Text = meaning.ToString();
                    }
                    else
                    {
                        branches(action);
                        Input_block.Text = meaning.ToString();
                    }
                }
                meaning_2 = 0;
                view = false;
                view_1 = true;
            }
            else
            {
                Input_block.Text = Input_block.Text + " " + data.Content.ToString() + " ";
            }
            action = data.Content.ToString();
            count++;
        }

        private void Full_delete(object sender, RoutedEventArgs e)
        {
            Input_block_1.Items.Clear();
        }

        private void Last_delete(object sender, RoutedEventArgs e)
        {
            int last = Input_block_1.Items.Count - 1;
            if (last > 0)
            {
                Input_block_1.Items.RemoveAt(last);
            }
        }
        
        private void Activation(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Content.ToString() == "Off")
            {
                Input_block_1.Visibility = Visibility.Hidden;
                full_del.Visibility = Visibility.Hidden; last_del.Visibility = Visibility.Hidden;
                Check_box.Visibility = Visibility.Hidden;
            }
            else
            {
                Input_block_1.Visibility = Visibility.Visible;
                full_del.Visibility = Visibility.Visible; last_del.Visibility = Visibility.Visible;
                Check_box.Visibility = Visibility.Visible;
            }
        }
    }
}