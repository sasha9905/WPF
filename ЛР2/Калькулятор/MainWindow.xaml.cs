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

namespace Калькулятор
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        float meaning = 0;
        float meaning_2 = 0;
        int count = 0;
        bool view = true;
        bool view_1 = true;
        string action;

        private void Numbers(object sender, RoutedEventArgs e)
        {
            if (count == 346784)
            {
                Input_block.Text = "0"; count = 0;
            }
            //  обнуление после '='
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
            meaning = 0; meaning_2 = 0; count = 0;
        }

        private void Result(object sender, RoutedEventArgs e)
        {
            Input_block.Text = meaning.ToString();
            switch(action.Substring(0, Math.Min(1, action.Length)))
            {
                case "+":
                    Input_block.Text = (meaning + meaning_2).ToString();
                    break; 
                case "-":
                    Input_block.Text = (meaning - meaning_2).ToString();
                    break;
                case "*":
                    Input_block.Text = (meaning * meaning_2).ToString();
                    break;
                case "/":
                    if (meaning_2 == 0)
                    {
                        Input_block.Text = "Здесь вам не пределы!";
                    }
                    else
                    {
                        Input_block.Text = (meaning / meaning_2).ToString();                 
                    }
                    break;
            }
            count = 346784;
            meaning = 0; meaning_2 = 0;
        }

        private void Action(object sender, RoutedEventArgs e)
        {
            var data = sender as Button;
            if (count != 0)
            {
                switch (action.Substring(0, Math.Min(1, action.Length)))
                {
                    case "+":
                        Input_block.Text = Input_block.Text + " = " +(meaning + meaning_2).ToString();
                        meaning = meaning + meaning_2;
                        meaning_2 = 0;
                        break;
                    case "-":
                        Input_block.Text = Input_block.Text + " = " + (meaning - meaning_2).ToString();
                        meaning = meaning - meaning_2;
                        meaning_2 = 0;
                        break;
                    case "*":
                        Input_block.Text = Input_block.Text + " = " + (meaning * meaning_2).ToString();
                        meaning = meaning * meaning_2;
                        meaning_2 = 0;
                        break;
                    case "/":
                        if (meaning_2 == 0)
                        {
                            Input_block.Text = "Здесь вам не пределы!";
                        }
                        else
                        {
                            Input_block.Text = Input_block.Text + " = " + (meaning / meaning_2).ToString();
                            meaning = meaning / meaning_2;
                            meaning_2 = 0;
                        }
                        break;
                }
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
    }
}
