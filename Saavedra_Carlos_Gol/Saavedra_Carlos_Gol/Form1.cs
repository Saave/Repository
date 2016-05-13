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

        Celula cell;
        Resize resizeGrid;
        List<Celula> cellList;
        int cellCount;
        bool isRunning;

        float[] xSqCoord;
        float[] ySqCoord;

        public Form1()
        {
            InitializeComponent();
            resizeGrid = new Resize();
            cellList = new List<Celula>();
            gPanel.Invalidate();
        }



        //grid drawing
        private void gPanel_Paint(object sender, PaintEventArgs e)
        {


            GridFrame(e);
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            Pen p = new Pen(Color.Black, 1.0f);
            
            // Grid Drawing variables this segments needs to add approx +1 to draw one more line "Frame"
            float segmentX = ((float)gPanel.Width/ (float)resizeGrid.GridRC[1]);
           float segmentY = (((float)gPanel.Height-75.00f) / (float)resizeGrid.GridRC[0]);
           float x = 3.00f;
           float y = 50.00f;
           // square position X and Y
           xSqCoord = new float[resizeGrid.GridRC[1]];
           ySqCoord = new float[resizeGrid.GridRC[0]];

            //cell number
            cellCount = resizeGrid.GridRC[1] * resizeGrid.GridRC[0];


           //columns
            for (int i = 0; i < (int)resizeGrid.GridRC[1]; i++)
            {
             
              e.Graphics.DrawLine(p, x, 0, x, gPanel.Height);
              
              xSqCoord[i] = x;
                x += segmentX;
            }
           //rows
           for (int j = 0; j < (int)resizeGrid.GridRC[0]; j++)
           {
                   e.Graphics.DrawLine(p, 0, y, gPanel.Width, y);
                   
                   ySqCoord[j] = y;
                y += segmentY;
           }

           // passing values  
              
            for (int cX = 0; cX < resizeGrid.GridRC[1]; cX++)
            {

                for (int cY = 0; cY < resizeGrid.GridRC[0]; cY++)
                {
                    cell = new Celula(xSqCoord[cX]+.5f,ySqCoord[cY]-.5f,segmentX-1,segmentY-1,Color.GreenYellow,false);
                    cellList.Add(cell);
                    //e.Graphics.FillRectangle(greenBrush, xSqCoord[cX] + .5f, ySqCoord[cY] + .5f, segmentX - 1, segmentY - 1);
                }
            }



         


            gPanel.Invalidate();
        }

        // Step one: Draw the frame
        void GridFrame(PaintEventArgs e)
        {
            Pen fPen = new Pen(Color.Black, 5.0f);
            e.Graphics.DrawLine(fPen, 0, 49, gPanel.Width,49);
            e.Graphics.DrawLine(fPen, 0, gPanel.Height - 24, gPanel.Width, gPanel.Height - 24);
            e.Graphics.DrawLine(fPen, 0, 49, 0, gPanel.Height - 24);
            e.Graphics.DrawLine(fPen, gPanel.Width, 49, gPanel.Width, gPanel.Height - 24);

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

        private void gPanel_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
