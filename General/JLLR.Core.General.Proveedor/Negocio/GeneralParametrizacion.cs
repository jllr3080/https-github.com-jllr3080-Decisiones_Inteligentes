#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.General.Proveedor.DAOs;
#endregion
namespace JLLR.Core.General.Proveedor.Negocio
{
    /// <summary>
    /// Todos los  metodos  de parametrizacion de la pantalla
    /// </summary>
    public class GeneralParametrizacion
    {
        #region DECLARACION E INSTANCIAS
        private readonly ColorDAOs _colorDaOs = new ColorDAOs();
        private readonly MarcaDAOs _marcaDaOs = new MarcaDAOs();
        private readonly MaterialDAOs _materialDaOs = new MaterialDAOs();
        private readonly TipoLavadoDAOs _tipoLavadoDaOs = new TipoLavadoDAOs();
        private readonly  CiudadDAOs _ciudadDaOs= new CiudadDAOs();
        private readonly  EstadoPagoDAOs _estadoPagoDaOs= new EstadoPagoDAOs();
        private readonly  PaisDAOs _paisDaOs= new PaisDAOs();
        private readonly  EstadoDAOs _estadoDaOs= new EstadoDAOs();
        private  readonly  TipoCorreoElectronicoDAOs _tipoCorreoElectronicoDaOs= new TipoCorreoElectronicoDAOs();
        private readonly  TipoDireccionDAOs _tipoDireccionDaOs= new TipoDireccionDAOs();
        private readonly  TipoGeneroDAOs _tipoGeneroDaOs= new TipoGeneroDAOs();
        private readonly  TipoIdentificacionDAOs _tipoIdentificacionDaOs= new TipoIdentificacionDAOs();
        private readonly  TipoRolIndividuoDAOs _tipoRolIndividuoDaOs=  new TipoRolIndividuoDAOs();
        private readonly  TipoTelefonoDAOs _tipoTelefonoDaOs= new TipoTelefonoDAOs();
        private readonly  EtapaProcesoDAOs _etapaProcesoDaOs= new EtapaProcesoDAOs();
        private readonly  PuntoVentaDAOs _puntoVentaDaOs= new PuntoVentaDAOs();
        


        #endregion

        #region COLOR
        /// <summary>
        /// Obtiene los  colores de las prendas
        /// </summary>
        /// <returns></returns>
        public IQueryable<COLOR> ObetenerColores()
        {
            try
            {
                return _colorDaOs.ObetenerColores();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region MARCA

        /// <summary>
        /// Obtiene las marcas de las prendas
        /// </summary>
        /// <returns></returns>
        public IQueryable<MARCA> ObtenerMarcas()
        {
            try
            {
                return _marcaDaOs.ObtenerMarcas();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region MATERIAL
        /// <summary>
        /// Obtiene los materiales  de los porductos 
        /// </summary>
        /// <returns></returns>
        public IQueryable<MATERIAL> ObtenerMateriales()
        {
            try
            {
                return _materialDaOs.ObtenerMateriales();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region TIPO LAVADO
        /// <summary>
        /// Obtener  de tipos de lavado
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_LAVADO> ObtenerTiposLavado()
        {
            try
            {
              return _tipoLavadoDaOs.ObtenerTiposLavado();


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region CIUDAD
        /// <summary>
        /// Obtener  ciudades
        /// </summary>
        /// <returns></returns>
        public IQueryable<CIUDAD> ObtenerCiudadPorPaisIdYEstadoId(int paisId, int estadoId)
        {
            try
            {
                return _ciudadDaOs.ObtenerCiudadPorPaisIdYEstadoId(paisId, estadoId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  ESTADO PAGO
        /// <summary>
        /// Obtener  de estados de pago
        /// </summary>
        /// <returns></returns>
        public IQueryable<ESTADO_PAGO> ObtenerEstadosPago()
        {
            try
            {
                return _estadoPagoDaOs.ObtenerEstadosPago();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  PAIS

        /// <summary>
        /// Obtener  Paises
        /// </summary>
        /// <returns></returns>
        public IQueryable<PAIS> ObtenerPaises()
        {
            try
            {
                return _paisDaOs.ObtenerPaises();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  ESTADO
        /// <summary>
        /// Obtener  estados por  el codigo del pais
        /// </summary>
        /// <returns></returns>
        public IQueryable<ESTADO> ObtenerEstadoPorPaisId(int paisId)
        {
            try
            {

                return _estadoDaOs.ObtenerEstadoPorPaisId(paisId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  TIPO CORREO ELECTRONICO
        /// <summary>
        /// Obtener tipos de  correo electronico
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_CORREO_ELECTRONICO> ObtenerTiposCorreoElectronico()
        {
            try
            {
                return _tipoCorreoElectronicoDaOs.ObtenerTiposCorreoElectronico();


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  TIPO DIRECCION
        /// <summary>
        /// Obtener  de tipos de direccion
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_DIRECCION> ObtenerTipoDirecciones()
        {
            try
            {

                return _tipoDireccionDaOs.ObtenerTipoDirecciones();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  TIPO GENERO
        /// <summary>
        /// Obtener  de tipos de genero
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_GENERO> ObtenerTipoGeneros()
        {
            try
            {

                return _tipoGeneroDaOs.ObtenerTipoGeneros();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  TIPO IDENTIFICACION
        /// <summary>
        /// Obtener  de tipos de lavado
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_IDENTIFICACION> ObtenerTipoIdentificaciones()
        {
            try
            {
                return _tipoIdentificacionDaOs.ObtenerTipoIdentificaciones();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  TIPO ROL INDIVIDUO
        /// <summary>
        /// Obtener tipos de roles de  individuo
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_ROL_INDIVIDUO> ObtenerTipRolesIndividuo()
        {
            try
            {
                return _tipoRolIndividuoDaOs.ObtenerTipRolesIndividuo();


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region  TIPO TELEFONO
        /// <summary>
        /// Obtener  de tipos de telefono
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_TELEFONO> ObtenerTiposTelefonos()
        {
            try
            {

                return _tipoTelefonoDaOs.ObtenerTiposTelefonos();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region ETAPA DE PROCESO
        /// <summary>
        /// Obtiene la  etapas de proceso por id
        /// </summary>
        /// <param name="etapaProcesoId"></param>
        /// <returns></returns>

        public ETAPA_PROCESO ObtenerEtapaProcesoPorEtapaProcesoId(int etapaProcesoId)
        {
            try
            {
                return _etapaProcesoDaOs.ObtenerEtapaProcesoPorEtapaProcesoId(etapaProcesoId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las etapdas  de proceso
        /// </summary>
        /// <returns></returns>
        public IQueryable<ETAPA_PROCESO> ObtenerEtapasProceso()
        {
            try
            {
                return _etapaProcesoDaOs.ObtenerEtapasProceso();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

        #region PUNTO VENTA
        /// <summary>
        /// Obtiene los puntos de  venta por sucursal Id
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public IQueryable<PUNTO_VENTA> ObtenerPuntosVentaPorSucursalId(int sucursalId)
        {
            try
            {
                return _puntoVentaDaOs.ObtenerPuntosVentaPorSucursalId(sucursalId);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion


    }
}
