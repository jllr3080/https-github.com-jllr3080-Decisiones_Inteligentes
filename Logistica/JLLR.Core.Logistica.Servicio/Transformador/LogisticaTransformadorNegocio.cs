#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.Logistica.Proveedor.Negocio;
using JLLR.Core.Logistica.Servicio.DTOs;
using JLLR.Core.Logistica.Servicio.Ensamblador;
using JLLR.Core.Logistica.Servicio.EnsambladorDTOs;
using JLLR.Core.Logistica.Servicio.Modelo;

#endregion

namespace JLLR.Core.Logistica.Servicio.Transformador
{
    /// <summary>
    /// Transformador de la capa de logistica
    /// </summary>
    public class LogisticaTransformadorNegocio
    {
        #region DECLARACIONES E INSTANCIAS
        private readonly LogisticaNegocio _logisticaNegocio = new LogisticaNegocio();
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
        public EntregaOrdenTrabajoModelo GrabarCuentaPorCobrarCompleta(EntregaOrdenTrabajoDTOs entregaOrdenTrabajoDtOs)
        {
            try
            {
                return
                    _ensambladorModelo.CrearEntregaOrdenTrabajo(
                        _logisticaNegocio.GrabarEntregaOrdenTrabajoCompleta(
                            _ensambladorEntidadDTOs.CrearEntregaOrdenTrabajoDtOs(entregaOrdenTrabajoDtOs)));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}