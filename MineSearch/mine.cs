using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MineSearch
{
    public delegate void MineClick(object sender, MouseEventArgs e);
    public class Mine : Button
    {
        public const int X = 60;
        public const int Y = 60;
        bool IsMine;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Idx_Y { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Idx_X { get; set; }

        public Mine(int x, int y, MineClick click)
        {
            this.Tag = this;
            Idx_Y = y;
            Idx_X = x;
            this.Location = new Point(x*X, y*Y + Form1.MENU_HIGHT);
            this.Name = "btnMine";
            this.Size = new Size(X, Y);
            this.TabIndex = 0;
            this.Text = "";
            this.UseVisualStyleBackColor = true;
            this.MouseDown += new MouseEventHandler(click);
            
        }

        public void GetMine()
        {
            int random;
            Random rand = new();
            random = rand.Next(0, 100);
            if (random > 70)
                IsMine = true;
            else
                IsMine = false;
        }

        public void Text_Change()
        {
            if (this.Text != "Flag")
            {
                if (IsMine == false)
                {
                    this.Text = "X";
                    this.BackColor = Color.FromArgb(212, 225, 225, 225);
                }
                if (IsMine == true)
                {
                    this.Text = "O";
                    this.BackColor = Color.FromArgb(212, 225, 225, 225);
                }
                this.Enabled = false;
            }
        }
        public void Set_Flag()
        {
            if (this.Text != "Flag")
            {
                this.BackColor = Color.Red;
                this.Text = "Flag";
            }
            else
            {
                this.BackColor = Color.FromArgb(212, 225, 225, 225);
                this.Text = "";
            }
                

        }
    }
}
