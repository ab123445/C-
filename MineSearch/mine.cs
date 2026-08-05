using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;

namespace MineSearch
{
    public delegate void MineClick(object sender, MouseEventArgs e);

    public class Mine : Button
    {
        public const int X = 60;
        public const int Y = 60;
        public bool IsMine;
        public bool solved;
        Form1 form1;
        //public bool opened = false;
        private int idx_y;
        public int getIdxY()
        {
            return idx_y;
        }
        public void setIdxY(int y)
        {
            idx_y = y;
        }

        private int idx_x;
        public int getIdxX()
        {
            return idx_x;
        }
        public void setIdxX(int x)
        {
            idx_x = x;
        }

        public Mine(int x, int y, MineClick click)
        {
            this.Tag = this;
            idx_y = y;
            idx_x = x;
            this.Location = new Point(x * X, y * Y + Form1.MENU_HEIGHT);
            this.Name = "btnMine";
            this.Size = new Size(X, Y);
            this.TabIndex = 0;
            this.Text = "";
            this.UseVisualStyleBackColor = true;
            this.MouseDown += new MouseEventHandler(click);
        }

        public void GetMine(bool isMine)
        {
            IsMine = isMine;
        }

        public void Mine_Open(int count)
        {
            form1 = Application.OpenForms["Form1"] as Form1;
            if (this.Text != "Flag")
            {
                if (IsMine == true)
                {
                    this.Text = "!!!";
                    this.BackColor = Color.Yellow;
                    this.Enabled = false;
                }
                else
                {
                    if (count == 0)
                        this.Text = "";
                    else
                        this.Text = $"{count}";
                    if (this.Enabled == true)
                    {
                        form1.addScore();
                    }
                    
                    this.BackColor = Color.LightGray;
                    this.solved = true;
                    this.Enabled = false;
                }
            }
        }

        public void Set_Flag(ref int Left)
        {
            if (this.Text != "Flag" && Enabled == true)
            {
                this.BackColor = Color.Red;
                this.Text = "Flag";
                Left = Left - 1;
            }
            else if (this.Text == "Flag" && Enabled == true)
            {
                this.BackColor = Color.FromArgb(212, 225, 225, 225);
                this.Text = "";
                Left = Left + 1;
            }
        }
    }
}