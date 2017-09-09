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
using Web.DTOs.FlujoProceso;
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
        public HistorialProcesoVistaModelo GrabarHistorialProceso(HistorialProcesoVistaModelo historialProcesoVistaModelo)
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
                return js.Deserialize<HistorialProcesoVistaModelo>(json);
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

        /// <summary>
        /// Obtiene todas las prendas  para  la logistica
        /// </summary>
        /// <param name="etapaProcesoId"></param>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<HistorialProcesoVistaModelo> ObtenerHistorialProcesoPorFlujoProceso(int etapaProcesoId, int sucursalId,
            int puntoVentaId)
        {
            try
            {

                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHistorialProcesoPorFlujoProceso?etapaProcesoId=" + etapaProcesoId+ "&sucursalId="+ sucursalId+ "&puntoVentaId="+ puntoVentaId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<HistorialProcesoVistaModelo>>(json);


            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza  el historial de proceso
        /// </summary>
        /// <param name="historialProceso"></param>
        public void ActualizarHistorialProceso(HistorialProcesoVistaModelo historialProceso)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(HistorialProcesoVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, historialProceso);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarHistorialProceso", "POST", datos);
                var js = new JavaScriptSerializer();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region TRANSACCIONAL

        #region REPORTES

        /// <summary>
        /// Obtiene el historial de prendas 
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="fechaRegistro"></param>
        /// <param name="etapaProcesoId"></param>
        /// <returns></returns>
        public List<HistorialProcesoVistaDTOs> ObtenerHistorialProcesoPrendasPorVariosParametros(int sucursalId,
            int puntoVentaId, string fechaRegistro, int etapaProcesoId)
        {
            try
            {

                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHistorialProcesoPrendasPorVariosParametros?sucursalId=" + sucursalId + "&puntoVentaId=" + puntoVentaId + "&fechaRegistro=" + fechaRegistro + "&etapaProcesoId="+ etapaProcesoId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<HistorialProcesoVistaDTOs>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        /// <summary>
        /// Obtiene el lsitado de  las ordenes de reproceso
        /// </summary>
        /// <param name="detalleOrdenTrabajoId"></param>
        /// <returns></returns>
        public List<DetalleHistorialReprocesoVistaDTOs> ObtenerDetalleHistorialReprocesosPorDetalleOrdenTrabajoId(
            int detalleOrdenTrabajoId)
        {

            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerDetalleHistorialReprocesosPorDetalleOrdenTrabajoId?detalleOrdenTrabajoId=" + detalleOrdenTrabajoId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<DetalleHistorialReprocesoVistaDTOs>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba  el historial de  los reprocesos
        /// </summary>
        /// <param name="historialReprocesoDtOs"></param>
        public void GrabarHistorialReprocesos(HistorialReprocesoVistaDTOs historialReprocesoDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(HistorialReprocesoVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, historialReprocesoDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarHistorialReprocesos", "POST", datos);
                var js = new JavaScriptSerializer();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        /// <summary>
        /// Reporte de  reproceso por prenda
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>
        public List<ReprocesoVistaDTOs> ObtenerReprocesoPorVariosParametros(int puntoVentaId, string fechaDesde, string fechaHasta)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerReprocesoPorVariosParametros?puntoVentaId=" + puntoVentaId+ "&fechaDesde="+ fechaDesde+ "&fechaHasta="+ fechaHasta);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ReprocesoVistaDTOs>>(json);


            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region HISTORIAL RECLAMO  REPROCESO PRENDA

        /// <summary>
        /// Obtiene el historial de reproceso de las prendas
        /// </summary>
        /// <param name="detallePrendaOrdenTrabajoId"></param>
        /// <returns></returns>
        public List<HistorialReclamoReprocesoPrendaVistaModelo>
            ObtenerHistorialReclamoReprocesoPrendaPorDetallePrendaOrdenTrabajoId(int detallePrendaOrdenTrabajoId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerHistorialReclamoReprocesoPrendaPorDetallePrendaOrdenTrabajoId?detallePrendaOrdenTrabajoId=" + detallePrendaOrdenTrabajoId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<HistorialReclamoReprocesoPrendaVistaModelo>>(json);


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba el  historial del reproceso de prendas   y los reclamos 
        /// </summary>
        /// <param name="historialReclamoReprocesoPrenda"></param>
        public void GrabarHistorialReclamoReprocesoPrenda(
            HistorialReclamoReprocesoPrendaVistaModelo historialReclamoReprocesoPrenda)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(HistorialReclamoReprocesoPrendaVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, historialReclamoReprocesoPrenda);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarHistorialReclamoReprocesoPrenda", "POST", datos);
                var js = new JavaScriptSerializer();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region HISTORIAL REPROCESO
        /// <summary>
        /// Graba el  historial del reproceso de prendas   y los reclamos 
        /// </summary>
        /// <param name="historialReclamoReprocesoPrenda"></param>
        public HistorialReprocesoVistaModelo GrabarHistorialReproceso(HistorialReprocesoVistaModelo historialReproceso)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(HistorialReprocesoVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, historialReproceso);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarHistorialReproceso", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<HistorialReprocesoVistaModelo>(json);
            }
            catch (Exception ex)
            {

                throw;

            }
        }
        #endregion

        #region DETALLE  HISTORIAL  PRENDA
        /// <summary>
        /// Grabar el detalle
        /// </summary>
        /// <param name="detalleHistorialReproceso"></param>
        public void GrabarDetalleHistorialReproceso(DetalleHistorialReprocesoVistaModelo detalleHistorialReproceso)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DetalleHistorialReprocesoVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, detalleHistorialReproceso);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarDetalleHistorialReproceso", "POST", datos);
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