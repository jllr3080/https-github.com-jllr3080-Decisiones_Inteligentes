#region using
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Contabilidad.Proveedor.DAOs
{
    /// <summary>
    /// Cuentas por  Pagar
    /// </summary>
    public class CuentaPorPagarDAOs : BaseDAOs
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

        /// <summary>
        /// Obtener  las cuentas  por pagar por  fecha
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechahasta"></param>
        /// <returns></returns>

        public IQueryable<CUENTA_POR_PAGAR> ObtenerCuentaPorPagarPorFecha(int sucursalId, DateTime fechaDesde,
            DateTime fechaHasta)
        {

            try
            {
                var cuentasPorPagar = from cuentaPorPagar in _entidad.CUENTA_POR_PAGAR
                                        where
                                            cuentaPorPagar.PUNTO_VENTA_ID == sucursalId &&
                                            EntityFunctions.TruncateTime(cuentaPorPagar.FECHA_CREACION) >= fechaDesde &&
                                            EntityFunctions.TruncateTime(cuentaPorPagar.FECHA_CREACION) <= fechaHasta
                                        select cuentaPorPagar;

                return cuentasPorPagar;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
