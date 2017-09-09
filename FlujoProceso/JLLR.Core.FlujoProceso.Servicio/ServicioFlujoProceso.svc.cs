#region using
using System;
using System.Collections.Generic;
using JLLR.Core.FlujoProceso.Servicio.Modelo;
using JLLR.Core.FlujoProceso.Servicio.Transformador;
using JLLR.Core.FlujoProceso.Servicio.DTOs;
#endregion
namespace JLLR.Core.FlujoProceso.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioFlujoProceso : IServicioFlujoProceso
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly FlujoProcesoTransformadorNegocio _flujoProcesoTransformadorNegocio= new FlujoProcesoTransformadorNegocio();
        #endregion

        #region HISTORIAL PROCESO
        /// <summary>
        /// Devuelve  todos  los  historiales de  proceso  del clciente, anulados  y  entregados
        /// </summary>
        /// <returns></returns>
        public List<HistorialProcesoModelo> ObtenerHistorialProceso()
        {
            try
            {

                return _flujoProcesoTransformadorNegocio.ObtenerHistorialProceso();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Graba el  historial del proceso
        /// </summary>
        public HistorialProcesoModelo GrabarHistorialProceso(HistorialProcesoModelo historialProceso)
        {
            try
            {
              return  _flujoProcesoTransformadorNegocio.GrabarHistorialProceso(historialProceso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba el  historial del proceso
        /// </summary>
        public void GrabarHistorialProcesoSinRetorno(HistorialProcesoModelo historialProceso)
        {
            try
            {
                 _flujoProcesoTransformadorNegocio.GrabarHistorialProcesoSinRetorno(historialProceso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        

        /// <summary>
        /// Obtener el historial del proceso por numero  de orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <returns></returns>
        public List<HistorialProcesoModelo> ObtenerHIstorialProcesosPorNumeroOrden(string numeroOrden)
        {
            try
            {
                return _flujoProcesoTransformadorNegocio.ObtenerHIstorialProcesosPorNumeroOrden(numeroOrden);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Obtiene todas las prendas  para  la logistica
        /// </summary>
        /// <param name="etapaProcesoId"></param>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public List<HistorialProcesoModelo> ObtenerHistorialProcesoPorFlujoProceso(int etapaProcesoId, int sucursalId,
            int puntoVentaId)
        {
            try
            {

                return _flujoProcesoTransformadorNegocio.ObtenerHistorialProcesoPorFlujoProceso(etapaProcesoId,
                    sucursalId, puntoVentaId);


            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza  el historial de proceso
        /// </summary>
        /// <param name="historialProceso"></param>
        public void ActualizarHistorialProceso(HistorialProcesoModelo historialProceso)
        {
            try
            {
                _flujoProcesoTransformadorNegocio.ActualizarHistorialProceso(historialProceso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region TRANSACCIONAL

        #region REPORTES

        /// <summary>
        /// Obtiene el historial de prendas 
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="fechaRegistro"></param>
        /// <param name="etapaProcesoId"></param>
        /// <returns></returns>
        public List<HistorialProcesoDTOs> ObtenerHistorialProcesoPrendasPorVariosParametros(int sucursalId,
            int puntoVentaId, string fechaRegistro, int etapaProcesoId)
        {
            try
            {

                return _flujoProcesoTransformadorNegocio.ObtenerHistorialProcesoPrendasPorVariosParametros(sucursalId,
                    puntoVentaId,Convert.ToDateTime(fechaRegistro), etapaProcesoId);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        /// <summary>
        /// Graba  el historial de  los reprocesos
        /// </summary>
        /// <param name="historialReprocesoDtOs"></param>
        public void GrabarHistorialReprocesos(HistorialReprocesoDTOs historialReprocesoDtOs)
        {
            try
            {
                _flujoProcesoTransformadorNegocio.GrabarHistorialReprocesos(historialReprocesoDtOs);

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        /// <summary>
        /// Obtiene el lsitado de  las ordenes de reproceso
        /// </summary>
        /// <param name="detalleOrdenTrabajoId"></param>
        /// <returns></returns>
        public List<DetalleHistorialReprocesoDTOs> ObtenerDetalleHistorialReprocesosPorDetalleOrdenTrabajoId(
            int detalleOrdenTrabajoId)
        {

            try
            {
                return
                    _flujoProcesoTransformadorNegocio.ObtenerDetalleHistorialReprocesosPorDetalleOrdenTrabajoId(
                        detalleOrdenTrabajoId);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Reporte de  reproceso por prenda
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>
        public List<ReprocesoDTOs> ObtenerReprocesoPorVariosParametros(int puntoVentaId, string fechaDesde, string fechaHasta)
        {
            try
            {
                return _flujoProcesoTransformadorNegocio.ObtenerReprocesoPorVariosParametros(puntoVentaId,Convert.ToDateTime(fechaDesde),Convert.ToDateTime(fechaHasta));


            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region HISTORIAL RECLAMO  REPROCESO PRENDA

        /// <summary>
        /// Obtiene el historial de reproceso de las prendas
        /// </summary>
        /// <param name="detallePrendaOrdenTrabajoId"></param>
        /// <returns></returns>
        public List<HistorialReclamoReprocesoPrendaModelo>
            ObtenerHistorialReclamoReprocesoPrendaPorDetallePrendaOrdenTrabajoId(int detallePrendaOrdenTrabajoId)
        {
            try
            {
                return
                    _flujoProcesoTransformadorNegocio
                        .ObtenerHistorialReclamoReprocesoPrendaPorDetallePrendaOrdenTrabajoId(
                            detallePrendaOrdenTrabajoId);


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba el  historial del reproceso de prendas   y los reclamos 
        /// </summary>
        /// <param name="historialReclamoReprocesoPrenda"></param>
        public void GrabarHistorialReclamoReprocesoPrenda(
            HistorialReclamoReprocesoPrendaModelo historialReclamoReprocesoPrenda)
        {
            try
            {
              _flujoProcesoTransformadorNegocio.GrabarHistorialReclamoReprocesoPrenda(historialReclamoReprocesoPrenda);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region HISTORIAL REPROCESO
        /// <summary>
        /// Graba el  historial del reproceso de prendas   y los reclamos 
        /// </summary>
        /// <param name="historialReclamoReprocesoPrenda"></param>
        public HistorialReprocesoModelo GrabarHistorialReproceso(HistorialReprocesoModelo historialReproceso)
        {
            try
            {
               return _flujoProcesoTransformadorNegocio.GrabarHistorialReproceso(historialReproceso);
            }
            catch (Exception ex)
            {

                throw;

            }
        }
        #endregion

        #region DETALLE  HISTORIAL  PRENDA
        /// <summary>
        /// Grabar el detalle
        /// </summary>
        /// <param name="detalleHistorialReproceso"></param>
        public void GrabarDetalleHistorialReproceso(DetalleHistorialReprocesoModelo detalleHistorialReproceso)
        {
            try
            {
                _flujoProcesoTransformadorNegocio.GrabarDetalleHistorialReproceso(detalleHistorialReproceso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion
    }
}
