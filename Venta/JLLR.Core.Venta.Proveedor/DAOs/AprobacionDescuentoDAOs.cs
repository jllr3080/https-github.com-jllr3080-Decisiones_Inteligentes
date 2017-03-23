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
    /// Aprobacion d e los  descuentos
    /// </summary>
    public class AprobacionDescuentoDAOs
    {

        /// <summary>
        /// Declaracione e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Graba la  aprobacion del descuento
        /// </summary>
        /// <param name="aprobacionDescuento"></param>

        public void GrabarAprobacionDescuento(APROBACION_DESCUENTO aprobacionDescuento)
        {
            try
            {
                _entidad.APROBACION_DESCUENTO.Add(aprobacionDescuento);
                _entidad.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}

