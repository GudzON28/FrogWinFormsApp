using System;
using System.Windows.Forms;

namespace FrogWinFormsApp
{
    public partial class MainForm : Form
    {
        private int stepCount = 0;
        private int center;

        private void MainForm_Shown(object sender, EventArgs e)
        {
            center = emptyPictureBox.Location.X;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
        }

        private void Swap(PictureBox sender)
        {
            var distance = Math.Abs(sender.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;

            if (distance > 2)
            {
                MessageBox.Show("Недопустимый ход!\r\nВозможен ход либо на соседнюю кувшинку, либо через одну.");
                return;
            }

            var oldLocation = sender.Location;
            sender.Location = emptyPictureBox.Location;
            emptyPictureBox.Location = oldLocation;

            stepCount++;
            scoreCountLabel.Text = stepCount.ToString();

            var leftSide = emptyPictureBox.Size.Width * 3;

            if (sender.Location.X <= leftSide)
            {
                sender.Tag = Side.Left;
            }
            else
            {
                sender.Tag = Side.Right;
            }

            if (EndGame())
            {
                var winnerForm = new WinnerForm(stepCount);

                if (winnerForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Restart();
                }
                else
                {
                    Close();
                }
            }
        }

        private bool EndGame()
        {
            if (rightPictureBox4.Tag.ToString() == Side.Left.ToString() && rightPictureBox3.Tag.ToString() == Side.Left.ToString() &&
                rightPictureBox2.Tag.ToString() == Side.Left.ToString() && rightPictureBox1.Tag.ToString() == Side.Left.ToString() &&
                center == emptyPictureBox.Location.X)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void RulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Цель игры — расположить лягушек, которые смотрят влево, в левую часть, а остальных - в правую часть за минимальное количество ходов.\r\n\r\n" +
                "Прыгать можно на листок, если он находится рядом или через 1 лягушку.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}