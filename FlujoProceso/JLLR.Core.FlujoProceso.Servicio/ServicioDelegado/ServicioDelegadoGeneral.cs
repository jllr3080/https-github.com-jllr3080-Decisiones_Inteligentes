#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using  modeloGeneral=JLLR.Core.General.Servicio.Modelo;
#endregion

namespace JLLR.Core.FlujoProceso.Servicio.ServicioDelegado
{
    public class ServicioDelegadoGeneral
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private static string direccionUrl = "http://localhost/Decisiones_Inteligentes_General/ServicioGeneral.svc/";


        #region ETAPA PROCESO
        #region ETAPA DE PROCESO
        /// <summary>
        /// Obtiene la  etapas de proceso por id
        /// </summary>
        /// <param name="etapaProcesoId"></param>
        /// <returns></returns>

        public modeloGeneral.EtapaProcesoModelo ObtenerEtapaProcesoPorEtapaProcesoId(int etapaProcesoId)
        {
            try
            {
                try
                {
                    var clienteWeb = new WebClient();
                    var json = clienteWeb.DownloadString(direccionUrl + "ObtenerEtapaProcesoPorEtapaProcesoId?etapaProcesoId="+ etapaProcesoId);
                    var js = new JavaScriptSerializer();
                    return js.Deserialize<modeloGeneral.EtapaProcesoModelo>(json);
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
        #endregion
    }
}