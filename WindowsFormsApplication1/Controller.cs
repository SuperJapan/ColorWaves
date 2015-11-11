using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Controller
    {
        private Model model;

        public Controller(DataGridView dataGridView, Model _model)
        {
            model = _model;
            dataGridView.CellMouseClick += (object sender, DataGridViewCellMouseEventArgs e) => 
            {
                model.addWave(e.ColumnIndex, e.RowIndex);
            };
        }
    }
}
