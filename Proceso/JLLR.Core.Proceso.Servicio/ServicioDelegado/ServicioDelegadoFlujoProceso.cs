#region using
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
namespace JLLR.Core.Proceso.Servicio.ServicioDelegado
{
    public class ServicioDelegadoFlujoProceso
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_Flujo_Proceso/ServicioFlujoProceso.svc/";


        #region HISTORIAL PROCESO
        /// <summary>
        /// Devuelve  todos  los  historiales de  proceso  del clciente, anulados  y  entregados
        /// </summary>
        /// <returns></returns>
        public List<HistorialProcesoModelo> ObtenerHistorialProceso()
        {
            try
            {

                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHistorialProceso");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<HistorialProcesoModelo>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza  el historial de proceso
        /// </summary>
        /// <param name="historialProceso"></param>
        public void ActualizarHistorialProceso(HistorialProcesoModelo historialProceso)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(HistorialProcesoModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, historialProceso);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarHistorialProceso", "POST", datos);
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}