using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace MineSearch
{
    public partial class Form1 : Form
    {
        //클리어 한번 뜨게 하고, 타이머 조정하기

        public const int MENU_HEIGHT = 30;
        List<List<Mine>> Mines = new();
        public int point = 0;
        bool firstTouched = false;
        int opponent;
        bool isMatch = false;
        int difficulty = 0;
        int total_Mine = 12;
        int size = 7;
        int Left_Mines;
        int highest = 0;
        double seconds = 0;

        ClientSocket client = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread t1 = new Thread(new ThreadStart(() => client.start()));
            t1.IsBackground = true;
            t1.Start();
            this.Width += (size + 3) * Mine.X - ClientRectangle.Width;
            this.Height += size * Mine.Y - ClientRectangle.Height + MENU_HEIGHT;
            CreateMine();
            Left_Mines = total_Mine;
            count_txtbox.Text = $"필요한 깃발: {Left_Mines}";
            time_txtbox.Text = $"{seconds}s";
            timer1.Interval = 100;
            //timer1.Start();
        }

        public void sendToMainThread(string command, string data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => sendToMainThread(command, data)));
                return;
            }
            if (command == "/msg")
            {
                setListBox(data);
            }
            if (command == "/setText")
            {
                this.Text = $"지뢰찾기 - {data}";
            }
            if (command == "/matchStart")
            {
                opponent = int.Parse(data);
                isMatch = true;
                size = 9;
                total_Mine = 5;
                seconds = 60;
                difficulty++;
                difficultybutton.Text = "2단계(고정)";
                setConsole(size, size * Mine.Y - 20);
                this.Width += (size + 3) * Mine.X - ClientRectangle.Width;
                this.Height += size * Mine.Y - ClientRectangle.Height + MENU_HEIGHT;
                Restart();
            }
            if (command == "/end")
            {
                MessageBox.Show($"You lost. The winner is {data}.");
                timer1.Stop();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Mines[i][j].Mine_Open(Mines_Count(Mines[i][j]));
                    }
                }
                isMatch = false;
            }
        }
        void setListBox(string data)
        {
            ConsoleListBox.Items.Add(data);
        }

        void setConsole(int x, int height)
        {
            ConsoleListBox.Location = new Point(x * Mine.X + 10, 10 + Form1.MENU_HEIGHT);
            ConsoleListBox.Height = height;
        }
        private void CreateMine()
        {
            Random rand = new();

            for (int i = 0; i < size; i++)
            {
                Mines.Add(new List<Mine>());

                for (int j = 0; j < size; j++)
                {
                    Mine mine = new(i, j, button_MouseDown);
                    mine.GetMine(false);

                    Controls.Add(mine);
                    Mines[i].Add(mine);
                }
            }

            int mineCount = 0;

            while (mineCount < total_Mine)
            {
                int x = rand.Next(size);
                int y = rand.Next(size);

                if (Mines[x][y].IsMine == false)
                {
                    Mines[x][y].IsMine = true;
                    mineCount++;
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
                        me.getIdxX() + x < size &&
                        me.getIdxY() + y < size)
                    {
                        if (Mines[me.getIdxX() + x][me.getIdxY() + y].IsMine == true)
                            mines_count++;
                    }

                }
            }
            return mines_count;
        }
        public void surround_open(Mine me)
        {
            Mine m;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int nowX = me.getIdxX() + x;
                    int nowY = me.getIdxY() + y;
                    if (nowX >= 0 && nowY >= 0 &&
                        nowX < size && nowY < size)
                    {
                        if (x == 0 && y == 0)
                            continue;
                        m = Mines[nowX][nowY];
                        if (m.Enabled == false)
                            continue;
                        if (m.Text == "Flag")
                            continue;
                        m.Mine_Open(Mines_Count(m));
                        point++;
                    }
                }
            }
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
                        if (nowX >= 0 && nowY >= 0 &&
                            nowX < size && nowY < size)
                        {
                            if (x == 0 && y == 0)
                                continue;
                            m = Mines[nowX][nowY];
                            if (m.Enabled == false)
                                continue;
                            m.Mine_Open(Mines_Count(m));
                            point++;
                            if (Mines_Count(m) == 0)
                                auto_open(m);
                        }

                    }
                }
            }
        }
        public int check_surround_flags(Mine me)
        {
            Mine m;
            int surround_flags = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int nowX = me.getIdxX() + x;
                    int nowY = me.getIdxY() + y;

                    if (nowX >= 0 && nowY >= 0 &&
                        nowX < size && nowY < size)
                    {
                        m = Mines[nowX][nowY];
                        if (x == 0 && y == 0)
                            continue;
                        if (m.Text == "Flag")
                            surround_flags++;
                    }
                }
            }
            return surround_flags;
        }
        public void first_touch(Mine me)
        {
            timer1.Start();
            int deleted = 0;

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int nowX = me.getIdxX() + x;
                    int nowY = me.getIdxY() + y;

                    if (nowX >= 0 && nowY >= 0 &&
                        nowX < size &&
                        nowY < size)
                    {
                        if (Mines[nowX][nowY].IsMine == true)
                            deleted++;

                        Mines[nowX][nowY].IsMine = false;
                    }
                }
            }

            Random rand = new();

            while (deleted > 0)
            {
                int x = rand.Next(size);
                int y = rand.Next(size);

                if (x >= me.getIdxX() - 1 &&
                    x <= me.getIdxX() + 1 &&
                    y >= me.getIdxY() - 1 &&
                    y <= me.getIdxY() + 1)
                    continue;

                if (Mines[x][y].IsMine == false)
                {
                    Mines[x][y].IsMine = true;
                    deleted--;
                }
            }
        }
        public void left_click(Mine me)
        {
            if (firstTouched == false && me.Text != "Flag")
            {
                first_touch(me);
                firstTouched = true;
            }


            me.Mine_Open(Mines_Count(me));
            auto_open(me);
            point++;

            if (me.IsMine == true && me.Text != "Flag")
            {
                lose();
            }
            else
                win();

        }
        public void right_click(Mine me)
        {
            if (me.Enabled == false)
            {
                Mine m;
                if (check_surround_flags(me) == Mines_Count(me))
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            int nowX = me.getIdxX() + x;
                            int nowY = me.getIdxY() + y;

                            if (nowX >= 0 && nowY >= 0 &&
                                nowX < size && nowY < size)
                            {
                                m = Mines[nowX][nowY];
                                if (x == 0 && y == 0)
                                    continue;
                                if (m.Text == "Flag")
                                    continue;
                                left_click(m);
                            }
                        }
                    }
                }
            }
            else if (me.Enabled == true)
            {
                me.Set_Flag(ref Left_Mines);
                count_txtbox.Text = $"필요한 깃발: {Left_Mines}";
                win();
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
                left_click(me);
            }
            else if (e.Button == MouseButtons.Right)
            {
                right_click(me);
            }
        }

        private void lose()
        {
            
            timer1.Stop();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Mines[i][j].Mine_Open(Mines_Count(Mines[i][j]));
                }
            }
            if (isMatch == false)
            {
                MessageBox.Show($"Game Over\npoint : {point}점");
                DialogResult aaa = MessageBox.Show("다시 하시겠습니까?", "", MessageBoxButtons.YesNo);
                if (aaa == DialogResult.Yes)
                {
                    Restart();
                }
            }
            if (isMatch == true)
            {
                if (point > highest)
                {
                    MessageBox.Show($"최고점!\npoint : {point}점");
                    highest = point;
                }
            }
        }
        private void win()
        {
            int total = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (Mines[i][j].solved == true)
                    {
                        total++;
                    }
                }
            }

            if (total == size * size - total_Mine)
            {
                if (isMatch == false)
                {
                    timer1.Stop();
                    MessageBox.Show("clear!");
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            Mines[i][j].Enabled = false;
                        }
                    }
                    DialogResult aaa = MessageBox.Show("다시 하시겠습니까?", "", MessageBoxButtons.YesNo);
                    if (aaa == DialogResult.Yes)
                    {
                        Restart();
                    }
                }
                if (isMatch == true)
                {
                    timer1.Stop();
                    MessageBox.Show("You won!");
                    sendToMainThread("/msg", $"Match ended.\n The winner is {client.ClientCode}\n");
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            Mines[i][j].Enabled = false;
                        }
                    }
                    client.socksend($"/end {client.ClientCode} {opponent}");
                    isMatch = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isMatch == false)
            {
                seconds += 0.1;
            }
            if (isMatch == true)
            {
                seconds -= 0.1;
                if (seconds == 0)
                {
                    client.socksend($"/high {highest} {opponent}"); //상대에게 최고점을 보내주기
                }
            }
            time_txtbox.Text = $"{seconds:F1}s";
        }

        private void Restart()
        {
            for (int i = Mines.Count - 1; i >= 0; i--)
            {
                for (int j = Mines[i].Count - 1; j >= 0; j--)
                {
                    Controls.Remove(Mines[i][j]);
                    Mines[i][j].Dispose();
                    Mines[i].RemoveAt(j);
                }
                Mines.Remove(Mines[i]);
            }
            CreateMine();
            firstTouched = false;
            Left_Mines = total_Mine;
            point = 0;
            if (isMatch == false)
            {
                seconds = 0;
            }
            time_txtbox.Text = $"{seconds}s";
            count_txtbox.Text = $"필요한 깃발: {Left_Mines}";
            timer1.Stop();
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void RuleButton_Click(object sender, EventArgs e)
        {
            Rules frm = new();
            frm.Text = "Rules";
            frm.Width = 600;
            frm.Height = 600;
            frm.ShowDialog();
        }

        private void difficultybutton_Click(object sender, EventArgs e)
        {
            if (isMatch == false)
            {
                if (difficulty == 0)
                {
                    size = 9;
                    total_Mine = 20;
                    difficulty++;
                    difficultybutton.Text = "2단계";
                }
                else if (difficulty == 1)
                {
                    size = 11;
                    total_Mine = 30;
                    difficulty++;
                    difficultybutton.Text = "3단계";
                }
                else if (difficulty == 2)
                {
                    size = 13;
                    total_Mine = 35;
                    difficulty++;
                    difficultybutton.Text = "4단계";
                }
                else if (difficulty == 3)
                {
                    size = 7;
                    total_Mine = 12;
                    difficulty = 0;
                    difficultybutton.Text = "1단계";
                }

                setConsole(size, size * Mine.Y - 20);
                this.Width += (size + 3) * Mine.X - ClientRectangle.Width;
                this.Height += size * Mine.Y - ClientRectangle.Height + MENU_HEIGHT;
                for (int i = Mines.Count - 1; i >= 0; i--)
                {
                    for (int j = Mines[i].Count - 1; j >= 0; j--)
                    {
                        Controls.Remove(Mines[i][j]);
                        Mines[i][j].Dispose();
                        Mines[i].RemoveAt(j);
                    }
                    Mines.Remove(Mines[i]);
                }
                CreateMine();
                firstTouched = false;
                Left_Mines = total_Mine;
                point = 0;
                seconds = 0;
                time_txtbox.Text = $"{seconds}s";
                count_txtbox.Text = $"필요한 깃발: {Left_Mines}";
                timer1.Stop();
            }
            else if (isMatch == true)
            {
                sendToMainThread("/msg", "매치 도중에 난이도를 변경할 수 없습니다. ");
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Control control = GetChildAtPoint(e.Location);
            Mine me = control as Mine;
            if (me == null) return;
            if (me.Enabled == false)
            {
                Mine m;
                if (check_surround_flags(me) == Mines_Count(me))
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            int nowX = me.getIdxX() + x;
                            int nowY = me.getIdxY() + y;

                            if (nowX >= 0 && nowY >= 0 &&
                                nowX < size && nowY < size)
                            {
                                m = Mines[nowX][nowY];
                                if (x == 0 && y == 0)
                                    continue;
                                if (m.Text == "Flag")
                                    continue;
                                left_click(m);
                            }
                        }
                    }
                }
            }

        }

        private void WaitingBtn_Click(object sender, EventArgs e)
        {
            if (isMatch == false)
                client.socksend($"/join {client.ClientCode}");
        }
    }
}
