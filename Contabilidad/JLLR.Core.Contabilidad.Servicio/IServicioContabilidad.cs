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
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
            UriTemplate = "ObtenerHistorialCuentaPorCobrarPorVariosParametros?numeroOrden={numeroOrden}&puntoVentaId={puntoVentaId}&sucursalId={sucursalId}",
            ResponseFormat = WebMessageFormat.Json)]
        List<CuentaPorCobrarDTOs> ObtenerHistorialCuentaPorCobrarPorVariosParametros(string numeroOrden,
            int puntoVentaId, int sucursalId);

        /// <summary>
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
            UriTemplate = "ObtenerHistorialCuentaPorPagarPorVariosParametros?numeroOrden={numeroOrden}&puntoVentaId={puntoVentaId}&sucursalId={sucursalId}",
            ResponseFormat = WebMessageFormat.Json)]
        List<CuentaPorPagarDTOs> ObtenerHistorialCuentaPorPagarPorVariosParametros(string numeroOrden, int puntoVentaId,
            int sucursalId);
       

        /// <summary>
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        [OperationContract]
        [WebGet(
            UriTemplate = "ObtenerHistorialCuentaPorPagarPorNumeroOrden?numeroOrden={numeroOrden}",
            ResponseFormat = WebMessageFormat.Json)]
        List<CuentaPorPagarDTOs> ObtenerHistorialCuentaPorPagarPorNumeroOrden(string numeroOrden);
       
        /// <summary>
        /// Graba el asiento tanto  positivo como negativo
        /// </summary>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarAsiento/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarAsiento(AsientoDTOs asientoDtOs);

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


        /// <summary>
        /// Obtener  las cuentas  por  cobrar  por  fecha desde y  hasta  y el punto de  venta
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
            UriTemplate =
                "ObtenerCuentaPorPagarPorFechas?fechaDesde={fechaDesde}&fechaHasta={fechaHasta}&sucursalId={sucursalId}",
            ResponseFormat = WebMessageFormat.Json)]
        List<CuentaPorPagarDTOs> ObtenerCuentaPorPagarPorFechas(string fechaDesde, string fechaHasta,
            int sucursalId);

        /// <summary>
        /// Obtiene las aplicaciones de pago para ser validadas
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="mesId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
           UriTemplate =
               "ObtenerAplicacionPagosPorPuntoVentaIdYMesId?puntoVentaId={puntoVentaId}&mesId={mesId}",
           ResponseFormat = WebMessageFormat.Json)]
        List<AplicacionPagoDTOs> ObtenerAplicacionPagosPorPuntoVentaIdYMesId(int puntoVentaId, int mesId);
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

        /// <summary>
        /// Obtener las cuentas  por  cobrar por  fecha
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
           UriTemplate = "ObtenerCuentasPorCobrarPorFecha?sucursalId={sucursalId}&fechaDesde={fechaDesde}&fechaHasta={fechaHasta}",
           ResponseFormat = WebMessageFormat.Json)]
        List<CuentaPorCobrarModelo> ObtenerCuentasPorCobrarPorFecha(int sucursalId, string fechaDesde,
            string fechaHasta);

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

        /// <summary>
        /// Obtener  las cuentas  por pagar por  fecha
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechahasta"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
          UriTemplate = "ObtenerCuentaPorPagarPorFecha?sucursalId={sucursalId}&fechaDesde={fechaDesde}&fechaHasta={fechaHasta}",
          ResponseFormat = WebMessageFormat.Json)]
        List<CuentaPorPagarModelo> ObtenerCuentaPorPagarPorFecha(int sucursalId, string fechaDesde,
            string fechaHasta);

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

        #region  CIERRE MES

        /// <summary>
        /// Graba  el cierre  de  mes 
        /// </summary>
        /// <param name="cierreMes"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarCierreMes/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        CierreMesModelo GrabarCierreMes(CierreMesModelo cierreMes);



        /// <summary>
        /// Cierre  de  mes 
        /// </summary>
        /// <param name="mesId"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
           UriTemplate =
               "ObtenerCierresMesPorAplicacionPendiente?mesId={mesId}&puntoVentaId={puntoVentaId}",
           ResponseFormat = WebMessageFormat.Json)]
        List<CierreMesModelo> ObtenerCierresMesPorAplicacionPendiente(int mesId, int puntoVentaId);

        #endregion

        #region APLICACION PAGO

        /// <summary>
        /// Graba  el cierre  de  mes 
        /// </summary>
        /// <param name="aplicacionPago"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabaAplicacionPago/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        AplicacionPagoModelo GrabaAplicacionPago(AplicacionPagoModelo aplicacionPago);


        /// <summary>
        /// Graba  el cierre  de  mes 
        /// </summary>
        /// <param name="aplicacionPago"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizaAplicacionPago/*", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        AplicacionPagoModelo ActualizaAplicacionPago(AplicacionPagoModelo aplicacionPago);

        /// <summary>
        ///Obtiene  los pagos por cada  cierre  de  mes 
        /// </summary>
        /// <param name="cierreMesId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
          UriTemplate =
              "ObtenerAplicacionPagoPorCierreMesId?cierreMesId={cierreMesId}",
          ResponseFormat = WebMessageFormat.Json)]
        List<AplicacionPagoModelo> ObtenerAplicacionPagoPorCierreMesId(int cierreMesId);

        #endregion
    }



}
