using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Snake0114
{
    internal class Food
    {
        Label lblFood = new();
        Random rand = new();
        public Food(Control.ControlCollection Controls)
        {
            lblFood.AutoSize = false;
            int[] pos = [rand.Next(0, 816), rand.Next(0, 489)]; 
            lblFood.Location = new Point(pos[0], pos[1]);
            lblFood.Name = "lblFood";
            lblFood.Size = new Size(30, 30);
            lblFood.TabIndex = 7;
            lblFood.Text = "";
            lblFood.BackColor = SystemColors.Desktop;
            lblFood.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblFood);
        }
    }
}
