using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Snake0114
{
    internal class Food: Label
    {
        int[] food_pos;
        public Food(Control.ControlCollection Controls, int x, int y)
        {
            Label @this = new();
            @this.AutoSize = false;
            @this.Location = new Point(x + 5, y + 5);
            @this.Name = "lblFood";
            @this.Size = new Size(20, 20);
            @this.TabIndex = 7;
            @this.Text = "";
            @this.BackColor = SystemColors.Desktop;
            @this.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(@this);
            food_pos = [x, y];
        }
        public bool Reach(Snake snake)
        {
            int[] snake_pos = [snake.getX(), snake.getY()];
            if (snake_pos == food_pos)
            {
                return true;
            }
            else
                return false;
        }
    }
}
