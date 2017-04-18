#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Contabilidad.Proveedor.DAOs
{
    /// <summary>
    /// Metodos del historial de las cuentas por pagar
    /// </summary>
   public  class HistorialCuentaPorPagarDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Graba el historial de las cuentas por  pagar
        /// </summary>
        /// <param name="historialCuentaPorPagar"></param>
        /// <returns></returns>
        public HISTORIAL_CUENTA_POR_PAGAR GrabarHistorialCuentaPorPagar(HISTORIAL_CUENTA_POR_PAGAR historialCuentaPorPagar)
        {
            try
            {
                _entidad.HISTORIAL_CUENTA_POR_PAGAR.Add(historialCuentaPorPagar);
                _entidad.SaveChanges();
                return historialCuentaPorPagar;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Actualiza el historial de cuentas  por pagar
        /// </summary>
        /// <param name="historialCuentaPorPagar"></param>

        public void ActualizaHistorialCuentaPorPagar(HISTORIAL_CUENTA_POR_PAGAR historialCuentaPorPagar)
        {
            try
            {
                var original = _entidad.HISTORIAL_CUENTA_POR_PAGAR.Find(historialCuentaPorPagar.HISTORIAL_CUENTA_POR_PAGAR_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(historialCuentaPorPagar);
                    _entidad.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

    }
}
