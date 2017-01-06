#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Contabilidad.Servicio.DTOs;
using JLLR.Core.Contabilidad.Servicio.Modelo;
using JLLR.Core.Contabilidad.Servicio.Transformador;

#endregion

namespace JLLR.Core.Contabilidad.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioContabilidad : IServicioContabilidad
    {
        #region  DECLARACIONES  E INSTANCIAS
        private readonly ContabilidadTransformadorNegocio _contabilidadTransformadorNegocio = new ContabilidadTransformadorNegocio();
        #endregion

        #region TRANSACCIONAL
        /// <summary>
        /// Graba la cuenta por pagar  
        /// </summary>
        /// <param name="cuentaPorCobrarDtOs"></param>
        /// <returns></returns>
        public CuentaPorCobrarModelo GrabarCuentaPorCobrarCompleta(CuentaPorCobrarDTOs cuentaPorCobrarDtOs)
        {
            try
            {
                return _contabilidadTransformadorNegocio.GrabarCuentaPorCobrarCompleta(cuentaPorCobrarDtOs);
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
                return _contabilidadTransformadorNegocio.ObtenerHistorialCuentaPorCobrarPorNumeroOrden(numeroOrden);
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
                return _contabilidadTransformadorNegocio.ObtenerHistorialCuentaPorCobrarPorNumeroidentificacion(numeroIdentificacion);
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
        public CuentaPorCobrarModelo GrabarCuentaPorCobrar(CuentaPorCobrarModelo cuentaPorCobrar)
        {
            try
            {
                return _contabilidadTransformadorNegocio.GrabarCuentaPorCobrar(cuentaPorCobrar);

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
               _contabilidadTransformadorNegocio.ActualizaCuentaPorCobrar(cuentaPorCobrar);

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
                return _contabilidadTransformadorNegocio.GrabarHistorialCuentaPorCobrar(historialCuentaPorCobrar);

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
                _contabilidadTransformadorNegocio.ActualizarHistorialCuentaPorCobrar(historialCuentaPorCobrar);
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

                return _contabilidadTransformadorNegocio.GrabarCuentaPorPagar(cuentaPorPagar);

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
                _contabilidadTransformadorNegocio.ActualizaCuentaPorPagar(cuentaPorPagar);

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
                return _contabilidadTransformadorNegocio.GrabarHistorialCuentaPorPagar(historialCuentaPorPagar);

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
                _contabilidadTransformadorNegocio.ActualizaHistorialCuentaPorPagar(historialCuentaPorPagar);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
