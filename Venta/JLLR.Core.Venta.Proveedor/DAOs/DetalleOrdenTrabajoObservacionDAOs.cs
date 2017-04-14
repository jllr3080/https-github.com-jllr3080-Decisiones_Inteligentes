using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

namespace JLLR.Core.Venta.Proveedor.DAOs
{
    public class DetalleOrdenTrabajoObservacionDAOs:BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Graba todas las observaciones de  los detalles de la orden de trabajo
        /// </summary>
        /// <param name="detalleOrdenTrabajoObservacion"></param>
        public void GrabarDetalleOrdenTrabajoObservacion(DETALLE_ORDEN_TRABAJO_OBSERVACION detalleOrdenTrabajoObservacion)
        {
            try
            {
                _entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION.Add(detalleOrdenTrabajoObservacion);
                _entidad.SaveChanges();

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
                var detalleOrdenTrabajoObservaciones =
                    from detalleOrdenTrabajoObservacion in _entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION
                    where detalleOrdenTrabajoObservacion.DETALLE_PRENDA_ORDEN_TRABAJO_ID == detalleOrdenTrabajoId
                    select detalleOrdenTrabajoObservacion;
                return detalleOrdenTrabajoObservaciones.OrderBy(m => m.DETALLE_ORDEN_TRABAJO_OBSERVACION_ID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
