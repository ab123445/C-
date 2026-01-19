using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Snake0114
{
    internal class Snake
    {
        public const int X = 30;
        public const int Y = 30;
        Label lblHead = new();
        public Snake(Control.ControlCollection Controls, int x, int y)
        {
            lblHead.AutoSize = false;
            lblHead.Location = new Point(x, y);
            lblHead.Name = "lblHead";
            lblHead.Size = new Size(X, Y);
            lblHead.TabIndex = 7;
            lblHead.Text = ":";
            lblHead.BackColor = SystemColors.ActiveCaption;
            lblHead.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblHead);
        }
        public void moveX(int x)
        {
            lblHead.Left += x;
        }
        public void moveY(int y)
        {
            lblHead.Top += y;
        }
    }
}
