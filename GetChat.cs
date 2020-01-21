using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatSteer {
    static class GetChat {

        static string last_message0 = "";
        static string last_message1 = "";
        static string last_message2 = "";

        public static void Get(string source, ListBox KeyList, ListBox Messages) {
            source = source.
                Replace("Top chat\n", "").
                Replace("Welcome to live chat! Remember to guard your privacy and abide by our community guidelines.\n", "").
                Replace("LEARN MORE\n", "").
                Replace("Say something...\n", "").
                Replace("Say something... (slow mode is on)\n", "").
                Replace("0/200\n", "").
                Replace("All messages you send will appear publicly\n", "").
                Replace("SIGN IN TO CHAT", "").
                Replace("Napisz coś...\n", "").
                Replace("Napisz coś... (tryb zwolniony jest włączony)\n", "").
                Replace("Witamy na czacie na żywo! Nie zapomnij o ochronie prywatności i przestrzeganiu Wytycznych dla społeczności.\n", "").
                Replace("WIĘCEJ INFORMACJI\n", "").
                Replace("ZALOGUJ SIĘ DO CZATU", "").
                Replace("Wszystkie wysłane wiadomości będą widoczne publicznie\n", "").
                Replace("Topczat\n", "")
            ;

            string[] s = source.Split(new string[] { "\n" }, StringSplitOptions.None);

            string new_last_message0 = "";
            string new_last_message1 = "";
            string new_last_message2 = "";

            List<string> keys = new List<string>();
            List<string> authors = new List<string>();

            for(int i = s.Length - 1; i >= 0; i -= 2) {
                if(i - 1 < 0)
                    continue;
                if(s[i - 1].Length <= 0 || s[i].Length <= 0)
                    continue;

                string m = s[i - 1].Substring(1);

                if(
                    last_message0 == s[i] + m ||
                    last_message1 == s[i] + m ||
                    last_message2 == s[i] + m
                )
                    break;

                keys.Add(m);
                authors.Add(s[i]);

                if(new_last_message0 == "")
                    new_last_message0 = s[i] + m;
                else if(new_last_message1 == "")
                    new_last_message1 = s[i] + m;
                else if(new_last_message2 == "")
                    new_last_message2 = s[i] + m;
            }

            if(new_last_message0 != "")
                last_message0 = new_last_message0;
            if(new_last_message1 != "")
                last_message1 = new_last_message1;
            if(new_last_message2 != "")
                last_message2 = new_last_message2;

            for(int i = keys.Count - 1; i >= 0; i--) {

                string[] elements = SafeMessage.Get(keys[i]).Split(' ');
                for(int i2 = 0; i2 < elements.Length; i2++) {
                    string key = KeyReader.GetKeys(elements[i2]);
                    if(key != null) {
                        KeyList.Items.Add(key);
                        i2 = elements.Length;
                    }
                }

                Messages.Items.Add(authors[i] + ": " + keys[i]);
                KeyList.SelectedIndex = KeyList.Items.Count - 1;
                if(KeyList.Items.Count > 180)
                    KeyList.Items.RemoveAt(0);
                if(Messages.Items.Count > 21)
                    Messages.Items.RemoveAt(0);
            }

            //DEBUG MODE
            /*Messages.Items.Clear();
            for(int i = 0; i < s.Length; i++) {
                Messages.Items.Add(s[i]);
            }*/
        }

    }
}
