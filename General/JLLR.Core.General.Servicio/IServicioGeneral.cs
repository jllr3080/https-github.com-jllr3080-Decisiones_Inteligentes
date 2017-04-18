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


        /// <summary>
        /// Graba los colores
        /// </summary>
        /// <param name="color"></param>

        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarColor/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarColor(ColorModelo color);

        /// <summary>
        /// Actualiza el color
        /// </summary>
        /// <param name="color"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizaColor/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizaColor(ColorModelo color);

        /// <summary>
        /// Obtiene los  colores de las prendas
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObetenerTodosColores", ResponseFormat = WebMessageFormat.Json)]
        List<ColorModelo> ObetenerTodosColores();
       
       
        #endregion

        #region MARCA

        /// <summary>
        /// Obtiene las marcas de las prendas
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerMarcas", ResponseFormat = WebMessageFormat.Json)]
        List<MarcaModelo> ObtenerMarcas();

        /// <summary>
        /// Graba las  marcas
        /// </summary>
        /// <param name="marca"></param>

        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarMarca/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarMarca(MarcaModelo marca);

        /// <summary>
        ///  valida si  existe la marca ya  creada
        /// </summary>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ValidarSiExisteMarcaPorDescripcion?descripcion={descripcion}", ResponseFormat = WebMessageFormat.Json)]
        MarcaModelo ValidarSiExisteMarcaPorDescripcion(string descripcion);

        /// <summary>
        /// Actualiza marca
        /// </summary>
        /// <param name="marca"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "ActualizaMarca/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void ActualizaMarca(MarcaModelo marca);

        /// <summary>
        /// Obtiene las marcas de las prendas
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerTodasMarcas", ResponseFormat = WebMessageFormat.Json)]
        List<MarcaModelo> ObtenerTodasMarcas();
       
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

        #region ETAPA DE PROCESO

        /// <summary>
        /// Obtiene la  etapas de proceso por id
        /// </summary>
        /// <param name="etapaProcesoId"></param>
        /// <returns></returns>

        [OperationContract]
        [WebGet(UriTemplate = "ObtenerEtapaProcesoPorEtapaProcesoId?etapaProcesoId={etapaProcesoId}", ResponseFormat = WebMessageFormat.Json)]
        EtapaProcesoModelo ObtenerEtapaProcesoPorEtapaProcesoId(int etapaProcesoId);


        /// <summary>
        /// Obtiene todas las etapdas  de proceso
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerEtapasProceso", ResponseFormat = WebMessageFormat.Json)]

        List<EtapaProcesoModelo> ObtenerEtapasProceso();

        #endregion

        #region PUNTO VENTA

        /// <summary>
        /// Obtiene los puntos de  venta por sucursal Id
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerPuntosVentaPorSucursalId?sucursalId={sucursalId}", ResponseFormat = WebMessageFormat.Json)]
        List<PuntoVentaModelo> ObtenerPuntosVentaPorSucursalId(int sucursalId);

        #endregion


        #region FORMA PAGO

        /// <summary>
        /// Obtiene  todas las   formas  de  pago
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerFormaPagos", ResponseFormat = WebMessageFormat.Json)]
        List<FormaPagoModelo> ObtenerFormaPagos();

        #endregion


        #region PARAMETRO

        /// <summary>
        /// Obtiene los  parametros por descripcion
        /// </summary>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerParametroPorDescripcion?descripcion={descripcion}", ResponseFormat = WebMessageFormat.Json)]
        ParametroModelo ObtenerParametroPorDescripcion(string descripcion);

        #endregion

        #region PARROQUIA

        /// <summary>
        /// Obtiene  todas las parroquias  depenedinedo del pais,provincia y canton
        /// </summary>
        /// <param name="paisId"></param>
        /// <param name="ciudadId"></param>
        /// <param name="estadoId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "ObtenerParroquiasPorVariosParametros?paisId={paisId}&ciudadId={ciudadId}&estadoId={estadoId}",
            ResponseFormat = WebMessageFormat.Json)]
        List<ParroquiaModelo> ObtenerParroquiasPorVariosParametros(int paisId, int ciudadId, int estadoId);

        #endregion

    }


}
