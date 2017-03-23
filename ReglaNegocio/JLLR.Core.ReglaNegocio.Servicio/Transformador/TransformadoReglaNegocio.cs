#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.ReglaNegocio.Servicio.DTOs;
using JLLR.Core.ReglaNegocio.Proveedor.Negocio;
using  JLLR.Core.ReglaNegocio.Servicio.EnsambladorDTOs;
#endregion

namespace JLLR.Core.ReglaNegocio.Servicio.Transformador
{

    /// <summary>
    /// Transforma desde la capa del proveedor al servicio
    /// </summary>
    public class TransformadoReglaNegocio
    {
        #region  DECLARACIONES  E INSTANCIAS
        private Proveedor.Negocio.ReglaNegocio _reglaNegocio = new Proveedor.Negocio.ReglaNegocio();
        private EnsambladorEntidadDTOs _ensambladorEntidadDtOs = new EnsambladorEntidadDTOs();
        private EnsambladorModeloDTOs _ensambladorModeloDtOs= new EnsambladorModeloDTOs();
        #endregion

        #region TRANSACCIONAL
        /// <summary>
        /// Obtener las reglas para aplicar     
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<ReglaDTOs> ObtenerReglasPorPuntoVentaIdYSucursalId(int puntoVentaId, int sucursalId)
        {
            try
            {

                return
                    _ensambladorModeloDtOs.CrearReglasNegocio(_reglaNegocio.ObtenerReglasPorPuntoVentaIdYSucursalId(puntoVentaId, sucursalId));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

    }
}