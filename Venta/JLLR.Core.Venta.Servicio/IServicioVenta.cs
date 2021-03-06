﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Venta.Servicio.DTOs;
using JLLR.Core.Venta.Servicio.Modelo;
using JLLR.Core.Venta.Servicio.Modelo.Parametrizacion;

#endregion

namespace JLLR.Core.Venta.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioVenta
    {
        #region NEGOCIO

        #region  TRANSACCIONAL

        /// <summary>
        /// Graba la operacion de descuento  
        /// </summary>
        /// <param name="parametroAnulacionDtOs"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarAnluacionPrenda/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarAnluacionPrenda(ParametroAnulacionDTOs parametroAnulacionDtOs);
        
        /// <summary>
        /// Grabar el detallde  de las prendas
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>

        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarDetallePrendaCompleto/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarDetallePrendaCompleto(OrdenTrabajoDTOs ordenTrabajoDtOs);
                /// <summary>
        /// Obtiene la impresion corta sin el detalle de las prensdas
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        [WebGet(
                   UriTemplate =
                       "ObtenerOrdenTrabajoCortaPorNumeroOrdenYPuntoVenta?numeroOrden={numeroOrden}&puntoVentaId={puntoVentaId}",
                   ResponseFormat = WebMessageFormat.Json)]
        List<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoCortaPorNumeroOrdenYPuntoVenta(string numeroOrden,
            int puntoVentaId);

        /// <summary>
        /// Obtiene las  ordenes temporales
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerOrdenTrabajoPorEstadoTemporal?puntoVentaId={puntoVentaId}", ResponseFormat = WebMessageFormat.Json)]
        List<OrdenTrabajoDTOs> ObtenerOrdenTrabajoPorEstadoTemporal(int puntoVentaId);
        /// <summary>
        /// Obtiene  el detalle  de las  fotografias   guardadas
        /// </summary>
        /// <param name="detallePrendaOrdenTrabajoId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerDetalleOrdenTrabajoFotografiaDtOsesPorDetallePrendaId?detallePrendaOrdenTrabajoId={detallePrendaOrdenTrabajoId}", ResponseFormat = WebMessageFormat.Json)]
        List<DetalleOrdenTrabajoFotografiaDTOs>
            ObtenerDetalleOrdenTrabajoFotografiaDtOsesPorDetallePrendaId(int detallePrendaOrdenTrabajoId);
      
        /// <summary>
        /// Graba la operacion de descuento  
        /// </summary>
        /// <param name="parametroDescuentoDtOs"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarTransaccionDescuentoOrden/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]

        void GrabarTransaccionDescuentoOrden(ParametroDescuentoDTOs parametroDescuentoDtOs);
       

        /// <summary>
        /// Graba el reverso de la transaccion reversa comision,cuenta por  cobrar y cuenta por  pagar
        /// </summary>
        /// <param name="parametroReversoDtOs"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarReversoTransaccion/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string GrabarReversoTransaccion(ParametroReversoDTOs parametroReversoDtOs);
        

        /// <summary>
        /// Graba las comisiones  hace un asiento de  cuentas por cobrar y cuentas por pagar
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>

        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarTransaccionInicialCompleta/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string GrabarTransaccionInicialCompleta(OrdenTrabajoDTOs ordenTrabajoDtOs);

        /// <summary>
        /// Obtiene todas las observaciones  de las prendas por  
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId?detalleOrdenTrabajoId={detalleOrdenTrabajoId}", ResponseFormat = WebMessageFormat.Json)]
        List<DetalleOrdenTrabajoObservacionDTOs> ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId(
            int detalleOrdenTrabajoId);

        /// <summary>
        /// Obtiene  todos los descuentos   que  estan por aprobarse
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerOrdenesTrabajoDescuentoPorEstadoProceso", ResponseFormat = WebMessageFormat.Json)]
        List<OrdenTrabajoDescuentoDTO> ObtenerOrdenesTrabajoDescuentoPorEstadoProceso();
       
        /// <summary>
        /// Graba la orden  de trabajo de forma completa
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarOrdenTrabajoCompleta/*", RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        OrdenTrabajoDTOs GrabarOrdenTrabajoCompleta(OrdenTrabajoDTOs ordenTrabajoDtOs);

        /// <summary>
        /// Obtiene todas las  ordenes  que estan lista para enviarse  a matriz
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerOrdenTrabajoPorEnvioMatriz?puntoVentaId={puntoVentaId}&sucursalId={sucursalId}", ResponseFormat = WebMessageFormat.Json)]
        List<OrdenTrabajoDTOs> ObtenerOrdenTrabajoPorEnvioMatriz(int puntoVentaId, int sucursalId);


       
        #endregion

        #region ORDEN TRABAJO

        /// <summary>
        /// Actualiza  la orden de trabajo
        /// </summary>
        /// <param name="ordenTrabajo"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizarOrdenTrabajo/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizarOrdenTrabajo(OrdenTrabajoModelo ordenTrabajo);

        /// <summary>
        /// Obtiene  por  id de la orden de trabajo
        /// </summary>
        /// <param name="ordenTrabajoId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
             UriTemplate =
                 "ObtenerOrdenTrabajoPorOrdenTrabajoId?ordenTrabajoId={ordenTrabajoId}",
             ResponseFormat = WebMessageFormat.Json)]
        OrdenTrabajoDTOs ObtenerOrdenTrabajoPorOrdenTrabajoId(int ordenTrabajoId);
        #endregion

        #region DETALLE DE  ORDEN DE TRABAJO OBSERVACIONES

        /// <summary>
        /// Graba todas las observaciones de  los detalles de la orden de trabajo
        /// </summary>
        /// <param name="detalleOrdenTrabajoObservacion"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarDetalleOrdenTrabajoObservacion/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarDetalleOrdenTrabajoObservacion(DetalleOrdenTrabajoObservacionModelo detalleOrdenTrabajoObservacion);


        /// <summary>
        /// Obtiene las observaciones 
        /// </summary>
        /// <param name="detalleOrdenTrabajoId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
            UriTemplate ="ObtenerDetalleOrdenTrabajoObservaciones?detalleOrdenTrabajoId={detalleOrdenTrabajoId}",ResponseFormat = WebMessageFormat.Json)]
        List<DetalleOrdenTrabajoObservacionModelo> ObtenerDetalleOrdenTrabajoObservaciones(int detalleOrdenTrabajoId);

        #endregion

        #region ORDEN TRABAJO COMISION

        /// <summary>
        /// Graba la comision de la orden de  trabajo
        /// </summary>
        /// <param name="ordenTrabajoComision"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabaOrdenTrabajoComision/*", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        OrdenTrabajoComisionModelo GrabaOrdenTrabajoComision(OrdenTrabajoComisionModelo ordenTrabajoComision);

        #endregion

        #region  VENTA COMISION

        /// <summary>
        /// Graba la  venta de la ocmision
        /// </summary>
        /// <param name="ventaComision"></param>

        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarVentaComision/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarVentaComision(VentaComisionModelo ventaComision);



        /// <summary>
        /// Actualizar  venta de  comision
        /// </summary>
        /// <param name="ventaComision"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizarVentaComision/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizarVentaComision(VentaComisionModelo ventaComision);


        /// <summary>
        /// Obtiene las  venta de las comisiones
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerVentaComisiones?puntoVentaId={puntoVentaId}", ResponseFormat = WebMessageFormat.Json)]
        List<VentaComisionModelo> ObtenerVentaComisiones(int puntoVentaId);
        

        /// <summary>
        /// Obtiene 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerVentaComisionPorusuarioId?usuarioId={usuarioId}", ResponseFormat = WebMessageFormat.Json)]
        VentaComisionModelo ObtenerVentaComisionPorusuarioId(int usuarioId);

        #endregion

        #region HISTORIAL REGLA

        /// <summary>
        /// Graba el  historial de las  reglas
        /// </summary>
        /// <param name="historialRegla"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarHistorialRegla/*", RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarHistorialRegla(HistorialReglaModelo historialRegla);

        #endregion

        #region ORDEN TRABAJO DESCUENTO

        /// <summary>
        /// Actualiza  la orden de  descuento
        /// </summary>
        /// <param name="ordenTrabajoDescuento"></param>
        [WebInvoke(UriTemplate = "ActualizarOrdenTrabajoDescuento/*", RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizarOrdenTrabajoDescuento(OrdenTrabajoDescuentoModelo ordenTrabajoDescuento);
        /// <summary>
        /// Graba el descuento de la orden d etrabajo
        /// </summary>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarOrdenTrabajoDescuento/*", RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarOrdenTrabajoDescuento(OrdenTrabajoDescuentoModelo ordenTrabajoDescuento);



        /// <summary>
        /// Obtiene todas las ordenes de  trabajo para ekl descuento  por el estado
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerOrdenTrabajoDescuentoPorEstadoProceso", ResponseFormat = WebMessageFormat.Json)]
        List<OrdenTrabajoDescuentoModelo> ObtenerOrdenTrabajoDescuentoPorEstadoProceso();

        #endregion

        #region  APROBACION DESCUENTO

        /// <summary>
        /// Graba la  aprobacion del descuento
        /// </summary>
        /// <param name="aprobacionDescuento"></param>

        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarAprobacionDescuento/*", RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarAprobacionDescuento(AprobacionDescuentoModelo aprobacionDescuento);

        #endregion

        #region REPORTES

        /// <summary>
        ///  Obtiene el reporte de prenda  y marcas 
        /// </summary>
        /// <param name="prendaId"></param>
        /// <param name="marcaId"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
            UriTemplate =
                "ObtenerPrendayMarcaPorVariosParametros?prendaId={prendaId}&marcaId={marcaId}&fecha={fecha}&colorId={colorId}",
            ResponseFormat = WebMessageFormat.Json)]
        List<PrendaMarcaDTOs> ObtenerPrendayMarcaPorVariosParametros(int prendaId, int marcaId, string fecha,int colorId);
        /// <summary>
        /// Obtiene el reporte de   numero de  prendas por  fecha  desde y fecha hasta
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
            UriTemplate =
                "ObtenerNumeroPrendasPorFecha?fechaDesde={fechaDesde}&fechaHasta={fechaHasta}&sucursalId={sucursalId}",
            ResponseFormat = WebMessageFormat.Json)]
        List<NumeroPrendaDTOs> ObtenerNumeroPrendasPorFecha(string fechaDesde, string fechaHasta, int sucursalId);


        /// <summary>
        /// Obtiene el  reporte de   estadp de  cuenta 
        /// </summary>
        /// <param name="puntoventaId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>

        [WebGet(
           UriTemplate =
               "ObtenerEstadoCuentaPorVariosParametros?puntoventaId={puntoventaId}&fechaDesde={fechaDesde}&fechaHasta={fechaHasta}",
           ResponseFormat = WebMessageFormat.Json)]
        List<EstadoCuentaDTOs> ObtenerEstadoCuentaPorVariosParametros(int puntoventaId, string fechaDesde,
            string fechaHasta);
       

        /// <summary>
        /// Obtiene  la orden de  trabajo por  numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
             UriTemplate =
                 "ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta?numeroOrden={numeroOrden}&puntoVentaId={puntoVentaId}",
             ResponseFormat = WebMessageFormat.Json)]
        List<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(string numeroOrden, int puntoVentaId);


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

        /// <summary>
        /// Metodo para extraer solo el detalle de la orden de  trabajo
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
           UriTemplate =
               "ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta?numeroOrden={numeroOrden}&puntoVentaId={puntoVentaId}",
           ResponseFormat = WebMessageFormat.Json)]
        List<DetalleOrdenTrabajoModelo> ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta(string numeroOrden,
            int puntoVentaId);

        #endregion


        #region DETALLE  ORDEN  TRABAJO  FOTOGRAFIA

        /// <summary>
        /// Graba la fotografia  que se  genero en la orden de trabajo
        /// </summary>
        /// <param name="detalleTrabajoFotografia"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarDetalleOrdenFotografia/*", RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarDetalleOrdenFotografia(DetalleOrdenTrabajoFotografiaModelo detalleTrabajoFotografia);

        #endregion

        #region  DETALLE PRENDA

        /// <summary>
        /// Graba la orden de trabajo
        /// </summary>
        /// <param name="detallePrendaOrdenTrabajo"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarDetallePrendaOrdenTrabajo/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        DetallePrendaOrdenTrabajoModelo GrabarDetallePrendaOrdenTrabajo(
            DetallePrendaOrdenTrabajoModelo detallePrendaOrdenTrabajo);



        /// <summary>
        /// Actualiza la orden de trabajo
        /// </summary>
        /// <param name="detallePrendaOrdenTrabajo"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizarDetallePrendaOrdenTrabajo/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizarDetallePrendaOrdenTrabajo(DetallePrendaOrdenTrabajoModelo detallePrendaOrdenTrabajo);

        #endregion

        #region NUMERACION ORDEN


        /// <summary>
        /// Obtiene  todas las sucursales 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerPuntosVentaCompleto", ResponseFormat = WebMessageFormat.Json)]
        List<NumeracionOrdenDTOs> ObtenerPuntosVentaCompleto();

        /// <summary>
        /// Grabar punto de  venta y numero de  orden
        /// </summary>
        /// <param name="numeracionOrdenDtOs"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarPuntoVentaCompleto/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarPuntoVentaCompleto(NumeracionOrdenDTOs numeracionOrdenDtOs);



        /// <summary>
        /// Grabar punto de  venta y numero de  orden
        /// </summary>
        /// <param name="numeracionOrdenDtOs"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizarPuntoVentaCompleto/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizarPuntoVentaCompleto(NumeracionOrdenDTOs numeracionOrdenDtOs);




        #endregion

        #region VENTA COMISION  INDUSTRIALES

        /// <summary>
        /// Obtiene el valor de la venta de  industriales
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerComisionesIndustrialesPorPuntoVenta?puntoVentaId={puntoVentaId}", ResponseFormat = WebMessageFormat.Json)]
        List<VentaComisionIndustrialesDTOs> ObtenerComisionesIndustrialesPorPuntoVenta(int puntoVentaId);


        /// <summary>
        /// Grabar promociones
        /// </summary>
        /// <param name="ventaComisionIndustrialesDtOs"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarVentaComisionIndustrialesCompleto/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarVentaComisionIndustrialesCompleto(VentaComisionIndustrialesDTOs ventaComisionIndustrialesDtOs);



        /// <summary>
        /// Actualizar promociones
        /// </summary>
        /// <param name="ventaComisionIndustrialesDtOs"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizarVentaComisionIndustrialesCompleto/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizarVentaComisionIndustrialesCompleto(VentaComisionIndustrialesDTOs ventaComisionIndustrialesDtOs);
        
        #endregion
        #endregion
        #region VALIDACION

        #region ORDEN TRABAJO

        /// <summary>
        ///  Obtiene el numero de  ordenes que fueron asignadas  como urgentes
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerNumeroEntregaUrgentesPorFechaActual?sucursalId={sucursalId}", ResponseFormat = WebMessageFormat.Json)]

     
        int ObtenerNumeroEntregaUrgentesPorFechaActual(int sucursalId);


        #endregion

        #endregion



    }




}
