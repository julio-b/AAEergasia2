using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AAEergasia2 {
    public delegate void WrongClickHandler();
    public delegate void WinHandler();

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
        public WrongClickHandler clickHandlers;
        public WinHandler winHandlers;
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

            for (int i = 0; i < N; i++) {
                for (int j = 0; j < M; j++) {
                    pics[i, j] = new Pic();
                    pics[i, j].BackgroundImage = img[ i*M + j ];
                }
            }
           
        }

        public void reset()
        {
            foreach (Pic p in pics)
            {
                p.Close();
                p.MouseClick += new MouseEventHandler(imageClick);
                p.MouseEnter += new EventHandler(mouseEnter);
                p.MouseLeave += new EventHandler(mouseLeave);
            }
            //shuffle pics[,]
            int N = pics.GetLength(0);
            int M = pics.GetLength(1);
            Random r = new Random();
            for (int i = 0; i < N * M; i++)
            {
                int j = r.Next(i, N * M);
                Pic temp = pics[i / M, i % M];
                pics[i / M, i % M] = pics[j / M, j % M];
                pics[j / M, j % M] = temp;
            }
            updatePositions();
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
            if (!previous.Equals(current)) {
                delay.Tag = new Pic[] { previous, current };
                waiting = true;
                delay.Start();
                if (clickHandlers != null)
                    clickHandlers(); //fire up events
            } else {
                current.MouseClick -= imageClick;
                current.MouseEnter -= mouseEnter;
                current.MouseLeave -= mouseLeave;
                mouseLeave(current, null);
                previous.MouseClick -= imageClick;
                previous.MouseEnter -= mouseEnter;
                previous.MouseLeave -= mouseLeave;
                if (checkWinner() && winHandlers != null)
                    winHandlers(); //fire up events
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
            pic.BringToFront(); //panw apo ta diplana tou
        }

        private void mouseLeave(object sender, EventArgs e)
        {
            Pic pic = (Pic)sender;
            pic.Width -= scaleX;
            pic.Height -= scaleY;
            
        }

    }
}
