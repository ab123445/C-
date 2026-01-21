using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Snake0114
{
    internal class Food: Label
    {
        public int food_x;
        public int food_y;
        public Food(Control.ControlCollection Controls, int x, int y)
        {
            this.AutoSize = false;
            this.Location = new Point(x * Snake.X + 5, MainForm.MENU_HEIGHT + y * Snake.Y + 5);
            this.Name = "lblFood";
            this.Size = new Size(20, 20);
            this.TabIndex = 7;
            this.Text = "";
            this.BackColor = SystemColors.Desktop;
            this.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(this);
            food_x = x;
            food_y = y;
        }
    }
}
