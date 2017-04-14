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

        /// <summary>
        /// Actualiza las  cuentas  por cobrar
        /// </summary>
        /// <param name="cuentaPorCobrar"></param>

        public void ActualizaCuentaPorCobrar(CUENTA_POR_COBRAR cuentaPorCobrar)
        {
            try
            {
                var original = _entidad.CUENTA_POR_COBRAR.Find(cuentaPorCobrar.CUENTA_POR_COBRAR_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(cuentaPorCobrar);
                    _entidad.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Obtener las cuentas  por  cobrar por  fecha
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>

        public IQueryable<CUENTA_POR_COBRAR> ObtenerCuentasPorCobrarPorFecha(int sucursalId, DateTime fechaDesde,
            DateTime fechaHasta)
        {
            try
            {
                var cuentasPorCobrar= from cuentaPorCobrar in _entidad.CUENTA_POR_COBRAR
                                      where
                                            cuentaPorCobrar.PUNTO_VENTA_ID == sucursalId &&
                                            EntityFunctions.TruncateTime(cuentaPorCobrar.FECHA_CREACION) >= fechaDesde &&
                                            EntityFunctions.TruncateTime(cuentaPorCobrar.FECHA_CREACION) <= fechaHasta && cuentaPorCobrar.SALDO != 0
                                      select cuentaPorCobrar;

                return cuentasPorCobrar;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }



    }
}
