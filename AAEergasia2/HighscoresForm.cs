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
        public HighscoresForm(Highscores hs) {
            InitializeComponent();
            this.hs = hs;
            showTop10();
        }

        public HighscoresForm(Highscores hs, int score, int time):this(hs) {
            this.score = score;
            this.time = time;
            nameTextBox.Visible = true;
            insertScoreBtn.Visible = true;
        }

        private void insertScoreBtn_Click(object sender, EventArgs e) {
            if (nameTextBox.Text == "") return;
            hs.InsertScore(nameTextBox.Text, score, time);
            nameTextBox.Visible = false;
            insertScoreBtn.Visible = false;
            showTop10();
        }

        private void showTop10() {
            var top10 = hs.GetTopTimes();//GetTopScores();
            topTenRichTxt.Text = "#. Name\t\tScore\tTime\n";///dlt
            dataGridView1.Rows.Clear();
            int i = 0;
            while (top10.Read() && i++ < 10) {
                topTenRichTxt.Text += i.ToString() +". " + top10["name"] +"\t\t"+ top10["score"]+"\t"+top10["time"]+"\n";///dlt
                dataGridView1.Rows.Add(new object[] { top10["name"], top10["score"], top10["time"] });
            }
        }

        private void reset_Click(object sender, EventArgs e) {
            hs.ClearDb();
            showTop10();
        }
    }
}
