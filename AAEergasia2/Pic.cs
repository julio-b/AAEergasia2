using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AAEergasia2 {

    class Pic: PictureBox {
        Bitmap topImage = new Bitmap(@"..\..\jinx\top.jpg");

        public Pic() : base() {
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch; //kanei thn eikona na einai oso einai to picturebox
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Image = topImage;
            Cursor = Cursors.Hand;
        }
        public void Open() {
            Image = null;
        }
        public void Close() {
            Image = topImage;
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

        int scaleX, scaleY;

        public Mem(int N, int M) {

            pics = new Pic[N,M] ;
            delay = new Timer();

            delay.Interval = 1000;//1s
            delay.Tick += new EventHandler(closeDelay);

            //load images
            List<Bitmap> img = new List<Bitmap>();
            for (int i = 0; i < N*M; i+=2) {
                Bitmap bmp = new Bitmap(@"..\..\jinx\" + i / 2 + ".png");
                img.Add(bmp);
                img.Add(bmp);
            }
            
            //shuffle img
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
                    pics[i, j].MouseEnter += new EventHandler(mouseEnter);
                    pics[i, j].MouseLeave += new EventHandler(mouseLeave);
                }
            }
        }

        public void updatePositions() {
            var panelSize = pics[0, 0].Parent.Size;
            int _N = pics.GetLength(0);
            int _M = pics.GetLength(1);

            int picW = panelSize.Width / _M;
            int picH = panelSize.Height / _N;

            for (int i = 0; i < _N; i++) {
                for (int j = 0; j < _M; j++) {
                    pics[i, j].Size = new System.Drawing.Size(picW, picH);
                    pics[i, j].Top = i * picH;
                    pics[i, j].Left = j * picW;
                }
            }

            scaleX = pics[0, 0].Width / 10;
            scaleY = pics[0, 0].Height / 10;
        }

        public bool checkWinner() {
            foreach(var p in pics) {
                if (p.Image != null) //an yparxei estw ena kleisto
                    return false;
            }
            return true;
        }

        public void imageClick(object sender, MouseEventArgs e) {
            if (waiting) return;
            var current = sender as Pic;
            if (current == previous) return;
            current.Open();
            if (previous == null) { //prwto klik
                previous = current;
                return;
            }
            MessageBox.Show(previous.Equals(current).ToString());
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

        private void mouseEnter(object sender, EventArgs e)
        {
            Pic pic = (Pic)sender;
            pic.Width += scaleX;
            pic.Height += scaleY;
        }

        private void mouseLeave(object sender, EventArgs e)
        {
            Pic pic = (Pic)sender;
            pic.Width -= scaleX;
            pic.Height -= scaleY;
        }

    }
}
