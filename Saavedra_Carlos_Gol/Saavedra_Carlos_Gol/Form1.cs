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
       // bool isRunning;

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
           // Pen p = new Pen(Color.Black, 2.0f);
             
            // Grid Drawing variables this segments needs to add approx +1 to draw one more line "Frame"
           float segmentX = ((float)gPanel.Width/ (float)resizeGrid.GridRC[1]);
           float segmentY = (((float)gPanel.Height-75.00f) / (float)resizeGrid.GridRC[0]);
           float x = 2.00f;
           float y = 50.00f;
           // square position X and Y
           xSqCoord = new float[resizeGrid.GridRC[1]];
           ySqCoord = new float[resizeGrid.GridRC[0]];
           
            //cell number
            cellCount = resizeGrid.GridRC[1] * resizeGrid.GridRC[0];
            
            int bCount = 0;

            
            //columns
            for (int i = 0; i < (int)resizeGrid.GridRC[1]; i++)
            {
             
             // e.Graphics.DrawLine(p, x, 0, x, gPanel.Height);
              
              xSqCoord[i] = x;
                x += segmentX;
            }
           //rows
           for (int j = 0; j < (int)resizeGrid.GridRC[0]; j++)
           {
                   //e.Graphics.DrawLine(p, 0, y, gPanel.Width, y);
                   
                   ySqCoord[j] = y;
                   y += segmentY;
           }

            // passing values  

            for (int cX = 0; cX < resizeGrid.GridRC[1]; cX++)
            {

                for (int cY = 0; cY < resizeGrid.GridRC[0]; cY++)
                {
                    cell = new Celula(xSqCoord[cX], ySqCoord[cY], segmentX, segmentY, Color.Gray, false);
                    cellList.Add(cell);
                    bCount++;
                    // SolidBrush colorBrush = new SolidBrush(cell.CellColor);
                    // e.Graphics.FillRectangle(colorBrush, cell.CellPositionX, cell.CellPositionY, cell.CellSizeX, cell.CellSizeY);
                }
            }


            GridFrame(e);
            DrawGrid(e);
            gPanel.Invalidate();
        }

        // Step one: Draw the frame
        void GridFrame(PaintEventArgs e)
        {

            DrawCell(e);
            Pen fPen = new Pen(Color.Black, 5.0f);
            e.Graphics.DrawLine(fPen, 0, 49, gPanel.Width,49);
            e.Graphics.DrawLine(fPen, 0, gPanel.Height - 24, gPanel.Width, gPanel.Height - 24);
            e.Graphics.DrawLine(fPen, 0, 49, 0, gPanel.Height - 24);
            e.Graphics.DrawLine(fPen, gPanel.Width-2, 49, gPanel.Width-2, gPanel.Height - 24);

        }

        void DrawGrid(PaintEventArgs e)
        {
            for (int i = 0; i < resizeGrid.GridRC[1]; i++)
            {
                Pen gPen = new Pen(Color.Black, 2.0f);
                e.Graphics.DrawLine(gPen, xSqCoord[i], 0, xSqCoord[i], gPanel.Height);
               

            }
           for (int j = 0; j < resizeGrid.GridRC[0]; j++)
           {
               Pen gPen = new Pen(Color.Black, 2.0f);
               e.Graphics.DrawLine(gPen, 0, ySqCoord[j], gPanel.Width, ySqCoord[j]);
           }
        }
        void DrawCell(PaintEventArgs e)
        {
            foreach (Celula cell in cellList)

            {

                if (cell.IsAlive)
                {
                    SolidBrush colorBrush = new SolidBrush(cell.CellColor);
                    e.Graphics.FillRectangle(colorBrush, cell.CellPositionX , 
                    cell.CellPositionY, cell.CellSizeX, cell.CellSizeY );

                }
                else
                   
                {
                    SolidBrush colorBrush = new SolidBrush(cell.CellColor);
                    e.Graphics.FillRectangle(colorBrush, cell.CellPositionX,
                    cell.CellPositionY , cell.CellSizeX, cell.CellSizeY);

                }

               
            }
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
            for (int i = 0; i < cellList.Count; i++)
            {

                if (MousePosition.X >= cellList[i].CellPositionX && MousePosition.X <= (cellList[i].CellPositionX + cellList[i].CellSizeX))
                {
                    if (cell.IsAlive)
                    {

                        cell.IsAlive = false;
                        cell.CellColor = Color.Gray;
                    }
                    else
                        cell.IsAlive = true;
                    cell.CellColor = Color.Green;
                }

            }
            gPanel.Invalidate();

        }

        private void gPanel_Click(object sender, EventArgs e)
        {
           
        }
    }
}
