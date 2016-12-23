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
        private int score;
        private Highscores hs;
        public HighscoresForm(Highscores hs) {
            InitializeComponent();
            this.hs = hs;
            showTop10();
        }

        public HighscoresForm(Highscores hs, int score):this(hs) {
            this.score = score;//
            nameTextBox.Visible = true;
            insertScoreBtn.Visible = true;
        }

        private void insertScoreBtn_Click(object sender, EventArgs e) {
            if (nameTextBox.Text == "") return;
            hs.InsertScore(nameTextBox.Text, score);
            nameTextBox.Visible = false;
            insertScoreBtn.Visible = false;
            showTop10();
        }

        private void showTop10() {
            var top10 = hs.GetTopScores();
            topTenRichTxt.Text = "#. Name\tScore\n";
            int i = 0;
            while (top10.Read() && i++ < 10) {
                topTenRichTxt.Text += i.ToString() +". " + top10["name"] +"\t"+ top10["score"]+"\n";
            }
        }
    }
}
