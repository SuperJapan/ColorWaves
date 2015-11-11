using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Wave
    {
        private List<Color> colors = new List<Color>() { Color.Blue, Color.Red, Color.Yellow, Color.Green, Color.Pink, Color.Gray, Color.Gold, Color.Lime, Color.Magenta };
        
        private int cellFirstPosX = 0;
        private int cellFirstPosY = 0;
        DataGridView dataGridView;

        private static int wavesCount = 0;
        private Color cellColor;
        
        private int stepNum = 0;
        private List<int> colorCellXList = new List<int>();
        private List<int> colorCellYList = new List<int>();

        public Wave(int posX, int posY, DataGridView _dataGridView)
        {
            cellFirstPosX = posX;
            cellFirstPosY = posY;
            dataGridView = _dataGridView;
            
            cellColor = Utils.getRandomeColor(colors);
                        
            createMatrix();
            updateMatrix(0);
        }

        int gridWidth = 0;
        int gridHeight = 0;

        private void createMatrix()
        {
            gridWidth = dataGridView.ColumnCount;
            gridHeight = dataGridView.RowCount;
            
            for(int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    colorCellXList.Add(0);
                    colorCellYList.Add(0);
                    
                    if (x == cellFirstPosX && y == cellFirstPosY)
                    {
                        colorCellXList[x] = 1;
                        colorCellYList[y] = 1;
                    }
                }
            }            
        }

        private void updateMatrix(int stepNum)
        {
            List<int> _colorCellXList = colorCellXList.ToList();
            List<int> _colorCellYList = colorCellYList.ToList();
            
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    if (_colorCellXList[x] == 1 && _colorCellYList[y] == 1)
                    {
                        if (x - 1 >= 0) colorCellXList[x - 1] = 1;
                        if (x + 1 < gridWidth) colorCellXList[x + 1] = 1;
                        if (y - 1 >= 0) colorCellYList[y - 1] = 1;
                        if (y + 1 < gridHeight) colorCellYList[y + 1] = 1;
                    }
                }
            }
        }

        public bool isComplete = false;
        public void updateWave()
        {
            //Utils.wl("updateWave color:"+cellColor);
            updateMatrix(stepNum);
            
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    if (colorCellXList[x] == 1 && colorCellYList[y] == 1)
                    {
                        dataGridView.Rows[y].Cells[x].Style.BackColor = cellColor;
                    }
                }
            }

            stepNum++;
            if (stepNum > gridHeight)
                isComplete = true;
        }
    }
}
