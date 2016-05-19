﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Saavedra_Carlos_Gol_B
{
    public partial class Form1 : Form
    {
        const int rows = 90;
        const int columns = 90;
        bool[,] Universe = new bool[rows, columns];
        bool[,] scratchPad = new bool[rows, columns];
        Timer uTime = new Timer();
        int generationX = 0;

        public Form1()
        {
            InitializeComponent();
            uTime.Tick += T_Tick;
            Universe = new bool[rows, columns];
            scratchPad = new bool[rows, columns];
        }

       

        private void gPanel_Paint(object sender, PaintEventArgs e)
        {
            // GridFrame(e);
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            Pen p = new Pen(Color.Gray, 1.0f);

            Font font = new Font("Arial", 5.0f);

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
                    if (Universe[cX,cY] == true)
                    {
                        if (countNegh == 2 || countNegh == 3)
                        { scratchPad[cX, cY] = true; }
                        else
                        { scratchPad[cX, cY] = false; }
                        
                    }
                   else
                    {
                        if (countNegh == 3)
                        { scratchPad[cX, cY] = true; }
                        else
                        { scratchPad[cX, cY] = false; }

                    }


                }
            }


            // Swap them...
            bool[,] temp = Universe;
            Universe = scratchPad;
            scratchPad = temp;
            scratchPad = new bool[rows, columns];
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = 0; y <= Universe.GetLength(1)-1; y++)
            {
                for (int x = 0; x <= Universe.GetLength(0)-1; x++)
                {
                    Universe[x, y] = false;
                }     
            }
            generationX = 0;
            labelGenerations.Text = "Generations: " + generationX.ToString();
            gPanel.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            //Call next generation
            generationX++;
            NextGeneration();
            labelGenerations.Text = "Generations: " + generationX.ToString();
            // ?? show
             gPanel.Invalidate();
        }
        private void playButton_Click(object sender, EventArgs e)
        {
            uTime.Interval = 100;
            uTime.Enabled = true;
           // uTime.Tick += T_Tick;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            uTime.Enabled = false;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            NextGeneration();
            gPanel.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Application.StartupPath;
            // Set up some filters to narrow down what file types we can save as
            save.Filter = ".cell (cell files) |*.cell";

            // This will open the standard "save" window
            if (save.ShowDialog() == DialogResult.OK)
            {
                // Associate a stream with the filename they used
               // FileStream stream = new FileStream(save.FileName, FileMode.Create);
                StreamWriter writer = new StreamWriter(save.FileName);
                StringBuilder tempStr = new StringBuilder();
                for (int i = 0; i < Universe.GetLength(1); i++)
                {
                    for (int j = 0; j < Universe.GetLength(0); j++)
                    {
                        if (Universe[i, j] == true)
                        { tempStr.Append('O'); }
                        else
                        { tempStr.Append('.'); }
                    }
                    
                }
                writer.WriteLine(tempStr);
                writer.Close();
                //stream.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
