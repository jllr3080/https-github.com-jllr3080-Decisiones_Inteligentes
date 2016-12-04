#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Individuo.Servicio.DTOs;
using JLLR.Core.Individuo.Servicio.Modelo;

#endregion

namespace JLLR.Core.Individuo.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioIndividuo
    {

        #region TRANSACCIONAL

        #region CLIENTE
        /// <summary>
        /// Obtiene   la informacion del cliente
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerDatosClientePorNumeroIdentificacion?numeroIdentificacion={numeroIdentificacion}", ResponseFormat = WebMessageFormat.Json)]
        ClienteDTOs ObtenerDatosClientePorNumeroIdentificacion(string numeroIdentificacion);


        /// <summary>
        /// Grabar cliente
        /// </summary>
        /// <param name="clienteGeneralDtOs"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarCliente/*",RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        ClienteModelo GrabarCliente(ClienteGeneralDTOs clienteGeneralDtOs);
        #endregion
        #endregion

        #region VALIDACIONES
        #region CLIENTE

        /// <summary>
        /// Validar si el cliente ya existe  
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
             UriTemplate = "ValidarExistenciaClientePorNumeroIdentificacion?numeroIdentificacion={numeroIdentificacion}",
             ResponseFormat = WebMessageFormat.Json)]
        bool ValidarExistenciaClientePorNumeroIdentificacion(string numeroIdentificacion);

        #endregion

        #endregion
    }



}
