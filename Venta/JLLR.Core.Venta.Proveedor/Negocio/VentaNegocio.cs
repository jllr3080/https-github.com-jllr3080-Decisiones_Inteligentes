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
        #endregion


        #region NEGOCIO
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
        #endregion



    }
}
