#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.ReglaNegocio.Servicio.DTOs;
using JLLR.Core.ReglaNegocio.Servicio.Modelo;

#endregion

namespace JLLR.Core.ReglaNegocio.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioReglaNegocio
    {

        #region TRANSACCIONAL

        /// <summary>
        /// Obtiene  las  promociones  vigentes 
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerPromocionesVigentes?puntoVentaId={puntoVentaId}&sucursalId={sucursalId}", ResponseFormat = WebMessageFormat.Json)]
        List<ReglaModelo> ObtenerPromocionesVigentes(int puntoVentaId, int sucursalId);
      

        /// <summary>
        /// Obtener las reglas para aplicar     
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerReglasPorPuntoVentaIdYSucursalId?puntoVentaId={puntoVentaId}&sucursalId={sucursalId}", ResponseFormat = WebMessageFormat.Json)]
        List<ReglaDTOs> ObtenerReglasPorPuntoVentaIdYSucursalId(int puntoVentaId, int sucursalId);

        #endregion

        #region REGLA NEGOCIO

        /// <summary>
        /// Ejeuta las  reglas  de  negocio
        /// </summary>
        /// <param name="parametroEntradaReglaNegocio"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "EjecucionReglaNegocio/*", RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        ParametroSalidaReglaNegocioDTOs EjecucionReglaNegocio(ParametroEntradaReglaNegocioDTOs parametroEntradaReglaNegocio);

        #endregion
    }



}
