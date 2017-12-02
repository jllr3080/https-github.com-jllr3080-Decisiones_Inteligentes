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
        private readonly  CierreMesDAOs _cierreMesDaOs=  new CierreMesDAOs();
        private readonly  AplicacionPagoDAOs _aplicacionPagoDaOs= new AplicacionPagoDAOs();
        #endregion

        #region TRANSACCIONAL

        /// <summary>
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<CuentaPorCobrarDTOs> ObtenerHistorialCuentaPorCobrarPorVariosParametros(string numeroOrden, int puntoVentaId, int sucursalId)
        {
            try
            {
                return _transaccionalDaOs.ObtenerHistorialCuentaPorCobrarPorVariosParametros(numeroOrden, puntoVentaId,
                    sucursalId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<CuentaPorPagarDTOs> ObtenerHistorialCuentaPorPagarPorVariosParametros(string numeroOrden, int puntoVentaId, int sucursalId)
        {
            try
            {
                return _transaccionalDaOs.ObtenerHistorialCuentaPorPagarPorVariosParametros(numeroOrden, puntoVentaId,
                    sucursalId);


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        public List<CuentaPorPagarDTOs> ObtenerHistorialCuentaPorPagarPorNumeroOrden(string numeroOrden)
        {
            try
            {
                return _transaccionalDaOs.ObtenerHistorialCuentaPorPagarPorNumeroOrden(numeroOrden);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba el asiento tanto  positivo como negativo
        /// </summary>
        public void GrabarAsiento(AsientoDTOs asientoDtOs)
        {

            try
            {
                _transaccionalDaOs.GrabarAsiento(asientoDtOs);
            }
            catch (Exception ex)
            {
                
                throw;
            }

        }


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

        /// <summary>
        /// Obtener  las cuentas  por  cobrar  por  fecha desde y  hasta  y el punto de  venta
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<CuentaPorPagarDTOs> ObtenerCuentaPorPagarPorFechas(DateTime fechaDesde, DateTime fechaHasta,
            int sucursalId)
        {

            try
            {
                return _transaccionalDaOs.ObtenerCuentaPorPagarPorFechas(fechaDesde,fechaHasta,sucursalId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Obtiene las aplicaciones de pago para ser validadas
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="mesId"></param>
        /// <returns></returns>
        public IQueryable<AplicacionPagoDTOs> ObtenerAplicacionPagosPorPuntoVentaIdYMesId(int puntoVentaId, int mesId)
        {
            try
            {
                return _transaccionalDaOs.ObtenerAplicacionPagosPorPuntoVentaIdYMesId(puntoVentaId, mesId);
            }
            catch (Exception)
            {

                throw;
            }

        }


        /// <summary>
        /// Obtiene las cuentas opor  cobrar  por numero  de cedula 
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>

        public List<CuentaPorCobrarDTOs> ObtenerCuentasPorCobrarCompleto(string numeroIdentificacion, int puntoVentaId, int sucursalId)
        {
            try
            {
                return _transaccionalDaOs.ObtenerCuentasPorCobrarCompleto(numeroIdentificacion, puntoVentaId, sucursalId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene cuentas por cobrar por fechas
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>

        public List<CuentaPorCobrarDTOs> ObtenerCuentasPorCobrarCompletaPorFechas(int puntoVentaId, int sucursalId, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
             return _transaccionalDaOs.ObtenerCuentasPorCobrarCompletaPorFechas(puntoVentaId,sucursalId,fechaDesde,fechaHasta);
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
             return _cuentaPorCobrarDaOs.ObtenerCuentasPorCobrarPorFecha(sucursalId,fechaDesde,fechaHasta);
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
                return _cuentaPorPagarDaOs.ObtenerCuentaPorPagarPorFecha(sucursalId, fechaDesde, fechaHasta);
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

        #region  CIERRE MES
        /// <summary>
        /// Graba  el cierre  de  mes 
        /// </summary>
        /// <param name="cierreMes"></param>
        /// <returns></returns>
        public CIERRE_MES GrabarCierreMes(CIERRE_MES cierreMes)
        {
            try
            {
              return _cierreMesDaOs.GrabarCierreMes(cierreMes);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Cierre  de  mes 
        /// </summary>
        /// <param name="mesId"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public IQueryable<CIERRE_MES> ObtenerCierresMesPorAplicacionPendiente(int mesId, int puntoVentaId)
        {
            try
            {
                return _cierreMesDaOs.ObtenerCierresMesPorAplicacionPendiente(mesId,  puntoVentaId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region APLICACION PAGO
        /// <summary>
        /// Graba  el cierre  de  mes 
        /// </summary>
        /// <param name="aplicacionPago"></param>
        /// <returns></returns>
        public APLICACION_PAGO GrabaAplicacionPago(APLICACION_PAGO aplicacionPago)
        {
            try
            {
              return _aplicacionPagoDaOs.GrabaAplicacionPago(aplicacionPago);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba  el cierre  de  mes 
        /// </summary>
        /// <param name="aplicacionPago"></param>
        /// <returns></returns>
        public APLICACION_PAGO ActualizaAplicacionPago(APLICACION_PAGO aplicacionPago)
        {
            try
            {
                return _aplicacionPagoDaOs.ActualizaAplicacionPago(aplicacionPago);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        ///Obtiene  los pagos por cada  cierre  de  mes 
        /// </summary>
        /// <param name="cierreMesId"></param>
        /// <returns></returns>
        public IQueryable<APLICACION_PAGO> ObtenerAplicacionPagoPorCierreMesId(int cierreMesId)
        {
            try
            {
                return _aplicacionPagoDaOs.ObtenerAplicacionPagoPorCierreMesId(cierreMesId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }

}
