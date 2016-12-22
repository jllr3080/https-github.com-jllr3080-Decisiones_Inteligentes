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
using Web.DTOs.Contabilidad;
using Web.DTOs.Individuo;
using Web.DTOs.Logistica;
using Web.Models.General;
using Web.Models.Logistica;

#endregion

namespace Web.ServicioDelegado
{
    public class ServicioDelegadoLogistica
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_Logistica/ServicioLogistica.svc/";


        #region TRANSACCIONAL
        /// <summary>
        /// Graba la cuenta por pagar  
        /// </summary>
        /// <param name="cuentaPorCobrarDtOs"></param>
        /// <returns></returns>
        public EntregaOrdenTrabajoVistaModelo GrabarCuentaPorCobrarCompleta(EntregaOrdenTrabajoVistaDTOs entregaOrdenTrabajoVistaDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(EntregaOrdenTrabajoVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, entregaOrdenTrabajoVistaDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarCuentaPorCobrarCompleta", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<EntregaOrdenTrabajoVistaModelo>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}