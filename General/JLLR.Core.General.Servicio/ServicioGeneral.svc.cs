﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.General.Servicio.Modelo;
using JLLR.Core.General.Servicio.Transformador;
#endregion

namespace JLLR.Core.General.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioGeneral : IServicioGeneral
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly GeneralTransformadorParametrizacion _generalTransformadorParametrizacion = new GeneralTransformadorParametrizacion();
        #endregion

        #region COLOR
        /// <summary>
        /// Obtiene los  colores de las prendas
        /// </summary>
        /// <returns></returns>
        public List<ColorModelo> ObetenerColores()
        {
            try
            {
                return _generalTransformadorParametrizacion.ObetenerColores();
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
        public List<MarcaModelo> ObtenerMarcas()
        {
            try
            {
                return _generalTransformadorParametrizacion.ObtenerMarcas();
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
        public List<MaterialModelo> ObtenerMateriales()
        {
            try
            {
                return _generalTransformadorParametrizacion.ObtenerMateriales();
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
        public List<TipoLavadoModelo> ObtenerTiposLavado()
        {
            try
            {
                return _generalTransformadorParametrizacion.ObtenerTiposLavado();


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
        public List<CiudadModelo> ObtenerCiudadPorPaisIdYEstadoId(int paisId, int estadoId)
        {
            try
            {
                return _generalTransformadorParametrizacion.ObtenerCiudadPorPaisIdYEstadoId(paisId,estadoId);
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
        public List<EstadoPagoModelo> ObtenerEstadosPago()
        {
            try
            {
                return _generalTransformadorParametrizacion.ObtenerEstadosPago();
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
        public List<PaisModelo> ObtenerPaises()
        {
            try
            {
                return _generalTransformadorParametrizacion.ObtenerPaises();
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
        public List<EstadoModelo> ObtenerEstadoPorPaisId(int paisId)
        {
            try
            {

                return _generalTransformadorParametrizacion.ObtenerEstadoPorPaisId(paisId);
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
        public List<TipoCorreoElectronicoModelo> ObtenerTiposCorreoElectronico()
        {
            try
            {
                return _generalTransformadorParametrizacion.ObtenerTiposCorreoElectronico();


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
        public List<TipoDireccionModelo> ObtenerTipoDirecciones()
        {
            try
            {
                return _generalTransformadorParametrizacion.ObtenerTipoDirecciones();
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
        public List<TipoGeneroModelo> ObtenerTipoGeneros()
        {
            try
            {
                return _generalTransformadorParametrizacion.ObtenerTipoGeneros();
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
        public List<TipoIdentificacionModelo> ObtenerTipoIdentificaciones()
        {
            try
            {
                return _generalTransformadorParametrizacion.ObtenerTipoIdentificaciones();
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
        public List<TipoRolIndividuoModelo> ObtenerTipRolesIndividuo()
        {
            try
            {
                return _generalTransformadorParametrizacion.ObtenerTipRolesIndividuo();


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
        public List<TipoTelefonoModelo> ObtenerTiposTelefonos()
        {
            try
            {
                return _generalTransformadorParametrizacion.ObtenerTiposTelefonos();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}