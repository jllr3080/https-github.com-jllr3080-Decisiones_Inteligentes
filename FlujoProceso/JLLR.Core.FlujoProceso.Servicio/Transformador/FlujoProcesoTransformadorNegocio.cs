#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.FlujoProceso.Proveedor.Negocio;
using JLLR.Core.FlujoProceso.Servicio.Modelo;
using  JLLR.Core.FlujoProceso.Servicio.Ensamblador;
using JLLR.Core.FlujoProceso.Servicio.EnsambladorDTOs;
#endregion


namespace JLLR.Core.FlujoProceso.Servicio.Transformador
{
    /// <summary>
    /// Relaciona las entidades con los modelos
    /// </summary>
    public class FlujoProcesoTransformadorNegocio
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly FlujoProcesoNegocio _flujoProcesoNegocio= new FlujoProcesoNegocio();
        private readonly EnsambladorEntidadDTOs _ensambladorEntidadDTOs = new EnsambladorEntidadDTOs();
        private readonly EnsambladorModeloDTOs _ensambladorModeloDTOs = new EnsambladorModeloDTOs();
        private readonly EnsambladorEntidad _ensambladorEntidad = new EnsambladorEntidad();
        private readonly EnsambladorModelo _ensambladorModelo = new EnsambladorModelo();
        #endregion

        #region HISTORIAL PROCESO
        /// <summary>
        /// Graba el  historial del proceso
        /// </summary>
        public void GrabarHistorialProceso(HistorialProcesoModelo historialProceso)
        {
            try
            {
                _flujoProcesoNegocio.GrabarHistorialProceso(_ensambladorEntidad.CrearHistorialProceso(historialProceso));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtener el historial del proceso por numero  de orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <returns></returns>
        public List<HistorialProcesoModelo> ObtenerHIstorialProcesosPorNumeroOrden(string numeroOrden)
        {
            try
            {
                return
                    _ensambladorModelo.CrearHistorialProcesos(
                        _flujoProcesoNegocio.ObtenerHIstorialProcesosPorNumeroOrden(numeroOrden));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}