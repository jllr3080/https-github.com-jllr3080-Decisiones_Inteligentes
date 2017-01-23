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
        #endregion

        #region HISTORIAL PROCESO
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
        
        #endregion
    }
}
