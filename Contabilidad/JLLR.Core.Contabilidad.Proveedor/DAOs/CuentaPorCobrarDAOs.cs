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
    /// Cabcecera  de las cuentas por  cobrar
    /// </summary>
    public class CuentaPorCobrarDAOs:BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Graba la cabecera de la cuenta por cobrar
        /// </summary>
        /// <param name="cuentaPorCobrar"></param>
        /// <returns></returns>
        public CUENTA_POR_COBRAR GrabarCuentaPorCobrar(CUENTA_POR_COBRAR cuentaPorCobrar)
        {
            try
            {

                _entidad.CUENTA_POR_COBRAR.Add(cuentaPorCobrar);
                _entidad.SaveChanges();
                return cuentaPorCobrar;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }




    }
}
