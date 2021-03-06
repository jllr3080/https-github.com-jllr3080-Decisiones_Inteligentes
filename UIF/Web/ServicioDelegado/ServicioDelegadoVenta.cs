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
using Web.Models.Venta.Parametrizacion;

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
        /// Graba la operacion de descuento  
        /// </summary>
        /// <param name="parametroAnulacionDtOs"></param>
        public void GrabarAnluacionPrenda(ParametroAnulacionVistaDTOs parametroAnulacionDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ParametroAnulacionVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, parametroAnulacionDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarAnluacionPrenda", "POST", datos);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Grabar el detallde  de las prendas
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>

        public void GrabarDetallePrendaCompleto(OrdenTrabajoVistaDTOs ordenTrabajoDtOs)
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
                var json = clienteWeb.UploadString(direccionUrl + "GrabarDetallePrendaCompleto", "POST", datos);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene la impresion corta sin el detalle de las prensdas
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<ConsultaOrdenTrabajoVistaDTOs> ObtenerOrdenTrabajoCortaPorNumeroOrdenYPuntoVenta(string numeroOrden,
            int puntoVentaId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerOrdenTrabajoCortaPorNumeroOrdenYPuntoVenta?numeroOrden=" + numeroOrden + "&puntoVentaId=" + puntoVentaId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ConsultaOrdenTrabajoVistaDTOs>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene  el detalle  de las  fotografias   guardadas
        /// </summary>
        /// <param name="detallePrendaOrdenTrabajoId"></param>
        /// <returns></returns>
        public List<DetalleOrdenTrabajoFotografiaVistaDTOs>
            ObtenerDetalleOrdenTrabajoFotografiaDtOsesPorDetallePrendaId(int detallePrendaOrdenTrabajoId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerDetalleOrdenTrabajoFotografiaDtOsesPorDetallePrendaId?detallePrendaOrdenTrabajoId=" + detallePrendaOrdenTrabajoId);
                var js = new JavaScriptSerializer();
                js.MaxJsonLength=Int32.MaxValue;
                
                return js.Deserialize<List<DetalleOrdenTrabajoFotografiaVistaDTOs>>(json);


            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Graba la operacion de descuento  
        /// </summary>
        /// <param name="parametroDescuentoDtOs"></param>
        public void GrabarTransaccionDescuentoOrden(ParametroDescuentoVistaDTOs parametroDescuentoDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ParametroDescuentoVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, parametroDescuentoDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarTransaccionDescuentoOrden", "POST", datos);
                //var js = new JavaScriptSerializer();
                //return js.Deserialize<string>(json);
            }
            catch (Exception exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Graba el reverso de la transaccion reversa comision,cuenta por  cobrar y cuenta por  pagar
        /// </summary>
        /// <param name="parametroReversoDtOs"></param>
        /// <returns></returns>
        public string GrabarReversoTransaccion(ParametroReversoVistaDTOs parametroReversoDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ParametroReversoVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, parametroReversoDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarReversoTransaccion", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<string>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Obtiene todas las observaciones  de las prendas por  
        /// </summary>
        /// <returns></returns>

        public List<DetalleOrdenTrabajoObservacionVistaDTOs> ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId(int detalleOrdenTrabajoId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId?detalleOrdenTrabajoId="+ detalleOrdenTrabajoId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<DetalleOrdenTrabajoObservacionVistaDTOs>>(json);



            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene  todos los descuentos   que  estan por aprobarse
        /// </summary>
        /// <returns></returns>
        public List<OrdenTrabajoDescuentoVistaDTO> ObtenerOrdenesTrabajoDescuentoPorEstadoProceso()
        {
            try
            {


                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerOrdenesTrabajoDescuentoPorEstadoProceso");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<OrdenTrabajoDescuentoVistaDTO>>(json);

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Graba la orden  de trabajo de forma completa
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>
        /// <returns></returns>
        public OrdenTrabajoVistaDTOs GrabarOrdenTrabajoCompleta(OrdenTrabajoVistaDTOs ordenTrabajoDtOs)
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
                return js.Deserialize<OrdenTrabajoVistaDTOs>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Graba las comisiones  hace un asiento de  cuentas por cobrar y cuentas por pagar
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>

        public string GrabarTransaccionInicialCompleta(OrdenTrabajoVistaDTOs ordenTrabajoDtOs)
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
                var json = clienteWeb.UploadString(direccionUrl + "GrabarTransaccionInicialCompleta", "POST", datos);
                var js = new JavaScriptSerializer();
                return js.Deserialize<string>(json);

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
        /// Obtiene  por  id de la orden de trabajo
        /// </summary>
        /// <param name="ordenTrabajoId"></param>
        /// <returns></returns>
        public List<OrdenTrabajoVistaDTOs> ObtenerOrdenTrabajoPorEstadoTemporal(int puntoVentaId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerOrdenTrabajoPorEstadoTemporal?puntoVentaId=" + puntoVentaId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<OrdenTrabajoVistaDTOs>>(json);
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
        ///  Obtiene el reporte de prenda  y marcas 
        /// </summary>
        /// <param name="prendaId"></param>
        /// <param name="marcaId"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<PrendaMarcaVistaDTOs> ObtenerPrendayMarcaPorVariosParametros(int prendaId, int marcaId, string fecha, int colorId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerPrendayMarcaPorVariosParametros?prendaId=" + prendaId + "&marcaId=" + marcaId+ "&fecha="+ fecha+ "&colorId=" + colorId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<PrendaMarcaVistaDTOs>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene el reporte de   numero de  prendas por  fecha  desde y fecha hasta
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>

        public List<NumeroPrendaVistaDTOs> ObtenerNumeroPrendasPorFecha(string fechaDesde, string fechaHasta, int sucursalId)
        {
            try
            {

                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerNumeroPrendasPorFecha?fechaDesde=" + fechaDesde + "&fechaHasta=" + fechaHasta + "&sucursalId="+ sucursalId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<NumeroPrendaVistaDTOs>>(json);



            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene el  reporte de   estadp de  cuenta 
        /// </summary>
        /// <param name="puntoventaId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>
        public List<EstadoCuentaVistaDTOs> ObtenerEstadoCuentaPorVariosParametros(int puntoventaId, string fechaDesde,
            string fechaHasta)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerEstadoCuentaPorVariosParametros?puntoventaId=" + puntoventaId+ "&fechaDesde="+ fechaDesde + "&fechaHasta="+ fechaHasta);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<EstadoCuentaVistaDTOs>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

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

        /// <summary>
        /// Metodo para extraer solo el detalle de la orden de  trabajo
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<DetalleOrdenTrabajoVistaModelo> ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta(string numeroOrden,
            int puntoVentaId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta?numeroOrden=" + numeroOrden + "&puntoVentaId=" + puntoVentaId );
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<DetalleOrdenTrabajoVistaModelo>>(json);

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

        #region ORDEN TRABAJO COMISION

        /// <summary>
        /// Graba la comision de la orden de  trabajo
        /// </summary>
        /// <param name="ordenTrabajoComision"></param>
        public void GrabaOrdenTrabajoComision(OrdenTrabajoComisionVistaModelo ordenTrabajoComision)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(OrdenTrabajoComisionVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, ordenTrabajoComision);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabaOrdenTrabajoComision", "POST", datos);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        
        #region  VENTA COMISION

        /// <summary>
        /// Obtiene 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        public VentaComisionVistaModelo ObtenerVentaComisionPorusuarioId(int usuarioId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerVentaComisionPorusuarioId?usuarioId=" + usuarioId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<VentaComisionVistaModelo>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Graba la  venta de la ocmision
        /// </summary>
        /// <param name="ventaComision"></param>

        public void GrabarVentaComision(VentaComisionVistaModelo ventaComision)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(VentaComisionVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, ventaComision);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarVentaComision", "POST", datos);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Actualizar  venta de  comision
        /// </summary>
        /// <param name="ventaComision"></param>
        public void ActualizarVentaComision(VentaComisionVistaModelo ventaComision)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(VentaComisionVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, ventaComision);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarVentaComision", "POST", datos);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Obtiene las  venta de las comisiones
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<VentaComisionVistaModelo> ObtenerVentaComisiones(int puntoVentaId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerVentaComisiones?puntoVentaId=" + puntoVentaId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<VentaComisionVistaModelo>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region HISTORIAL REGLA
        /// <summary>
        /// Graba el  historial de las  reglas
        /// </summary>
        /// <param name="historialRegla"></param>
        public void GrabarHistorialRegla(HistorialReglaVistaModelo historialRegla)
        {
            try
            {

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(HistorialReglaVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, historialRegla);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarHistorialRegla ", "POST", datos);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region ORDEN TRABAJO DESCUENTO

        /// <summary>
        /// Actualiza  la orden de  descuento
        /// </summary>
        /// <param name="ordenTrabajoDescuento"></param>
        public void ActualizarOrdenTrabajoDescuento(OrdenTrabajoDescuentoVistaModelo ordenTrabajoDescuento)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(OrdenTrabajoDescuentoVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, ordenTrabajoDescuento);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarOrdenTrabajoDescuento ", "POST", datos);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Graba el descuento de la orden d etrabajo
        /// </summary>
        public void GrabarOrdenTrabajoDescuento(OrdenTrabajoDescuentoVistaModelo ordenTrabajoDescuento)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(OrdenTrabajoDescuentoVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, ordenTrabajoDescuento);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarOrdenTrabajoDescuento ", "POST", datos);

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Obtiene todas las ordenes de  trabajo para ekl descuento  por el estado
        /// </summary>
        /// <returns></returns>
        public List<OrdenTrabajoDescuentoVistaDTO> ObtenerOrdenTrabajoDescuentoPorEstadoProceso()
        {
            try
            {

                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerOrdenTrabajoDescuentoPorEstadoProceso");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<OrdenTrabajoDescuentoVistaDTO>>(json);


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  APROBACION DESCUENTO
        /// <summary>
        /// Graba la  aprobacion del descuento
        /// </summary>
        /// <param name="aprobacionDescuento"></param>

        public void GrabarAprobacionDescuento(AprobacionDescuentoVistaModelo aprobacionDescuento)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AprobacionDescuentoVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, aprobacionDescuento);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarAprobacionDescuento ", "POST", datos);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region DETALLE  ORDEN  TRABAJO  FOTOGRAFIA
        /// <summary>
        /// Graba la fotografia  que se  genero en la orden de trabajo
        /// </summary>
        /// <param name="detalleTrabajoFotografia"></param>
        public void GrabarDetalleOrdenFotografia(DetalleOrdenTrabajoFotografiaVistaModelo detalleTrabajoFotografia)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DetalleOrdenTrabajoFotografiaVistaModelo));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, detalleTrabajoFotografia);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarDetalleOrdenFotografia ", "POST", datos);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region NUMERACION ORDEN


        /// <summary>
        /// Obtiene  todas las sucursales 
        /// </summary>
        /// <returns></returns>
        public List<NumeracionOrdenVistaDTOs> ObtenerPuntosVentaCompleto()
        {
            try
            {


                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerPuntosVentaCompleto");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<NumeracionOrdenVistaDTOs>>(json);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Grabar punto de  venta y numero de  orden
        /// </summary>
        /// <param name="numeracionOrdenDtOs"></param>
        public void GrabarPuntoVentaCompleto(NumeracionOrdenVistaDTOs numeracionOrdenDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(NumeracionOrdenVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, numeracionOrdenDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarPuntoVentaCompleto ", "POST", datos);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Grabar punto de  venta y numero de  orden
        /// </summary>
        /// <param name="numeracionOrdenDtOs"></param>
        public void ActualizarPuntoVentaCompleto(NumeracionOrdenVistaDTOs numeracionOrdenDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(NumeracionOrdenVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, numeracionOrdenDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarPuntoVentaCompleto ", "POST", datos);

            }
            catch (Exception ex)
            {

                throw;
            }
        }



        #endregion

        #region VENTA COMISION  INDUSTRIALES

        /// <summary>
        /// Obtiene el valor de la venta de  industriales
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<VentaComisionIndustrialesVistaDTOs> ObtenerComisionesIndustrialesPorPuntoVenta(int puntoVentaId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerComisionesIndustrialesPorPuntoVenta?puntoVentaId=" + puntoVentaId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<VentaComisionIndustrialesVistaDTOs>>(json);


            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Grabar promociones
        /// </summary>
        /// <param name="ventaComisionIndustrialesDtOs"></param>
        public void GrabarVentaComisionIndustrialesCompleto(VentaComisionIndustrialesVistaDTOs ventaComisionIndustrialesDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(VentaComisionIndustrialesVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, ventaComisionIndustrialesDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "GrabarVentaComisionIndustrialesCompleto ", "POST", datos);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Actualizar promociones
        /// </summary>
        /// <param name="ventaComisionIndustrialesDtOs"></param>
        public void ActualizarVentaComisionIndustrialesCompleto(VentaComisionIndustrialesVistaDTOs ventaComisionIndustrialesDtOs)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(VentaComisionIndustrialesVistaDTOs));
                MemoryStream memoria = new MemoryStream();
                serializer.WriteObject(memoria, ventaComisionIndustrialesDtOs);
                string datos = Encoding.UTF8.GetString(memoria.ToArray(), 0, (int)memoria.Length);
                WebClient clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.UploadString(direccionUrl + "ActualizarVentaComisionIndustrialesCompleto ", "POST", datos);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #endregion

        #region VALIDACION

        #region ORDEN TRABAJO

        /// <summary>
        ///  Obtiene el numero de  ordenes que fueron asignadas  como urgentes
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public int ObtenerNumeroEntregaUrgentesPorFechaActual(int sucursalId)
        {
            try
            {
                var clienteWeb = new WebClient();
                clienteWeb.Headers["content-type"] = "application/json";
                clienteWeb.Encoding = Encoding.UTF8;
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerNumeroEntregaUrgentesPorFechaActual?sucursalId="+ sucursalId);
                var js = new JavaScriptSerializer();
                js.MaxJsonLength = Int32.MaxValue;

                return js.Deserialize<int>(json);
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