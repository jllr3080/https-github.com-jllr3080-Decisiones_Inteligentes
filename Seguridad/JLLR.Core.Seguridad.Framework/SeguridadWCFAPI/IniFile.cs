#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace JLLR.Core.Seguridad.Framework.SeguridadWCFAPI
{
  public   class IniFile
    {
        public string path;

        public IniFile(string INIPath)
        {
            this.path = INIPath;
        }

        [DllImport("kernel32", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public string IniReadString(string Section, string Key, string Default)
        {
            StringBuilder stringBuilder = new StringBuilder(255);
            IniFile.GetPrivateProfileString(Section, Key, Default, stringBuilder, 255, this.path);
            return stringBuilder.ToString();
        }

        public string IniReadValue(string Section, string Key, string Default)
        {
            StringBuilder stringBuilder = new StringBuilder(255);
            IniFile.GetPrivateProfileString(Section, Key, Default, stringBuilder, 255, this.path);
            return stringBuilder.ToString();
        }

        public void IniWriteString(string Section, string Key, string Value)
        {
            IniFile.WritePrivateProfileString(Section, Key, Value, this.path);
        }

        public void IniWriteValue(string Section, string Key, string Value)
        {
            IniFile.WritePrivateProfileString(Section, Key, Value, this.path);
        }

        [DllImport("kernel32", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    }
}

