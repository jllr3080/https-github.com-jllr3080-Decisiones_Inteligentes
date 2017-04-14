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
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<CuentaPorCobrarVistaDTOs> ObtenerHistorialCuentaPorCobrarPorVariosParametros(string numeroOrden, int puntoVentaId, int sucursalId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHistorialCuentaPorCobrarPorNumeroOrden?numeroOrden=" + numeroOrden + "&puntoVentaId=" + puntoVentaId + "&sucursalId=" + sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CuentaPorCobrarVistaDTOs>>(json);
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
        public List<CuentaPorPagarVistaDTOs> ObtenerHistorialCuentaPorPagarPorVariosParametros(string numeroOrden, int puntoVentaId, int sucursalId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHistorialCuentaPorPagarPorVariosParametros?numeroOrden=" + numeroOrden + "&puntoVentaId=" + puntoVentaId + "&sucursalId=" + sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CuentaPorPagarVistaDTOs>>(json);


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
        public List<CuentaPorPagarVistaDTOs> ObtenerHistorialCuentaPorPagarPorNumeroOrden(string numeroOrden)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHistorialCuentaPorPagarPorNumeroOrden?numeroOrden=" + numeroOrden);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CuentaPorPagarVistaDTOs>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

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

        /// <summary>
        /// Obtiene el historial por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        public List<CuentaPorCobrarVistaDTOs> ObtenerHistorialCuentaPorCobrarPorNumeroOrden(string numeroOrden)
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHistorialCuentaPorCobrarPorNumeroOrden?numeroOrden=" + numeroOrden );
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CuentaPorCobrarVistaDTOs>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene  el historial de cuenta por cobrar  por numero de identificacion
        /// </summary>
        public List<CuentaPorCobrarVistaDTOs> ObtenerHistorialCuentaPorCobrarPorNumeroidentificacion(string numeroIdentificacion)
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHistorialCuentaPorCobrarPorNumeroidentificacion?numeroIdentificacion=" + numeroIdentificacion);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CuentaPorCobrarVistaDTOs>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
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
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerCuentaPorPagarPorFechas?fechaDesde=" + fechaDesde+ "&fechaHasta="+ fechaHasta+ "&sucursalId="+ sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CuentaPorPagarVistaDTOs>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region CUENTA POR COBRAR

        /// <summary>
        /// Graba la cabecera de la cuenta por cobrar
        /// </summary>
        /// <param name="cuentaPorCobrar"></param>
        /// <returns></returns>
        public CuentaPorCobrarVistaModelo GrabarCuentaPorCobrar(CuentaPorCobrarVistaModelo cuentaPorCobrar)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CuentaPorCobrarVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, cuentaPorCobrar);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarCuentaPorCobrar", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<CuentaPorCobrarVistaModelo>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza las  cuentas  por cobrar
        /// </summary>
        /// <param name="cuentaPorCobrar"></param>

        public void ActualizaCuentaPorCobrar(CuentaPorCobrarVistaModelo cuentaPorCobrar)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CuentaPorCobrarVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, cuentaPorCobrar);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizaCuentaPorCobrar", "POST", datos);
                //var js = new JavaScriptSerializer();
                //return js.Deserialize<CuentaPorCobrarVistaModelo>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtener las cuentas  por  cobrar por  fecha
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>

        public List<CuentaPorCobrarVistaModelo> ObtenerCuentasPorCobrarPorFecha(int sucursalId, string fechaDesde,
            string fechaHasta)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerCuentasPorCobrarPorFecha?sucursalId=" + sucursalId + "&fechaDesde=" + fechaDesde + "&fechaHasta=" + fechaHasta);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CuentaPorCobrarVistaModelo>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #region HISTORIAL CUENTAS POR COBRAR
        /// <summary>
        /// Graba el  historial de los cobros
        /// </summary>
        /// <param name="historialCuentaPorCobrar"></param>
        /// <returns></returns>

        public HistorialCuentaPorCobrarVistaModelo GrabarHistorialCuentaPorCobrar(HistorialCuentaPorCobrarVistaModelo historialCuentaPorCobrar)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(HistorialCuentaPorCobrarVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, historialCuentaPorCobrar);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarHistorialCuentaPorCobrar", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<HistorialCuentaPorCobrarVistaModelo>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Actualiza  las  cuentas por cobrar
        /// </summary>
        /// <param name="historialCuentaPorCobrar"></param>
        public void ActualizarHistorialCuentaPorCobrar(HistorialCuentaPorCobrarVistaModelo historialCuentaPorCobrar)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(HistorialCuentaPorCobrarVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, historialCuentaPorCobrar);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarHistorialCuentaPorCobrar", "POST", datos);
                //var js = new JavaScriptSerializer();
                //return js.Deserialize<HistorialCuentaPorCobrarVistaModelo>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #region CUENTA POR PAGAR
        /// <summary>
        /// Graba las cuentas  por  pagar
        /// </summary>
        /// <param name="cuentaPorPagar"></param>
        /// <returns></returns>
        public CuentaPorPagarVistaModelo GrabarCuentaPorPagar(CuentaPorPagarVistaModelo cuentaPorPagar)
        {
            try
            {

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CuentaPorPagarVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, cuentaPorPagar);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarCuentaPorPagar", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<CuentaPorPagarVistaModelo>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba las cuentas  por  pagar
        /// </summary>
        /// <param name="cuentaPorPagar"></param>
        /// <returns></returns>
        public void ActualizaCuentaPorPagar(CuentaPorPagarVistaModelo cuentaPorPagar)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CuentaPorPagarVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, cuentaPorPagar);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizaCuentaPorPagar", "POST", datos);
                //var js = new JavaScriptSerializer();
                //return js.Deserialize<CuentaPorPagarVistaModelo>(json);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtener  las cuentas  por pagar por  fecha
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechahasta"></param>
        /// <returns></returns>

        public List<CuentaPorPagarVistaModelo> ObtenerCuentaPorPagarPorFecha(int sucursalId, string fechaDesde,
            string fechaHasta)
        {

            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerCuentaPorPagarPorFecha?sucursalId=" + sucursalId + "&fechaDesde=" + fechaDesde + "&fechaHasta=" + fechaHasta);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CuentaPorPagarVistaModelo>>(json);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region HISTORIAL CUENTAS POR PAGAR
        /// <summary>
        /// Graba el historial de las cuentas por  pagar
        /// </summary>
        /// <param name="historialCuentaPorPagar"></param>
        /// <returns></returns>
        public HistorialCuentaPorPagarVistaModelo GrabarHistorialCuentaPorPagar(HistorialCuentaPorPagarVistaModelo historialCuentaPorPagar)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(HistorialCuentaPorPagarVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, historialCuentaPorPagar);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarHistorialCuentaPorPagar", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<HistorialCuentaPorPagarVistaModelo>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza el historial de cuentas  por pagar
        /// </summary>
        /// <param name="historialCuentaPorPagar"></param>

        public void ActualizaHistorialCuentaPorPagar(HistorialCuentaPorPagarVistaModelo historialCuentaPorPagar)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(HistorialCuentaPorPagarVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, historialCuentaPorPagar);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizaHistorialCuentaPorPagar", "POST", datos);
                //var js = new JavaScriptSerializer();
                //return js.Deserialize<HistorialCuentaPorPagarVistaModelo>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}