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


        /// <summary>
        /// Obtiene el historial por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        [OperationContract]
        [WebGet(
            UriTemplate = "ObtenerHistorialCuentaPorCobrarPorNumeroOrden?numeroOrden={numeroOrden}",
            ResponseFormat = WebMessageFormat.Json)]

        List<CuentaPorCobrarDTOs> ObtenerHistorialCuentaPorCobrarPorNumeroOrden(string numeroOrden);


        /// <summary>
        /// Obtiene  el historial de cuenta por cobrar  por numero de identificacion
        /// </summary>
        [OperationContract]
        [WebGet(
            UriTemplate =
                "ObtenerHistorialCuentaPorCobrarPorNumeroidentificacion?numeroIdentificacion={numeroIdentificacion}",
            ResponseFormat = WebMessageFormat.Json)]
        List<CuentaPorCobrarDTOs> ObtenerHistorialCuentaPorCobrarPorNumeroidentificacion(string numeroIdentificacion);
       
        #endregion

        #region CUENTA POR COBRAR

        /// <summary>
        /// Graba la cabecera de la cuenta por cobrar
        /// </summary>
        /// <param name="cuentaPorCobrar"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarCuentaPorCobrar/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        CuentaPorCobrarModelo GrabarCuentaPorCobrar(CuentaPorCobrarModelo cuentaPorCobrar);


        /// <summary>
        /// Actualiza las  cuentas  por cobrar
        /// </summary>
        /// <param name="cuentaPorCobrar"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizaCuentaPorCobrar/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizaCuentaPorCobrar(CuentaPorCobrarModelo cuentaPorCobrar);

        #endregion

        #region HISTORIAL CUENTAS POR COBRAR

        /// <summary>
        /// Graba el  historial de los cobros
        /// </summary>
        /// <param name="historialCuentaPorCobrar"></param>
        /// <returns></returns>

        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarHistorialCuentaPorCobrar/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        HistorialCuentaPorCobrarModelo GrabarHistorialCuentaPorCobrar(
            HistorialCuentaPorCobrarModelo historialCuentaPorCobrar);



        /// <summary>
        /// Actualiza  las  cuentas por cobrar
        /// </summary>
        /// <param name="historialCuentaPorCobrar"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizarHistorialCuentaPorCobrar/*", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]

        void ActualizarHistorialCuentaPorCobrar(HistorialCuentaPorCobrarModelo historialCuentaPorCobrar);
        
        #endregion

        #region CUENTA POR PAGAR

        /// <summary>
        /// Graba las cuentas  por  pagar
        /// </summary>
        /// <param name="cuentaPorPagar"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarCuentaPorPagar/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        CuentaPorPagarModelo GrabarCuentaPorPagar(CuentaPorPagarModelo cuentaPorPagar);


        /// <summary>
        /// Graba las cuentas  por  pagar
        /// </summary>
        /// <param name="cuentaPorPagar"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizaCuentaPorPagar/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizaCuentaPorPagar(CuentaPorPagarModelo cuentaPorPagar);

        #endregion

        #region HISTORIAL CUENTAS POR PAGAR

        /// <summary>
        /// Graba el historial de las cuentas por  pagar
        /// </summary>
        /// <param name="historialCuentaPorPagar"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarHistorialCuentaPorPagar/*", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        HistorialCuentaPorPagarModelo GrabarHistorialCuentaPorPagar(
            HistorialCuentaPorPagarModelo historialCuentaPorPagar);

        /// <summary>
        /// Actualiza el historial de cuentas  por pagar
        /// </summary>
        /// <param name="historialCuentaPorPagar"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizaHistorialCuentaPorPagar/*", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]

        void ActualizaHistorialCuentaPorPagar(HistorialCuentaPorPagarModelo historialCuentaPorPagar);

        #endregion
    }



}
