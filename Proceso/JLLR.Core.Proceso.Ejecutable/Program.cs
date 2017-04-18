using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace JLLR.Core.Proceso.Ejecutable
{
    public class Program
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_Proceso/ServicioProceso.svc/";

        public static void Main(string[] args)
        {
            try
            {
                EnvioCorreoMasivo();
            }
            catch (Exception EX)
            {

                EnvioCorreoMasivo();
            }
        }
        /// <summary>
        /// Graba el asiento tanto  positivo como negativo
        /// </summary>
        public static void EnvioCorreoMasivo()
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "EnvioCorreoMasivo");
               
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
