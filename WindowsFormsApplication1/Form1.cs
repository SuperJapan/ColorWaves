using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ColorWaves : Form
    {
        public ColorWaves()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startProgram();
        }

        private void startProgram()
        {
            int widthDataGrid = 30;
            int heightDataGrid = 30;
            int cellWidth = 15;
            int cellHeight = 15;
            int speed = 500;

            View view = new View(this.dataGridView1, widthDataGrid, heightDataGrid, cellWidth, cellHeight);
            Model model = new Model(this.dataGridView1, speed);
            Controller cntrl = new Controller(this.dataGridView1, model);            
        }
    }
}
