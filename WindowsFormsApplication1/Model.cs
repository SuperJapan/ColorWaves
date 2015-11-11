using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Model
    {
        DataGridView dataGridView;

        public Model(DataGridView _dataGridView, int speed)
        {
            dataGridView = _dataGridView;
            
            start(speed);
        }

        private void start(int speed)
        {
            Timer timer = new Timer();
            timer.Tick += (object sender, EventArgs e) => { updateTimer(); };
            timer.Interval = speed;
            timer.Start();
        }
        
        private void updateTimer()
        {
            if (isExistWave)
            {
                Wave wComplete = null;
                foreach(Wave w in waveList)
                {
                    w.updateWave();

                    if (w.isComplete) 
                        wComplete = w;
                }
                
                if (wComplete != null) 
                    waveList.Remove(wComplete);
            }
        }
        
        
        
        private List<Wave> waveList = new List<Wave>();
        private bool isExistWave = false;

        public void addWave(int posX, int posY)
        {
            //Utils.wl("addWave posX:" + posX + " posY:" + posY);
            Wave wave = new Wave(posX, posY, dataGridView);
            waveList.Add(wave);
            
            isExistWave = true;
        }

    }
}
