using System;
using System.Collections.Generic;
using System.Text;

namespace Snake0114
{
    internal class Item
    {
        public int item_x;
        public int item_y;
        protected Label lblitem = new();
        public Item(Control.ControlCollection Controls, int x, int y, MainForm main)
        {
            lblitem.AutoSize = false;
            lblitem.Location = new Point(x * Snake.X, main.menuStrip1.Height + y * Snake.Y);
            lblitem.Name = "lblitem";
            lblitem.Size = new Size(Snake.X, Snake.Y);
            lblitem.TabIndex = 7;
            lblitem.Text = ":";
            lblitem.BackColor = Color.Black;
            lblitem.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblitem);
            item_x = x;
            item_y = y;
        }

        public virtual void OnEat(MainForm main)
        {
        }

        public Label GetLabel()
        {
            return lblitem;
        }

    }
}
