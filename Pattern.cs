using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ChatSteer {
    static class Pattern {

        const string pattern =
            "<xml>\r\n" +
            "   <key element=\"przod\" time=\"100\">W</key>\r\n" +
            "   <key element=\"lewo\" time=\"100\">A</key>\r\n" +
            "   <key element=\"prawo\" time=\"100\">D</key>\r\n" +
            "   <key element=\"tyl\" time=\"100\">S</key>\r\n" +
            "   <key element=\"mgora\" time=\"100\">MouseUp</key>\r\n" +
            "   <key element=\"mdol\" time=\"100\">MouseDown</key>\r\n" +
            "   <key element=\"mlewo\" time=\"100\">MouseLeft</key>\r\n" +
            "   <key element=\"mprawo\" time=\"100\">MouseRight</key>\r\n" +
            "   <key element=\"klik\" time=\"1\">LButton</key>\r\n" +
            "   <key element=\"klik2\" time=\"1\">RButton</key>\r\n" +
            "   <key element=\"skok\" time=\"50\">Space</key>\r\n" +
            "   <key element=\"escape\" time=\"50\">Escape</key>\r\n" +
            "</xml>\r\n"
        ;


        public static void Check() {
            if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ChatSteer/pattern.xml")) {

                using(StreamWriter file = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ChatSteer/pattern.xml"))  {
                    file.Write(pattern);
                    file.Close();
                }

            }
        }

    }
}
