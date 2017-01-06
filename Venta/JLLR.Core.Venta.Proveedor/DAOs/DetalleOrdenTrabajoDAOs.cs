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

       
    }
}
