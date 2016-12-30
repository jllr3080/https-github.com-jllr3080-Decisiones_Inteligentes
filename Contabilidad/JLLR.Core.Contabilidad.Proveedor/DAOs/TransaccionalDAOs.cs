#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Contabilidad.Proveedor.DTOs;

#endregion
namespace JLLR.Core.Contabilidad.Proveedor.DAOs
{
    /// <summary>
    /// Metodos  generales 
    /// </summary>
    public class TransaccionalDAOs : BaseDAOs
    {
        #region DECLARACIONES E INSTANCIAS
        private readonly CuentaPorCobrarDAOs _cuentaPorCobrarDaOs = new CuentaPorCobrarDAOs();
        
        #endregion


        #region TRANSACCIONAL
        /// <summary>
        /// Graba la cuenta por pagar  
        /// </summary>
        /// <param name="cuentaPorCobrarDtOs"></param>
        /// <returns></returns>
        public CUENTA_POR_COBRAR GrabarCuentaPorCobrarCompleta(CuentaPorCobrarDTOs cuentaPorCobrarDtOs)
        {
            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    CUENTA_POR_COBRAR cuentaPorCobrar =
                        _cuentaPorCobrarDaOs.GrabarCuentaPorCobrar(cuentaPorCobrarDtOs.CuentaPorCobrar);

             
                   
                    transaction.Complete();

                    return cuentaPorCobrarDtOs.CuentaPorCobrar;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion
    }
}
