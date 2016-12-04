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
    /// Metodos de  las ordenes de  trabajo 
    /// </summary>
    public class OrdenTrabajoDAOs:BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Graba la orden de trabajo
        /// </summary>
        /// <param name="ordenTrabajo"></param>
        /// <returns></returns>
        public ORDEN_TRABAJO GrabarOrdenTrabajo(ORDEN_TRABAJO ordenTrabajo)
        {
            try
            {
                _entidad.ORDEN_TRABAJO.Add(ordenTrabajo);
                _entidad.SaveChanges();
                return ordenTrabajo;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

    }
}
