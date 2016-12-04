#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Seguridad.Servicio.DTOs;
#endregion

namespace JLLR.Core.Seguridad.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioSeguridad
    {
        #region TRANSACCIONAL

        /// <summary>
        /// Ingresa al sistema 
        /// </summary>
        /// <param name="nombreusuario"></param>
        /// <param name="claveUsuario"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        [OperationContract]
        [WebGet(UriTemplate = "IngresoSistema?nombreusuario={nombreusuario}&claveUsuario={claveUsuario}&puntoVentaId={puntoVentaId}&sucursalId={sucursalId}", ResponseFormat = WebMessageFormat.Json)]
        UsuarioDTOs IngresoSistema(string nombreusuario, string claveUsuario, int puntoVentaId, int sucursalId);


        /// <summary>
        /// Genera el menu  de acuerdo al usuario  revisa  el perfil
        /// </summary>
        /// <param name="usuarioId"></param>
        [OperationContract]
        [WebGet(UriTemplate = "GenerarMenu?usuarioId={usuarioId}", ResponseFormat = WebMessageFormat.Json)]
        List<AccesoDTOs> GenerarMenu(int usuarioId);

        #endregion


    }


    
}
