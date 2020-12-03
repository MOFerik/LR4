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
        }

        public class CircleStorage
        {
            public CCircle[] arr = new CCircle[1000];
            public int i = 0;
            int selected = 0;

            public void AddStor(CCircle circ)
            {
                if (i < 1000)
                {
                    arr[i] = circ;
                    selected = i;
                    i++;
                }
                else
                    return;
            }
        }

        CircleStorage stor = new CircleStorage();

        Pen persPen = new Pen(Color.Black, 3);
        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            CCircle circ = new CCircle();
            circ.x = e.X;
            circ.y = e.Y;
           // Pen pen = new Pen(Color.Blue);
           // Rectangle rect = new Rectangle(e.X - 15, e.Y - 15, 30, 30);
           // panel1.CreateGraphics().DrawEllipse(persPen, rect);
            stor.AddStor(circ);
            if (stor.i > 0)
                for (int j = 0; j < stor.i; j++)
                {
                    Pen pen = new Pen(Color.Blue);
                    Rectangle rect = new Rectangle(stor.arr[j].x - 15, stor.arr[j].y - 15, 30, 30);
                    panel1.CreateGraphics().DrawEllipse(persPen, rect);
                }
        }
    }
}
