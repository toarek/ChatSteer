using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ChatSteer {
    public static class ActiveWarning {

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static void Check(CheckedListBox processList) {
            if(GetActiveWindowTitle() != processList.CheckedItems[0].ToString()) {
                string title = "Nieaktywny sterowany program";
                string message =
                    "Sterowany program o nazwie: " +
                    processList.CheckedItems[0] +
                    " nie jest aktywowany, aktywować go?"
                ;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes) {
                    var ahk = new AutoHotkey.Interop.AutoHotkeyEngine();
                    ahk.ExecRaw("WinActivate, " + processList.CheckedItems[0]);
                }
            }
        }

        static string GetActiveWindowTitle() {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if(GetWindowText(handle, Buff, nChars) > 0) {
                return Buff.ToString();
            }
            return null;
        }

    }
}
