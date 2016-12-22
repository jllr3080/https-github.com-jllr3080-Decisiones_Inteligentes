﻿#region using
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Web.DTOs.Contabilidad;
using Web.DTOs.Individuo;
using Web.Models.Contabilidad;
using Web.Models.FlujoProceso;
using Web.Models.General;

#endregion
namespace Web.ServicioDelegado
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
        public void GrabarHistorialProceso(HistorialProcesoVistaModelo historialProcesoVistaModelo)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(HistorialProcesoVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, historialProcesoVistaModelo);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarHistorialProceso", "POST", datos);
                var js = new JavaScriptSerializer();
               
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtener el historial del proceso por numero  de orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <returns></returns>
        public List<HistorialProcesoVistaModelo> ObtenerHIstorialProcesosPorNumeroOrden(string numeroOrden)
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHIstorialProcesosPorNumeroOrden?numeroOrden=" + numeroOrden );
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<HistorialProcesoVistaModelo>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}