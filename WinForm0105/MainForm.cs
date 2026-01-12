using System.Collections;

namespace WinForm0105
{
    public partial class MainForm : Form
    {
        int Wrong_Ans = 0;
        int Right_Ans = 0;
        int Accuracy_Rate = 100;


        public MainForm()
        {
            InitializeComponent();
        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            char ch = (char)e.KeyCode;
            textBox1.Clear();
            if (listBox1.Items.Contains(ch))
            {
                Right_Ans += 1;
                listBox1.Items.Remove(ch);
            }

            else
                Wrong_Ans += 1;

            WrongAnswer.Text = Wrong_Ans.ToString();
            RightAnswer.Text = Right_Ans.ToString();

            Accuracy_Rate = (int)((double)Right_Ans / (double)(Wrong_Ans + Right_Ans) * 100);

            lblAccuracy.Text = $"{Accuracy_Rate}%";
            pgAccuracy.Value = Accuracy_Rate;

            if (Accuracy_Rate < 70 || Wrong_Ans > 10)
            {
                timer1.Stop();
                MessageBox.Show("Game Over");
            }
            else if (Right_Ans == 20)
            {
                timer1.Stop();
                MessageBox.Show("You win!");
            }
        }

        Random rand = new Random();
        private void MainForm_Load(object sender, EventArgs e)
        {


            timer1.Interval = 1000;
            //timer1.Start();
            timer2.Interval = 1700;
            timer2.Start();
            pgAccuracy.Value = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            char randch = (char)rand.Next('A', 'Z' + 1);
            listBox1.Items.Add(randch);
        }

        private void txtWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;


            for (int i = 0; i < lblWords.Count; i++)
            {
                if (lblWords[i].Text.Equals(txtWord.Text))
                {
                    Label lblWord = lblWords[i];
                    lblWords.Remove(lblWord);
                    Controls.Remove(lblWord);
                    break;
                }
            }
        }

        int stamina = 3;
        List<Label> lblWords = new List<Label>();
        string[] fruits = { "apple", "banana", "grape", "watermelon", "pineapple"};
        private void makelabel()
        {
            Label lblWord = new();
            lblWord.AutoSize = true;
            int[] RandPos = {rand.Next(label2.Left, label2.Right),
                53 };
            lblWord.Location = new Point(RandPos[0], RandPos[1]);
            lblWord.Name = "lblWord";
            lblWord.Size = new Size(36, 15);
            lblWord.TabIndex = 7;
            int RandFruit = rand.Next(0, fruits.Length);
            lblWord.Text = fruits[RandFruit];
            lblWords.Add(lblWord);
            Controls.Add(lblWord);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            makelabel();
            for (int i = 0; i < lblWords.Count; i++)
            {
                lblWords[i].Top += 20;
                if (lblWords[i].Bottom > label2.Top)
                {

                }
            }
            pgStamina.Value = stamina;
        }
    }
}
