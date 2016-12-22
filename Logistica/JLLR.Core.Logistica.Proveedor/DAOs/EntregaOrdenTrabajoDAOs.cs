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
    /// Metodo para la entrega de  prendas  hacia la ruta
    /// </summary>
    public class EntregaOrdenTrabajoDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();



      /// <summary>
      /// Graba la entrega de las ordenes de  trabajo
      /// </summary>
      /// <param name="entregaOrdenTrabajo"></param>
        public ENTREGA_ORDEN_TRABAJO GrabaEntregaOrdenTrabajo(ENTREGA_ORDEN_TRABAJO entregaOrdenTrabajo)
        {
            try
            {
                _entidad.ENTREGA_ORDEN_TRABAJO.Add(entregaOrdenTrabajo);
                _entidad.SaveChanges();
                return entregaOrdenTrabajo;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
