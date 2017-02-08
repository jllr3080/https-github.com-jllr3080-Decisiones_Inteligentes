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

        /// <summary>
        /// Actualza  el  cliente
        /// </summary>
        /// <param name="clienteGeneralDtOs"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizarCliente/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizarCliente(ClienteGeneralDTOs clienteGeneralDtOs);

        /// <summary>
        /// Obtiene el cliente completo por  numero  de documento
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
             UriTemplate = "ObtenerClientePorNumeroIdentificacion?numeroIdentificacion={numeroIdentificacion}",
             ResponseFormat = WebMessageFormat.Json)]
        ClienteGeneralDTOs ObtenerClientePorNumeroIdentificacion(string numeroIdentificacion);
        #endregion

        #region PROVEEDOR

        /// <summary>
        /// Grabar Proveedor
        /// </summary>
        /// <param name="proveedorDtOs"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarProveedor/*", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]

        ProveedorModelo GrabarProveedor(ProveedorDTOs proveedorDtOs);


        /// <summary>
        /// Actualza  el  cliente
        /// </summary>
        /// <param name="clienteGeneralDtOs"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizarProveedor/*", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizarProveedor(ProveedorDTOs proveedorDtOs);

        /// <summary>
        /// Obtiene el proveedor completo por  numero  de documento
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>

        [OperationContract]
        [WebGet(UriTemplate = "ObtenerProveedorPorNumeroIdentificacion?numeroIdentificacion={numeroIdentificacion}",
            ResponseFormat = WebMessageFormat.Json)]
        ProveedorDTOs ObtenerProveedorPorNumeroIdentificacion(string numeroIdentificacion);
       
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
