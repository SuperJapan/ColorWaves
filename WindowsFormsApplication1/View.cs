using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class View
    {
        DataGridView dataGridView;

        public View(DataGridView _dataGridView, int _widthDataGrid, int _heightDataGrid, int _cellWidth, int _cellHeight)
        {
            dataGridView = _dataGridView;
            
            createDataGrid(_widthDataGrid, _heightDataGrid, _cellWidth, _cellHeight);
        }
        
        private void createDataGrid(int _widthDataGrid, int _heightDataGrid, int cellWidth, int cellHeight)
        {
            dataGridView.ColumnCount = _widthDataGrid;            
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.RowHeadersVisible = false;
            dataGridView.ShowCellToolTips = false;
            dataGridView.MultiSelect = false;
            dataGridView.Dock = DockStyle.Fill;
            
            //Utils.wl("_widthDataGrid:" + _widthDataGrid + " _heightDataGrid" + _heightDataGrid + " cellWidth:" + cellWidth + " cellHeight:" + cellHeight);

            for (int y = 0; y < _heightDataGrid; y++)
            {
                dataGridView.Rows.Add();
                for (int x = 0; x < _widthDataGrid; x++)
                {
                    dataGridView.Columns[x].Width = cellWidth;
                    dataGridView.Rows[y].Height = cellHeight;
                    dataGridView.Rows[y].Cells[x].Value = " ";                   
                }
            }
        }
    }
}
