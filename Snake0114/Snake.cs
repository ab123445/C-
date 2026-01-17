using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Snake0114
{
    internal class Snake
    {
        Label lblHead = new();
        public Snake(Control.ControlCollection Controls)
        {
            lblHead.AutoSize = false;
            lblHead.Location = new Point(380, 177);
            lblHead.Name = "lblHead";
            lblHead.Size = new Size(30, 30);
            lblHead.TabIndex = 7;
            lblHead.Text = ":";
            lblHead.BackColor = SystemColors.ActiveCaption;
            lblHead.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblHead);
        }
        public void moveX(int X)
        {
            lblHead.Left += X;
        }
        public void moveY(int Y)
        {
            lblHead.Top += Y;
        }
    }
}
