﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Venta.Proveedor.DAOs;
using JLLR.Core.Venta.Proveedor.DTOs;

#endregion
namespace JLLR.Core.Venta.Proveedor.Negocio
{
    /// <summary>
    /// Metodos de la venta de  negocio
    /// </summary>
    public class VentaNegocio:BaseDAOs
    {
        #region DECLARACION E INSTANCIAS
        private readonly OrdenTrabajoDAOs _ordenTrabajoDaOs= new OrdenTrabajoDAOs();
        private readonly  DetalleOrdenTrabajoDAOs _detalleOrdenTrabajoDaOs= new DetalleOrdenTrabajoDAOs();
        private readonly TransaccionalDAOs _transaccionalDaOs = new TransaccionalDAOs();
        private readonly  DetalleOrdenTrabajoObservacionDAOs _detalleOrdenTrabajoObservacionDaOs= new DetalleOrdenTrabajoObservacionDAOs();
        private readonly  OrdenTrabajoComisionDAOs _ordenTrabajoComisionDaOs= new OrdenTrabajoComisionDAOs();
        private readonly  HistorialReglaDAOs _historialReglaDaOs= new HistorialReglaDAOs();
        private readonly  OrdenTrabajoDescuentoDAOs _ordenTrabajoDescuentoDaOs= new OrdenTrabajoDescuentoDAOs();
        private readonly  AprobacionDescuentoDAOs _aprobacionDescuentoDaOs= new AprobacionDescuentoDAOs();
        private readonly  DetalleOrdenTrabajoFotografiaDAOs _detalleOrdenTrabajoFotografiaDaOs= new DetalleOrdenTrabajoFotografiaDAOs();
        private readonly  DetallePrendaOrdenTrabajoDAOs _detallePrendaOrdenTrabajoDaOs= new DetallePrendaOrdenTrabajoDAOs();
        #endregion


        #region NEGOCIO

        #region  TRANSACCIONAL



        /// <summary>
        /// Grabar el detallde  de las prendas
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>

        public void GrabarDetallePrendaCompleto(OrdenTrabajoDTOs ordenTrabajoDtOs)
        {
            try
            {
                _transaccionalDaOs.GrabarDetallePrendaCompleto(ordenTrabajoDtOs);
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
        public IQueryable<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoCortaPorNumeroOrdenYPuntoVenta(string numeroOrden,
            int puntoVentaId)
        {
            try
            {
                return _transaccionalDaOs.ObtenerOrdenTrabajoCortaPorNumeroOrdenYPuntoVenta(numeroOrden, puntoVentaId);
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
                return _transaccionalDaOs.ObtenerOrdenTrabajoPorEstadoTemporal(puntoVentaId);

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
        public IQueryable<DetalleOrdenTrabajoFotografiaDTOs>
            ObtenerDetalleOrdenTrabajoFotografiaDtOsesPorDetallePrendaId(int detallePrendaOrdenTrabajoId)
        {
            try
            {
                return
                    _transaccionalDaOs.ObtenerDetalleOrdenTrabajoFotografiaDtOsesPorDetallePrendaId(
                        detallePrendaOrdenTrabajoId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Graba el descuento de la comision por  devolucion al cliente de  algun valor
        /// </summary>
        /// <param name="ordenTrabajoId"></param>
        /// <param name="usuarioId"></param>
        /// <param name="descuentoFranquicia"></param>
        public void GrabarDescuentoComision(int ordenTrabajoId, int usuarioId, decimal descuentoFranquicia)
        {
            try
            {
              _transaccionalDaOs.GrabarDescuentoComision(ordenTrabajoId,usuarioId,descuentoFranquicia);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba el reverso de las comisiones  de una orden de trabajo este es el caso de  anulacion
        /// </summary>
        /// <param name="ordenTrabajoId"></param>
        /// <param name="usuarioId"></param>
        public void GrabarReversoOrdenTrabajoComision(int ordenTrabajoId, int usuarioId)
        {
            try
            {
               _transaccionalDaOs.GrabarReversoOrdenTrabajoComision(ordenTrabajoId,usuarioId);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las observaciones  de las prendas por  
        /// </summary>
        /// <returns></returns>

        public IQueryable<DetalleOrdenTrabajoObservacionDTOs> ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId(int detalleOrdenTrabajoId)
        {
            try
            {
                return
                    _transaccionalDaOs.ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId(
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
        public IQueryable<OrdenTrabajoDescuentoDTO> ObtenerOrdenesTrabajoDescuentoPorEstadoProceso()
        {
            try
            {
              
                return _transaccionalDaOs.ObtenerOrdenesTrabajoDescuentoPorEstadoProceso();

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Graba la orden de trabajo 
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>
        /// <returns></returns>
        public OrdenTrabajoDTOs GrabarOrdenTrabajoCompleta(OrdenTrabajoDTOs ordenTrabajoDtOs)
        {
            try
            {
                return _transaccionalDaOs.GrabarOrdenTrabajoCompleta(ordenTrabajoDtOs);
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
                return _transaccionalDaOs.ObtenerOrdenTrabajoPorEnvioMatriz(puntoVentaId,sucursalId);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        #region VENTA COMISION  INDUSTRIALES


        /// <summary>
        /// Obtiene el valor de la venta de  industriales
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public VentaComisionIndustrialesDTOs ObtenerComisionIndustrialesPorPuntoVenta(int puntoVentaId)
        {
            try
            {
               return _transaccionalDaOs.ObtenerComisionIndustrialesPorPuntoVenta(puntoVentaId);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        #endregion

        #endregion

        #region ORDEN TRABAJO

        /// <summary>
        /// Actualiza la orden de trabajo
        /// </summary>
        /// <param name=""></param>
        public void ActualizarOrdenTrabajo(ORDEN_TRABAJO ordenTrabajo)
        {
            try
            {
                _ordenTrabajoDaOs.ActualizarOrdenTrabajo(ordenTrabajo);
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
                return _ordenTrabajoDaOs.ObtenerOrdenTrabajoPorOrdenTrabajoId(ordenTrabajoId);
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
        public void GrabarDetalleOrdenTrabajoObservacion(DETALLE_ORDEN_TRABAJO_OBSERVACION detalleOrdenTrabajoObservacion)
        {
            try
            {
                _detalleOrdenTrabajoObservacionDaOs.GrabarDetalleOrdenTrabajoObservacion(detalleOrdenTrabajoObservacion);
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
        public IQueryable<DETALLE_ORDEN_TRABAJO_OBSERVACION> ObtenerDetalleOrdenTrabajoObservaciones(
            int detalleOrdenTrabajoId)
        {
            try
            {
                return _detalleOrdenTrabajoObservacionDaOs.ObtenerDetalleOrdenTrabajoObservaciones(detalleOrdenTrabajoId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region ORDEN TRABAJO COMISION


        /// <summary>
        /// Obtener las  comisiones  de las ordens
        /// </summary>
        /// <param name="ordenTrabajoComision"></param>
        /// <returns></returns>

        public void ActualizarOrdenTrabajoComision(ORDEN_TRABAJO_COMISION ordenTrabajoComision)
        {
            try
            {
               _ordenTrabajoComisionDaOs.ActualizarOrdenTrabajoComision(ordenTrabajoComision);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba la comision de la orden de  trabajo
        /// </summary>
        /// <param name="ordenTrabajoComision"></param>
        public ORDEN_TRABAJO_COMISION GrabaOrdenTrabajoComision(ORDEN_TRABAJO_COMISION ordenTrabajoComision)
        {
            try
            {
              return _ordenTrabajoComisionDaOs.GrabaOrdenTrabajoComision(ordenTrabajoComision);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtener las  comisiones  de las ordens
        /// </summary>
        /// <param name="detalleOrdenTrabajoId"></param>
        /// <returns></returns>

        public ORDEN_TRABAJO_COMISION ObtenerOrdenTrabajoComisionPorId(int detalleOrdenTrabajoId)
        {
            try
            {
                return _ordenTrabajoComisionDaOs.ObtenerOrdenTrabajoComisionPorId(detalleOrdenTrabajoId);
            }
            catch (Exception)
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
        public VENTA_COMISION ObtenerVentaComisionPorusuarioId(int usuarioId)
        {
            try
            {
               return _transaccionalDaOs.ObtenerVentaComisionPorusuarioId(usuarioId);

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
        public void GrabarHistorialRegla(HISTORIAL_REGLA historialRegla)
        {
            try
            {
            
                _historialReglaDaOs.GrabarHistorialRegla(historialRegla);
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
        public void ActualizarOrdenTrabajoDescuento(ORDEN_TRABAJO_DESCUENTO ordenTrabajoDescuento)
        {
            try
            {
              
                _ordenTrabajoDescuentoDaOs.ActualizarOrdenTrabajoDescuento(ordenTrabajoDescuento);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Graba el descuento de la orden d etrabajo
        /// </summary>
        public void GrabarOrdenTrabajoDescuento(ORDEN_TRABAJO_DESCUENTO ordenTrabajoDescuento)
        {
            try
            {
              _ordenTrabajoDescuentoDaOs.GrabarOrdenTrabajoDescuento(ordenTrabajoDescuento);

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
        public IQueryable<ORDEN_TRABAJO_DESCUENTO> ObtenerOrdenTrabajoDescuentoPorEstadoProceso()
        {
            try
            {

                return _ordenTrabajoDescuentoDaOs.ObtenerOrdenTrabajoDescuentoPorEstadoProceso();

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

        public void GrabarAprobacionDescuento(APROBACION_DESCUENTO aprobacionDescuento)
        {
            try
            {
              _aprobacionDescuentoDaOs.GrabarAprobacionDescuento(aprobacionDescuento);
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
        public void GrabarDetalleOrdenFotografia(DETALLE_TRABAJO_FOTOGRAFIA detalleTrabajoFotografia)
        {
            try
            {
                _detalleOrdenTrabajoFotografiaDaOs.GrabarDetalleOrdenFotografia(detalleTrabajoFotografia);

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
        /// <param name="ordenTrabajo"></param>
        /// <returns></returns>
        public DETALLE_PRENDA_ORDEN_TRABAJO GrabarDetallePrendaOrdenTrabajo(DETALLE_PRENDA_ORDEN_TRABAJO detallePrendaOrdenTrabajo)
        {
            try
            {
               return _detallePrendaOrdenTrabajoDaOs.GrabarDetallePrendaOrdenTrabajo(detallePrendaOrdenTrabajo);
                
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
        public void ActualizarDetallePrendaOrdenTrabajo(DETALLE_PRENDA_ORDEN_TRABAJO detallePrendaOrdenTrabajo)
        {
            try
            {
              _detallePrendaOrdenTrabajoDaOs.ActualizarDetallePrendaOrdenTrabajo(detallePrendaOrdenTrabajo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region DETALLE  ORDEN  TRABAJO

        /// <summary>
        /// Graba el detalle de la orden de trabajo
        /// </summary>
        /// <param name="detalleOrdenTrabajo"></param>
        /// <returns></returns>
        public DETALLE_ORDEN_TRABAJO GrabarDetelleOrdenTrabajo(DETALLE_ORDEN_TRABAJO detalleOrdenTrabajo)
        {
            try
            {
                return _detalleOrdenTrabajoDaOs.GrabarDetelleOrdenTrabajo(detalleOrdenTrabajo);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza la orden de trabajo
        /// </summary>
        /// <param name=""></param>
        public void ActualizarDetalleOrdenTrabajo(DETALLE_ORDEN_TRABAJO detalleOrdenTrabajo)
        {
            try
            {
                _detalleOrdenTrabajoDaOs.ActualizarDetalleOrdenTrabajo(detalleOrdenTrabajo);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Encontrar el detalle de la orden  de trabajo 
        /// </summary>
        /// <param name="detalleOrdenTrabajoId"></param>
        public DETALLE_ORDEN_TRABAJO ObtenerDetalleOrdenTrabajoPorId(int detalleOrdenTrabajoId)
        {
            try
            {
             return   _detalleOrdenTrabajoDaOs.ObtenerDetalleOrdenTrabajoPorId(detalleOrdenTrabajoId);
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
        public IQueryable<NumeracionOrdenDTOs> ObtenerPuntosVentaCompleto()
        {
            try
            {
                
                return _transaccionalDaOs.ObtenerPuntosVentaCompleto();

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
               _transaccionalDaOs.GrabarPuntoVentaCompleto(numeracionOrdenDtOs);
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
                _transaccionalDaOs.ActualizarPuntoVentaCompleto(numeracionOrdenDtOs);

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
        public IQueryable<VentaComisionIndustrialesDTOs> ObtenerComisionesIndustrialesPorPuntoVenta(int puntoVentaId)
        {
            try
            {
                return _transaccionalDaOs.ObtenerComisionesIndustrialesPorPuntoVenta(puntoVentaId);
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
                _transaccionalDaOs.GrabarVentaComisionIndustrialesCompleto(ventaComisionIndustrialesDtOs);
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
                _transaccionalDaOs.ActualizarVentaComisionIndustrialesCompleto(ventaComisionIndustrialesDtOs);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion
        #endregion

        #region REPORTES

        /// <summary>
        ///  Obtiene el reporte de prenda  y marcas 
        /// </summary>
        /// <param name="prendaId"></param>
        /// <param name="marcaId"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public IQueryable<PrendaMarcaDTOs> ObtenerPrendayMarcaPorVariosParametros(int prendaId, int marcaId, DateTime fecha, int colorId)
        {
            try
            {
               return _transaccionalDaOs.ObtenerPrendayMarcaPorVariosParametros(prendaId,marcaId,fecha, colorId);
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

        public List<NumeroPrendaDTOs> ObtenerNumeroPrendasPorFecha(DateTime fechaDesde, DateTime fechaHasta, int sucursalId)
        {
            try
            {

             return _transaccionalDaOs.ObtenerNumeroPrendasPorFecha(fechaDesde,fechaHasta, sucursalId);
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
        public List<EstadoCuentaDTOs> ObtenerEstadoCuentaPorVariosParametros(int puntoventaId, DateTime fechaDesde,
            DateTime fechaHasta)
        {
            try
            {
              return  _transaccionalDaOs.ObtenerEstadoCuentaPorVariosParametros(puntoventaId,fechaDesde,fechaHasta);

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
        public IQueryable<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(DateTime fechaDesde, int sucursalId)
        {
            try
            {
                return _transaccionalDaOs.ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(fechaDesde, sucursalId);

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
        public IQueryable<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(string numeroOrden, int puntoVentaId)
        {
            try
            {
                return _transaccionalDaOs.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(numeroOrden, puntoVentaId);
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
        public IQueryable<DETALLE_ORDEN_TRABAJO> ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta(string numeroOrden,
            int puntoVentaId)
        {
            try
            {
                return _transaccionalDaOs.ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta(numeroOrden, puntoVentaId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion



    }
}
