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

    public partial class Form1 : Form {
        private const int N = 4;
        private const int M = 6;

        private Mem game;
        HighscoresForm f;
        int clicks;
        int seconds;

        public Form1() {
            InitializeComponent();
            startNewGame();
        }

        private void startNewGame() {
            game = new Mem(N, M, new MouseEventHandler(startT));// check if (N*M)%2==0
            game.clickHandlers = new WrongClickHandler(wrongClick);
            game.winHandlers = new WinHandler(gameWon);
            foreach (var i in game.pics)
                GamePanel.Controls.Add(i);
            game.reset();
            PerformLayout();
            game.updatePositions();
            timer.Tag = false;
        }

        private void gameWon()
        {
            if (f != null) f.Close();
            f = new HighscoresForm(clicks, seconds);
            f.Show();
            timer.Stop();
            timer.Tag = true;
            label3.Visible = true;
        }

        private void wrongClick()
        {
            clicks++;
            LClicks.Text = clicks.ToString();
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            game.updatePositions();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            seconds += timer.Interval/1000;
            LTime.Text = String.Format(@"{0:D2}:{1:D2}", seconds/60, seconds%60);
        }

        private void highscoresToolStripMenuItem_Click(object sender, EventArgs e) {
            if (f != null) f.Close();
            f = new HighscoresForm();
            f.Show();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.reset();
            clicks = 0;
            seconds = 0;
            LClicks.Text = "0";
            LTime.Text = "00:00";
            timer.Tag = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void loadPicturesToolStripMenuItem_Click(object sender, EventArgs e) {
            openFileDialog1.Title = "Select " + (N * M / 2) + " pictures";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(openFileDialog1.FileNames.Length < N * M / 2)
                {
                    MessageBox.Show("Please give "+(N*M/2)+" pictures or more.", "Warning");
                }
                else
                {
                    game.loadImages(openFileDialog1.FileNames);
                    resetToolStripMenuItem_Click(null, null);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string about = "Created by:\n";
            about += "\tΓιώργος\n";
            about += "\tΘεοφάνης\n";
            about += "\tΤζούλιο\n";
            MessageBox.Show(about, "About");
        }

        private void startT(object sender, MouseEventArgs e) {
            if ((bool)timer.Tag == true) { resetToolStripMenuItem_Click(null, null); return; }
            if (label3.Visible == true)  label3.Visible = false; 
            if (!timer.Enabled)  timer.Start(); 
        }
    }


}
