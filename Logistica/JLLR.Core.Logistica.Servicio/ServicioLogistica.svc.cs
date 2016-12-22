#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Logistica.Servicio.DTOs;
using JLLR.Core.Logistica.Servicio.Modelo;
using JLLR.Core.Logistica.Servicio.Transformador;

#endregion

namespace JLLR.Core.Logistica.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioLogistica : IServicioLogistica
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly  LogisticaTransformadorNegocio _logisticaTransformadorNegocio= new LogisticaTransformadorNegocio();
        #endregion

        #region TRANSACCIONAL
        /// <summary>
        /// Graba la cuenta por pagar  
        /// </summary>
        /// <param name="cuentaPorCobrarDtOs"></param>
        /// <returns></returns>
        public EntregaOrdenTrabajoModelo GrabarCuentaPorCobrarCompleta(EntregaOrdenTrabajoDTOs entregaOrdenTrabajoDtOs)
        {
            try
            {
                return _logisticaTransformadorNegocio.GrabarCuentaPorCobrarCompleta(entregaOrdenTrabajoDtOs);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion


    }
}
