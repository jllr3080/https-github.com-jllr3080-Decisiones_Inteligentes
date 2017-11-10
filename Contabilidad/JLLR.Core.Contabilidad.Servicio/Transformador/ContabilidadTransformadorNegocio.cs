#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  JLLR.Core.Contabilidad.Proveedor.Negocio;
using JLLR.Core.Contabilidad.Servicio.DTOs;
using JLLR.Core.Contabilidad.Servicio.Ensamblador;
using JLLR.Core.Contabilidad.Servicio.EnsambladorDTOs;
using JLLR.Core.Contabilidad.Servicio.Modelo;

#endregion
namespace JLLR.Core.Contabilidad.Servicio.Transformador
{
    /// <summary>
    ///  Transformador de contabildiad
    /// </summary>
    public class ContabilidadTransformadorNegocio
    {
        #region DECLARACIONES E INSTANCIAS
        private readonly ContabilidadNegocio _contabilidadNegocio= new ContabilidadNegocio();
        private readonly EnsambladorEntidadDTOs _ensambladorEntidadDTOs = new EnsambladorEntidadDTOs();
        private readonly EnsambladorModeloDTOs _ensambladorModeloDTOs = new EnsambladorModeloDTOs();
        private readonly EnsambladorEntidad _ensambladorEntidad = new EnsambladorEntidad();
        private readonly EnsambladorModelo _ensambladorModelo = new EnsambladorModelo();
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
                return
                    _ensambladorModeloDTOs.CreaCuentasPorCobrarDtOs(
                        _contabilidadNegocio.ObtenerHistorialCuentaPorCobrarPorVariosParametros(numeroOrden,
                            puntoVentaId, sucursalId));
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
                return
                    _ensambladorModeloDTOs.CrearCuentasPorPagarDtOs(
                        _contabilidadNegocio.ObtenerHistorialCuentaPorPagarPorVariosParametros(numeroOrden, puntoVentaId,
                            sucursalId));


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
                return
                    _ensambladorModeloDTOs.CrearCuentasPorPagarDtOs(
                        _contabilidadNegocio.ObtenerHistorialCuentaPorPagarPorNumeroOrden(numeroOrden));

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
                _contabilidadNegocio.GrabarAsiento(_ensambladorEntidadDTOs.CrearAsiento(asientoDtOs));
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
        public CuentaPorCobrarModelo GrabarCuentaPorCobrarCompleta(CuentaPorCobrarDTOs cuentaPorCobrarDtOs)
        {
            try
            {
                return null;

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
               return   _ensambladorModeloDTOs.CreaCuentasPorCobrarDtOs(_contabilidadNegocio.ObtenerHistorialCuentaPorCobrarPorNumeroOrden(numeroOrden));
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
                return _ensambladorModeloDTOs.CreaCuentasPorCobrarDtOs(_contabilidadNegocio.ObtenerHistorialCuentaPorCobrarPorNumeroidentificacion(numeroIdentificacion));
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
                return
                    _ensambladorModeloDTOs.CrearCuentasPorPagarDtOs(
                        _contabilidadNegocio.ObtenerCuentaPorPagarPorFechas(fechaDesde, fechaHasta, sucursalId));
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
        public List<AplicacionPagoDTOs> ObtenerAplicacionPagosPorPuntoVentaIdYMesId(int puntoVentaId, int mesId)
        {
            try
            {
                return
                    _ensambladorModeloDTOs.CrearAplicacionPagoDtOses(
                        _contabilidadNegocio.ObtenerAplicacionPagosPorPuntoVentaIdYMesId(puntoVentaId, mesId));

            }
            catch (Exception)
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
        public CuentaPorCobrarModelo GrabarCuentaPorCobrar(CuentaPorCobrarModelo cuentaPorCobrar)
        {
            try
            {
                return
                    _ensambladorModelo.CrearCuentaPorCobrar(_contabilidadNegocio.GrabarCuentaPorCobrar(_ensambladorEntidad.CrearCuentaPorCobrar(cuentaPorCobrar)));

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

        public void ActualizaCuentaPorCobrar(CuentaPorCobrarModelo cuentaPorCobrar)
        {
            try
            {
                _contabilidadNegocio.ActualizaCuentaPorCobrar(_ensambladorEntidad.CrearCuentaPorCobrar(cuentaPorCobrar));

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

        public List<CuentaPorCobrarModelo> ObtenerCuentasPorCobrarPorFecha(int sucursalId, DateTime fechaDesde,
            DateTime fechaHasta)
        {
            try
            {
                return
                    _ensambladorModelo.CrearCuentasPorCobrar(
                        _contabilidadNegocio.ObtenerCuentasPorCobrarPorFecha(sucursalId, fechaDesde, fechaHasta));
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

        public HistorialCuentaPorCobrarModelo GrabarHistorialCuentaPorCobrar(HistorialCuentaPorCobrarModelo historialCuentaPorCobrar)
        {
            try
            {
                return
                    _ensambladorModelo.CrearHistorialCuentaPorCobrar(
                        _contabilidadNegocio.GrabarHistorialCuentaPorCobrar(
                            _ensambladorEntidad.CrearHistorialCuentaPorCobrar(historialCuentaPorCobrar)));

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
        public void ActualizarHistorialCuentaPorCobrar(HistorialCuentaPorCobrarModelo historialCuentaPorCobrar)
        {
            try
            {
                _contabilidadNegocio.ActualizarHistorialCuentaPorCobrar(_ensambladorEntidad.CrearHistorialCuentaPorCobrar(historialCuentaPorCobrar));
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
        public CuentaPorPagarModelo GrabarCuentaPorPagar(CuentaPorPagarModelo cuentaPorPagar)
        {
            try
            {

                return
                    _ensambladorModelo.CrearCuentaPorPagar(
                        _contabilidadNegocio.GrabarCuentaPorPagar(_ensambladorEntidad.CrearCuentaPorPagar(cuentaPorPagar)));
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
        public void ActualizaCuentaPorPagar(CuentaPorPagarModelo cuentaPorPagar)
        {
            try
            {
             _contabilidadNegocio.ActualizaCuentaPorPagar(_ensambladorEntidad.CrearCuentaPorPagar(cuentaPorPagar));
                
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

        public List<CuentaPorPagarModelo> ObtenerCuentaPorPagarPorFecha(int sucursalId, DateTime fechaDesde,
            DateTime fechaHasta)
        {

            try
            {
                return
                    _ensambladorModelo.CrearCuentasPorPagar(
                        _contabilidadNegocio.ObtenerCuentaPorPagarPorFecha(sucursalId, fechaDesde, fechaHasta));
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
        public HistorialCuentaPorPagarModelo GrabarHistorialCuentaPorPagar(HistorialCuentaPorPagarModelo historialCuentaPorPagar)
        {
            try
            {
                return
                    _ensambladorModelo.CrearHistorialCuentaPorPagar(
                        _contabilidadNegocio.GrabarHistorialCuentaPorPagar(
                            _ensambladorEntidad.CrearHistorialCuentaPorPagar(historialCuentaPorPagar)));

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

        public void ActualizaHistorialCuentaPorPagar(HistorialCuentaPorPagarModelo historialCuentaPorPagar)
        {
            try
            {
                _contabilidadNegocio.ActualizaHistorialCuentaPorPagar(_ensambladorEntidad.CrearHistorialCuentaPorPagar(historialCuentaPorPagar));
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
        public CierreMesModelo GrabarCierreMes(CierreMesModelo cierreMes)
        {
            try
            {
                return
                    _ensambladorModelo.CrearCierre(
                        _contabilidadNegocio.GrabarCierreMes(_ensambladorEntidad.CrearCierreMes(cierreMes)));
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
        public List<CierreMesModelo> ObtenerCierresMesPorAplicacionPendiente(int mesId, int puntoVentaId)
        {
            try
            {
                return
                    _ensambladorModelo.CrearCierres(_contabilidadNegocio.ObtenerCierresMesPorAplicacionPendiente(mesId,
                        puntoVentaId));
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
        public AplicacionPagoModelo GrabaAplicacionPago(AplicacionPagoModelo aplicacionPago)
        {
            try
            {
                return
                    _ensambladorModelo.CrearAplicacionPago(
                        _contabilidadNegocio.GrabaAplicacionPago(_ensambladorEntidad.CrearAplicacionPago(aplicacionPago)));
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
        public AplicacionPagoModelo ActualizaAplicacionPago(AplicacionPagoModelo aplicacionPago)
        {
            try
            {
                return
                    _ensambladorModelo.CrearAplicacionPago(
                        _contabilidadNegocio.ActualizaAplicacionPago(
                            _ensambladorEntidad.CrearAplicacionPago(aplicacionPago)));
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
        public List<AplicacionPagoModelo> ObtenerAplicacionPagoPorCierreMesId(int cierreMesId)
        {
            try
            {
                return
                    _ensambladorModelo.CrearAplicacionesPago(
                        _contabilidadNegocio.ObtenerAplicacionPagoPorCierreMesId(cierreMesId));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}