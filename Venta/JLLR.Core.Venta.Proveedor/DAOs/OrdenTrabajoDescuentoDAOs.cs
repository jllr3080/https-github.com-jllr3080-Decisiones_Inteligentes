#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.Venta.Proveedor.DAOs
{
    /// <summary>
    /// Metodos de la orden de trabajo de  descuento
    /// </summary>
    public class OrdenTrabajoDescuentoDAOs
    {

        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Graba el descuento de la orden d etrabajo
        /// </summary>
        public void GrabarOrdenTrabajoDescuento(ORDEN_TRABAJO_DESCUENTO ordenTrabajoDescuento)
        {
            try
            {
                _entidad.ORDEN_TRABAJO_DESCUENTO.Add(ordenTrabajoDescuento);
                _entidad.SaveChanges();

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Obtiene todas las ordenes de  trabajo para ekl descuento  por el estado
        /// </summary>
        /// <returns></returns>
        public IQueryable<ORDEN_TRABAJO_DESCUENTO> ObtenerOrdenTrabajoDescuentoPorEstadoProceso()
        {
            try
            {
                var ordenesTrabajoDescuento = from ordenTrabajoDescuento in _entidad.ORDEN_TRABAJO_DESCUENTO
                    where ordenTrabajoDescuento.ESTADO_PROCESO == false
                    select ordenTrabajoDescuento;

                return ordenesTrabajoDescuento.OrderBy(m => m.FECHA_CREACION);

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Actualiza  la orden de  descuento
        /// </summary>
        /// <param name="ordenTrabajoDescuento"></param>
        public void ActualizarOrdenTrabajoDescuento(ORDEN_TRABAJO_DESCUENTO ordenTrabajoDescuento)
        {
            try
            {
                var original = _entidad.ORDEN_TRABAJO_DESCUENTO.Find(ordenTrabajoDescuento.ORDEN_TRABAJO_DESCUENTO_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(ordenTrabajoDescuento);
                    _entidad.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

    }
}
