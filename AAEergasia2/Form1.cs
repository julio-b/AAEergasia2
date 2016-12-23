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

        public Form1() {
            InitializeComponent();
            startNewGame();
        }

        private void startNewGame() {
            game = new Mem(4, 6);
            foreach (var i in game.pics) { GamePanel.Controls.Add(i); }
            PerformLayout();
            game.updatePositions();
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            game.updatePositions();
        }
    }


}
