
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
        /// Graba el  historial del proceso
        /// </summary>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarHistorialProceso/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarHistorialProceso(HistorialProcesoModelo historialProceso);


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

        #endregion
    }




}
