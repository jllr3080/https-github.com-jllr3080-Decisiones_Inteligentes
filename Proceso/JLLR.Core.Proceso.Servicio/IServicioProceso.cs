#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
#endregion
namespace JLLR.Core.Proceso.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioProceso
    {


        /// <summary>
        /// Envia  correo masivos para anulaciones, entrega de cliente  y entrega a  franquicia
        /// </summary>
        [OperationContract]
        [WebGet(UriTemplate = "EnvioCorreoMasivo", ResponseFormat = WebMessageFormat.Json)]

        void EnvioCorreoMasivo();
    }


   
}
