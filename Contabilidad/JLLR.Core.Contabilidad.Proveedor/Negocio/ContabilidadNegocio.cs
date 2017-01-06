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
        private readonly  CuentaPorPagarDAOs _cuentaPorPagarDaOs= new CuentaPorPagarDAOs();
        private readonly  TransaccionalDAOs _transaccionalDaOs= new TransaccionalDAOs();
        private readonly  HistorialCuentaPorCobrarDAOs _historialCuentaPorCobrarDaOs= new HistorialCuentaPorCobrarDAOs();
        private readonly  HistorialCuentaPorPagarDAOs _historialCuentaPorPagarDaOs= new HistorialCuentaPorPagarDAOs();
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

        /// <summary>
        /// Obtiene el historial por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        public List<CuentaPorCobrarDTOs> ObtenerHistorialCuentaPorCobrarPorNumeroOrden(string numeroOrden)
        {
            try
            {
                return _transaccionalDaOs.ObtenerHistorialCuentaPorCobrarPorNumeroOrden(numeroOrden);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene  el historial de cuenta por cobrar  por numero de identificacion
        /// </summary>
        public List<CuentaPorCobrarDTOs> ObtenerHistorialCuentaPorCobrarPorNumeroidentificacion(string numeroIdentificacion)
        {
            try
            {
                return _transaccionalDaOs.ObtenerHistorialCuentaPorCobrarPorNumeroidentificacion(numeroIdentificacion);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region CUENTA POR COBRAR

        /// <summary>
        /// Graba la cabecera de la cuenta por cobrar
        /// </summary>
        /// <param name="cuentaPorCobrar"></param>
        /// <returns></returns>
        public CUENTA_POR_COBRAR GrabarCuentaPorCobrar(CUENTA_POR_COBRAR cuentaPorCobrar)
        {
            try
            {
                return _cuentaPorCobrarDaOs.GrabarCuentaPorCobrar(cuentaPorCobrar);

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
                _cuentaPorCobrarDaOs.ActualizaCuentaPorCobrar(cuentaPorCobrar);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region HISTORIAL CUENTAS POR COBRAR
        /// <summary>
        /// Graba el  historial de los cobros
        /// </summary>
        /// <param name="historialCuentaPorCobrar"></param>
        /// <returns></returns>

        public HISTORIAL_CUENTA_POR_COBRAR GrabarHistorialCuentaPorCobrar(HISTORIAL_CUENTA_POR_COBRAR historialCuentaPorCobrar)
        {
            try
            {
                return _historialCuentaPorCobrarDaOs.GrabarHistorialCuentaPorCobrar(historialCuentaPorCobrar);

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
                
                _historialCuentaPorCobrarDaOs.ActualizarHistorialCuentaPorCobrar(historialCuentaPorCobrar);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #region CUENTA POR PAGAR
        /// <summary>
        /// Graba las cuentas  por  pagar
        /// </summary>
        /// <param name="cuentaPorPagar"></param>
        /// <returns></returns>
        public CUENTA_POR_PAGAR GrabarCuentaPorPagar(CUENTA_POR_PAGAR cuentaPorPagar)
        {
            try
            {
               
                return _cuentaPorPagarDaOs.GrabarCuentaPorPagar(cuentaPorPagar);
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
                _cuentaPorPagarDaOs.ActualizaCuentaPorPagar(cuentaPorPagar);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region HISTORIAL CUENTAS POR PAGAR
        /// <summary>
        /// Graba el historial de las cuentas por  pagar
        /// </summary>
        /// <param name="historialCuentaPorPagar"></param>
        /// <returns></returns>
        public HISTORIAL_CUENTA_POR_PAGAR GrabarHistorialCuentaPorPagar(HISTORIAL_CUENTA_POR_PAGAR historialCuentaPorPagar)
        {
            try
            {
                return _historialCuentaPorPagarDaOs.GrabarHistorialCuentaPorPagar(historialCuentaPorPagar);

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
                _historialCuentaPorPagarDaOs.ActualizaHistorialCuentaPorPagar(historialCuentaPorPagar);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }

}
