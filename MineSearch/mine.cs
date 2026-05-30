using System;
using System.Collections.Generic;
using System.Text;

namespace MineSearch
{
    public delegate void MineClick(object sender, MouseEventArgs e);
    public class Mine : Button
    {
        public const int X = 60;
        public const int Y = 60;
        bool IsMine;
        
        public Mine(int x, int y, int random, MineClick click)
        {
            this.Tag = this;

            this.Location = new Point(x*X, y*Y);
            this.Name = "btnMine";
            this.Size = new Size(X, Y);
            this.TabIndex = 0;
            this.Text = "";
            this.UseVisualStyleBackColor = true;
            Color Default_color = this.BackColor;
            this.MouseDown += new MouseEventHandler(click);
            
            if (random > 70)
                IsMine = true;
            else
                IsMine = false;
        }

        public void Text_Change()
        {
            if (IsMine == false)
                this.Text = "X";
            if (IsMine == true)
                this.Text = "O";

            //this.Enabled = false;
        }
        public void Set_Flag()
        {
            if (this.BackColor != Color.Red)
                this.BackColor = Color.Red;
            //else
            //    this.BackColor;
        }
    }
}
