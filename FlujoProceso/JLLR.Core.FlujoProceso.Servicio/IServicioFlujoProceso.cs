using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.FlujoProceso.Servicio.Modelo;

namespace JLLR.Core.FlujoProceso.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioFlujoProceso
    {

        #region HISTORIAL PROCESO

        /// <summary>
        /// Graba el  historial del proceso
        /// </summary>
        [OperationContract]
        [WebInvoke(UriTemplate = "GrabarHistorialProceso/*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        void GrabarHistorialProceso(HistorialProcesoModelo historialProceso);


        /// <summary>
        /// Obtener el historial del proceso por numero  de orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(
           UriTemplate =
               "ObtenerHIstorialProcesosPorNumeroOrden?numeroOrden={numeroOrden}",
           ResponseFormat = WebMessageFormat.Json)]
        List<HistorialProcesoModelo> ObtenerHIstorialProcesosPorNumeroOrden(string numeroOrden);

        #endregion
    }


    
    
}
