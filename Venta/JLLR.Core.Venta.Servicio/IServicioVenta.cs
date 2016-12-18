#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Venta.Servicio.DTOs;
using JLLR.Core.Venta.Servicio.Modelo;
#endregion

namespace JLLR.Core.Venta.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioVenta
    {
        #region NEGOCIO

        #region  TRANSACCIONAL
        /// <summary>
        /// Graba la orden  de trabajo de forma completa
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarOrdenTrabajoCompleta/*", RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        OrdenTrabajoModelo GrabarOrdenTrabajoCompleta(OrdenTrabajoDTOs ordenTrabajoDtOs);
        #endregion

        #region DETALLE DE  ORDEN DE TRABAJO OBSERVACIONES

        /// <summary>
        /// Graba todas las observaciones de  los detalles de la orden de trabajo
        /// </summary>
        /// <param name="detalleOrdenTrabajoObservacion"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarDetalleOrdenTrabajoObservacion/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarDetalleOrdenTrabajoObservacion(DetalleOrdenTrabajoObservacionModelo detalleOrdenTrabajoObservacion);


        /// <summary>
        /// Obtiene las observaciones 
        /// </summary>
        /// <param name="detalleOrdenTrabajoId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
            UriTemplate ="ObtenerDetalleOrdenTrabajoObservaciones?detalleOrdenTrabajoId={detalleOrdenTrabajoId}",ResponseFormat = WebMessageFormat.Json)]
        List<DetalleOrdenTrabajoObservacionModelo> ObtenerDetalleOrdenTrabajoObservaciones(int detalleOrdenTrabajoId);
       
        #endregion

        #region REPORTES

        /// <summary>
        /// Obtiene  la orden de  trabajo por  numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
             UriTemplate =
                 "ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta?numeroOrden={numeroOrden}&puntoVentaId={puntoVentaId}",
             ResponseFormat = WebMessageFormat.Json)]
        List<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(string numeroOrden, int puntoVentaId);


        /// <summary>
        /// Obtiene  
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>

        [OperationContract]
        [WebGet(
             UriTemplate =
                 "ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal?fechaDesde={fechaDesde}&sucursalId={sucursalId}",
             ResponseFormat = WebMessageFormat.Json)]
        List<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(string fechaDesde,
            int sucursalId);


        #endregion

        #endregion

       


    }




}
