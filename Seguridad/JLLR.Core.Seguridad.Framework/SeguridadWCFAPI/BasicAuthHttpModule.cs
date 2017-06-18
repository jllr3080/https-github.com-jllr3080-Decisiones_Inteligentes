#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
#endregion
namespace JLLR.Core.Seguridad.Framework.SeguridadWCFAPI
{
   public class BasicAuthHttpModule
    {
        private const string Realm = "WebAPI Authentication";

        public BasicAuthHttpModule()
        {
        }

        public static string AppDataPath()
        {
            return string.Concat("C:\\", "Confiamed");
        }

        private static bool AuthenticateUser(string credentials)
        {
            bool flag;
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            credentials = encoding.GetString(Convert.FromBase64String(credentials));
            string[] strArrays = credentials.Split(new char[] { ':' });
            string str = strArrays[0];
            string str1 = strArrays[1];

            string iniValue = BasicAuthHttpModule.getIniValue("System", "username", str);
            string iniValue1 = BasicAuthHttpModule.getIniValue("System", "password", str1);

            if ((str != iniValue ? false : str1 == iniValue1))
            {
                BasicAuthHttpModule.SetPrincipal(new GenericPrincipal(new GenericIdentity(str), null));
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public void Dispose()
        {
        }

        public static string getIniValue(string MainSection, string key, string defaultValue)
        {
            IniFile iniFile = new IniFile(string.Concat(BasicAuthHttpModule.AppDataPath(), "\\config.ini"));
            return iniFile.IniReadValue(MainSection, key, defaultValue);
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(BasicAuthHttpModule.OnApplicationAuthenticateRequest);
            context.EndRequest += new EventHandler(BasicAuthHttpModule.OnApplicationEndRequest);
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            string item = HttpContext.Current.Request.Headers["Authorization"];
            if (item != null)
            {
                AuthenticationHeaderValue authenticationHeaderValue = AuthenticationHeaderValue.Parse(item);
                if ((!authenticationHeaderValue.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) ? false : authenticationHeaderValue.Parameter != null))
                {
                    BasicAuthHttpModule.AuthenticateUser(authenticationHeaderValue.Parameter);
                }
            }
        }

        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", "WebAPI Authentication"));
            }
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }
}
