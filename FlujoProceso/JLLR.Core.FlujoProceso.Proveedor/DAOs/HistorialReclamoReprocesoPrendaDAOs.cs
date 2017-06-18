#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.FlujoProceso.Proveedor.DAOs
{
    /// <summary>
    /// 
    /// </summary>
    public class HistorialReclamoReprocesoPrendaDAOs:BaseDAOs
    {

        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Obtiene el historial de reproceso de las prendas
        /// </summary>
        /// <param name="detallePrendaOrdenTrabajoId"></param>
        /// <returns></returns>
        public IQueryable<HISTORIAL_RECLAMO_REPROCESO_PRENDA>
            ObtenerHistorialReclamoReprocesoPrendaPorDetallePrendaOrdenTrabajoId( int detallePrendaOrdenTrabajoId)
        {
            try
            {
                var historialReclamoReprocesoPrendas =
                    from historialReclamoReprocesoPrenda in _entidad.HISTORIAL_RECLAMO_REPROCESO_PRENDA
                    where historialReclamoReprocesoPrenda.DETALLE_PRENDA_ORDEN_TRABAJO_ID == detallePrendaOrdenTrabajoId
                    select historialReclamoReprocesoPrenda;

                return historialReclamoReprocesoPrendas;

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
                _entidad.HISTORIAL_RECLAMO_REPROCESO_PRENDA.Add(historialReclamoReprocesoPrenda);
                _entidad.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
