using System;
using System.Drawing;
using System.Windows.Forms;


namespace Game_of_life
{
    public partial class GameOfLIfe : Form
    {
        Graphics gr;
        int resolution;
        bool[,] deadOrAlive;
        int nOfcols;
        int nOfrows;
        int curGen;
        string universeFormat;
        int x, y;
        public GameOfLIfe()
        {
            InitializeComponent();
        }
        void StartParam()
        {
            resolution = (int)NUDresolution.Value;
            nOfcols = pictureBox1.Width / resolution;
            nOfrows = pictureBox1.Height / resolution;
            deadOrAlive = new bool[nOfcols, nOfrows];
            universeFormat = DUDuniverseFormat.Text;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(pictureBox1.Image);
        }
        void NextGen()
        {
            gr.Clear(Color.Black);
            bool[,] newDeadOrAlive = new bool[nOfcols, nOfrows];
            for (int i = 0; i < deadOrAlive.GetLength(0); i++)
            {
                for (int j = 0; j < deadOrAlive.GetLength(1); j++)
                {
                    int n = nOfNeighbours(i, j);
                    bool alive = deadOrAlive[i, j];

                    if (!alive && n == 3)
                    {
                        newDeadOrAlive[i, j] = true;
                    }
                    else if (alive && (n < 2 || n > 3))
                    {
                        newDeadOrAlive[i, j] = false;
                    }
                    else
                    {
                        newDeadOrAlive[i, j] = deadOrAlive[i, j];
                    }
                    if (alive)
                    {
                        gr.FillEllipse(Brushes.SpringGreen, 
                            new Rectangle(i * resolution, j * resolution, resolution, resolution));
                    }
                }
            }
            deadOrAlive = newDeadOrAlive;
            pictureBox1.Refresh();
            Text = $"Generation{++curGen}";
        }
        void PauseGame()
        {
            if (!timer1.Enabled || resolution == 0) return;
            timer1.Stop();
        }
        void ContinueGame()
        {
            if (timer1.Enabled || resolution == 0) return;
            timer1.Start();
        }
        int nOfNeighbours(int i, int j)
        {
            int n = 0;
            for (int a = -1; a < 2; a++)
            {
                for (int b = -1; b < 2; b++)
                {
                    int row = 0;
                    int column = 0;
                    if (universeFormat == "Closed")
                    {
                        row = (j + b + nOfrows) % nOfrows;
                        column = (i + a + nOfcols) % nOfcols;
                    }
                    if (universeFormat == "Limited")
                    {
                        row = j + b;
                        column = i + a;
                        if (row < 0 || column < 0 || row > nOfrows - 1 || column > nOfcols - 1) continue;
                    }
                    bool alive = deadOrAlive[column, row];
                    if (alive && !(column == i && row == j)) n++;
                }
            }
            return n;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            resolution = (int)NUDresolution.Value;
            timer1.Interval = (int)NUDgenRate.Value;
            NextGen();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            PauseGame();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            PauseGame();
            ClearField();
        }
        void ClearField()
        {
            if (resolution == 0) return;
            curGen = 0;
            resolution = 0;
            NUDresolution.Enabled = true;
            NUDresolution.Minimum = 2;
            DUDuniverseFormat.Enabled = true;
            NUDdensity.Enabled = true;
            gr.Clear(Color.Black);
            pictureBox1.Refresh();
            deadOrAlive = new bool[nOfcols, nOfrows];
        }
        void RandomGen()
        {
            StartParam();
            Random rnd = new Random();
            for (int i = 0; i < deadOrAlive.GetLength(0); i++)
            {
                for (int j = 0; j < deadOrAlive.GetLength(1); j++)
                {
                    deadOrAlive[i, j] = rnd.Next((int)NUDdensity.Value) == 0;
                    if (deadOrAlive[i, j]) gr.FillEllipse(Brushes.SpringGreen,
                        new Rectangle(i * resolution, j * resolution, resolution, resolution));
                }
            }
        }
        void StartGame()
        {
            if (timer1.Enabled || resolution == 0) return;
            NUDresolution.Minimum = NUDresolution.Value;
            DUDuniverseFormat.Enabled = false;
            NUDdensity.Enabled = false;
            Text = $"Generation{curGen}";
            timer1.Start();
        }
        void MyGen()
        {
            StartParam();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (resolution == 0) return;
            if (e.Button == MouseButtons.Left)
            {
                x = e.Location.X / resolution;
                y = e.Location.Y / resolution;
                deadOrAlive[x, y] = true;
                if (!timer1.Enabled)
                {
                    gr.FillEllipse(Brushes.SpringGreen,
                        new Rectangle(x * resolution, y * resolution, resolution, resolution));
                    pictureBox1.Invalidate();
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                x = e.Location.X / resolution;
                y = e.Location.Y / resolution;
                deadOrAlive[x, y] = false;
                if (!timer1.Enabled)
                {
                    gr.FillEllipse(Brushes.Black,
                        new Rectangle(x * resolution, y * resolution, resolution, resolution));
                    pictureBox1.Invalidate();
                }
            }
        }

        private void My_generation_Click(object sender, EventArgs e)
        {
            MyGen();
        }

        private void Random_generation_Click(object sender, EventArgs e)
        {
            RandomGen();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (resolution == 0) return;
            if (e.Button == MouseButtons.Left)
            {
                x = e.Location.X / resolution;
                y = e.Location.Y / resolution;
                if (x >= 0 && y >= 0 && x < nOfcols && y < nOfrows)
                {
                    deadOrAlive[x, y] = true;
                    if (!timer1.Enabled)
                    {
                        gr.FillEllipse(Brushes.SpringGreen,
                            new Rectangle(x * resolution, y * resolution, resolution, resolution));
                        pictureBox1.Invalidate();
                    }
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                x = e.Location.X / resolution;
                y = e.Location.Y / resolution;
                if (x >= 0 && y >= 0 && x < nOfcols && y < nOfrows)
                {
                    deadOrAlive[x, y] = false;
                    if (!timer1.Enabled)
                    {
                        gr.FillEllipse(Brushes.Black,
                            new Rectangle(x * resolution, y * resolution, resolution, resolution));
                        pictureBox1.Invalidate();
                    }
                }
            }
        }
        void GunTemplate()
        {
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(131 / resolution * resolution, 147 / resolution * resolution, resolution, resolution));
            deadOrAlive[131 / resolution, 147 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(123 / resolution * resolution, 164 / resolution * resolution, resolution, resolution));
            deadOrAlive[123 / resolution, 164 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(144 / resolution * resolution, 144 / resolution * resolution, resolution, resolution));
            deadOrAlive[144 / resolution, 144 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(143 / resolution * resolution, 158 / resolution * resolution, resolution, resolution));
            deadOrAlive[143 / resolution, 158 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(340 / resolution * resolution, 140 / resolution * resolution, resolution, resolution));
            deadOrAlive[340 / resolution, 140 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(342 / resolution * resolution, 159 / resolution * resolution, resolution, resolution));
            deadOrAlive[342 / resolution, 159 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(344 / resolution * resolution, 181 / resolution * resolution, resolution, resolution));
            deadOrAlive[344 / resolution, 181 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(364 / resolution * resolution, 208 / resolution * resolution, resolution, resolution));
            deadOrAlive[364 / resolution, 208 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(360 / resolution * resolution, 124 / resolution * resolution, resolution, resolution));
            deadOrAlive[360 / resolution, 124 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(383 / resolution * resolution, 107 / resolution * resolution, resolution, resolution));
            deadOrAlive[383 / resolution, 107 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(402 / resolution * resolution, 103 / resolution * resolution, resolution, resolution));
            deadOrAlive[402 / resolution, 103 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(385 / resolution * resolution, 226 / resolution * resolution, resolution, resolution));
            deadOrAlive[385 / resolution, 226 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(405 / resolution * resolution, 228 / resolution * resolution, resolution, resolution));
            deadOrAlive[405 / resolution, 228 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(434 / resolution * resolution, 169 / resolution * resolution, resolution, resolution));
            deadOrAlive[434 / resolution, 169 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(455 / resolution * resolution, 122 / resolution * resolution, resolution, resolution));
            deadOrAlive[455 / resolution, 122 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(477 / resolution * resolution, 142 / resolution * resolution, resolution, resolution));
            deadOrAlive[477 / resolution, 142 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(474 / resolution * resolution, 162 / resolution * resolution, resolution, resolution));
            deadOrAlive[474 / resolution, 162 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(474 / resolution * resolution, 186 / resolution * resolution, resolution, resolution));
            deadOrAlive[474 / resolution, 186 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(455 / resolution * resolution, 214 / resolution * resolution, resolution, resolution));
            deadOrAlive[455 / resolution, 214 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(499 / resolution * resolution, 164 / resolution * resolution, resolution, resolution));
            deadOrAlive[499 / resolution, 164 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(560 / resolution * resolution, 144 / resolution * resolution, resolution, resolution));
            deadOrAlive[560 / resolution, 144 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(563 / resolution * resolution, 128 / resolution * resolution, resolution, resolution));
            deadOrAlive[563 / resolution, 128 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(565 / resolution * resolution, 106 / resolution * resolution, resolution, resolution));
            deadOrAlive[565 / resolution, 106 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(575 / resolution * resolution, 104 / resolution * resolution, resolution, resolution));
            deadOrAlive[575 / resolution, 104 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(577 / resolution * resolution, 115 / resolution * resolution, resolution, resolution));
            deadOrAlive[577 / resolution, 115 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(583 / resolution * resolution, 140 / resolution * resolution, resolution, resolution));
            deadOrAlive[583 / resolution, 140 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(603 / resolution * resolution, 163 / resolution * resolution, resolution, resolution));
            deadOrAlive[603 / resolution, 163 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(607 / resolution * resolution, 80 / resolution * resolution, resolution, resolution));
            deadOrAlive[607 / resolution, 80 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(646 / resolution * resolution, 166 / resolution * resolution, resolution, resolution));
            deadOrAlive[646 / resolution, 166 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(653 / resolution * resolution, 192 / resolution * resolution, resolution, resolution));
            deadOrAlive[653 / resolution, 192 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(642 / resolution * resolution, 71 / resolution * resolution, resolution, resolution));
            deadOrAlive[642 / resolution, 71 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(646 / resolution * resolution, 57 / resolution * resolution, resolution, resolution));
            deadOrAlive[646 / resolution, 57 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(865 / resolution * resolution, 96 / resolution * resolution, resolution, resolution));
            deadOrAlive[865 / resolution, 96 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(885 / resolution * resolution, 96 / resolution * resolution, resolution, resolution));
            deadOrAlive[885 / resolution, 96 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(889 / resolution * resolution, 116 / resolution * resolution, resolution, resolution));
            deadOrAlive[889 / resolution, 116 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(873 / resolution * resolution, 118 / resolution * resolution, resolution, resolution));
            deadOrAlive[873 / resolution, 118 / resolution] = true;
        }
        void Loafer()
        {
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(268 / resolution * resolution, 165 / resolution * resolution, resolution, resolution));
            deadOrAlive[268 / resolution, 165 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(295 / resolution * resolution, 162 / resolution * resolution, resolution, resolution));
            deadOrAlive[295 / resolution, 162 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(250 / resolution * resolution, 185 / resolution * resolution, resolution, resolution));
            deadOrAlive[250 / resolution, 185 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(275 / resolution * resolution, 208 / resolution * resolution, resolution, resolution));
            deadOrAlive[275 / resolution, 208 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(300 / resolution * resolution, 225 / resolution * resolution, resolution, resolution));
            deadOrAlive[300 / resolution, 225 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(322 / resolution * resolution, 185 / resolution * resolution, resolution, resolution));
            deadOrAlive[322 / resolution, 185 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(325 / resolution * resolution, 208 / resolution * resolution, resolution, resolution));
            deadOrAlive[325 / resolution, 208 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(361 / resolution * resolution, 161 / resolution * resolution, resolution, resolution));
            deadOrAlive[361 / resolution, 161 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(385 / resolution * resolution, 184 / resolution * resolution, resolution, resolution));
            deadOrAlive[385 / resolution, 184 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(409 / resolution * resolution, 188 / resolution * resolution, resolution, resolution));
            deadOrAlive[409 / resolution, 188 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(406 / resolution * resolution, 166 / resolution * resolution, resolution, resolution));
            deadOrAlive[406 / resolution, 166 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(427 / resolution * resolution, 164 / resolution * resolution, resolution, resolution));
            deadOrAlive[427 / resolution, 164 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(431 / resolution * resolution, 243 / resolution * resolution, resolution, resolution));
            deadOrAlive[431 / resolution, 243 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(432 / resolution * resolution, 273 / resolution * resolution, resolution, resolution));
            deadOrAlive[432 / resolution, 273 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(400 / resolution * resolution, 276 / resolution * resolution, resolution, resolution));
            deadOrAlive[400 / resolution, 276 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(380 / resolution * resolution, 278 / resolution * resolution, resolution, resolution));
            deadOrAlive[380 / resolution, 278 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(354 / resolution * resolution, 296 / resolution * resolution, resolution, resolution));
            deadOrAlive[354 / resolution, 296 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(383 / resolution * resolution, 321 / resolution * resolution, resolution, resolution));
            deadOrAlive[383 / resolution, 321 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(411 / resolution * resolution, 336 / resolution * resolution, resolution, resolution));
            deadOrAlive[411 / resolution, 336 / resolution] = true;
            gr.FillEllipse(Brushes.SpringGreen, new Rectangle(431 / resolution * resolution, 341 / resolution * resolution, resolution, resolution));
            deadOrAlive[431 / resolution, 341 / resolution] = true;
        }
        private void Continue_Click(object sender, EventArgs e)
        {
            ContinueGame();
        }


        private void Templates_SelectedIndexChanged(object sender, EventArgs e)
        {
            NUDresolution.Value = 22;
            StartParam();
            NUDresolution.Enabled = false;
            string template = Templates.SelectedItem.ToString();
            switch (template)
            {
                case "Gun":
                    {
                        GunTemplate();
                        break;
                    }
                case "Loafer":
                    {
                        Loafer();
                        break;
                    }
            }
        }
    }
}
