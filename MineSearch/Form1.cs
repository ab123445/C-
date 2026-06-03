namespace MineSearch
{
    public partial class Form1 : Form
    {
        public const int MENU_HIGHT = 30;
        List<List<Mine>> Mines = new();

        Random rand = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ClientRectangle.Width
            this.Width += 9 * Mine.X - ClientRectangle.Width;
            this.Height += 9 * Mine.Y - ClientRectangle.Height + MENU_HIGHT;


            for (int i = 0; i < 9; i++)
            {
                Mines.Add(new List<Mine>());
                for (int j = 0; j < 9; j++)
                {
                    Mine mine = new(i, j, button_MouseDown);
                    mine.GetMine();
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
                        me.getIdxX() + x <= 8 && me.getIdxY() + y <=8)
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
                //txtRuleBox.Text = "Success"; //
                for (int x = -1; x < 2; x++)
                {
                    for (int y = -1; y < 2; y++)
                    {
                        if (me.getIdxX() + x >= 0 && me.getIdxY() + y >= 0 &&
                            me.getIdxX() + x <= 8 && me.getIdxY() + y <= 8) // && m.Enabled == true 수정해야 함
                        {
                            txtRuleBox.Text = "Success2"; //
                            m = Mines[me.getIdxX() + x][me.getIdxY() + y];
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
                me.Mine_Open(Mines_Count(me));
                //auto_open(me);
            }
            else if (e.Button == MouseButtons.Right)
            {
                me.Set_Flag();
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
    }
}
