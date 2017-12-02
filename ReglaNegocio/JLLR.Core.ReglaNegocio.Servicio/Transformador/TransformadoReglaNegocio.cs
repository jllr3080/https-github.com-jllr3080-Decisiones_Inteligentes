#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.ReglaNegocio.Servicio.DTOs;
using JLLR.Core.ReglaNegocio.Proveedor.Negocio;
using JLLR.Core.ReglaNegocio.Servicio.Ensamblador;
using  JLLR.Core.ReglaNegocio.Servicio.EnsambladorDTOs;
using JLLR.Core.ReglaNegocio.Servicio.Modelo;

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
        private EnsambladorEntidad _ensambladorEntidad = new EnsambladorEntidad();
        private EnsambladorModelo _ensambladorModelo = new EnsambladorModelo();
        #endregion

        #region TRANSACCIONAL


        /// <summary>
        /// Obtiene  las  promociones  vigentes 
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>

        public List<ReglaModelo> ObtenerPromocionesVigentes(int puntoVentaId, int sucursalId)
        {
            try
            {
                return _ensambladorModelo.CrearReglas(_reglaNegocio.ObtenerPromocionesVigentes(puntoVentaId, sucursalId));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
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

        #region REGLA NEGOCIO

        /// <summary>
        /// Ejeuta las  reglas  de  negocio
        /// </summary>
        /// <param name="parametroEntradaReglaNegocio"></param>
        /// <returns></returns>
        public ParametroSalidaReglaNegocioDTOs EjecucionReglaNegocio(ParametroEntradaReglaNegocioDTOs parametroEntradaReglaNegocio)
        {

            try
            {

                return _ensambladorModeloDtOs.CRearParametroSalidaReglaNegocioDtOs( _reglaNegocio.EjecucionReglaNegocio(_ensambladorEntidadDtOs.CrearParametroEntradaReglaNegocioDtOs( parametroEntradaReglaNegocio)));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion           

        #region REGLA

        /// <summary>
        /// Obtiene la promocion por  Id
        /// </summary>
        /// <param name="reglaId"></param>
        /// <returns></returns>
        public ReglaModelo ObtenerReglaPorId(int reglaId)
        {
            try
            {
                return  _ensambladorModelo.CrearRegla( _reglaNegocio.ObtenerReglaPorId(reglaId));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion      

        #region ADMINISTRACION PROMOCIONES

        /// <summary>
        /// Grabar promociones
        /// </summary>
        /// <param name="reglaCompletaDtOs"></param>
        public void GrabarPromocionesCompleta(ReglaCompletaDTOs reglaCompletaDtOs)
        {
            try
            {
              _reglaNegocio.GrabarPromocionesCompleta(_ensambladorEntidadDtOs.CreaReglaCompletaDtOs(reglaCompletaDtOs));
           }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Actualizar promociones
        /// </summary>
        /// <param name="reglaCompletaDtOs"></param>
        public void ActualizarPromocionesCompleta(ReglaCompletaDTOs reglaCompletaDtOs)
        {
            try
            {
                _reglaNegocio.ActualizarPromocionesCompleta(_ensambladorEntidadDtOs.CreaReglaCompletaDtOs(reglaCompletaDtOs));
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Obtiene las promociones
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>

        public List<ReglaCompletaDTOs> ObtenerPromociones(int puntoVentaId)
        {
            try
            {
                return _ensambladorModeloDtOs.CreaReglasCompletaDtOs(_reglaNegocio.ObtenerPromociones(puntoVentaId));

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        #endregion
    }
}