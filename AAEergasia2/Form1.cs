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
        private Mem game;
        HighscoresForm f;
        int clicks;
        int seconds;

        public Form1() {
            InitializeComponent();
            startNewGame();
            timer.Start();
        }

        private void startNewGame() {
            game = new Mem(2, 2);//(4,6)
            game.clickHandlers = new WrongClickHandler(wrongClick);
            game.winHandlers = new WinHandler(gameWon);
            foreach (var i in game.pics)
                GamePanel.Controls.Add(i);
            game.reset();
            PerformLayout();
            game.updatePositions();
        }

        private void gameWon()
        {
            if (f != null) f.Close();
            f = new HighscoresForm(clicks, seconds);
            f.Show();
            timer.Stop();
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
            timer.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

    }


}
