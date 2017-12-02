#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.Venta.Proveedor.DAOs
{
    /// <summary>
    /// Metodos del detalle de  la orden de  trabajo
    /// </summary>
    public class DetalleOrdenTrabajoDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Graba el detalle de la orden de trabajo
        /// </summary>
        /// <param name="detalleOrdenTrabajo"></param>
        /// <returns></returns>
        public DETALLE_ORDEN_TRABAJO GrabarDetelleOrdenTrabajo(DETALLE_ORDEN_TRABAJO detalleOrdenTrabajo)
        {
            try
            {
                _entidad.DETALLE_ORDEN_TRABAJO.Add(detalleOrdenTrabajo);
                _entidad.SaveChanges();
                return detalleOrdenTrabajo;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene  el detalle de  una orden de  trabajo por  orden de trabajo id
        /// </summary>
        /// <param name="ordenTrabajoId"></param>
        /// <returns></returns>
        public IQueryable<DETALLE_ORDEN_TRABAJO> ObtenerDetalleOrdenTrabajosPorOrdenTrabajoId(int ordenTrabajoId)
        {
            try
            {
                var detalleOrdenesTrabajo = from detalleOrdenTrabajo in _entidad.DETALLE_ORDEN_TRABAJO
                    where detalleOrdenTrabajo.ORDEN_TRABAJO_ID == ordenTrabajoId
                    select detalleOrdenTrabajo;

                return detalleOrdenesTrabajo;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Actualiza la orden de trabajo
        /// </summary>
        /// <param name=""></param>
        public void ActualizarDetalleOrdenTrabajo(DETALLE_ORDEN_TRABAJO detalleOrdenTrabajo)
        {
            try
            {
                var original = _entidad.DETALLE_ORDEN_TRABAJO.Find(detalleOrdenTrabajo.DETALLE_ORDEN_TRABAJO_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(detalleOrdenTrabajo);
                    _entidad.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Encontrar el detalle de la orden  de trabajo 
        /// </summary>
        /// <param name="detalleOrdenTrabajoId"></param>
        public DETALLE_ORDEN_TRABAJO ObtenerDetalleOrdenTrabajoPorId(int detalleOrdenTrabajoId)
        {
            try
            {
                return _entidad.DETALLE_ORDEN_TRABAJO.Find(detalleOrdenTrabajoId);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
