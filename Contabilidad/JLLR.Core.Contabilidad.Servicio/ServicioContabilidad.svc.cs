#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Contabilidad.Servicio.DTOs;
using JLLR.Core.Contabilidad.Servicio.Modelo;
using JLLR.Core.Contabilidad.Servicio.Transformador;

#endregion

namespace JLLR.Core.Contabilidad.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioContabilidad : IServicioContabilidad
    {
        #region  DECLARACIONES  E INSTANCIAS
        private readonly ContabilidadTransformadorNegocio _contabilidadTransformadorNegocio = new ContabilidadTransformadorNegocio();
        #endregion

        #region TRANSACCIONAL
        /// <summary>
        /// Graba la cuenta por pagar  
        /// </summary>
        /// <param name="cuentaPorCobrarDtOs"></param>
        /// <returns></returns>
        public CuentaPorCobrarModelo GrabarCuentaPorCobrarCompleta(CuentaPorCobrarDTOs cuentaPorCobrarDtOs)
        {
            try
            {
                return _contabilidadTransformadorNegocio.GrabarCuentaPorCobrarCompleta(cuentaPorCobrarDtOs);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
