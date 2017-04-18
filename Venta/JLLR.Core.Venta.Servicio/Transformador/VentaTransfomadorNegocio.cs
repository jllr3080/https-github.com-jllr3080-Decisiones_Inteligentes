#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.Venta.Proveedor.Negocio;
using JLLR.Core.Venta.Servicio.DTOs;
using JLLR.Core.Venta.Servicio.Modelo;
using JLLR.Core.Venta.Servicio.EnsambladorDTOs;
using JLLR.Core.Venta.Servicio.Ensamblador;
using JLLR.Core.Venta.Servicio.Modelo.Parametrizacion;
using  ensambladorLogistica=JLLR.Core.Logistica.Servicio.Ensamblador;
#endregion
namespace JLLR.Core.Venta.Servicio.Transformador
{

    /// <summary>
    /// Metodos  generales
    /// </summary>
    public class VentaTransfomadorNegocio
    {

        #region DECLARACIONES  E INSTANCIAS
        private readonly VentaNegocio _ventaNegocio = new VentaNegocio();
        private readonly VentaParametrizacion _ventaParametrizacion= new VentaParametrizacion();
        private readonly EnsambladorEntidadDTOs _ensambladorEntidadDTOs = new EnsambladorEntidadDTOs();
        private readonly EnsambladorModeloDTOs _ensambladorModeloDTOs = new EnsambladorModeloDTOs();
        private readonly EnsambladorEntidad _ensambladorEntidad = new EnsambladorEntidad();
        private readonly EnsambladorModelo _ensambladorModelo = new EnsambladorModelo();
        private readonly  ensambladorLogistica.EnsambladorModelo _ensambladorModeloLogistica= new ensambladorLogistica.EnsambladorModelo();
        private  readonly ensambladorLogistica.EnsambladorEntidad _ensambladorEntidadLogistica= new ensambladorLogistica.EnsambladorEntidad();

        #endregion


        #region NEGOCIO 


        #region TRANSACCIONAL
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
                _ventaNegocio.GrabarDescuentoComision(ordenTrabajoId, usuarioId, descuentoFranquicia);
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
                _ventaNegocio.GrabarReversoOrdenTrabajoComision(ordenTrabajoId, usuarioId);

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

        public List<DetalleOrdenTrabajoObservacionDTOs> ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId(int detalleOrdenTrabajoId)
        {
            try
            {
                return
                    _ensambladorModeloDTOs.CrearDetalleOrdenTrabajosObservacionDtOs(
                        _ventaNegocio.ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId(
                            detalleOrdenTrabajoId));



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


                return
                    _ensambladorModeloDTOs.CrearOrdenTrabajoDescuentoDtos(
                        _ventaNegocio.ObtenerOrdenesTrabajoDescuentoPorEstadoProceso());

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
                return _ensambladorModeloDTOs.CrearOrdenTrabajotOs(_ventaNegocio.GrabarOrdenTrabajoCompleta(_ensambladorEntidadDTOs.CrearOrdenTrabajotOs(ordenTrabajoDtOs)));
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
                return _ensambladorModeloDTOs.CrearOrdenesTrabajosDtOs(_ventaNegocio.ObtenerOrdenTrabajoPorEnvioMatriz(puntoVentaId,sucursalId));

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
                _ventaNegocio.ActualizarOrdenTrabajo(_ensambladorEntidad.CrearOrdenTrabajo(ordenTrabajo));
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
                return
                    _ensambladorModeloDTOs.CrearOrdenTrabajotOs(
                        _ventaNegocio.ObtenerOrdenTrabajoPorOrdenTrabajoId(ordenTrabajoId));
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
                _ventaNegocio.GrabarDetalleOrdenTrabajoObservacion(_ensambladorEntidad.CrearDetalleOrdenTrabajoObservacion(detalleOrdenTrabajoObservacion));
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
                    _ensambladorModelo.CrearDetalleOrdenTrabajosObservacion(
                        _ventaNegocio.ObtenerDetalleOrdenTrabajoObservaciones(detalleOrdenTrabajoId));
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
                return
                    _ensambladorModelo.CrearOrdenTrabajoComision(
                        _ventaNegocio.GrabaOrdenTrabajoComision(
                            _ensambladorEntidad.CrearOrdenTrabajoComision(ordenTrabajoComision)));

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
                return _ensambladorModelo.CrearVentaComision(_ventaNegocio.ObtenerVentaComisionPorusuarioId(usuarioId));

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  REPORTES
        /// <summary>
        ///  Obtiene el reporte de prenda  y marcas 
        /// </summary>
        /// <param name="prendaId"></param>
        /// <param name="marcaId"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<PrendaMarcaDTOs> ObtenerPrendayMarcaPorVariosParametros(int prendaId, int marcaId, DateTime fecha)
        {
            try
            {
                return
                    _ensambladorModeloDTOs.CrearPrendaMarcasDtOs(
                        _ventaNegocio.ObtenerPrendayMarcaPorVariosParametros(prendaId, marcaId, fecha));
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

        public List<NumeroPrendaDTOs> ObtenerNumeroPrendasPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {

                return
                    _ensambladorModeloDTOs.CrearNumeroPrendasDtOs(_ventaNegocio.ObtenerNumeroPrendasPorFecha(
                        fechaDesde, fechaHasta));


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
                return
                    _ensambladorModeloDTOs.CrearEstadosCuentaDtOs(
                        _ventaNegocio.ObtenerEstadoCuentaPorVariosParametros(puntoventaId, fechaDesde, fechaHasta));

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

                return _ensambladorModeloDTOs.CrearConsultaOrdenesTrabajoDtOs(_ventaNegocio.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(numeroOrden, puntoVentaId));

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
        public List<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(DateTime fechaDesde, int sucursalId)
        {
            try
            {
                return _ensambladorModeloDTOs.CrearConsultaOrdenesTrabajoDtOs(_ventaNegocio.ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(fechaDesde,sucursalId));

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
                return
                    _ensambladorModelo.CrearDetalleOrdenesTrabajo(_ventaNegocio.ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta(numeroOrden, puntoVentaId));

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

                _ventaNegocio.GrabarHistorialRegla(_ensambladorEntidad.CrearHistorialRegla(historialRegla));
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

               _ventaNegocio.ActualizarOrdenTrabajoDescuento(_ensambladorEntidad.CrearOrdenTrabajoDescuento(ordenTrabajoDescuento));
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
                _ventaNegocio.GrabarOrdenTrabajoDescuento(
                    _ensambladorEntidad.CrearOrdenTrabajoDescuento(ordenTrabajoDescuento));

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

                return
                    _ensambladorModelo.CrearOrdenTrabajoDescuentos(
                        _ventaNegocio.ObtenerOrdenTrabajoDescuentoPorEstadoProceso());

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
                _ventaNegocio.GrabarAprobacionDescuento(_ensambladorEntidad.CrearAprobacionDescuento(aprobacionDescuento));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion



        #endregion

        #region PARAMETRIZACION
        #region VENTA COMISION

        /// <summary>
        /// Obtener Comision de las sucursal
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="vieneRegla"></param>
        /// <param name="tipoLavadoId"></param>
        /// <returns></returns>
        public VentaComisionModelo ObtenerbVentaComisionPorVariosParametros(int sucursalId, int puntoVentaId, bool vieneRegla, int tipoLavadoId,int promocionAplicada)
        {
            try
            {
                return _ensambladorModelo.CrearVentaComision(_ventaParametrizacion.ObtenerbVentaComisionPorVariosParametros(sucursalId,puntoVentaId,vieneRegla,tipoLavadoId,promocionAplicada));
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