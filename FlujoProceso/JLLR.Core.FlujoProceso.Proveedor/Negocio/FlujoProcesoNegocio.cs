#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.FlujoProceso.Proveedor.DAOs;

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
        #endregion

    }
}
