#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using Web.DTOs.Individuo;
using Web.Models.General;

#endregion

namespace Web.ServicioDelegado
{
    public class ServicioDelegadoGeneral
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_General/ServicioGeneral.svc/";
        
        #region COLOR
        /// <summary>
        /// Obtiene los  colores de las prendas
        /// </summary>
        /// <returns></returns>
        public List<ColorVistaModelo> ObetenerColores()
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObetenerColores");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ColorVistaModelo>>(json);
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
        public List<MarcaVistaModelo> ObtenerMarcas()
        {
            try
            {
                try
                {
                    var clienteWeb = new WebClient();
                    var json = clienteWeb.DownloadString(direccionUrl + "ObtenerMarcas");
                    var js = new JavaScriptSerializer();
                    return js.Deserialize<List<MarcaVistaModelo>>(json);
                }
                catch (Exception ex)
                {

                    throw;
                }
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
        public List<MaterialVistaModelo> ObtenerMateriales()
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerMateriales");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<MaterialVistaModelo>>(json);
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
        public List<TipoLavadoVistaModelo> ObtenerTiposLavado()
        {
            try
            {
                    var clienteWeb = new WebClient();
                    var json = clienteWeb.DownloadString(direccionUrl + "ObtenerTiposLavado");
                    var js = new JavaScriptSerializer();
                    return js.Deserialize<List<TipoLavadoVistaModelo>>(json);
               
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
        public List<CiudadVistaModelo> ObtenerCiudadPorPaisIdYEstadoId(int paisId, int estadoId)
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerCiudadPorPaisIdYEstadoId?paisId="+ paisId + "&estadoId="+ estadoId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<CiudadVistaModelo>>(json);

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
        public List<EstadoPagoVistaModelo> ObtenerEstadosPago()
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerEstadosPago");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<EstadoPagoVistaModelo>>(json);

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
        public List<PaisVistaModelo> ObtenerPaises()
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerPaises");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<PaisVistaModelo>>(json);
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
        public List<EstadoVistaModelo> ObtenerEstadoPorPaisId(int paisId)
        {
            try
            {

                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerEstadoPorPaisId?paisId="+  paisId);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<EstadoVistaModelo>>(json);
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
        public List<TipoCorreoElectronicoVistaModelo> ObtenerTiposCorreoElectronico()
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerTiposCorreoElectronico");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<TipoCorreoElectronicoVistaModelo>>(json);


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
        public List<TipoDireccionVistaModelo> ObtenerTipoDirecciones()
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerTipoDirecciones");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<TipoDireccionVistaModelo>>(json);
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
        public List<TipoGeneroVistaModelo> ObtenerTipoGeneros()
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerTipoGeneros");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<TipoGeneroVistaModelo>>(json);
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
        public List<TipoIdentificacionVistaModelo> ObtenerTipoIdentificaciones()
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerTipoIdentificaciones");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<TipoIdentificacionVistaModelo>>(json);
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
        public List<TipoRolIndividuoVistaModelo> ObtenerTipRolesIndividuo()
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerTipRolesIndividuo");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<TipoRolIndividuoVistaModelo>>(json);

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
        public List<TipoTelefonoVistaModelo> ObtenerTiposTelefonos()
        {
            try
            {
                var clienteWeb = new WebClient();
                var json = clienteWeb.DownloadString(direccionUrl + "ObtenerTiposTelefonos");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<TipoTelefonoVistaModelo>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}