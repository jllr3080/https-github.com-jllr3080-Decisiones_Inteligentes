#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Venta.Proveedor.DAOs;
using JLLR.Core.Venta.Proveedor.DTOs;

#endregion
namespace JLLR.Core.Venta.Proveedor.Negocio
{
    /// <summary>
    /// Metodos de la venta de  negocio
    /// </summary>
    public class VentaNegocio
    {
        #region DECLARACION E INSTANCIAS
        private readonly OrdenTrabajoDAOs _ordenTrabajoDaOs= new OrdenTrabajoDAOs();
        private readonly  DetalleOrdenTrabajoDAOs _detalleOrdenTrabajoDaOs= new DetalleOrdenTrabajoDAOs();
        private readonly TransaccionalDAOs _transaccionalDaOs = new TransaccionalDAOs();
        private readonly  DetalleOrdenTrabajoObservacionDAOs _detalleOrdenTrabajoObservacionDaOs= new DetalleOrdenTrabajoObservacionDAOs();
        #endregion


        #region NEGOCIO
        #region  TRANSACCIONAL
        /// <summary>
        /// Graba la orden de trabajo 
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>
        /// <returns></returns>
        public ORDEN_TRABAJO GrabarOrdenTrabajoCompleta(OrdenTrabajoDTOs ordenTrabajoDtOs)
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

        #endregion



        #region REPORTES
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
        #endregion



    }
}
