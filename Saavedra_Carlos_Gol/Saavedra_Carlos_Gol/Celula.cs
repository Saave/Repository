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
        Color cellColor;
        float cellPositionX;
        float cellPositionY;
        float cellSizeX;
        float cellSizeY;
        bool isAlive;

        public Celula(float _cellPositionX, float _cellPositionY, float _cellSizeX, float _cellSizeY, Color _cellColor, bool _isAlive)
        {
            this.cellPositionX = _cellPositionX;
            this.cellPositionY = _cellPositionY;
            this.cellSizeX = _cellSizeX;
            this.cellSizeY = _cellSizeY;
            this.cellColor = _cellColor;
            this.isAlive = _isAlive;
        }

        public void CellBehavior(bool _doa)
        {
            isAlive = _doa;
            if (_doa)
            { cellColor = Color.Green; }
            else
            { cellColor = Color.Gray; }


        }


    }
}
