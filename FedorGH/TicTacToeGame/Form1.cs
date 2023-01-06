using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeGame
{
    public partial class КрестикиНолики : Form
    {
        Button[] buttons;
        bool X_or_O = true;
        int min = 0;
        int sec = 0;
        Timer tick = new Timer();

        public КрестикиНолики()
        {
            InitializeComponent();
            restart.Enabled = false;
            start.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e) // Действия которые происходят с каждым нажатием
        {
            buttons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            Button currentButton = (Button)sender;
            if (X_or_O == true && currentButton.Text == "")
            {
                whoseMove.Text = "нолик";
                currentButton.Text = "X";
                X_or_O = !X_or_O;
            }
            else if (X_or_O == false && currentButton.Text == "")
            {
                whoseMove.Text = "крестик";
                currentButton.Text = "O";
                X_or_O = !X_or_O;
            }

            string whoWinner = X_or_O == false ? "крестиков" : "ноликов";

            if (CheckForWin(0, 3, 6) == 1 || CheckForWin(1, 4, 7) == 1 || CheckForWin(2, 5, 8) == 1 || CheckForWin(0, 1, 2) == 1 || CheckForWin(3, 4, 5) == 1 || CheckForWin(6, 7, 8) == 1 || CheckForWin(0, 4, 8) == 1 || CheckForWin(2, 4, 6) == 1)
            {
                StopGame();
                MessageBox.Show($"Победа {whoWinner}");
            }
            else if (CheckForDraw() == 9)
            {
                StopGame();
                MessageBox.Show("Ничья");
            }
        
        }

        private void timer1_Tick(object sender, EventArgs e) // Логика секундомера
        {
            if (sec != 59)
                sec++;
            else
            {
                sec = 0;
                min++;
            }

            label3.Text = $"{String.Format("{0:00}", min)}:{String.Format("{0:00}", sec)}";
        }

        private void start_Click(object sender, EventArgs e) // Что происходит при нажатии кнопки "начать"
        {
            groupBox1.Enabled = true;
            restart.Enabled = true;
            tick.Interval = 1000;
            tick.Tick += timer1_Tick;
            tick.Start();
            start.Enabled = false;
        }

        private void restart_Click_1(object sender, EventArgs e) // Что происходит при нажатии кнопки "заново"
        {
            Application.Restart();
        }

        private void StopGame() // Что происходит когда игра завершилась
        {
            label1.Text = $"Игра окончена за {min} мин. {sec} сек.";
            whoseMove.Text = "";
            tick.Stop();
            groupBox1.Enabled = false;
        }

        private int CheckForWin(int indexFirstButton, int indexSecondButton, int indexThirdButton) // Проверка на победу
        {
            int s = 0;
            if(buttons[indexFirstButton].Text == buttons[indexSecondButton].Text && buttons[indexSecondButton].Text == buttons[indexThirdButton].Text && buttons[indexFirstButton].Text !="")
                s++;
            return s;
        }
        private int CheckForDraw() // Проверка на ничью
        {
            int s = 0;
            for (int i = 0; i < 9; i++)
            {
                if (buttons[i].Text != "")
                    s++;
            }
            return s;
        }
    }
}
