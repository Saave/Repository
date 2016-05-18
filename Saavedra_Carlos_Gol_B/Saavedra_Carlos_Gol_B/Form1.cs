using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saavedra_Carlos_Gol_B
{
    public partial class Form1 : Form
    {
        bool[,] Universe = new bool[10, 10];
        bool[,] scratchPad = new bool[10, 10];
        Timer utime = new Timer();
        int generationX = 0;

        public Form1()
        {
            InitializeComponent();
        }

       

        private void gPanel_Paint(object sender, PaintEventArgs e)
        {
            // GridFrame(e);
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            Pen p = new Pen(Color.Black, 2.0f);

            Font font = new Font("Arial", 10.0f);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            float cellWidth = ((float)gPanel.Width / (float)Universe.GetLength(0));
            float cellHeight = ((float)gPanel.Height / (float)Universe.GetLength(1));

            for (int cX = 0; cX < Universe.GetLength(0); cX++)
            {

                for (int cY = 0; cY < Universe.GetLength(1); cY++)
                {

                    float x = (float)cX * cellWidth;
                    float y = (float)cY * cellHeight;
                    

                    // Color the cell:
                    if (Universe[cX, cY])
                    {
                        e.Graphics.FillRectangle(greenBrush, x, y, cellWidth, cellHeight);
                    }
                    else
                    {

                    }

                    // Draw Grid
                    e.Graphics.DrawRectangle(p, x, y, cellWidth, cellHeight);


                    int neigbors = CountNeibors(cX, cY);

                    e.Graphics.DrawString(neigbors.ToString(), font, Brushes.Black,
                        new RectangleF(x, y, cellWidth, cellHeight), stringFormat);

                }
            }
        }
        void NextGeneration()
        {
            for (int cX = 0; cX < Universe.GetLength(0); cX++)
            {

                for (int cY = 0; cY < Universe.GetLength(1); cY++)
                {
                    int countNegh = CountNeibors(cX, cY);
                    //dont change anything in the universe but turn tings on the scretch pad


                }
            }


            // Swap them...
            bool[,] temp = Universe;
            Universe = scratchPad;
            scratchPad = temp;
            // i also need to clean the scratchPad nested loop averything to false


        }

        int CountNeibors(int x, int y)
        {
            int count = 0;
            int tX = 0;
            int tY = 0;

            // TXX
            // XOX
            // XXX

            tX = x - 1;
            tY = y - 1;
            if (tX >= 0)
            {
                if (tY >= 0)
                {
                    //count needs to return just alive cells
                    if (Universe[tX, tY])
                    {
                        count++;
                    }
                }
            }

            //XTX
            //X0X
            //XXX
            tX = x;
            tY = y - 1;
            if (tX >= 0)
            {
                if (tY >= 0)
                {
                    if (Universe[tX, tY] == true)
                    {
                        count++;
                    }
                }
            }
        
            //XXT
            //X0X
            //XXX
            tX = x + 1;
            tY = y - 1;
            if (tX < Universe.GetLength(0))
            {
                if (tY >= 0)
                {
                    if (Universe[tX, tY] == true)
                    {
                        count++;
                    }
                }
            }

            //XXX
            //T0X
            //XXX

            tX = x - 1;
            tY = y;
            if (tX >= 0)
            {
                if (tY >= 0)
                {
                    if (Universe[tX, tY] == true)
                    {
                        count++;
                    }
                }
            }

            //XXX
            //X0T
            //XXX

            tX = x + 1;
            tY = y;
            if (tX < Universe.GetLength(0))
            {
                if (tY >= 0)
                {
                    if (Universe[tX, tY] == true)
                    {
                        count++;
                    }
                }
            }

            //XXX
            //X0X
            //TXX

            tX = x - 1;
            tY = y + 1;
            if (tX >= 0)
            {
                if (tY < Universe.GetLength(1))
                {
                    if (Universe[tX, tY] == true)
                    {
                        count++;
                    }
                }
            }

            //XXX
            //X0X
            //XTX

            tX = x;
            tY = y + 1;
            if (tX >= 0)
            {
                if (tY < Universe.GetLength(1))
                {
                    if (Universe[tX, tY] == true)
                    {
                        count++;
                    }
                }
            }


            // XXX
            // XOX
            // XXT

            tX = x + 1;
            tY = y + 1;
            if (tX < Universe.GetLength(0)) //GetLength is a function
            {
                if (tY < Universe.GetLength(1))
                {
                    //count needs to return just alive cells
                    if (Universe[tX, tY])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private void gPanel_MouseClick(object sender, MouseEventArgs e)
        {
            float cellWidth = ((float)gPanel.Width / (float)Universe.GetLength(0));
            float cellHeight = ((float)gPanel.Height / (float)Universe.GetLength(1));

            //indexer of the 2d array
            int x = (int)((float)e.X / cellWidth);
            int y = (int)((float)e.Y / cellHeight);

            // toggles the cell on/off
            Universe[x, y] = !Universe[x, y];

            gPanel.Invalidate();
           

        }


    }
}
