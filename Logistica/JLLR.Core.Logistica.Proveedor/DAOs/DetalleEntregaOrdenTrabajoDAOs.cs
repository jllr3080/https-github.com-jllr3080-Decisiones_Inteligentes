#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Logistica.Proveedor.DAOs
{
    /// <summary>
    /// Detalle  entrega orden d e  trabajo
    /// </summary>
    public class DetalleEntregaOrdenTrabajoDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();



        /// <summary>
        /// Graba la entrega de las ordenes de  trabajo
        /// </summary>
        /// <param name="entregaOrdenTrabajo"></param>
        public void GrabaDetalleEntregaOrdenTrabajo(DETALLE_ENTREGA_ORDEN_TRABAJO detalleEntregaOrdenTrabajo)
        {
            try
            {
                _entidad.DETALLE_ENTREGA_ORDEN_TRABAJO.Add(detalleEntregaOrdenTrabajo);
                _entidad.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}
