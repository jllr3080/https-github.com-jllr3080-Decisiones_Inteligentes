#region  using
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
    /// Metodos de las  ordenes de trabajo  de las comisiones
    /// </summary>
    public class OrdenTrabajoComisionDAOs
    {
        /// <summary>
        /// Declaracion  e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Graba la comision de la orden de  trabajo
        /// </summary>
        /// <param name="ordenTrabajoComision"></param>
        public ORDEN_TRABAJO_COMISION GrabaOrdenTrabajoComision(ORDEN_TRABAJO_COMISION ordenTrabajoComision)
        {
            try
            {
                _entidad.ORDEN_TRABAJO_COMISION.Add(ordenTrabajoComision);
                _entidad.SaveChanges();
                return ordenTrabajoComision;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
