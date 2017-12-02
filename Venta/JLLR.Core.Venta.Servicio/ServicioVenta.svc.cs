#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Venta.Proveedor.Validacion;
using JLLR.Core.Venta.Servicio.DTOs;
using JLLR.Core.Venta.Servicio.Modelo;
using JLLR.Core.Venta.Servicio.Modelo.Parametrizacion;
using JLLR.Core.Venta.Servicio.Negocio;
using JLLR.Core.Venta.Servicio.Transformador;

#endregion

namespace JLLR.Core.Venta.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioVenta : IServicioVenta
    {
        #region  DECLARACIONES  E INSTANCIAS
        private readonly VentaTransfomadorNegocio _ventaTransformadorNegocio = new VentaTransfomadorNegocio();
        private  readonly  VentaNegocio _ventaNegocio= new VentaNegocio();

        #endregion

        #region TRANSACCIONAL
        #region NEGOCIO

        /// <summary>
        /// Graba la operacion de descuento  
        /// </summary>
        /// <param name="parametroAnulacionDtOs"></param>
        public void GrabarAnluacionPrenda(ParametroAnulacionDTOs parametroAnulacionDtOs)
        {
            try
            {
                _ventaNegocio.GrabarAnluacionPrenda(parametroAnulacionDtOs);
            }
            catch ( Exception ex)
            {
            }
        }

    /// <summary>
    /// Grabar el detallde  de las prendas
    /// </summary>
    /// <param name="ordenTrabajoDtOs"></param>

    public
            void GrabarDetallePrendaCompleto(OrdenTrabajoDTOs ordenTrabajoDtOs)
        {
            try
            {
              _ventaTransformadorNegocio.GrabarDetallePrendaCompleto(ordenTrabajoDtOs);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Obtiene la impresion corta sin el detalle de las prensdas
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoCortaPorNumeroOrdenYPuntoVenta(string numeroOrden,
            int puntoVentaId)
        {
            try
            {
                return _ventaTransformadorNegocio.ObtenerOrdenTrabajoCortaPorNumeroOrdenYPuntoVenta(numeroOrden,
                    puntoVentaId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Obtiene las  ordenes temporales
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<OrdenTrabajoDTOs> ObtenerOrdenTrabajoPorEstadoTemporal(int puntoVentaId)
        {
            try
            {
                return _ventaTransformadorNegocio.ObtenerOrdenTrabajoPorEstadoTemporal(puntoVentaId);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Obtiene  el detalle  de las  fotografias   guardadas
        /// </summary>
        /// <param name="detallePrendaOrdenTrabajoId"></param>
        /// <returns></returns>
        public List<DetalleOrdenTrabajoFotografiaDTOs>
            ObtenerDetalleOrdenTrabajoFotografiaDtOsesPorDetallePrendaId(int detallePrendaOrdenTrabajoId)
        {
            try
            {
                return
                    _ventaTransformadorNegocio.ObtenerDetalleOrdenTrabajoFotografiaDtOsesPorDetallePrendaId(
                        detallePrendaOrdenTrabajoId);
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Graba la operacion de descuento  
        /// </summary>
        /// <param name="parametroDescuentoDtOs"></param>
        public void GrabarTransaccionDescuentoOrden(ParametroDescuentoDTOs parametroDescuentoDtOs)
        {
            try
            {
                _ventaNegocio.GrabarTransaccionDescuentoOrden(parametroDescuentoDtOs);
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba el reverso de la transaccion reversa comision,cuenta por  cobrar y cuenta por  pagar
        /// </summary>
        /// <param name="parametroReversoDtOs"></param>
        /// <returns></returns>
        public string GrabarReversoTransaccion(ParametroReversoDTOs parametroReversoDtOs)
        {
            try
            {


                return _ventaNegocio.GrabarReversoTransaccion(parametroReversoDtOs);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Graba las comisiones  hace un asiento de  cuentas por cobrar y cuentas por pagar
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>

        public string GrabarTransaccionInicialCompleta(OrdenTrabajoDTOs ordenTrabajoDtOs)
        {
            try
            {
               return _ventaNegocio.GrabarTransaccionInicialCompleta(ordenTrabajoDtOs);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Obtiene todas las observaciones  de las prendas por  
        /// </summary>
        /// <returns></returns>

        public List<DetalleOrdenTrabajoObservacionDTOs> ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId(int detalleOrdenTrabajoId)
        {
            try
            {
                return
                    _ventaTransformadorNegocio.ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId(
                        detalleOrdenTrabajoId);



            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene  todos los descuentos   que  estan por aprobarse
        /// </summary>
        /// <returns></returns>
        public List<OrdenTrabajoDescuentoDTO> ObtenerOrdenesTrabajoDescuentoPorEstadoProceso()
        {
            try
            {


                return _ventaTransformadorNegocio.ObtenerOrdenesTrabajoDescuentoPorEstadoProceso();


            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba la orden  de trabajo de forma completa
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>
        /// <returns></returns>
        public OrdenTrabajoDTOs GrabarOrdenTrabajoCompleta(OrdenTrabajoDTOs ordenTrabajoDtOs)
        {
            try
            {
                return _ventaTransformadorNegocio.GrabarOrdenTrabajoCompleta(ordenTrabajoDtOs);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las  ordenes  que estan lista para enviarse  a matriz
        /// </summary>
        /// <returns></returns>
        public List<OrdenTrabajoDTOs> ObtenerOrdenTrabajoPorEnvioMatriz(int puntoVentaId, int sucursalId)
        {
            try
            {
                return _ventaTransformadorNegocio.ObtenerOrdenTrabajoPorEnvioMatriz(puntoVentaId,sucursalId);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

       
        #endregion

        #region ORDEN TRABAJO

        /// <summary>
        /// Actualiza la orden de trabajo
        /// </summary>
        /// <param name=""></param>
        public void ActualizarOrdenTrabajo(OrdenTrabajoModelo ordenTrabajo)
        {
            try
            {
                _ventaTransformadorNegocio.ActualizarOrdenTrabajo(ordenTrabajo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene  por  id de la orden de trabajo
        /// </summary>
        /// <param name="ordenTrabajoId"></param>
        /// <returns></returns>
        public OrdenTrabajoDTOs ObtenerOrdenTrabajoPorOrdenTrabajoId(int ordenTrabajoId)
        {
            try
            {
                return _ventaTransformadorNegocio.ObtenerOrdenTrabajoPorOrdenTrabajoId(ordenTrabajoId);
                    
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region DETALLE DE  ORDEN DE TRABAJO OBSERVACIONES
        /// <summary>
        /// Graba todas las observaciones de  los detalles de la orden de trabajo
        /// </summary>
        /// <param name="detalleOrdenTrabajoObservacion"></param>
        public void GrabarDetalleOrdenTrabajoObservacion(DetalleOrdenTrabajoObservacionModelo detalleOrdenTrabajoObservacion)
        {
            try
            {
                _ventaTransformadorNegocio.GrabarDetalleOrdenTrabajoObservacion(detalleOrdenTrabajoObservacion);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene las observaciones 
        /// </summary>
        /// <param name="detalleOrdenTrabajoId"></param>
        /// <returns></returns>
        public List<DetalleOrdenTrabajoObservacionModelo> ObtenerDetalleOrdenTrabajoObservaciones(
            int detalleOrdenTrabajoId)
        {
            try
            {
                return
                    _ventaTransformadorNegocio.ObtenerDetalleOrdenTrabajoObservaciones(detalleOrdenTrabajoId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region ORDEN TRABAJO COMISION

        /// <summary>
        /// Graba la comision de la orden de  trabajo
        /// </summary>
        /// <param name="ordenTrabajoComision"></param>
        public OrdenTrabajoComisionModelo GrabaOrdenTrabajoComision(OrdenTrabajoComisionModelo ordenTrabajoComision)
        {
            try
            {
                return _ventaTransformadorNegocio.GrabaOrdenTrabajoComision(ordenTrabajoComision);


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  VENTA COMISION

        /// <summary>
        /// Obtiene 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        public VentaComisionModelo ObtenerVentaComisionPorusuarioId(int usuarioId)
        {
            try
            {
                return _ventaTransformadorNegocio.ObtenerVentaComisionPorusuarioId(usuarioId);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba la  venta de la ocmision
        /// </summary>
        /// <param name="ventaComision"></param>

        public void GrabarVentaComision(VentaComisionModelo ventaComision)
        {
            try
            {
                _ventaTransformadorNegocio.GrabarVentaComision(ventaComision);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Actualizar  venta de  comision
        /// </summary>
        /// <param name="ventaComision"></param>
        public void ActualizarVentaComision(VentaComisionModelo ventaComision)
        {
            try
            {
                _ventaTransformadorNegocio.ActualizarVentaComision(ventaComision);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Obtiene las  venta de las comisiones
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<VentaComisionModelo> ObtenerVentaComisiones(int puntoVentaId)
        {
            try
            {
                return _ventaTransformadorNegocio.ObtenerVentaComisiones(puntoVentaId);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region HISTORIAL REGLA
        /// <summary>
        /// Graba el  historial de las  reglas
        /// </summary>
        /// <param name="historialRegla"></param>
        public void GrabarHistorialRegla(HistorialReglaModelo historialRegla)
        {
            try
            {

                _ventaTransformadorNegocio.GrabarHistorialRegla(historialRegla);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region ORDEN TRABAJO DESCUENTO

        /// <summary>
        /// Actualiza  la orden de  descuento
        /// </summary>
        /// <param name="ordenTrabajoDescuento"></param>
        public void ActualizarOrdenTrabajoDescuento(OrdenTrabajoDescuentoModelo ordenTrabajoDescuento)
        {
            try
            {

                _ventaTransformadorNegocio.ActualizarOrdenTrabajoDescuento(ordenTrabajoDescuento);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Graba el descuento de la orden d etrabajo
        /// </summary>
        public void GrabarOrdenTrabajoDescuento(OrdenTrabajoDescuentoModelo ordenTrabajoDescuento)
        {
            try
            {
              _ventaTransformadorNegocio.GrabarOrdenTrabajoDescuento(ordenTrabajoDescuento);

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Obtiene todas las ordenes de  trabajo para ekl descuento  por el estado
        /// </summary>
        /// <returns></returns>
        public List<OrdenTrabajoDescuentoModelo> ObtenerOrdenTrabajoDescuentoPorEstadoProceso()
        {
            try
            {

                return _ventaTransformadorNegocio.ObtenerOrdenTrabajoDescuentoPorEstadoProceso();


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  APROBACION DESCUENTO
        /// <summary>
        /// Graba la  aprobacion del descuento
        /// </summary>
        /// <param name="aprobacionDescuento"></param>

        public void GrabarAprobacionDescuento(AprobacionDescuentoModelo aprobacionDescuento)
        {
            try
            {
               _ventaTransformadorNegocio.GrabarAprobacionDescuento(aprobacionDescuento);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region REPORTES

        /// <summary>
        ///  Obtiene el reporte de prenda  y marcas 
        /// </summary>
        /// <param name="prendaId"></param>
        /// <param name="marcaId"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<PrendaMarcaDTOs> ObtenerPrendayMarcaPorVariosParametros(int prendaId, int marcaId, string fecha, int colorId    )
        {
            try
            {
                return _ventaTransformadorNegocio.ObtenerPrendayMarcaPorVariosParametros(prendaId, marcaId,Convert.ToDateTime(fecha),colorId);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene el reporte de   numero de  prendas por  fecha  desde y fecha hasta
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>

        public List<NumeroPrendaDTOs> ObtenerNumeroPrendasPorFecha(string fechaDesde, string fechaHasta,int sucursalId)
        {
            try
            {

                return _ventaTransformadorNegocio.ObtenerNumeroPrendasPorFecha(Convert.ToDateTime(fechaDesde),Convert.ToDateTime(fechaHasta), sucursalId);



            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene el  reporte de   estadp de  cuenta 
        /// </summary>
        /// <param name="puntoventaId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>
        public List<EstadoCuentaDTOs> ObtenerEstadoCuentaPorVariosParametros(int puntoventaId, string fechaDesde,
            string fechaHasta)
        {
            try
            {
                return _ventaTransformadorNegocio.ObtenerEstadoCuentaPorVariosParametros(puntoventaId,Convert.ToDateTime(fechaDesde),
                    Convert.ToDateTime(fechaHasta));


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene  la orden de  trabajo por  numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(string numeroOrden, int puntoVentaId)
        {
            try
            {

                return _ventaTransformadorNegocio.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(numeroOrden, puntoVentaId);


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene  
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(string fechaDesde, int sucursalId)
        {
            try
            {
                return _ventaTransformadorNegocio.ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(Convert.ToDateTime(fechaDesde), sucursalId);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Metodo para extraer solo el detalle de la orden de  trabajo
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<DetalleOrdenTrabajoModelo> ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta(string numeroOrden,
            int puntoVentaId)
        {
            try
            {
                return _ventaTransformadorNegocio.ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta(numeroOrden,
                    puntoVentaId);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region DETALLE  ORDEN  TRABAJO  FOTOGRAFIA
        /// <summary>
        /// Graba la fotografia  que se  genero en la orden de trabajo
        /// </summary>
        /// <param name="detalleTrabajoFotografia"></param>
        public void GrabarDetalleOrdenFotografia(DetalleOrdenTrabajoFotografiaModelo detalleTrabajoFotografia)
        {
            try
            {
               _ventaTransformadorNegocio.GrabarDetalleOrdenFotografia(detalleTrabajoFotografia);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  DETALLE PRENDA
        /// <summary>
        /// Graba la orden de trabajo
        /// </summary>
        /// <param name="detallePrendaOrdenTrabajo"></param>
        /// <returns></returns>
        public DetallePrendaOrdenTrabajoModelo GrabarDetallePrendaOrdenTrabajo(DetallePrendaOrdenTrabajoModelo detallePrendaOrdenTrabajo)
        {
            try
            {
                return _ventaTransformadorNegocio.GrabarDetallePrendaOrdenTrabajo(detallePrendaOrdenTrabajo);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Actualiza la orden de trabajo
        /// </summary>
        /// <param name="detallePrendaOrdenTrabajo"></param>
        public void ActualizarDetallePrendaOrdenTrabajo(DetallePrendaOrdenTrabajoModelo detallePrendaOrdenTrabajo)
        {
            try
            {
              _ventaTransformadorNegocio.ActualizarDetallePrendaOrdenTrabajo(detallePrendaOrdenTrabajo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region NUMERACION ORDEN


        /// <summary>
        /// Obtiene  todas las sucursales 
        /// </summary>
        /// <returns></returns>
        public List<NumeracionOrdenDTOs> ObtenerPuntosVentaCompleto()
        {
            try
            {

                return _ventaTransformadorNegocio.ObtenerPuntosVentaCompleto();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Grabar punto de  venta y numero de  orden
        /// </summary>
        /// <param name="numeracionOrdenDtOs"></param>
        public void GrabarPuntoVentaCompleto(NumeracionOrdenDTOs numeracionOrdenDtOs)
        {
            try
            {
                _ventaTransformadorNegocio.GrabarPuntoVentaCompleto(numeracionOrdenDtOs);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Grabar punto de  venta y numero de  orden
        /// </summary>
        /// <param name="numeracionOrdenDtOs"></param>
        public void ActualizarPuntoVentaCompleto(NumeracionOrdenDTOs numeracionOrdenDtOs)
        {
            try
            {
              _ventaTransformadorNegocio.ActualizarPuntoVentaCompleto(numeracionOrdenDtOs);

            }
            catch (Exception ex)
            {

                throw;
            }
        }



        #endregion

        #region VENTA COMISION  INDUSTRIALES

        /// <summary>
        /// Obtiene el valor de la venta de  industriales
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<VentaComisionIndustrialesDTOs> ObtenerComisionesIndustrialesPorPuntoVenta(int puntoVentaId)
        {
            try
            {
                return _ventaTransformadorNegocio.ObtenerComisionesIndustrialesPorPuntoVenta(puntoVentaId);



            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Grabar promociones
        /// </summary>
        /// <param name="ventaComisionIndustrialesDtOs"></param>
        public void GrabarVentaComisionIndustrialesCompleto(VentaComisionIndustrialesDTOs ventaComisionIndustrialesDtOs)
        {
            try
            {
              _ventaTransformadorNegocio.GrabarVentaComisionIndustrialesCompleto(ventaComisionIndustrialesDtOs);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Actualizar promociones
        /// </summary>
        /// <param name="ventaComisionIndustrialesDtOs"></param>
        public void ActualizarVentaComisionIndustrialesCompleto(VentaComisionIndustrialesDTOs ventaComisionIndustrialesDtOs)
        {
            try
            {
                _ventaTransformadorNegocio.ActualizarVentaComisionIndustrialesCompleto(ventaComisionIndustrialesDtOs);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #endregion

        #region VALIDACION

        #region ORDEN TRABAJO

        /// <summary>
        ///  Obtiene el numero de  ordenes que fueron asignadas  como urgentes
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public int ObtenerNumeroEntregaUrgentesPorFechaActual(int sucursalId)
        {
            try
            {
                return _ventaTransformadorNegocio.ObtenerNumeroEntregaUrgentesPorFechaActual(sucursalId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        #endregion
    }
}
