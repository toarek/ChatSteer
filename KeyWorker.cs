using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ChatSteer {
    static class KeyWorker {

        public static string app = "";
        public static ListBox keyList;

        public static string pressAndHold = "";

        public static void Work() {
            var ahk = new AutoHotkey.Interop.AutoHotkeyEngine();

            while(ToStatic.main.GetWork()) {
                if(keyList.Items.Count > 0) {

                    string key = keyList.Items[keyList.Items.Count - 1].ToString();
                    int time = Convert.ToInt32(KeyReader.GetTimes(key));

                    int x = 0;
                    int y = 0;

                    if(key == "MouseDown") {
                        y = time;
                    } else if(key == "MouseUp") {
                        y = -time;
                    } else if(key == "MouseRight") {
                        x = time;
                    } else if(key == "MouseLeft") {
                        x = -time;
                    }

                    string c = "";

                    if(key.Length >= 3)
                        c = key.Substring(0, 2);

                    if(c != "\\#") {
                        ahk.ExecRaw(
                            "#IfWinExist, " + app + "\n" +
                            "Send, {" + pressAndHold + " UP}\n" +
                            "#IfWinExist\n"
                        );
                    } else {
                        key = key.Remove(0, 2);
                    }

                    if(x == 0 && y == 0) {

                        if(c == "\\@") {
                            pressAndHold = key.Remove(0, 2);
                            ahk.ExecRaw(
                                "#IfWinExist, " + app + "\n" +
                                "Send, {" + pressAndHold + " DOWN}\n" +
                                "#IfWinExist\n"
                            );
                        } else {
                            ahk.ExecRaw(
                                "#IfWinExist, " + app + "\n" +
                                "Send, {" + key + " DOWN}\n" +
                                "Sleep, " + time + "\n" +
                                "Send, {" + key + " UP}\n" +
                                "#IfWinExist\n"
                            );
                        }
                        Thread.Sleep(time);

                    } else {
                        ahk.ExecRaw(
                            "#IfWinExist, " + app + "\n" +
                            "MouseMove, " + x + ", " + y + ", 99, R\n" +
                            "#IfWinExist\n"
                        );
                        Thread.Sleep(500);
                    }

                    ToStatic.main.keyListRemove.Add(keyList.Items.Count - 1);

                } else {
                    Thread.Sleep(17);
                }
            }
        }

    }
}
