#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.General.Proveedor.DAOs
{
    /// <summary>
    /// Metodos de la etapa de proceso de perfil
    /// </summary>
    public class EtapaProcesoPerfilDAOs
    {

        /// <summary>
        /// Declaracion e   instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Obtiene  las etapas de proceso por  perfil
        /// </summary>
        /// <param name="perfilId"></param>
        /// <returns></returns>
        public IQueryable<ETAPA_PROCESO_PERFIL> ObtenerEtapaProcesoPerfilesPorPerfilId(int perfilId)
        {
            try
            {
                var etapasProcesoPerfil = from etapaProcesoPerfil in _entidad.ETAPA_PROCESO_PERFIL
                    where etapaProcesoPerfil.PERFIL_ID == perfilId
                    select etapaProcesoPerfil;

                return etapasProcesoPerfil;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Obtiene  las etapas de proceso por  perfil
        /// </summary>
        /// <param name="perfilId"></param>
        /// <returns></returns>
        public IQueryable<ETAPA_PROCESO_PERFIL> ObtenerEtapaProcesosPerfiles()
        {
            try
            {
                var etapasProcesoPerfil = from etapaProcesoPerfil in _entidad.ETAPA_PROCESO_PERFIL
                    select etapaProcesoPerfil;
                                          

                return etapasProcesoPerfil;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
