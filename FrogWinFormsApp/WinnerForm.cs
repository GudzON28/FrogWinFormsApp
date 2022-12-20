using System;
using System.Windows.Forms;

namespace FrogWinFormsApp
{
    public partial class WinnerForm : Form
    {
        private int finalScore = 0;
        private int bestScore = 24;

        public WinnerForm(int finalScore)
        {
            InitializeComponent();
            this.finalScore = finalScore;
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WinnerForm_Shown(object sender, EventArgs e)
        {
            countStepLabel.Text = finalScore.ToString();
            countToBestResultLabel.Text = (finalScore - bestScore).ToString();
        }
    }
}
