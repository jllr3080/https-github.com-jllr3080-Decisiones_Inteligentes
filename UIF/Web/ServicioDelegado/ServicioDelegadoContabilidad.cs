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
using Web.DTOs.Venta;
using Web.Models.Contabilidad;
using Web.Models.General;
using Web.Models.Venta.Negocio;

#endregion

namespace Web.ServicioDelegado
{
    public class ServicioDelegadoContabilidad
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_Contabilidad/ServicioContabilidad.svc/";

        #region TRANSACCIONAL

        /// <summary>
        /// Graba la cuenta por pagar  
        /// </summary>
        /// <param name="cuentaPorCobrarVistaDtOs"></param>
        /// <returns></returns>
        public CuentaPorCobrarVistaModelo GrabarCuentaPorCobrarCompleta(CuentaPorCobrarVistaDTOs cuentaPorCobrarVistaDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CuentaPorCobrarVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, cuentaPorCobrarVistaDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarCuentaPorCobrarCompleta", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<CuentaPorCobrarVistaModelo>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}