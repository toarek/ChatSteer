using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace ChatSteer {
    public static class KeyReader {

        static Dictionary<string, string> keys = new Dictionary<string, string>();
        static Dictionary<string, string> times = new Dictionary<string, string>();
        static string currApp;

        public static string GetCurrApp() {
            return currApp;
        }

        public static string GetKeys(string key) {
            if(keys.ContainsKey(key))
                return keys[key];
            else
                return null;
        }

        public static string GetTimes(string key) {
            try {
                return times[key];
            } catch(KeyNotFoundException) {
                return null;
            }
        }

        public static void LoadKeys(string app) {
            keys.Clear();
            times.Clear();
            currApp = app;

            string file = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ChatSteer/" + currApp + ".xml";

            if(!File.Exists(file))
                Console.WriteLine("Missing name attribute in node (File \"" + file + "\"). Element ignored");

            XmlReader reader = XmlReader.Create(File.OpenRead(file));
            reader.MoveToContent();
            while(reader.Read()) {
                if(reader.NodeType == XmlNodeType.Element) {
                    if(reader.Name == "key") {
                        XElement elem = XElement.ReadFrom(reader) as XElement;
                        if(elem != null) {
                            XAttribute attr = elem.Attribute("element");
                            if(attr == null || attr.Value == null || attr.Value.Length == 0) {
                                Console.WriteLine("Missing name attribute in node (File \"" + file + "\"). Element ignored");
                                continue;
                            }
                            if(attr.Value != "NULL") {
                                try {
                                    XAttribute time = elem.Attribute("time");
                                    keys.Add(attr.Value, elem.Value);
                                    times.Add(elem.Value, time.Value);
                                } catch(ArgumentException) {
                                    Console.WriteLine("Key \"" + attr.Value + "\" is duplicated (File \"" + file + "\"). Element ignored");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
