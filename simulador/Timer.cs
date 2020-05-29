using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulador
{
    class Timer
    {
        public System.Timers.Timer timer1 = new System.Timers.Timer();
 
        public int i = 0;
        public String label;
        public void iniciarTimer()
        {
           timer1.Enabled = true;
        }
        public void PausarTimer()
        {
           timer1.Stop();
        }
        public void borrarTimer()
        {
            timer1.Stop();
            label = "";
            i = 0;
        }


        
    }
        
}
