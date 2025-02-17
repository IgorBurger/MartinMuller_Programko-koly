using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Drawing;
using System.Windows.Media;
using Piškvorky;

namespace WtfApp
{
    internal class ViewModel
    {
        TextBlock WinMessage;
        //string[,] gameBoardString;
        public ViewModel(TextBlock win) 
        {
            WinMessage = win;
            //gameBoardString = new string[3, 3];
        }

        Button[,] buttons;


        char PlayerChar = 'X';
        public Button[,] GenerateButtons(Grid gameBoard)
        {
            buttons = new Button[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button();
                    button.Click += ButtonClicked;
                    button.FontSize = 100;
                    // Nastavení pozice v Gridu
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    button.Tag = i + " " + j;

                    // Přidání tlačítka do Gridu
                    gameBoard.Children.Add(button);

                    // Přidání tlačítka do pole tlačítek
                    buttons[i, j] = button;
                }
            }
            return buttons;
        }
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Model model = new Model();
            Button pressedButton = ((Button)sender);
            //string[] ButtonPos = pressedButton.Tag.ToString().Split(" ");

            




            if (pressedButton.Content == null)
            {
                pressedButton.Content = PlayerChar;
                switch (pressedButton.Content)
                {
                    case 'X':
                        if (model.CheckWin(buttons)) 
                        {
                            WinMessage.Text = "Hráč X vyhrál!";
                            WinMessage.Visibility = Visibility.Visible;
                        }

                        PlayerChar = 'O';
                        break;
                    case 'O':
                        if (model.CheckWin(buttons))
                        {
                            WinMessage.Text = "Hráč O vyhrál!";
                            WinMessage.Visibility = Visibility.Visible;
                        }

                        PlayerChar = 'X';
                        break;
                }
            }

            //MessageBox.Show("Tlačítko kliknuto");
        }
    }
}