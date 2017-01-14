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
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();
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


        /// <summary>
        /// Obtiene  el historial de cuenta por cobrar  por numero de identificacion
        /// </summary>
        public List<CuentaPorCobrarDTOs> ObtenerHistorialCuentaPorCobrarPorNumeroidentificacion( string numeroIdentificacion)
        {
            try
            {
                var cuentasPorCobrar = from cuentaPorCobrar in _entidad.CUENTA_POR_COBRAR
                                       join historialCuentaPorCobrar in _entidad.HISTORIAL_CUENTA_POR_COBRAR on
                                           cuentaPorCobrar.CUENTA_POR_COBRAR_ID equals historialCuentaPorCobrar.CUENTA_POR_COBRAR_ID
                                       join cliente in _entidad.CLIENTE on cuentaPorCobrar.CLIENTE_ID equals cliente.CLIENTE_ID
                                       join individuo in _entidad.INDIVIDUO on cliente.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                                       where individuo.NUMERO_IDENTIFICACION == numeroIdentificacion
                                       select new CuentaPorCobrarDTOs() { HistorialCuentaPorCobrar = historialCuentaPorCobrar, CuentaPorCobrar = cuentaPorCobrar ,Cliente = individuo.PRIMER_CAMPO + individuo.SEGUNDO_CAMPO+ individuo.TERCER_CAMPO+ individuo.CUARTO_CAMPO};

                List<CuentaPorCobrarDTOs> _listaCuentaPorCobrarDtOses = new List<CuentaPorCobrarDTOs>();

                foreach (var objetoCuentaPorCobrar in cuentasPorCobrar)
                {
                    _listaCuentaPorCobrarDtOses.Add(objetoCuentaPorCobrar);

                }

                return _listaCuentaPorCobrarDtOses;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Obtiene el historial por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        public  List<CuentaPorCobrarDTOs> ObtenerHistorialCuentaPorCobrarPorNumeroOrden(string numeroOrden)
        {
            try
            {
                var cuentasPorCobrar = from cuentaPorCobrar in _entidad.CUENTA_POR_COBRAR
                    join historialCuentaPorCobrar in _entidad.HISTORIAL_CUENTA_POR_COBRAR on
                        cuentaPorCobrar.CUENTA_POR_COBRAR_ID equals historialCuentaPorCobrar.CUENTA_POR_COBRAR_ID
                    join cliente in _entidad.CLIENTE on cuentaPorCobrar.CLIENTE_ID equals cliente.CLIENTE_ID
                    join individuo in _entidad.INDIVIDUO on cliente.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                    where cuentaPorCobrar.NUMERO_ORDEN == numeroOrden
                                       select new CuentaPorCobrarDTOs() { HistorialCuentaPorCobrar = historialCuentaPorCobrar, CuentaPorCobrar = cuentaPorCobrar, Cliente = individuo.PRIMER_CAMPO + individuo.SEGUNDO_CAMPO + individuo.TERCER_CAMPO + individuo.CUARTO_CAMPO };

                List<CuentaPorCobrarDTOs> _listaCuentaPorCobrarDtOses=  new List<CuentaPorCobrarDTOs>();

                foreach (var objetoCuentaPorCobrar in cuentasPorCobrar)
                {
                    _listaCuentaPorCobrarDtOses.Add(objetoCuentaPorCobrar);

                }

                return _listaCuentaPorCobrarDtOses;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        #endregion
    }
}
