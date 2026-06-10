using System;
using System.Drawing;
using System.Numerics;

namespace MineSearch //지뢰 개수 고정 구현 필요(15 / 81)
{
    public partial class Form1 : Form
    {
        public const int MENU_HIGHT = 30;
        List<List<Mine>> Mines = new();
        private int point = 0;
        bool firstTouched = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ClientRectangle.Width
            this.Width += 9 * Mine.X - ClientRectangle.Width;
            this.Height += 9 * Mine.Y - ClientRectangle.Height + MENU_HIGHT;
            CreateMine();

        }

        private void CreateMine()
        {
            Random rand = new();
            for (int i = 0; i < 9; i++)
            {
                Mines.Add(new List<Mine>());
                for (int j = 0; j < 9; j++)
                {
                    int random = rand.Next(0, 100);
                    Mine mine = new(i, j, button_MouseDown);
                    mine.GetMine(random);
                    Controls.Add(mine);
                    Mines[i].Add(mine);
                }
            }
        }


        public int Mines_Count(Mine me)
        {
            int mines_count = 0;
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    if (me.getIdxX() + x >= 0 && me.getIdxY() + y >= 0 &&
                        me.getIdxX() + x <= 8 && me.getIdxY() + y <= 8)
                    {
                        if (Mines[me.getIdxX() + x][me.getIdxY() + y].IsMine == true)
                            mines_count++;
                    }

                }
            }
            return mines_count;
        }
        public void auto_open(Mine me)
        {
            Mine m;
            if (Mines_Count(me) == 0)
            {
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        int nowX = me.getIdxX() + x;
                        int nowY = me.getIdxY() + y;
                        if (nowX >= 0 && nowY + y >= 0 &&
                            nowX + x <= 8 && nowY <= 8)
                        {
                            if (x == 0 && y == 0)
                                continue;
                            m = Mines[nowX][nowY];
                            if (m.Enabled == false)
                                continue;
                            m.Mine_Open(Mines_Count(m));
                            if (Mines_Count(m) == 0)
                                auto_open(m);
                        }

                    }
                }
            }
        }
        public void button_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            Mine me = button.Tag as Mine;
            if (me == null) return;



            if (e.Button == MouseButtons.Left)
            {
                if (firstTouched == false)
                {
                    int deleted = 0;
                    for (int x = -1; x <=1; x++)
                    {
                        for (int y = -1; y <=1; y++)
                        {
                            int nowX = me.getIdxX() + x;
                            int nowY = me.getIdxY() + y;
                            if (nowX >= 0 && nowY >= 0 &&
                                nowX <= 8 && nowY <= 8)
                            {
                                if (Mines[nowX][nowY].IsMine == true)
                                    deleted++;
                                Mines[nowX][nowY].IsMine = false; // 지뢰개수 보정 필요 enable == true && isMine == false 인 곳에 없어진 지뢰만큼 심기
                            }

                        }
                    }
                    firstTouched = true;
                }
                me.Mine_Open(Mines_Count(me));
                auto_open(me);
                if (me.IsMine == true)
                {
                    lose();
                }
                point++;
                win();
            }
            else if (e.Button == MouseButtons.Right)
            {
                me.Set_Flag();
                win();
            }
        }

        private void lose()
        {
            MessageBox.Show($"Game Over\npoint : {point}점");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Mines[i][j].Enabled = false;
                }
            }
        }
        private void win()
        {
            int total = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Mines[i][j].solved == true)
                    {
                        total++;
                    }
                }
            }
            if (total == 81)
            {
                MessageBox.Show("clear!");
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Mines[i][j].Enabled = false;
                    }
                }
            }
        }
        private void txtRulebox_Click(object sender, EventArgs e)
        {
            Rules frm = new();
            frm.Text = "Rules";
            frm.Width = 600;
            frm.Height = 600;
            frm.ShowDialog();
        }

        private void txtRestartBox_Click(object sender, EventArgs e)
        {
            for (int i = Mines.Count - 1; i >= 0; i--)
            {
                for (int j = Mines[i].Count - 1; j >= 0 ; j--)
                {
                    Controls.Remove(Mines[i][j]);
                    Mines[i][j].Dispose();
                    Mines[i].RemoveAt(j);
                }
                Mines.Remove(Mines[i]);
            }
            CreateMine();
            firstTouched = false;
        }
    }
}
