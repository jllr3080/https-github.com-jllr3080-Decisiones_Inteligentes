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
    /// Parroquias
    /// </summary>
    public class ParroquiaDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
         private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();

        /// <summary>
        /// Obtiene  todas las parroquias  depenedinedo del pais,provincia y canton
        /// </summary>
        /// <param name="paisId"></param>
        /// <param name="ciudadId"></param>
        /// <param name="estadoId"></param>
        /// <returns></returns>
        public IQueryable<PARROQUIA> ObtenerParroquiasPorVariosParametros(int paisId, int ciudadId, int estadoId)
        {
            try
            {
                var parroquias = from parroquia in _entidad.PARROQUIA
                    where parroquia.PAIS_ID == paisId && parroquia.ESTADO_ID == estadoId && parroquia.CIUDAD_ID == ciudadId
                    select parroquia;

                return parroquias.OrderBy(m => m.DESCRIPCION);

            }
            catch (Exception ex)
            {
                
                throw;
            }
            
        }
    }
}
