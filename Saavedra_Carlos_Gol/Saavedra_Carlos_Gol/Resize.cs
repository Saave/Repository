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

    public partial class Resize : Form
    {
        int[] gridRC = {18,18};
       // bool isOpen = false;
        public int[] GridRC
        {
            get
            {
                return gridRC;
            }

            set
            {
                gridRC[1] = (int)rowsNUD.Value;
                gridRC[0] = (int)columnsNUD.Value;
            }
           
        }

        public Resize()
        {
            InitializeComponent();
           // isOpen = true;

        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            gridRC[1] = (int)rowsNUD.Value;
            gridRC[0] = (int)columnsNUD.Value;
            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            gridRC[1] = (int)rowsNUD.Value;
            gridRC[0] = (int)columnsNUD.Value;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
