
#region using
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using JLLR.Core.FlujoProceso.Servicio.Modelo;
using JLLR.Core.FlujoProceso.Servicio.DTOs;
#endregion
namespace JLLR.Core.FlujoProceso.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioFlujoProceso
    {

        #region HISTORIAL PROCESO

        /// <summary>
        /// Devuelve  todos  los  historiales de  proceso  del clciente, anulados  y  entregados
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate ="ObtenerHistorialProceso",ResponseFormat = WebMessageFormat.Json)]
        List<HistorialProcesoModelo> ObtenerHistorialProceso();
        /// <summary>
        /// Graba el  historial del proceso
        /// </summary>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarHistorialProceso/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        HistorialProcesoModelo GrabarHistorialProceso(HistorialProcesoModelo historialProceso);


        /// <summary>
        /// Obtener el historial del proceso por numero  de orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
           UriTemplate =
               "ObtenerHIstorialProcesosPorNumeroOrden?numeroOrden={numeroOrden}",
           ResponseFormat = WebMessageFormat.Json)]
        List<HistorialProcesoModelo> ObtenerHIstorialProcesosPorNumeroOrden(string numeroOrden);


        /// <summary>
        /// Obtiene todas las prendas  para  la logistica
        /// </summary>
        /// <param name="etapaProcesoId"></param>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
          UriTemplate =
              "ObtenerHistorialProcesoPorFlujoProceso?etapaProcesoId={etapaProcesoId}&sucursalId={sucursalId}&puntoVentaId={puntoVentaId}",
          ResponseFormat = WebMessageFormat.Json)]
        List<HistorialProcesoModelo> ObtenerHistorialProcesoPorFlujoProceso(int etapaProcesoId, int sucursalId,
            int puntoVentaId);


        /// <summary>
        /// Actualiza  el historial de proceso
        /// </summary>
        /// <param name="historialProceso"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizarHistorialProceso/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizarHistorialProceso(HistorialProcesoModelo historialProceso);

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

        [OperationContract]
        [WebGet(
          UriTemplate =
              "ObtenerHistorialProcesoPrendasPorVariosParametros?sucursalId={sucursalId}&puntoVentaId={puntoVentaId}&fechaRegistro={fechaRegistro}&etapaProcesoId={etapaProcesoId}",
          ResponseFormat = WebMessageFormat.Json)]
        List<HistorialProcesoDTOs> ObtenerHistorialProcesoPrendasPorVariosParametros(int sucursalId,
            int puntoVentaId, string fechaRegistro, int etapaProcesoId);


        #endregion

        /// <summary>
        /// Graba  el historial de  los reprocesos
        /// </summary>
        /// <param name="historialReprocesoDtOs"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarHistorialReprocesos/*", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarHistorialReprocesos(HistorialReprocesoDTOs historialReprocesoDtOs);

        /// <summary>
        /// Obtiene el lsitado de  las ordenes de reproceso
        /// </summary>
        /// <param name="detalleOrdenTrabajoId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerDetalleHistorialReprocesosPorDetalleOrdenTrabajoId?detalleOrdenTrabajoId={detalleOrdenTrabajoId}", ResponseFormat = WebMessageFormat.Json)]
        List<DetalleHistorialReprocesoDTOs> ObtenerDetalleHistorialReprocesosPorDetalleOrdenTrabajoId(
            int detalleOrdenTrabajoId);

        /// <summary>
        /// Reporte de  reproceso por prenda
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerReprocesoPorVariosParametros?puntoVentaId={puntoVentaId}&fechaDesde={fechaDesde}&fechaHasta={fechaHasta}", ResponseFormat = WebMessageFormat.Json)]
        List<ReprocesoDTOs> ObtenerReprocesoPorVariosParametros(int puntoVentaId, string fechaDesde,
            string fechaHasta);

        #endregion

        #region HISTORIAL RECLAMO  REPROCESO PRENDA

        /// <summary>
        /// Obtiene el historial de reproceso de las prendas
        /// </summary>
        /// <param name="detallePrendaOrdenTrabajoId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerHistorialReclamoReprocesoPrendaPorDetallePrendaOrdenTrabajoId?detallePrendaOrdenTrabajoId={detallePrendaOrdenTrabajoId}", ResponseFormat = WebMessageFormat.Json)]
        List<HistorialReclamoReprocesoPrendaModelo>
            ObtenerHistorialReclamoReprocesoPrendaPorDetallePrendaOrdenTrabajoId(int detallePrendaOrdenTrabajoId);


        /// <summary>
        /// Graba el  historial del reproceso de prendas   y los reclamos 
        /// </summary>
        /// <param name="historialReclamoReprocesoPrenda"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarHistorialReclamoReprocesoPrenda/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarHistorialReclamoReprocesoPrenda(
            HistorialReclamoReprocesoPrendaModelo historialReclamoReprocesoPrenda);

        #endregion

        #region HISTORIAL REPROCESO

        /// <summary>
        /// Graba el  historial del reproceso de prendas   y los reclamos 
        /// </summary>
        /// <param name="historialReclamoReprocesoPrenda"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarHistorialReproceso/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        HistorialReprocesoModelo GrabarHistorialReproceso(HistorialReprocesoModelo historialReproceso);

        /// <summary>
        /// Graba el  historial del reproceso de prendas   y los reclamos 
        /// </summary>
        /// <param name="historialReproceso"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarHistorialProcesoSinRetorno/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarHistorialProcesoSinRetorno(HistorialProcesoModelo historialReproceso);

        #endregion

        #region DETALLE  HISTORIAL  PRENDA

        /// <summary>
        /// Grabar el detalle
        /// </summary>
        /// <param name="detalleHistorialReproceso"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarDetalleHistorialReproceso/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarDetalleHistorialReproceso(DetalleHistorialReprocesoModelo detalleHistorialReproceso);


        #endregion
    }




}
