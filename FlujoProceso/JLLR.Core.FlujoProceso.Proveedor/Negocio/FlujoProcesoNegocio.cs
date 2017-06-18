#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.FlujoProceso.Proveedor.DAOs;
using JLLR.Core.FlujoProceso.Proveedor.DTOs;

#endregion
namespace JLLR.Core.FlujoProceso.Proveedor.Negocio
{
    /// <summary>
    /// Metodo de flujo de proceso
    /// </summary>
    public class FlujoProcesoNegocio
    {

        #region Declaracion e Instancias
        private readonly  HistorialProcesoDAOs _historialProcesoDaOs= new HistorialProcesoDAOs();
        private  readonly  TransaccionalDAOs _transaccionalDaOs= new TransaccionalDAOs();
        private readonly  HistorialReclamoReprocesoPrendaDAOs _historialReclamoReprocesoPrendaDaOs= new HistorialReclamoReprocesoPrendaDAOs();
        private readonly  HistorialReprocesoDAOs _historialReprocesoDaOs= new HistorialReprocesoDAOs();
        
        #endregion

        #region HISTORIAL PROCESO

        /// <summary>
        /// Devuelve  todos  los  historiales de  proceso  del clciente, anulados  y  entregados
        /// </summary>
        /// <returns></returns>
        public IQueryable<HISTORIAL_PROCESO> ObtenerHistorialProceso()
        {
            try
            {
               
                return _historialProcesoDaOs.ObtenerHistorialProceso();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba el  historial del proceso
        /// </summary>
        public void GrabarHistorialProceso(HISTORIAL_PROCESO historialProceso)
        {
            try
            {
              _historialProcesoDaOs.GrabarHistorialProceso(historialProceso);
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
        public IQueryable<HISTORIAL_PROCESO> ObtenerHIstorialProcesosPorNumeroOrden(string numeroOrden)
        {
            try
            {
                return _historialProcesoDaOs.ObtenerHIstorialProcesosPorNumeroOrden(numeroOrden);
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
        public IQueryable<HISTORIAL_PROCESO> ObtenerHistorialProcesoPorFlujoProceso(int etapaProcesoId, int sucursalId,
            int puntoVentaId)
        {
            try
            {
               
                return _historialProcesoDaOs.ObtenerHistorialProcesoPorFlujoProceso(etapaProcesoId,sucursalId,puntoVentaId);


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
        public void ActualizarHistorialProceso(HISTORIAL_PROCESO historialProceso)
        {
            try
            {
                _historialProcesoDaOs.ActualizarHistorialProceso(historialProceso); 
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
            int puntoVentaId, DateTime fechaRegistro, int etapaProcesoId)
        {
            try
            {
                
                return _transaccionalDaOs.ObtenerHistorialProcesoPrendasPorVariosParametros(sucursalId,puntoVentaId,fechaRegistro,etapaProcesoId);
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
                _transaccionalDaOs.GrabarHistorialReprocesos(historialReprocesoDtOs);
            }
            catch (Exception ex)
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
        public IQueryable<HISTORIAL_RECLAMO_REPROCESO_PRENDA>
            ObtenerHistorialReclamoReprocesoPrendaPorDetallePrendaOrdenTrabajoId(int detallePrendaOrdenTrabajoId)
        {
            try
            {
             return _historialReclamoReprocesoPrendaDaOs.ObtenerHistorialReclamoReprocesoPrendaPorDetallePrendaOrdenTrabajoId(detallePrendaOrdenTrabajoId);

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
            HISTORIAL_RECLAMO_REPROCESO_PRENDA historialReclamoReprocesoPrenda)
        {
            try
            {
                 _historialReclamoReprocesoPrendaDaOs.GrabarHistorialReclamoReprocesoPrenda(historialReclamoReprocesoPrenda);
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
        public void GrabarHistorialReproceso(HISTORIAL_REPROCESO historialReproceso)
        {
            try
            {
                _historialReprocesoDaOs.GrabarHistorialReproceso(historialReproceso);
            }
            catch (Exception ex)
            {

                throw;

            }
        }
        #endregion


      
    }
}
