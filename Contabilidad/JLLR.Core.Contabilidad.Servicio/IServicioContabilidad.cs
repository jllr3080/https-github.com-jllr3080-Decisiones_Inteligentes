#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Contabilidad.Servicio.DTOs;
using JLLR.Core.Contabilidad.Servicio.Modelo;

#endregion

namespace JLLR.Core.Contabilidad.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioContabilidad
    {

        #region TRANSACCIONAL

        /// <summary>
        /// Graba la cuenta por pagar  
        /// </summary>
        /// <param name="cuentaPorCobrarDtOs"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarCuentaPorCobrarCompleta/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        CuentaPorCobrarModelo GrabarCuentaPorCobrarCompleta(CuentaPorCobrarDTOs cuentaPorCobrarDtOs);

        #endregion
    }



}
