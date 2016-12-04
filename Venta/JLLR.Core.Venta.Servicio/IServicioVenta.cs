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
        #region TRANSACCIONAL

        #region NEGOCIO
        /// <summary>
        /// Graba la orden  de trabajo de forma completa
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarOrdenTrabajoCompleta/*", RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        OrdenTrabajoModelo GrabarOrdenTrabajoCompleta(OrdenTrabajoDTOs ordenTrabajoDtOs);
        #endregion

        #region REPORTES

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
