using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        bool a = true;
        int min = 0;
        int sec = 0;
        Timer tick = new Timer();

        public Form1()
        {
            InitializeComponent();
            restart.Enabled = false;
            start.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            if (a == true && currentButton.Text == "")
            {
                label2.Text = "нолик";
                currentButton.Text = "X";
                a = !a;
            }
            else if (a == false && currentButton.Text == "")
            {
                label2.Text = "крестик";
                currentButton.Text = "O";
                a = !a;
            }

            string whoWinner = a == false ? "крестиков" : "ноликов";

            if ((button1.Text == button4.Text && button4.Text == button7.Text && button1.Text != "") ||
                (button2.Text == button5.Text && button5.Text == button8.Text && button2.Text != "") ||
                (button3.Text == button6.Text && button6.Text == button9.Text && button3.Text != "") ||
                (button1.Text == button2.Text && button2.Text == button3.Text && button1.Text != "") ||
                (button4.Text == button5.Text && button5.Text == button6.Text && button4.Text != "") ||
                (button7.Text == button8.Text && button8.Text == button9.Text && button7.Text != "") ||
                (button1.Text == button5.Text && button5.Text == button9.Text && button1.Text != "") ||
                (button3.Text == button5.Text && button5.Text == button7.Text && button3.Text != ""))
            {
                StopGame();
                MessageBox.Show($"Победа {whoWinner}");
            }
            else if(button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "")
            {
                StopGame();
                MessageBox.Show("Ничья");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
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

        private void start_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            restart.Enabled = true;
            tick.Interval = 1000;
            tick.Tick += timer1_Tick;
            tick.Start();
            start.Enabled = false;
        }

        private void restart_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void StopGame()
        {
            label1.Text = $"Игра окончена за {min} мин. {sec} сек.";
            label2.Text = "";
            tick.Stop();
            groupBox1.Enabled = false;
        }
    }
}
