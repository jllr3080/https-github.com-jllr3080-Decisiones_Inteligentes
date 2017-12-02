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
        /// Obtiene el cliente completo por  numero  de documento
        /// </summary>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerClientePorApellidos?primerApellido={primerApellido}&segundoApellido={segundoApellido}", ResponseFormat = WebMessageFormat.Json)]
        List<ClienteGeneralDTOs> ObtenerClientePorApellidos(string primerApellido, string segundoApellido);
        /// <summary>
        /// Obtiene   la informacion del cliente
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerDatosClientePorNumeroIdentificacion?numeroIdentificacion={numeroIdentificacion}", ResponseFormat = WebMessageFormat.Json)]
        ClienteDTOs ObtenerDatosClientePorNumeroIdentificacion(string numeroIdentificacion);


        /// <summary>
        /// Obtiene   la informacion del cliente
        /// </summary>
        /// <param name="apellidoPaterno"></param>
        /// <param name="apellidoMaterno"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerDatosClientePorApellidos?apellidoPaterno={apellidoPaterno}&apellidoMaterno={apellidoMaterno}", ResponseFormat = WebMessageFormat.Json)]
        List<ClienteDTOs> ObtenerDatosClientePorApellidos(string apellidoPaterno, string apellidoMaterno);

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

        #region  TELEFONO

        /// <summary>
        /// Obtiene los numeros de  telefono 
        /// </summary>
        /// <param name="individuoId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerTelefonosPorIndividuoId?individuoId={individuoId}", ResponseFormat = WebMessageFormat.Json)]
        List<TelefonoModelo> ObtenerTelefonosPorIndividuoId(int individuoId);

        /// <summary>
        /// Eliminar  los  telefonos
        /// </summary>
        /// <param name="telefono"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "EliminaTelefono/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void EliminaTelefono(TelefonoModelo telefono);

        #endregion
    }



}
