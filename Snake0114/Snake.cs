using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace Snake0114
{
    internal class Snake
    {
        public const int X = 30;
        public const int Y = 30;
        Label lblHead = new();
        List<Label> lblBodies = new List<Label>();
        List<Point> MovingLine = new List<Point>();


        public Snake(Control.ControlCollection Controls, int x, int y, MainForm main)
        {
            lblHead.AutoSize = false;
            lblHead.Location = new Point(x * X, main.menuStrip1.Height + y * Y);
            lblHead.Name = "lblHead";
            lblHead.Size = new Size(X, Y);
            lblHead.TabIndex = 7;
            lblHead.Text = ":";
            lblHead.BackColor = SystemColors.ActiveCaption;
            lblHead.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblHead);
        }
        public void MakeBody(Control.ControlCollection Controls, int x, int y, MainForm main)
        {
            Label lblBody = new();
            lblBody.AutoSize = false;
            lblBody.Location = new Point(x * X, main.menuStrip1.Height + y * Y);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(X, Y);
            lblBody.TabIndex = 7;
            lblBody.Text = "";
            lblBody.BackColor = SystemColors.ActiveCaption;
            lblBody.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblBody);
            lblBodies.Add(lblBody);
        }

        public void Reset(Control.ControlCollection Controls)
        {
            for (int i = lblBodies.Count - 1; i >= 0; i--)
            {
                lblBodies[i].Dispose();
                Controls.Remove(lblBodies[i]);
                lblBodies.Remove(lblBodies[i]);
            }
            lblHead.Dispose();
            Controls.Remove(lblHead);
            //lblBodies.Clear();
            
        }
        public bool ReachBorder(MainForm main)
        {
            if (lblHead.Top < 0 || lblHead.Left < 0
                || lblHead.Top > MainForm.MAX_HEIGHT * Y + main.menuStrip1.Height || lblHead.Left > MainForm.MAX_WIDTH * X)
            {
                return true;
            }
            return false;
        }
        public void moveBody()
        {
            MovingLine.Add(lblHead.Location);
            for (int i = MovingLine.Count - lblBodies.Count - 1; i >= 0; i--)
            {
                MovingLine.Remove(MovingLine[i]);
            }
            for (int i = 0; i < lblBodies.Count; i++)
            {
                lblBodies[i].Location = MovingLine[i];
            }
        }

        public List<Point> GetBody()
        {
            return MovingLine;
        }

        public void moveX(int x)
        {
            lblHead.Left += x;
        }
        public void moveY(int y)
        {
            lblHead.Top += y;
        }
        public bool ReachFood(Food food, MainForm main)
        {
            if (lblHead.Left == food.food_x * Snake.X &&
                lblHead.Top == food.food_y * Snake.Y + main.menuStrip1.Height)
            {
                return true;
            }
            else
                return false;
        }

        public bool ReachItem(Item item, MainForm main)
        {
            if (lblHead.Left == item.item_x * Snake.X &&
                lblHead.Top == item.item_y * Snake.Y + main.menuStrip1.Height)
            {
                return true;
            }
            else
                return false;
        }

        public bool ReachWall(Label wall)
        {
            if (lblHead.Location == wall.Location)
            {
                return true;
            }
            return false;
        }
        public bool ReachBody()
        {
            for (int i = 0; i < lblBodies.Count; i++)
            {
                if (lblHead.Location == lblBodies[i].Location)
                {
                    return true;
                }
            }
            return false;
        }
        public void ShortenTail(Control.ControlCollection Controls)
        {
            var last = lblBodies[lblBodies.Count - 1];
            Controls.Remove(last);
            lblBodies.Remove(last);

            last.Dispose();
            
        }
        public int GetBodies()
        {
            return lblBodies.Count;
        }
    }
}
