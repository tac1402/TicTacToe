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
        string seconds = "";

        Timer tick = new Timer();
        public Form1()
        {
            InitializeComponent();
            restart.Enabled = false;
            start.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (a == true && ((Button)sender).Text == "")
            {
                label2.Text = "нолик";
                sender.GetType().GetProperty("Text").SetValue(sender, "X");
                a = !a;
            }
            else if (a == false && ((Button)sender).Text == "")
            {
                label2.Text = "крестик";
                sender.GetType().GetProperty("Text").SetValue(sender, "O");
                a = !a;
            }

            string answer = a == false ? "крестиков" : "ноликов";

            if (((button1.Text == button4.Text && button4.Text == button7.Text) && button1.Text != "") ||
                ((button2.Text == button5.Text && button5.Text == button8.Text) && button2.Text != "") ||
                ((button3.Text == button6.Text && button6.Text == button9.Text) && button3.Text != "") ||
                ((button1.Text == button2.Text && button2.Text == button3.Text) && button1.Text != "") ||
                ((button4.Text == button5.Text && button5.Text == button6.Text) && button4.Text != "") ||
                ((button7.Text == button8.Text && button8.Text == button9.Text) && button7.Text != "") ||
                ((button1.Text == button5.Text && button5.Text == button9.Text) && button1.Text != "") ||
                ((button3.Text == button5.Text && button5.Text == button7.Text) && button3.Text != ""))
            {
                label1.Text = $"Игра окончена за {min} мин. {sec} сек.";
                label2.Text = "";
                tick.Stop();
                groupBox1.Enabled = false;
                MessageBox.Show($"Победа {answer}");
            }
            else if(button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "")
            {
                label1.Text = $"Игра окончена за {min} мин. {sec} сек.";
                label2.Text = "";
                tick.Stop();
                groupBox1.Enabled = false;
                MessageBox.Show("Ничья");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec != 60)
            {
                seconds = sec.ToString().Length == 1 ? seconds = $"0{sec}" : seconds = $"{sec}";
            }
            else
            {
                sec = 0;
                seconds = "00";
                min++;
            }

            label3.Text = $"0{min}:{seconds}";

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
    }
}
