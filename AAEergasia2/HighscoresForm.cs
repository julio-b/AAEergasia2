using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAEergasia2 {
    public partial class HighscoresForm : Form {
        private Highscores hs;
        private int score;
        private int time;

        public HighscoresForm() {
            InitializeComponent();
            hs = new Highscores();
            showTop10();
        }

        public HighscoresForm(int score, int time):this() {
            this.score = score;
            this.time = time;
            nameTextBox.Enabled = true;
            insertScoreBtn.Enabled = true;
        }

        private void insertScoreBtn_Click(object sender, EventArgs e) {
            if (nameTextBox.Text == "") return;
            hs.InsertScore(nameTextBox.Text, score, time);
            nameTextBox.Enabled = false;
            insertScoreBtn.Enabled = false;
            showTop10();
        }

        private void showTop10() {
            var top10 = hs.GetTopTimes();//GetTopScores();
            dataGridView1.Rows.Clear();
            while (top10.Read()) {
                dataGridView1.Rows.Add(new object[] {
                    top10["name"],
                    top10["score"],
                    String.Format(@"{0:D2}:{1:D2}", (int)top10["time"] / 60, (int)top10["time"] % 60)
                });
            }
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            if (nameTextBox.ForeColor == Color.DarkGray)
            {
                nameTextBox.Clear();
                nameTextBox.ForeColor = Color.Black;
            }
        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "")
            {
                nameTextBox.Text = "<Your Name>";
                nameTextBox.ForeColor = Color.DarkGray;
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            showTop10();
        }

        private void HighscoresForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            hs.Close();
        }
    }
}
