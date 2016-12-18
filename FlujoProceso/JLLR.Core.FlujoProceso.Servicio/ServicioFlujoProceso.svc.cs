using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.FlujoProceso.Servicio.Modelo;
using JLLR.Core.FlujoProceso.Servicio.Transformador;

namespace JLLR.Core.FlujoProceso.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioFlujoProceso : IServicioFlujoProceso
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly FlujoProcesoTransformadorNegocio _flujoProcesoTransformadorNegocio= new FlujoProcesoTransformadorNegocio();
        #endregion

        #region HISTORIAL PROCESO
        /// <summary>
        /// Graba el  historial del proceso
        /// </summary>
        public void GrabarHistorialProceso(HistorialProcesoModelo historialProceso)
        {
            try
            {
                _flujoProcesoTransformadorNegocio.GrabarHistorialProceso(historialProceso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtener el historial del proceso por numero  de orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <returns></returns>
        public List<HistorialProcesoModelo> ObtenerHIstorialProcesosPorNumeroOrden(string numeroOrden)
        {
            try
            {
                return _flujoProcesoTransformadorNegocio.ObtenerHIstorialProcesosPorNumeroOrden(numeroOrden);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
