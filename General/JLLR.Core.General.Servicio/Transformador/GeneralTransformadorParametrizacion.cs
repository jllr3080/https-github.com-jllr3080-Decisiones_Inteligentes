#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.General.Servicio.Ensamblador;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo= JLLR.Core.General.Servicio.Modelo;
using JLLR.Core.General.Proveedor.Negocio;
#endregion
namespace JLLR.Core.General.Servicio.Transformador
{

    /// <summary>
    /// Transformador de  la tablas  de parametrizacion de la capa  general
    /// </summary>
    public class GeneralTransformadorParametrizacion
    {

        #region DECLARACIONES  E INSTANCIAS
        private readonly GeneralParametrizacion _generalParametrizacion= new GeneralParametrizacion();
        private readonly EnsambladorEntidad _ensambladorEntidad = new EnsambladorEntidad();
        private readonly EnsambladorModelo _ensambladorModelo = new EnsambladorModelo();
        #endregion

        #region COLOR
        /// <summary>
        /// Obtiene los  colores de las prendas
        /// </summary>
        /// <returns></returns>
        public List<modelo.ColorModelo> ObetenerColores()
        {
            try
            {
                return _ensambladorModelo.CrearColores(_generalParametrizacion.ObetenerColores());
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
        public List<modelo.MarcaModelo> ObtenerMarcas()
        {
            try
            {
                return _ensambladorModelo.CrearMarcas(_generalParametrizacion.ObtenerMarcas());
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
        public List<modelo.MaterialModelo> ObtenerMateriales()
        {
            try
            {
                return _ensambladorModelo.CrearMateriales(_generalParametrizacion.ObtenerMateriales());
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
        public List<modelo.TipoLavadoModelo> ObtenerTiposLavado()
        {
            try
            {
                return _ensambladorModelo.CrearTiposLavado(_generalParametrizacion.ObtenerTiposLavado());


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
        public List<modelo.CiudadModelo> ObtenerCiudadPorPaisIdYEstadoId(int paisId, int estadoId)
        {
            try
            {
                return _ensambladorModelo.CrearCiudades(_generalParametrizacion.ObtenerCiudadPorPaisIdYEstadoId(paisId,estadoId));
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
        public List<modelo.EstadoPagoModelo> ObtenerEstadosPago()
        {
            try
            {
                return _ensambladorModelo.CrearEstadoPagos(_generalParametrizacion.ObtenerEstadosPago());
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
        public List<modelo.PaisModelo> ObtenerPaises()
        {
            try
            {
                return _ensambladorModelo.CrearPaises(_generalParametrizacion.ObtenerPaises());
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
        public List<modelo.EstadoModelo> ObtenerEstadoPorPaisId(int paisId)
        {
            try
            {

                return _ensambladorModelo.CrearEstados(_generalParametrizacion.ObtenerEstadoPorPaisId(paisId));
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
        public List<modelo.TipoCorreoElectronicoModelo> ObtenerTiposCorreoElectronico()
        {
            try
            {
                return _ensambladorModelo.CrearTipoCorreoElectronicos(_generalParametrizacion.ObtenerTiposCorreoElectronico());


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
        public List<modelo.TipoDireccionModelo> ObtenerTipoDirecciones()
        {
            try
            {
                return _ensambladorModelo.CrearTipoDirecciones(_generalParametrizacion.ObtenerTipoDirecciones());
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
        public List<modelo.TipoGeneroModelo> ObtenerTipoGeneros()
        {
            try
            {
                return _ensambladorModelo.CrearTipoGeneros(_generalParametrizacion.ObtenerTipoGeneros());
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
        public List<modelo.TipoIdentificacionModelo> ObtenerTipoIdentificaciones()
        {
            try
            {
                return _ensambladorModelo.CrearTipoIdentificaciones(_generalParametrizacion.ObtenerTipoIdentificaciones());
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
        public List<modelo.TipoRolIndividuoModelo> ObtenerTipRolesIndividuo()
        {
            try
            {
                return _ensambladorModelo.CrearTipoRolesIndividuo(_generalParametrizacion.ObtenerTipRolesIndividuo());


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
        public List<modelo.TipoTelefonoModelo> ObtenerTiposTelefonos()
        {
            try
            {
                return _ensambladorModelo.CrearTipoTelefonos(_generalParametrizacion.ObtenerTiposTelefonos());
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

        public modelo.EtapaProcesoModelo ObtenerEtapaProcesoPorEtapaProcesoId(int etapaProcesoId)
        {
            try
            {
                return
                    _ensambladorModelo.CrearEtapaProceso(
                        _generalParametrizacion.ObtenerEtapaProcesoPorEtapaProcesoId(etapaProcesoId));
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
        public List<modelo.EtapaProcesoModelo> ObtenerEtapasProceso()
        {
            try
            {
                return _ensambladorModelo.CrearEtapasProceso(_generalParametrizacion.ObtenerEtapasProceso());
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
        public List<modelo.PuntoVentaModelo> ObtenerPuntosVentaPorSucursalId(int sucursalId)
        {
            try
            {
                return
                    _ensambladorModelo.CrearPuntosVenta(
                        _generalParametrizacion.ObtenerPuntosVentaPorSucursalId(sucursalId));

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}