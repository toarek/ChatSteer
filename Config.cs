using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChatSteer {
    class Config {

        static string var_chatUrl;
        static string var_startShortcut;
        static string var_stopShortcut;

        public static string chatUrl() {
            return var_chatUrl;
        }

        public static string startShortcut() {
            return var_startShortcut;
        }

        public static string stopShortcut() {
            return var_stopShortcut;
        }

        public static void Load() {
            if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ChatSteer"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ChatSteer");
            if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ChatSteer/config.yml"))
                configcreate();
            configget();
        }

        static void configcreate() {
            using(FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ChatSteer/config.yml")) {
                Random r = new Random();

                Byte[] info = new UTF8Encoding(true).GetBytes(
                    "chatUrl=https://www.youtube.com/live_chat?v=dTgQ_A0I6Ts&is_popout=1\r\n" +
                    "startShortcut=F9\r\n" +
                    "stopShortcut=F10\r\n"
                );
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
        }

        static void configget() {
            string conf = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ChatSteer/config.yml");

            conf = conf.Replace("chatUrl=", "");
            conf = conf.Replace("startShortcut=", "");
            conf = conf.Replace("stopShortcut=", "");

            string[] confsplit = conf.Split(new[] { "\r\n" }, StringSplitOptions.None);

            var_chatUrl = confsplit[0];
            var_startShortcut = confsplit[1];
            var_stopShortcut = confsplit[2];
        }
    }
}
