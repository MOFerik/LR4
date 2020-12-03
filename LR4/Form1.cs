using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class CCircle
        {
            public int x;
            public int y;
            public int r = 30;
            public bool flag;
        }

        public class CircleStorage
        {
            public CCircle[] arr = new CCircle[1000];
            public int i = 0;

            public bool Check(int x, int y)
            {
                for (int j = 0; j < this.i; j++)
                {
                    if (x > this.arr[j].x - 15 && x < this.arr[j].x + 15 && y > this.arr[j].y - 15 && y < this.arr[j].y + 15)
                    {
                        this.arr[j].flag = true;
                        return true;
                    }
                }
                return false;
            }

            public void AddStor(CCircle circ)
            {
                if (i < 1000)
                {
                    arr[i] = circ;
                    i++;
                }
                else
                    return;
            }
        }

        CircleStorage stor = new CircleStorage();

        Pen mPen = new Pen(Color.Black, 3);
        Pen aPen = new Pen(Color.Red, 3);
        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (stor.Check(e.X, e.Y))
            {
                if (stor.i > 0)
                    for (int j = 0; j < stor.i; j++)
                    {
                        if (stor.arr[j].flag)
                        {
                            Rectangle rect = new Rectangle(stor.arr[j].x - 15, stor.arr[j].y - 15, 30, 30);
                            panel1.CreateGraphics().DrawEllipse(aPen, rect);
                        }
                        else
                        {
                            Rectangle rect = new Rectangle(stor.arr[j].x - 15, stor.arr[j].y - 15, 30, 30);
                            panel1.CreateGraphics().DrawEllipse(mPen, rect);
                        }
                    }
            }
            else
            {
                CCircle circ = new CCircle();
                circ.x = e.X;
                circ.y = e.Y;
                stor.AddStor(circ);
                if (stor.i > 0)
                    for (int j = 0; j < stor.i; j++)
                    {
                        if (stor.arr[j].flag)
                        {
                            Rectangle rect = new Rectangle(stor.arr[j].x - 15, stor.arr[j].y - 15, 30, 30);
                            panel1.CreateGraphics().DrawEllipse(aPen, rect);
                        }
                        else
                        {
                            Rectangle rect = new Rectangle(stor.arr[j].x - 15, stor.arr[j].y - 15, 30, 30);
                            panel1.CreateGraphics().DrawEllipse(mPen, rect);
                        }
                    }
            }
        }
    }
}
