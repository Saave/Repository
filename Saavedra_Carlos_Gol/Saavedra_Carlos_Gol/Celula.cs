using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Saavedra_Carlos_Gol
{
    class Celula
    {
        float cellPositionX;
        float cellPositionY;
        float cellSizeX;
        float cellSizeY;
        Color cellColor;
        bool isAlive;

        public Celula(float _cellPositionX, float _cellPositionY, float _cellSizeX, float _cellSizeY, Color _cellColor, bool _isAlive)
        {
            this.CellPositionX = _cellPositionX;
            this.CellPositionY = _cellPositionY;
            this.CellSizeX = _cellSizeX;
            this.CellSizeY = _cellSizeY;
            this.cellColor = _cellColor;
            this.isAlive = _isAlive;
        }

        public float CellPositionX
        {
            get
            {
                return cellPositionX;
            }

            set
            {
                cellPositionX = value;
            }
        }

        public float CellPositionY
        {
            get
            {
                return cellPositionY;
            }

            set
            {
                cellPositionY = value;
            }
        }

        public float CellSizeX
        {
            get
            {
                return cellSizeX;
            }

            set
            {
                cellSizeX = value;
            }
        }

        public float CellSizeY
        {
            get
            {
                return cellSizeY;
            }

            set
            {
                cellSizeY = value;
            }
        }

        public Color CellColor
        {
            get
            {
                return cellColor;
            }

            set
            {
                cellColor = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                return isAlive;
            }

            set
            {
                isAlive = value;
            }
        }

        public void CellBehavior(bool _doa)
        {
            this.IsAlive = _doa;
            if (_doa)
            { CellColor = Color.Green; }
            else
            { CellColor = Color.Gray; }
            

        }

    }
}
