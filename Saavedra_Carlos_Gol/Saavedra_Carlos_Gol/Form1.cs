using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saavedra_Carlos_Gol
{
    public partial class Form1 : Form
    {


        Resize resizeGrid;
        


        public Form1()
        {
            InitializeComponent();
            resizeGrid = new Resize();
        }




        private void gPanel_Paint(object sender, PaintEventArgs e)
        {

           


            Pen p = new Pen(Color.Black, 1.0f);

            float rowNumber = (((int)gPanel.Height-72) / (int)resizeGrid.GridRC[1]);
            float columnNumber = ((int)gPanel.Width / (int)resizeGrid.GridRC[0]);
            // columns
            for (float x = 1; x <= (float)gPanel.Width+1 ; x += columnNumber)
            {
                // menu, toolstrip, statusbar 24,25 top & 24 bot
                e.Graphics.DrawLine(p, x,50, x, gPanel.Height-24);
            
            }
            // raws
            for (float y = 50; y < gPanel.Height - 24; y += rowNumber)
            {
                e.Graphics.DrawLine(p, 0, y, gPanel.Width+1, y);

            }
            gPanel.Invalidate();


        }








        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void runToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resizeGrid = new Resize();
            resizeGrid.ShowDialog();
            //gPanel.Invalidate();
        }
    }
}
