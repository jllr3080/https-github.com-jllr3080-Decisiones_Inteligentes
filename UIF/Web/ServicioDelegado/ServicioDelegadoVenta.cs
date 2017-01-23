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
using Web.DTOs.Individuo;
using Web.DTOs.Logistica;
using Web.DTOs.Venta;
using Web.Models.Individuo;

using Web.Models.Venta.Negocio;

#endregion
namespace Web.ServicioDelegado
{

    /// <summary>
    /// Metodos  de  venta 
    /// </summary>
    public class ServicioDelegadoVenta
    {

        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_Venta/ServicioVenta.svc/";

        #region NEGOCIO
        #region TRANSACCIONAL

        /// <summary>
        /// Graba la orden  de trabajo de forma completa
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>
        /// <returns></returns>
        public OrdenTrabajoVistaModelo GrabarOrdenTrabajoCompleta(OrdenTrabajoVistaDTOs ordenTrabajoDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(OrdenTrabajoVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, ordenTrabajoDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarOrdenTrabajoCompleta", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<OrdenTrabajoVistaModelo>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las  ordenes  que estan lista para enviarse  a matriz
        /// </summary>
        /// <returns></returns>
        public List<OrdenTrabajoVistaDTOs> ObtenerOrdenTrabajoPorEnvioMatriz(int puntoVentaId, int sucursalId)
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerOrdenTrabajoPorEnvioMatriz?puntoVentaId="+ puntoVentaId+ "&sucursalId="+ sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<OrdenTrabajoVistaDTOs>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        
        /// <summary>
        /// Obtiene las ordenes de trabajo por etapa de proceso del perfil en el que se encuentra
        /// </summary>
        /// <param name="etapaProcesoPerfilId"></param>
        /// <returns></returns>
        public List<OrdenTrabajoVistaDTOs> ObtenerOrdenTrabajoPorEtapaProcesoPerfilId(int etapaProcesoPerfilId)
        {
            try
            {

                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerOrdenTrabajoPorEtapaProcesoPerfilId?etapaProcesoPerfilId=" + etapaProcesoPerfilId );
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<OrdenTrabajoVistaDTOs>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        #endregion

        #region ORDEN TRABAJO
        /// <summary>
        /// Obtiene  por  id de la orden de trabajo
        /// </summary>
        /// <param name="ordenTrabajoId"></param>
        /// <returns></returns>
        public OrdenTrabajoVistaDTOs ObtenerOrdenTrabajoPorOrdenTrabajoId(int ordenTrabajoId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerOrdenTrabajoPorOrdenTrabajoId?ordenTrabajoId=" + ordenTrabajoId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<OrdenTrabajoVistaDTOs>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza la orden de trabajo
        /// </summary>
        /// <param name=""></param>
        public void ActualizarOrdenTrabajo(OrdenTrabajoVistaModelo ordenTrabajo)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(OrdenTrabajoVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, ordenTrabajo);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarOrdenTrabajo", "POST", datos);
                //var js = new JavaScriptSerializer();
                //return js.Deserialize<OrdenTrabajoVistaModelo>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion
        
        #region REPORTES

        /// <summary>
        /// Obtiene  la orden de  trabajo por  numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<ConsultaOrdenTrabajoVistaDTOs> ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(string numeroOrden, int puntoVentaId)
        {
            try
            {

                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta?numeroOrden=" + numeroOrden + "&puntoVentaId=" + puntoVentaId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ConsultaOrdenTrabajoVistaDTOs>>(json);


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene  
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<ConsultaOrdenTrabajoVistaDTOs> ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(string fechaDesde, int sucursalId)
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal?fechaDesde=" + fechaDesde+ "&sucursalId="+ sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ConsultaOrdenTrabajoVistaDTOs>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion


        #region DETALLE DE  ORDEN DE TRABAJO OBSERVACIONES
        /// <summary>
        /// Graba todas las observaciones de  los detalles de la orden de trabajo
        /// </summary>
        /// <param name="detalleOrdenTrabajoObservacion"></param>
        public void GrabarDetalleOrdenTrabajoObservacion(DetalleOrdenTrabajoObservacionVistaModelo detalleOrdenTrabajoObservacion)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DetalleOrdenTrabajoObservacionVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, detalleOrdenTrabajoObservacion);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarDetalleOrdenTrabajoObservacion", "POST", datos);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene las observaciones 
        /// </summary>
        /// <param name="detalleOrdenTrabajoId"></param>
        /// <returns></returns>
        public List<DetalleOrdenTrabajoObservacionVistaModelo> ObtenerDetalleOrdenTrabajoObservaciones(
            int detalleOrdenTrabajoId)
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerDetalleOrdenTrabajoObservaciones?detalleOrdenTrabajoId=" + detalleOrdenTrabajoId );
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<DetalleOrdenTrabajoObservacionVistaModelo>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        #endregion
    }
}