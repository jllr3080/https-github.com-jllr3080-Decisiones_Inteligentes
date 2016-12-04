#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.General.Servicio.Modelo;
#endregion

namespace JLLR.Core.General.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioGeneral
    {

        #region COLOR

        /// <summary>
        /// Obtiene los  colores de las prendas
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObetenerColores", ResponseFormat = WebMessageFormat.Json)]
        List<ColorModelo> ObetenerColores();

        #endregion

        #region MARCA

        /// <summary>
        /// Obtiene las marcas de las prendas
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerMarcas", ResponseFormat = WebMessageFormat.Json)]
        List<MarcaModelo> ObtenerMarcas();

        #endregion

        #region MATERIAL

        /// <summary>
        /// Obtiene los materiales  de los porductos 
        /// </summary>
        /// <returns></returns>

        [OperationContract]
        [WebGet(UriTemplate = "ObtenerMateriales", ResponseFormat = WebMessageFormat.Json)]
        List<MaterialModelo> ObtenerMateriales();

        #endregion

        #region TIPO LAVADO

        /// <summary>
        /// Obtener  de tipos de lavado
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerTiposLavado", ResponseFormat = WebMessageFormat.Json)]
        List<TipoLavadoModelo> ObtenerTiposLavado();

        #endregion

        #region CIUDAD

        /// <summary>
        /// Obtener  ciudades
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerCiudadPorPaisIdYEstadoId?paisId={paisId}&estadoId={estadoId}",
             ResponseFormat = WebMessageFormat.Json)]
        List<CiudadModelo> ObtenerCiudadPorPaisIdYEstadoId(int paisId, int estadoId);

        #endregion

        #region  ESTADO PAGO

        /// <summary>
        /// Obtener  de estados de pago
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerEstadosPago", ResponseFormat = WebMessageFormat.Json)]
        List<EstadoPagoModelo> ObtenerEstadosPago();

        #endregion

        #region  PAIS

        /// <summary>
        /// Obtener  Paises
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerPaises", ResponseFormat = WebMessageFormat.Json)]
        List<PaisModelo> ObtenerPaises();

        #endregion

        #region  ESTADO

        /// <summary>
        /// Obtener  estados por  el codigo del pais
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerEstadoPorPaisId?paisId={paisId}", ResponseFormat = WebMessageFormat.Json)]
        List<EstadoModelo> ObtenerEstadoPorPaisId(int paisId);

        #endregion

        #region  TIPO CORREO ELECTRONICO

        /// <summary>
        /// Obtener tipos de  correo electronico
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerTiposCorreoElectronico", ResponseFormat = WebMessageFormat.Json)]
        List<TipoCorreoElectronicoModelo> ObtenerTiposCorreoElectronico();

        #endregion

        #region  TIPO DIRECCION

        /// <summary>
        /// Obtener  de tipos de direccion
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerTipoDirecciones", ResponseFormat = WebMessageFormat.Json)]
        List<TipoDireccionModelo> ObtenerTipoDirecciones();

        #endregion

        #region  TIPO GENERO

        /// <summary>
        /// Obtener  de tipos de genero
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerTipoGeneros", ResponseFormat = WebMessageFormat.Json)]
        List<TipoGeneroModelo> ObtenerTipoGeneros();

        #endregion

        #region  TIPO IDENTIFICACION

        /// <summary>
        /// Obtener  de tipos de lavado
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerTipoIdentificaciones", ResponseFormat = WebMessageFormat.Json)]
        List<TipoIdentificacionModelo> ObtenerTipoIdentificaciones();

        #endregion

        #region  TIPO ROL INDIVIDUO

        /// <summary>
        /// Obtener tipos de roles de  individuo
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerTipRolesIndividuo", ResponseFormat = WebMessageFormat.Json)]
        List<TipoRolIndividuoModelo> ObtenerTipRolesIndividuo();

        #endregion

        #region  TIPO TELEFONO

        /// <summary>
        /// Obtener  de tipos de telefono
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerTiposTelefonos", ResponseFormat = WebMessageFormat.Json)]
        List<TipoTelefonoModelo> ObtenerTiposTelefonos();

        #endregion
    }


}
