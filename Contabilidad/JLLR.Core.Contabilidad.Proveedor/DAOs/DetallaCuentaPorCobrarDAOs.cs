#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Contabilidad.Proveedor.DAOs
{
    /// <summary>
    /// Detalla de las cuentas por  cobrar
    /// </summary>
    public class DetallaCuentaPorCobrarDAOs : BaseDAOs
    { 
        
        /// <summary>
      /// Declaraciones e instancias
      /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Graba el detalle de la cuenta por cobrar
        /// </summary>
        /// <param name="cuentaPorCobrar"></param>
        /// <returns></returns>
        public DETALLE_CUENTA_POR_COBRAR GrabarDetalleCuentaPorCobrar(DETALLE_CUENTA_POR_COBRAR detalleCuentaPorCobrar)
        {
            try
            {

                _entidad.DETALLE_CUENTA_POR_COBRAR.Add(detalleCuentaPorCobrar);
                _entidad.SaveChanges();
                return detalleCuentaPorCobrar;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
