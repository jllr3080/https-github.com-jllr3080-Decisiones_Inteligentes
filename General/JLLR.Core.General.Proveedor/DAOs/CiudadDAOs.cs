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
    /// Metodos de la ciudad
    /// </summary>
    public class CiudadDAOs:BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Obtener  ciudades
        /// </summary>
        /// <returns></returns>
        public IQueryable<CIUDAD> ObtenerCiudadPorPaisIdYEstadoId(int paisId, int estadoId)
        {
            try
            {

                var ciudades = from ciudad in _entidad.CIUDAD
                              where ciudad.PAIS_ID == paisId && ciudad.ESTADO_ID==estadoId
                               select ciudad;

                return ciudades.OrderBy(m => m.DESCRIPCION);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
