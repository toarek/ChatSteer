using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSteer {
    public static class SafeMessage {

        public static string Get(string name) {

            char[] c = name.ToCharArray();
            string result = "";

            for(int i = 0; i < c.Length; i++) {
                switch(c[i]) {
                    default:
                        result += c[i];
                        break;
                    case 'ą':
                        result += "a";
                        break;
                    case 'ć':
                        result += "c";
                        break;
                    case 'ę':
                        result += "e";
                        break;
                    case 'ł':
                        result += "l";
                        break;
                    case 'ń':
                        result += "n";
                        break;
                    case 'ó':
                        result += "o";
                        break;
                    case 'ś':
                        result += "s";
                        break;
                    case 'ź':
                    case 'ż':
                        result += "z";
                        break;
                }
            }

            return result;

        }

    }
}
