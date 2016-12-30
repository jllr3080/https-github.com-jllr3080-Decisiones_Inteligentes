#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Contabilidad.Proveedor.DAOs
{
    /// <summary>
    /// Cuentas por  Pagar
    /// </summary>
    public class CuentaPorPagarDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Graba las cuentas  por  pagar
        /// </summary>
        /// <param name="cuentaPorPagar"></param>
        /// <returns></returns>
        public CUENTA_POR_PAGAR GrabarCuentaPorPagar(CUENTA_POR_PAGAR cuentaPorPagar)
        {
            try
            {
                _entidad.CUENTA_POR_PAGAR.Add(cuentaPorPagar);
                _entidad.SaveChanges();
                return cuentaPorPagar;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Graba las cuentas  por  pagar
        /// </summary>
        /// <param name="cuentaPorPagar"></param>
        /// <returns></returns>
        public void ActualizaCuentaPorPagar(CUENTA_POR_PAGAR cuentaPorPagar)
        {
            try
            {
                var original = _entidad.CUENTA_POR_PAGAR.Find(cuentaPorPagar.CUENTA_POR_PAGAR_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(cuentaPorPagar);
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
