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
using JLLR.Core.Contabilidad.Servicio.DTOs;
using  JLLR.Core.Contabilidad.Servicio.Modelo;
#endregion

namespace JLLR.Core.Venta.Servicio.ServicioDelegado
{
    public class ServicioDelegadoContabilidad
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_Contabilidad/ServicioContabilidad.svc/";

        #region  TRANSACCIONAL
        /// <summary>
        /// Graba el asiento tanto  positivo como negativo
        /// </summary>
        public void GrabarAsiento(AsientoDTOs asientoDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AsientoDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, asientoDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarAsiento", "POST", datos);
                //var js = new JavaScriptSerializer();
                //return js.Deserialize<CuentaPorCobrarVistaModelo>(json);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        public List<CuentaPorPagarDTOs> ObtenerHistorialCuentaPorPagarPorNumeroOrden(string numeroOrden)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHistorialCuentaPorPagarPorNumeroOrden?numeroOrden=" + numeroOrden);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CuentaPorPagarDTOs>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene el historial por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        public List<CuentaPorCobrarDTOs> ObtenerHistorialCuentaPorCobrarPorNumeroOrden(string numeroOrden)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHistorialCuentaPorCobrarPorNumeroOrden?numeroOrden=" + numeroOrden);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CuentaPorCobrarDTOs>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<CuentaPorCobrarDTOs> ObtenerHistorialCuentaPorCobrarPorVariosParametros(string numeroOrden, int puntoVentaId, int sucursalId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHistorialCuentaPorCobrarPorNumeroOrden?numeroOrden=" + numeroOrden + "&puntoVentaId="+ puntoVentaId + "&sucursalId="+ sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CuentaPorCobrarDTOs>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<CuentaPorPagarDTOs> ObtenerHistorialCuentaPorPagarPorVariosParametros(string numeroOrden, int puntoVentaId, int sucursalId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHistorialCuentaPorPagarPorVariosParametros?numeroOrden=" + numeroOrden + "&puntoVentaId=" + puntoVentaId + "&sucursalId=" + sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CuentaPorPagarDTOs>>(json);


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}