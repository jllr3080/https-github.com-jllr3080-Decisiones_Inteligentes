#region  using
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using JLLR.Core.FlujoProceso.Servicio.Modelo;

#endregion

namespace JLLR.Core.Venta.Servicio.ServicioDelegado
{
    public class ServicioDelegadoFlujoProceso
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_Flujo_Proceso/ServicioFlujoProceso.svc/";


        #region HISTORIAL PROCESO
        /// <summary>
        /// Graba el  historial del proceso
        /// </summary>
        public void GrabarHistorialProcesoSinRetorno(HistorialProcesoModelo historialProcesoVistaModelo)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(HistorialProcesoModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, historialProcesoVistaModelo);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarHistorialProcesoSinRetorno", "POST", datos);
                var js = new JavaScriptSerializer();
         

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}