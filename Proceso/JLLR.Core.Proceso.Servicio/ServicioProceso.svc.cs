#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Proceso.Servicio.Negocio;

#endregion
namespace JLLR.Core.Proceso.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioProceso : IServicioProceso
    {
        private readonly  ProcesoNegocio _procesoNegocio= new ProcesoNegocio();

        
        /// <summary>
        /// Envia  correo masivos para anulaciones, entrega de cliente  y entrega a  franquicia
        /// </summary>
        public void EnvioCorreoMasivo()
        {
            try
            {
                 _procesoNegocio.EnvioCorreoMasivo();

            }
            catch (Exception)
            {


            }
        }
    }
}
