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
    /// Hisorial de  pagos
    /// </summary>
    public class HistorialCuentaPorCobrarDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Graba el  historial de los cobros
        /// </summary>
        /// <param name="historialCuentaPorCobrar"></param>
        /// <returns></returns>

        public HISTORIAL_CUENTA_POR_COBRAR GrabarHistorialCuentaPorCobrar(HISTORIAL_CUENTA_POR_COBRAR historialCuentaPorCobrar)
        {
            try
            {
                _entidad.HISTORIAL_CUENTA_POR_COBRAR.Add(historialCuentaPorCobrar);
                _entidad.SaveChanges();
                return historialCuentaPorCobrar;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Actualiza  las  cuentas por cobrar
        /// </summary>
        /// <param name="historialCuentaPorCobrar"></param>
        public void ActualizarHistorialCuentaPorCobrar(HISTORIAL_CUENTA_POR_COBRAR historialCuentaPorCobrar)
        {
            try
            {
                var original = _entidad.HISTORIAL_CUENTA_POR_COBRAR.Find(historialCuentaPorCobrar.HISTORIAL_CUENTA_POR_COBRAR_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(historialCuentaPorCobrar);
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
