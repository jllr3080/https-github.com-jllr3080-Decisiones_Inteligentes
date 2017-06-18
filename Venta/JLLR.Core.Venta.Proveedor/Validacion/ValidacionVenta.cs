#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Venta.Proveedor.DAOs;

#endregion
namespace JLLR.Core.Venta.Proveedor.Validacion
{
    /// <summary>
    /// Funciones de validacion
    /// </summary>
    public class ValidacionVenta:BaseDAOs
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly  OrdenTrabajoDAOs _ordenTrabajoDaOs= new OrdenTrabajoDAOs();

        #endregion

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
                return _ordenTrabajoDaOs.ObtenerNumeroEntregaUrgentesPorFechaActual(sucursalId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
