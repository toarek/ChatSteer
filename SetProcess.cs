using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace ChatSteer {
    static class SetProcess {

        public static void Refresh(CheckedListBox list) {
            Process[] processList =
                Process.GetProcesses().
                Where(p => (long)p.MainWindowTitle.Length != 0).
                ToArray();
            ;

            list.Items.Clear();

            for(int i = 0; i < processList.Length; i++) {
                if(Process.GetCurrentProcess().Id == processList[i].Id)
                    continue;
                list.Items.Add(processList[i].MainWindowTitle);
            }
        }

    }
}
