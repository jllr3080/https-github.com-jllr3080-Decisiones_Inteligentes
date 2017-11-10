#region using
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using JLLR.Core.ServicioDelegado.Proveedor.VistaDTOs.Contabilidad;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Contabilidad;

#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado
{
    public class ServicioDelegadoContabilidad
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_Contabilidad/ServicioContabilidad.svc/";

        #region TRANSACCIONAL
        /// <summary>
        /// Obtener  las cuentas  por  cobrar  por  fecha desde y  hasta  y el punto de  venta
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<CuentaPorPagarVistaDTOs> ObtenerCuentaPorPagarPorFechas(string fechaDesde, string fechaHasta,
            int sucursalId)
        {

            try
            {

                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerCuentaPorPagarPorFechas?fechaDesde=" + fechaDesde + "&fechaHasta=" + fechaHasta + "&sucursalId=" + sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CuentaPorPagarVistaDTOs>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  CIERRE MES
        /// <summary>
        /// Graba  el cierre  de  mes 
        /// </summary>
        /// <param name="cierreMes"></param>
        /// <returns></returns>
        public CierreMesVistaModelo GrabarCierreMes(CierreMesVistaModelo cierreMes)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CierreMesVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, cierreMes);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarCierreMes", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<CierreMesVistaModelo>(json);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Cierre  de  mes 
        /// </summary>
        /// <param name="mesId"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<CierreMesVistaModelo> ObtenerCierresMesPorAplicacionPendiente(int mesId, int puntoVentaId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerCierresMesPorAplicacionPendiente?mesId=" + mesId + "&puntoVentaId=" + puntoVentaId );
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CierreMesVistaModelo>>(json);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene las aplicaciones de pago para ser validadas
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="mesId"></param>
        /// <returns></returns>
        public List<AplicacionPagoVistaDTOs> ObtenerAplicacionPagosPorPuntoVentaIdYMesId(int puntoVentaId, int mesId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerAplicacionPagosPorPuntoVentaIdYMesId?puntoVentaId=" + puntoVentaId + "&mesId=" + mesId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<AplicacionPagoVistaDTOs>>(json);

            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region APLICACION PAGO
        /// <summary>
        /// Graba  el cierre  de  mes 
        /// </summary>
        /// <param name="aplicacionPago"></param>
        /// <returns></returns>
        public AplicacionPagoVistaModelo GrabaAplicacionPago(AplicacionPagoVistaModelo aplicacionPago)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AplicacionPagoVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, aplicacionPago);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabaAplicacionPago", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<AplicacionPagoVistaModelo>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba  el cierre  de  mes 
        /// </summary>
        /// <param name="aplicacionPago"></param>
        /// <returns></returns>
        public AplicacionPagoVistaModelo ActualizaAplicacionPago(AplicacionPagoVistaModelo aplicacionPago)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AplicacionPagoVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, aplicacionPago);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizaAplicacionPago", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<AplicacionPagoVistaModelo>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        ///Obtiene  los pagos por cada  cierre  de  mes 
        /// </summary>
        /// <param name="cierreMesId"></param>
        /// <returns></returns>
        public List<AplicacionPagoVistaModelo> ObtenerAplicacionPagoPorCierreMesId(int cierreMesId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerAplicacionPagoPorCierreMesId?cierreMesId=" + cierreMesId );
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<AplicacionPagoVistaModelo>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
