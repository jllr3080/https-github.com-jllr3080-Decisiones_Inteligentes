#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.ReglaNegocio.Proveedor.DAOs;
using JLLR.Core.ReglaNegocio.Proveedor.DTOs;

#endregion

namespace JLLR.Core.ReglaNegocio.Proveedor.Negocio
{
    /// <summary>
    /// Reglas de  negocio
    /// </summary>
    public class ReglaNegocio
    {
        #region DECLARACIONES E INSTANCIAS

        private readonly  TransaccionalDAOs _transaccionalDaOs= new TransaccionalDAOs();
        #endregion

        #region TRANSACCIONAL
        /// <summary>
        /// Obtener las reglas para aplicar     
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public IQueryable<ReglaDTOs> ObtenerReglasPorPuntoVentaIdYSucursalId(int puntoVentaId, int sucursalId)
        {
            try
            {

                return _transaccionalDaOs.ObtenerReglasPorPuntoVentaIdYSucursalId(puntoVentaId, sucursalId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
