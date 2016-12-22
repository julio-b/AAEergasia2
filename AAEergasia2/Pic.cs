using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AAEergasia2 {
    class Pic: PictureBox {
        public Pic() : base() {
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Image = new Bitmap(@"..\\..\\jinx\\top.jpg");///////
        }
        public void Open() {
            Image = null;
        }
        public void Close() {
            Image = new Bitmap(@"..\\..\\jinx\\top.jpg");
        }
        public bool Equals(Pic obj) {
            if (obj == null) return false;
            return this.BackgroundImage==obj.BackgroundImage;
        }
    }


    class Mem {
        public Pic[,] pics;
        public Pic previous = null;

        private Timer delay;
        bool waiting = false;

        public Mem(int N, int M) {

            pics = new Pic[N,M] ;
            delay = new Timer();

            delay.Interval = 1000;//1s
            delay.Tick += new EventHandler(closeDelay);

            //load images
            List<Bitmap> img = new List<Bitmap> { };
            for (int i = 0; i < 12; i++) {
                img.Add(new Bitmap(@"..\\..\\jinx\\" + i + ".png"));
                img.Add( img [img.Count - 1] );
            }
            //suffle img
            Random r = new Random();
            for (int i = 0 ; i < img.Count; i++) {
                int j = r.Next(i, img.Count);
                var t = img[i];
                img[i] = img[j];
                img[j] = t;
            }

            for (int i = 0; i < N; i++) {
                for (int j = 0; j < M; j++) {
                    pics[i, j] = new Pic();
                    pics[i, j].BackgroundImage = img[ i*M + j ];
                    pics[i, j].MouseClick += new MouseEventHandler(imageClick);
                }
            }
        }

        public void updatePositions() {
            var panelSize = pics[0, 0].Parent.Size;
            int _N = pics.GetLength(0);
            int _M = pics.GetLength(1);
            
            //fix padding
            /*
            int padding = 1;//
            int picW = panelSize.Width/_M - padding;
            int picH = panelSize.Height/_N - padding;

            for (int i = 0; i < _N; i++) {
                for (int j = 0; j < _M; j++) {
                    pics[i, j].Size = new System.Drawing.Size(picW,picH);
                    pics[i, j].Top = i * (picH+padding);
                    pics[i, j].Left = j * (picW+padding);
                }
            }
            */
            int picW = panelSize.Width / _M;
            int picH = panelSize.Height / _N;

            for (int i = 0; i < _N; i++) {
                for (int j = 0; j < _M; j++) {
                    pics[i, j].Size = new System.Drawing.Size(picW, picH);
                    pics[i, j].Top = i * picH;
                    pics[i, j].Left = j * picW;
                }
            }

        }

        public bool checkWinner() {
            foreach(var p in pics) {
                if (p.Image != null) return false;
            }
            return true;
        }

        public void imageClick(object sender, MouseEventArgs e) {
            if (waiting) return;
            var current = sender as Pic;
            if (current == previous) return;
            current.Open();
            if (previous == null) {
                previous = current;
                return;
            }
            if (!previous.Equals(current)) {
                delay.Tag = new Pic[] { previous, current };
                waiting = true;
                delay.Start();
            } else {
                if (checkWinner()) { MessageBox.Show("You Won!"); }
            }
            previous = null;
        }

        public void closeDelay(object sender, EventArgs e) {
            var p = delay.Tag as Pic[];
            p[0].Close();
            p[1].Close();
            waiting = false;
            delay.Stop();
        }

    }
}
