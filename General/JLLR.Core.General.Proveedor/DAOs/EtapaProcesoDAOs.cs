#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
#endregion
namespace JLLR.Core.General.Proveedor.DAOs
{
    /// <summary>
    /// Metodos  de  las etapas d e pro
    /// </summary>
    public class EtapaProcesoDAOs: BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Obtiene todas las etapdas  de proceso
        /// </summary>
        /// <returns></returns>
        public IQueryable<ETAPA_PROCESO> ObtenerEtapasProceso()
        {
            try
            {
                var etapasProceso=  from  etapaProceso in  _entidad.ETAPA_PROCESO
                                    select etapaProceso;
                return etapasProceso;
            }
            catch(Exception ex)
            {
                throw ;
            }

        }

    }
}
