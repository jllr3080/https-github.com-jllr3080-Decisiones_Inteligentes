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
        /// Graba la cuenta por pagar  
        /// </summary>
        /// <param name="cuentaPorCobrarDtOs"></param>
        /// <returns></returns>
        public CuentaPorCobrarModelo GrabarCuentaPorCobrarCompleta(CuentaPorCobrarDTOs cuentaPorCobrarDtOs)
        {
            try
            {
                return
                    _ensambladorModelo.CrearCuentaPorPagar(
                        _contabilidadNegocio.GrabarCuentaPorCobrarCompleta(
                            _ensambladorEntidadDTOs.CrearCuentaPorCobrarDtOs(cuentaPorCobrarDtOs)));
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        #endregion
    }
}