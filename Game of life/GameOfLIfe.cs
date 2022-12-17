using System;
using System.Drawing;
using System.Windows.Forms;


namespace Game_of_life
{
    public partial class GameOfLIfeForm : Form
    {
        Graphics gr;
        GameEngine gameEngine;
        int resolution;
        public GameOfLIfeForm()
        {
            InitializeComponent();
        }
        void StartParam()
        {
            resolution = (int)NUDresolution.Value;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(pictureBox1.Image);
        }

        void DrawNextGen()
        {
            gr.Clear(Color.Black);
            DrawCurrentGen();
            pictureBox1.Refresh();
            Text = $"Generation{gameEngine.CurrentGeneration}";
            gameEngine.NextGen();
        }

        void DrawCurrentGen()
        {
            bool[,] deadOrAlive = gameEngine.GetCurrentGeneration();
            for (int x = 0; x < deadOrAlive.GetLength(0); x++)
            {
                for (int y = 0; y < deadOrAlive.GetLength(1); y++)
                {
                    if (deadOrAlive[x, y])
                    {
                        gr.FillEllipse(Brushes.SpringGreen, new Rectangle(x * resolution, y * resolution, resolution, resolution));
                    }
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            resolution = (int)NUDresolution.Value;
            timer1.Interval = (int)NUDgenRate.Value;
            DrawNextGen();
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            ContinueGame();
        }
        void ContinueGame()
        {
            if (timer1.Enabled || resolution == 0) return;
            timer1.Start();
        }


        private void Start_Click(object sender, EventArgs e)
        {
            StartGame();
        }
        void StartGame()
        {
            if (timer1.Enabled || resolution == 0) return;
            NUDresolution.Minimum = NUDresolution.Value;
            DUDuniverseFormat.Enabled = false;
            NUDdensity.Enabled = false;
            Text = $"Generation{gameEngine.CurrentGeneration}";
            timer1.Start();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            PauseGame();
        }
        void PauseGame()
        {
            if (!timer1.Enabled || resolution == 0) return;
            timer1.Stop();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            PauseGame();
            ClearField();
        }
        void ClearField()
        {
            if (resolution == 0) return;
            resolution = 0;
            NUDresolution.Enabled = true;
            NUDresolution.Minimum = 2;
            DUDuniverseFormat.Enabled = true;
            NUDdensity.Enabled = true;
            gr.Clear(Color.Black);
            pictureBox1.Refresh();
        }

        private void CellClickHandler(object sender, MouseEventArgs e)
        {
            if (resolution == 0) return;
            if (e.Button == MouseButtons.Left)
            {
                int x = e.Location.X / resolution;
                int y = e.Location.Y / resolution;
                gameEngine.AddCell(x, y);
                if (!timer1.Enabled)
                {
                    gr.FillEllipse(Brushes.SpringGreen, new Rectangle(x * resolution, y * resolution, resolution, resolution));
                    pictureBox1.Invalidate();
                }

            }
            if (e.Button == MouseButtons.Right)
            {
                int x = e.Location.X / resolution;
                int y = e.Location.Y / resolution;
                gameEngine.RemoveCell(x, y);
                if (!timer1.Enabled)
                {
                    gr.FillEllipse(Brushes.Black, new Rectangle(x * resolution, y * resolution, resolution, resolution));
                    pictureBox1.Invalidate();
                }

            }
        }
        private void CellClickMoveHandler(object sender, MouseEventArgs e)
        {
            if (resolution == 0) return;
            if (e.Button == MouseButtons.Left)
            {
                int x = e.Location.X / resolution;
                int y = e.Location.Y / resolution;
                gameEngine.AddCell(x, y);
                if (!timer1.Enabled)
                {
                    gr.FillEllipse(Brushes.SpringGreen, new Rectangle(x * resolution, y * resolution, resolution, resolution));
                    pictureBox1.Invalidate();
                }

            }
            if (e.Button == MouseButtons.Right)
            {
                int x = e.Location.X / resolution;
                int y = e.Location.Y / resolution;
                gameEngine.RemoveCell(x, y);
                if (!timer1.Enabled)
                {
                    gr.FillEllipse(Brushes.Black, new Rectangle(x * resolution, y * resolution, resolution, resolution));
                    pictureBox1.Invalidate();
                }

            }
        }

        private void CBselectedGeneration_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartParam();
            gameEngine = new GameEngine
                (
                  nOfCols: pictureBox1.Width / resolution,
                  nOfRows: pictureBox1.Height / resolution,
                  universeFormat: DUDuniverseFormat.Text,
                  density: (int)NUDdensity.Maximum + (int)NUDdensity.Minimum - (int)NUDdensity.Value
                );
            string firstGeneration = CBselectedGeneration.Text.ToString().ToLower().Trim();
            switch (firstGeneration)
            {
                case "random":
                    {
                        gameEngine.RandomGen();
                        DrawCurrentGen();
                        break;
                    }
                case "my":
                    {
                        break;
                    }
                case "gun template":
                    {
                        gameEngine.GunTemplate();
                        DrawCurrentGen();
                        break;
                    }
                case "loafer template":
                    {
                        gameEngine.LoaferTemplate();
                        DrawCurrentGen();
                        break;
                    }
                default: break;
            }
        }
    }
    public class GameEngine
    {
        bool[,] deadOrAlive;
        int nOfcols;
        int nOfrows;
        string universeFormat;
        int density;
        public uint CurrentGeneration { get; private set; }
        public GameEngine(int nOfCols, int nOfRows, string universeFormat, int density)
        {
            this.nOfcols = nOfCols;
            this.nOfrows = nOfRows;
            this.universeFormat = universeFormat;
            this.density = density;
            deadOrAlive = new bool[nOfCols, nOfRows];
        }
        public bool[,] GetCurrentGeneration()
        {
            bool[,] result = new bool[nOfcols, nOfrows];
            for (int x = 0; x < nOfcols; x++)
            {
                for (int y = 0; y < nOfrows; y++)
                {
                    result[x, y] = deadOrAlive[x, y];
                }
            }
            return result;
        }
        public void NextGen()
        {
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

                }
            }
            deadOrAlive = newDeadOrAlive;
            CurrentGeneration++;
        }
        int nOfNeighbours(int x, int y)
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
                        row = (y + b + nOfrows) % nOfrows;
                        column = (x + a + nOfcols) % nOfcols;
                    }
                    if (universeFormat == "Limited")
                    {
                        row = y + b;
                        column = x + a;
                        if (row < 0 || column < 0 || row > nOfrows - 1 || column > nOfcols - 1) continue;
                    }
                    bool alive = deadOrAlive[column, row];
                    if (alive && !(column == x && row == y)) n++;
                }
            }
            return n;
        }
        public void RandomGen()
        {
            Random rnd = new Random();
            for (int x = 0; x < deadOrAlive.GetLength(0); x++)
            {
                for (int y = 0; y < deadOrAlive.GetLength(1); y++)
                {
                    deadOrAlive[x, y] = rnd.Next(density) == 0;
                }
            }
        }
        public void ChangeCell(int x, int y, bool cellState)
        {
            if (x >= 0 && y >= 0 && x < nOfcols && y < nOfrows) deadOrAlive[x, y] = cellState;
        }
        public void AddCell(int x, int y)
        {
            ChangeCell(x, y, cellState: true);
        }
        public void RemoveCell(int x, int y)
        {
            ChangeCell(x, y, cellState: false);
        }
        public void GunTemplate()
        {
            deadOrAlive[10, 10] = true;
            deadOrAlive[10, 11] = true;
            deadOrAlive[11, 11] = true;
            deadOrAlive[11, 10] = true;
            deadOrAlive[21, 9] = true;
            deadOrAlive[22, 8] = true;
            deadOrAlive[23, 8] = true;
            deadOrAlive[25, 9] = true;
            deadOrAlive[24, 11] = true;
            deadOrAlive[26, 10] = true;
            deadOrAlive[26, 11] = true;
            deadOrAlive[27, 11] = true;
            deadOrAlive[26, 12] = true;
            deadOrAlive[25, 13] = true;
            deadOrAlive[20, 10] = true;
            deadOrAlive[20, 11] = true;
            deadOrAlive[20, 12] = true;
            deadOrAlive[21, 13] = true;
            deadOrAlive[22, 14] = true;
            deadOrAlive[23, 14] = true;
            deadOrAlive[30, 10] = true;
            deadOrAlive[31, 10] = true;
            deadOrAlive[32, 11] = true;
            deadOrAlive[34, 11] = true;
            deadOrAlive[34, 12] = true;
            deadOrAlive[30, 9] = true;
            deadOrAlive[31, 9] = true;
            deadOrAlive[30, 8] = true;
            deadOrAlive[31, 8] = true;
            deadOrAlive[34, 7] = true;
            deadOrAlive[34, 6] = true;
            deadOrAlive[44, 8] = true;
            deadOrAlive[45, 8] = true;
            deadOrAlive[44, 9] = true;
            deadOrAlive[45, 9] = true;
            deadOrAlive[32, 7] = true;
        }
        public void LoaferTemplate()
        {
            deadOrAlive[10, 10] = true;
            deadOrAlive[11, 9] = true;
            deadOrAlive[12, 9] = true;
            deadOrAlive[13, 10] = true;
            deadOrAlive[13, 11] = true;
            deadOrAlive[12, 12] = true;
            deadOrAlive[11, 11] = true;
            deadOrAlive[15, 9] = true;
            deadOrAlive[16, 10] = true;
            deadOrAlive[17, 10] = true;
            deadOrAlive[17, 9] = true;
            deadOrAlive[18, 9] = true;
            deadOrAlive[18, 13] = true;
            deadOrAlive[18, 14] = true;
            deadOrAlive[17, 14] = true;
            deadOrAlive[16, 14] = true;
            deadOrAlive[15, 15] = true;
            deadOrAlive[16, 16] = true;
            deadOrAlive[17, 17] = true;
            deadOrAlive[18, 17] = true;
        }
    }
}
