#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Contabilidad.Proveedor.DAOs;
using JLLR.Core.Contabilidad.Proveedor.DTOs;

#endregion
namespace JLLR.Core.Contabilidad.Proveedor.Negocio
{
    /// <summary>
    /// Tiene  todo el negocio de  contabildiad
    /// </summary>
    public class ContabilidadNegocio
    {
        #region DECLARACIONES E INSTANCIAS
        private readonly CuentaPorCobrarDAOs  _cuentaPorCobrarDaOs= new CuentaPorCobrarDAOs();
        private readonly  DetallaCuentaPorCobrarDAOs _detallaCuentaPorCobrarDaOs= new DetallaCuentaPorCobrarDAOs();
        private readonly  TransaccionalDAOs _transaccionalDaOs= new TransaccionalDAOs();
        #endregion

        #region TRANSACCIONAL

        /// <summary>
        /// Graba la cuenta por pagar  
        /// </summary>
        /// <param name="cuentaPorCobrarDtOs"></param>
        /// <returns></returns>
        public CUENTA_POR_COBRAR GrabarCuentaPorCobrarCompleta(CuentaPorCobrarDTOs cuentaPorCobrarDtOs)
        {
            try
            {
                return _transaccionalDaOs.GrabarCuentaPorCobrarCompleta(cuentaPorCobrarDtOs);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        #endregion
    }
}
