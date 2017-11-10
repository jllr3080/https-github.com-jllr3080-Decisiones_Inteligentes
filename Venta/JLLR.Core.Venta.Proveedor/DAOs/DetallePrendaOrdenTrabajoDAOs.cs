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
    /// Metodos  de los detalles de  las prendas
    /// </summary>
    public class DetallePrendaOrdenTrabajoDAOs : BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Graba la orden de trabajo
        /// </summary>
        /// <param name="ordenTrabajo"></param>
        /// <returns></returns>
        public DETALLE_PRENDA_ORDEN_TRABAJO GrabarDetallePrendaOrdenTrabajo(DETALLE_PRENDA_ORDEN_TRABAJO detallePrendaOrdenTrabajo)
        {
            try
            {
                _entidad.DETALLE_PRENDA_ORDEN_TRABAJO.Add(detallePrendaOrdenTrabajo);
                _entidad.SaveChanges();
                return detallePrendaOrdenTrabajo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Actualiza la orden de trabajo
        /// </summary>
        /// <param name="detallePrendaOrdenTrabajo"></param>
        public void ActualizarDetallePrendaOrdenTrabajo(DETALLE_PRENDA_ORDEN_TRABAJO detallePrendaOrdenTrabajo)
        {
            try
            {
                var original = _entidad.DETALLE_PRENDA_ORDEN_TRABAJO.Find(detallePrendaOrdenTrabajo.DETALLE_ORDEN_TRABAJO_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(detallePrendaOrdenTrabajo);
                    _entidad.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
