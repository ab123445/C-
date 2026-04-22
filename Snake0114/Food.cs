using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Snake0114
{
    public class Food: Label
    {
        public int food_x;
        public int food_y;
        public Food(Control.ControlCollection Controls, int x, int y)
        {
            this.AutoSize = false;
            this.Location = new Point(x, y);
            this.Name = "lblFood";
            this.Size = new Size(20, 20);
            this.TabIndex = 7;
            this.Text = "";
            this.BackColor = Color.Brown;
            this.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(this);
            food_x = x;
            food_y = y;
        }
    }
}
