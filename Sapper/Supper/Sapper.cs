using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Supper
{
    public partial class Sapper : Form
    {
        int
         FieldHeight, // кол-во клеток по вертикали
         FieldWight,// кол-во клеток по горизонтали
         Mines, // кол-во мин
         W = 28,  // ширина клетки
         H = 28;  // высота клетки
        // игровое (минное) поле
        int[,] Field;
        // значение элемента массива:
        // 0..8 - количество мин в соседних клетках
        // 9 - в клетке мина
        // 100..109 - клетка открыта
        // 200..209 - в клетку поставлен флаг
        // 50..59 - 50/50
        private int FindMines;  // кол-во найденных мин
        private int FindFlags; // кол-во поставленных флагов
        // статус игры
        private int status;
        // 0 - начало игры,
        // 1 - игра,
        // 2 – результат проигрыш
        // 3 - результат победа
        // графическая поверхность формы
        private System.Drawing.Graphics g;
        // прямоугольник поля
        Rectangle rt;
        // звуки
        System.Media.SoundPlayer click = new System.Media.SoundPlayer("Click.wav");
        System.Media.SoundPlayer bomb = new System.Media.SoundPlayer("Bomb.wav");
        System.Media.SoundPlayer tic = new System.Media.SoundPlayer("Tic.wav");
        System.Media.SoundPlayer win = new System.Media.SoundPlayer("Win.wav");
        bool soundcheck;
        public Sapper()
        {
            InitializeComponent();
            beginnerToolStripMenuItem.PerformClick();
            // загружаем звуки
            click.Load();
            bomb.Load();
            tic.Load();
            win.Load();

        }
        public void Start()
        {
            // В неотображаемые эл-ты массива -3 для рекурсиии
            Field = new int[FieldHeight + 2, FieldWight + 2];
            for (int row = 0; row <= FieldHeight + 1; row++)
            {
                Field[row, 0] = -3;
                Field[row, FieldWight + 1] = -3;
            }

            for (int col = 0; col <= FieldWight + 1; col++)
            {
                Field[0, col] = -3;
                Field[FieldHeight + 1, col] = -3;
            }
            // устанавливаем размер формы в соответствии с размером игрового поля
            this.ClientSize = new Size(W * FieldWight + 1, H * FieldHeight + MenuStrip.Height + 41);
            newGame(); // новая игра
            Restart();
        }
        public void Restart()
        {
            // задаём постоянные графические эл-ты
            g = GameField.CreateGraphics();
            int x = GameField.Size.Width / 2 - 25;
            int y = H * FieldHeight + MenuStrip.Height - 23;
            Point Loc = new Point(x, y);
            SmileBox.Location = Loc;
            SmileBox.Image = Image.FromFile("good.jpg");
            MinetextBox.Location = new Point(2, H * FieldHeight + MenuStrip.Height - 20);
            TimetextBox.Location = new Point(GameField.Width - 87, H * FieldHeight + MenuStrip.Height - 20);
            TimetextBox.Font = new Font("Tahoma", 16);
            TimetextBox.Text = "00:00:00";
        }
        public int MinesAround(int row, int col)
        {
            int k;
            for (row = 1; row <= FieldHeight; row++)
                for (col = 1; col <= FieldWight; col++)
                    if (Field[row, col] != 9)
                    {
                        k = 0;

                        if (Field[row - 1, col - 1] == 9) k++;
                        if (Field[row - 1, col] == 9) k++;
                        if (Field[row - 1, col + 1] == 9) k++;
                        if (Field[row, col - 1] == 9) k++;
                        if (Field[row, col + 1] == 9) k++;
                        if (Field[row + 1, col - 1] == 9) k++;
                        if (Field[row + 1, col] == 9) k++;
                        if (Field[row + 1, col + 1] == 9) k++;
                        Field[row, col] = k;
                    }
            return Field[row, col];
        }
        private void newGame()
        {
            int row, col;// индексы клетки
            int n = 0; // количество поставленных мин
            // очищаем поле
            for (row = 1; row <= FieldHeight; row++)
            {
                for (col = 1; col <= FieldWight; col++)
                {
                    Field[row, col] = 0;
                }
            }
            Random rnd = new Random();
            // расставим мины
            do
            {
                row = rnd.Next(FieldHeight) + 1;
                col = rnd.Next(FieldWight) + 1;

                if (Field[row, col] != 9)
                {
                    Field[row, col] = 9;
                    n++;
                }
            }
            while (n != Mines);
            // для каждой клетки вычислим кол-во мин вокруг
            MinesAround(row, col);
            // начинаем
            status = 0;
            FindMines = 0;
            FindFlags = 0;
            MinetextBox.Font = new Font("Tahoma", 16);
            MinetextBox.Text = Mines.ToString();

        }
        // рисует поле
        private void showField(Graphics g, int status)
        {
            for (int row = 1; row <= FieldHeight; row++)
                for (int col = 1; col <= FieldWight; col++)
                    this.cell(g, row, col, status);
        }
        // рисует клетку
        private void cell(Graphics g, int row, int col, int status)
        {
            int x, y;// координаты левого верхнего угла клетки
            x = (col - 1) * W + 1;
            y = (row - 1) * H + 1;
            // не открытые клетки
            if (Field[row, col] < 100)
                g.FillRectangle(Brushes.Gray,
                    x - 1, y - 1, W, H);
            // открытые или помеченные клетки
            if (Field[row, col] >= 100 && Field[row, col] < 200)
            {
                // открываем клетку
                if (Field[row, col] != 109)
                    g.FillRectangle(Brushes.White,
                        x - 1, y - 1, W, H);
                else
                    // взрыв!
                    g.FillRectangle(Brushes.Red,
                        x - 1, y - 1, W, H);
                // если в соседних клетках есть мины, указываем их количество
                if ((Field[row, col] >= 101) && (Field[row, col] <= 108))
                {
                    if (Field[row, col] == 101)
                    {
                        g.DrawString((Field[row, col] - 100).ToString(), new Font("Tahoma", 16, System.Drawing.FontStyle.Regular), Brushes.Blue, x + 3, y + 2);
                    }
                    if (Field[row, col] == 102)
                    {
                        g.DrawString((Field[row, col] - 100).ToString(), new Font("Tahoma", 16, System.Drawing.FontStyle.Regular), Brushes.Green, x + 3, y + 2);
                    }
                    if (Field[row, col] >= 103)
                    {
                        g.DrawString((Field[row, col] - 100).ToString(), new Font("Tahoma", 16, System.Drawing.FontStyle.Regular), Brushes.Red, x + 3, y + 2);
                    }
                }
            }
            // в клетке поставлен флаг
            if (Field[row, col] >= 200)
                this.flag(g, x, y);
            // в клетке 50/50
            if (Field[row, col] >= 50 && Field[row, col] < 100)
                this.question(g, x, y);
            // рисуем границу клетки
            g.DrawRectangle(Pens.Black,
                x - 1, y - 1, W, H);
            // если игра завершена (status = 2),
            // показываем мины
            if ((status == 2) && ((Field[row, col] % 10) == 9))
            {
                this.mine(g, x, y);
                if (Field[row, col] == 209)
                {
                    g.FillRectangle(Brushes.Gray,
                    x - 1, y - 1, W, H);
                    this.mine(g, x, y);
                    Pen MyPen = new Pen(Color.Red, 2);
                    g.DrawLine(MyPen, x + 2, y + 2, x + 25, y + 25);
                    g.DrawLine(MyPen, x + 25, y + 2, x + 2, y + 25);
                }
            }
        }
        // рекурсия
        private void open(int row, int col)
        {
            // координаты области вывода
            int x = (col - 1) * W + 1,
                y = (row - 1) * H + 1;
            if (Field[row, col] == 0)
            {
                Field[row, col] = 100;
                // отобразить содержимое клетки
                this.cell(g, row, col, status);
                // открыть примыкающие клетки
                this.open(row, col - 1);
                this.open(row - 1, col);
                this.open(row, col + 1);
                this.open(row + 1, col);
                this.open(row - 1, col - 1);
                this.open(row - 1, col + 1);
                this.open(row + 1, col - 1);
                this.open(row + 1, col + 1);
            }
            else
                if ((Field[row, col] < 50) && (Field[row, col] != -3))
                {
                    Field[row, col] += 100;
                    this.cell(g, row, col, status);
                }
        }

        //мина
        private void mine(Graphics g, int x, int y)
        {
            Pen pn = new Pen(Brushes.Black);
            g.DrawRectangle(pn, x - 1, y - 1, W, H);
            g.FillEllipse(Brushes.Black, x + 7, y + 7, 14, 14);
            g.DrawLine(Pens.Black, x + 14, y + 14, x + 6, y + 6);
            g.DrawLine(Pens.Black, x + 14, y + 14, x + 22, y + 22);
            g.DrawLine(Pens.Black, x + 14, y + 14, x + 6, y + 22);
            g.DrawLine(Pens.Black, x + 14, y + 14, x + 22, y + 6);
            g.DrawLine(Pens.Black, x + 14, y + 14, x + 6, y + 14);
            g.DrawLine(Pens.Black, x + 14, y + 14, x + 22, y + 14);
            g.DrawLine(Pens.Black, x + 14, y + 14, x + 14, y + 6);
            g.DrawLine(Pens.Black, x + 14, y + 14, x + 14, y + 22);
            g.FillEllipse(Brushes.White, x + 9, y + 9, 5, 5);
        }
        //вопрос
        private void question(Graphics g, int x, int y)
        {
            g.DrawString("?", new Font("Tahoma", 16, System.Drawing.FontStyle.Regular), Brushes.Black, x + 3, y + 2);
        }
        //флаг
        private void flag(Graphics g, int x, int y)
        {
            Pen pn = new Pen(Brushes.Black);
            g.DrawRectangle(pn, x - 1, y - 1, W, H);
            g.FillRectangle(Brushes.Gray, x - 1, y - 1, W, H);
            Point[] p = new Point[3];
            Point[] m = new Point[5];
            p[0].X = x + 14; p[0].Y = y + 3;
            p[1].X = x + 2; p[1].Y = y + 10;
            p[2].X = x + 14; p[2].Y = y + 13;
            g.FillPolygon(Brushes.Red, p);
            g.DrawLine(Pens.Black, x + 14, y + 4, x + 14, y + 17);
            Rectangle Rec = new Rectangle(x + 6, y + 17, 15, 5);
            g.FillRectangle(Brushes.Black, Rec);
        }
        DateTime Time;
        private void LeftButton(int row, int col)
        {
            // открыта клетка, в которой есть мина                   
            if (Field[row, col] == 9)
            {
                if (soundcheck == true)
                {
                    bomb.Play();
                }
                Field[row, col] += 100;
                Timer.Stop();
                // игра закончена
                status = 2;
                MinetextBox.Text = "LOSS";
                this.GameField.Invalidate();
            }
            else
            {
                if (Field[row, col] == 59)
                {
                    if (soundcheck == true)
                    {
                        bomb.Play();
                    }
                    Field[row, col] += 50;
                    Timer.Stop();
                    // игра закончена
                    status = 2;
                    MinetextBox.Text = "LOSS";
                    this.GameField.Invalidate();
                    click.Play();
                }
                if (Field[row, col] < 9)
                {
                    if (soundcheck == true)
                    {
                        click.Play();
                    }
                    this.open(row, col);
                }
            }
        }
        private void GameField_MouseClick_1(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            if (rt.Contains(p))
            {
                // первый щелчок
                if (status == 0)
                {
                    Time = DateTime.Now;
                    Timer.Start();
                    status = 1;
                }
                // координаты мыши в индексы           
                int row = (int)(e.Y / H) + 1,
                    col = (int)(e.X / W) + 1;
                // координаты области вывода
                int x = (col - 1) * W + 1,
                    y = (row - 1) * H + 1;
                // игра завершена
                if (status == 2) return;

                // щелчок левой кнопки мыши
                if (e.Button == MouseButtons.Left)
                {
                    LeftButton(row, col);
                }
                // щелчок правой кнопки мыши
                if (e.Button == MouseButtons.Right)
                {
                    if (soundcheck == true)
                    {
                        click.Play();
                    }
                    if (status != 3)
                    {
                        int m = int.Parse(MinetextBox.Text) - 1;
                        // в клетке не было флага, ставим его
                        if ((Field[row, col] <= 9) && Double.Parse(MinetextBox.Text) > 0)
                        {
                            this.cell(g, row, col, status);
                            MinetextBox.Text = m.ToString();
                            FindFlags += 1;

                            if (Field[row, col] == 9)
                                FindMines += 1;

                            Field[row, col] += 200;

                            if ((FindMines == Mines) && (FindFlags == Mines))
                            {

                                if (soundcheck == true)
                                {
                                    win.Play();
                                }
                                // игра закончена
                                status = 3;
                                Timer.Stop();
                                this.flag(g, x, y);
                                this.Invalidate();
                                MinetextBox.Text = "WIN!!!";
                            }
                            else
                                this.cell(g, row, col, status);
                        }
                        else

                            if (Field[row, col] >= 200)
                            {
                                int k = int.Parse(MinetextBox.Text) + 1;
                                MinetextBox.Text = k.ToString();
                                FindFlags -= 1;
                                Field[row, col] -= 150;
                                this.cell(g, row, col, status);
                                this.question(g, x, y);
                            }
                            else
                                if (Field[row, col] >= 50 && Field[row, col] <= 59)
                                {
                                    Field[row, col] -= 50;
                                    this.cell(g, row, col, status);
                                }

                    }
                }
                //нажатие скрола
                if (e.Button == MouseButtons.Middle)
                {
                    if (Field[row, col] > 100 && Field[row, col] < 109)
                    {
                        int f = 0;
                        if (Field[row - 1, col - 1] >= 200 && Field[row - 1, col - 1] <= 209) f++;
                        if (Field[row - 1, col] >= 200 && Field[row - 1, col - 1] <= 209) f++;
                        if (Field[row - 1, col + 1] >= 200 && Field[row - 1, col - 1] <= 209) f++;
                        if (Field[row, col - 1] >= 200 && Field[row - 1, col - 1] <= 209) f++;
                        if (Field[row, col + 1] >= 200 && Field[row - 1, col - 1] <= 209) f++;
                        if (Field[row + 1, col - 1] >= 200 && Field[row - 1, col - 1] <= 209) f++;
                        if (Field[row + 1, col] >= 200 && Field[row - 1, col - 1] <= 209) f++;
                        if (Field[row + 1, col + 1] >= 200 && Field[row - 1, col - 1] <= 209) f++;
                        int k = Field[row, col] - 100;
                        if (f == k)
                        {
                            LeftButton(row, col - 1);
                            LeftButton(row - 1, col);
                            LeftButton(row, col + 1);
                            LeftButton(row + 1, col);
                            LeftButton(row - 1, col - 1);
                            LeftButton(row - 1, col + 1);
                            LeftButton(row + 1, col - 1);
                            LeftButton(row + 1, col + 1);
                        }
                    }
                }
            }
        }
        private void GameField_Paint_1(object sender, PaintEventArgs e)
        {
            showField(g, status);
        }
        private void SmileBox_Click(object sender, EventArgs e)
        {
            newGame();
            showField(g, status);
            SmileBox.Image = Image.FromFile("good.jpg");
            Timer.Stop();
            TimetextBox.Text = "00:00:00";
            MinetextBox.Text = Mines.ToString();
        }
        //смайлики =)
        private void GameField_MouseDown(object sender, MouseEventArgs e)
        {
            if (status != 2)
            {
                SmileBox.Image = Image.FromFile("dribble.jpg");
            }

            if (status == 2)
            {
                SmileBox.Image = Image.FromFile("after_boom.jpg");
            }
            if (status == 3)
            {
                SmileBox.Image = Image.FromFile("cool.jpg");
            }
            if ((FindFlags == Mines) && (FindMines != Mines))
            {
                SmileBox.Image = Image.FromFile("question.jpg");
                if (status == 2)
                {
                    SmileBox.Image = Image.FromFile("after_boom.jpg");
                }
            }
        }
        //смайлики =) опять
        private void GameField_MouseUp(object sender, MouseEventArgs e)
        {
            if (status != 2)
            {
                SmileBox.Image = Image.FromFile("good.jpg");
            }
            if (status == 2)
            {
                SmileBox.Image = Image.FromFile("after_boom.jpg");
            }
            if (status == 3)
            {
                SmileBox.Image = Image.FromFile("cool.jpg");
            }
            if ((FindFlags == Mines) && (FindMines != Mines))
            {
                SmileBox.Image = Image.FromFile("question.jpg");
                if (status == 2)
                {
                    SmileBox.Image = Image.FromFile("after_boom.jpg");
                }
            }

        }
        // запись в таймер
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (soundcheck == true)
            {
                tic.Play();
            }
            TimetextBox.Text = (DateTime.Now - Time).ToString();
        }
        // менюха нев гаме
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
            showField(g, status);
            SmileBox.Image = Image.FromFile("good.jpg");
            TimetextBox.Text = "00:00:00";
            MinetextBox.Text = Mines.ToString();
        }
        // уровни сложности
        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.CheckState = CheckState.Checked;
            professionalToolStripMenuItem.CheckState = CheckState.Unchecked;
            amateurToolStripMenuItem.CheckState = CheckState.Unchecked;
            crazyToolStripMenuItem.CheckState = CheckState.Unchecked;
            FieldHeight = 11;
            FieldWight = 11;
            Mines = 10;
            rt = new Rectangle(0, 0, FieldWight * W, FieldHeight * H);
            GameField.Invalidate();
            Timer.Stop();
            TimetextBox.Text = "00:00:00";
            Start();

        }

        private void amateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            amateurToolStripMenuItem.CheckState = CheckState.Checked;
            beginnerToolStripMenuItem.CheckState = CheckState.Unchecked;
            professionalToolStripMenuItem.CheckState = CheckState.Unchecked;
            crazyToolStripMenuItem.CheckState = CheckState.Unchecked;
            FieldHeight = 16;
            FieldWight = 16;
            Mines = 25;
            rt = new Rectangle(0, 0, FieldWight * W, FieldHeight * H);
            GameField.Invalidate();
            Timer.Stop();
            TimetextBox.Text = "00:00:00";
            Start();
        }

        private void professionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            professionalToolStripMenuItem.CheckState = CheckState.Checked;
            beginnerToolStripMenuItem.CheckState = CheckState.Unchecked;
            amateurToolStripMenuItem.CheckState = CheckState.Unchecked;
            crazyToolStripMenuItem.CheckState = CheckState.Unchecked;
            FieldHeight = 16;
            FieldWight = 21;
            Mines = 50;
            rt = new Rectangle(0, 0, FieldWight * W, FieldHeight * H);
            GameField.Invalidate();
            Timer.Stop();
            TimetextBox.Text = "00:00:00";
            Start();
        }

        private void crezyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crazyToolStripMenuItem.CheckState = CheckState.Checked;
            professionalToolStripMenuItem.CheckState = CheckState.Unchecked;
            beginnerToolStripMenuItem.CheckState = CheckState.Unchecked;
            amateurToolStripMenuItem.CheckState = CheckState.Unchecked;
            FieldHeight = 16;
            FieldWight = 21;
            Mines = 100;
            rt = new Rectangle(0, 0, FieldWight * W, FieldHeight * H);
            GameField.Invalidate();
            Timer.Stop();
            TimetextBox.Text = "00:00:00";
            Start();
        }
        //запрет изменения размера
        private void Supper_Resize(object sender, EventArgs e)
        {
            this.ClientSize = new Size(W * FieldWight + 1, H * FieldHeight + MenuStrip.Height + 41);
        }
        // меню на звук
        private void soundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (soundcheck == false)
            {
                soundcheck = true;

            }
            else
                soundcheck = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0 \nDeveloper:Grishina Marina", "Sapper", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}