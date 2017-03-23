#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Web.DTOs.ReglaNegocio;
using Web.Models.Inventario.Parametrizacion;

#endregion

namespace Web.ServicioDelegado
{
    public class ServicioDelegadoReglaNegocio
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_Regla_Negocio/ServicioReglaNegocio.svc/";


        #region TRANSACCIONAL
        /// <summary>
        /// Obtener las reglas para aplicar     
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<ReglaVistaDTOs> ObtenerReglasPorPuntoVentaIdYSucursalId(int puntoVentaId, int sucursalId)
        {
            try
            {

                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerReglasPorPuntoVentaIdYSucursalId?puntoVentaId=" + puntoVentaId + "&sucursalId="+ sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ReglaVistaDTOs>>(json);


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}