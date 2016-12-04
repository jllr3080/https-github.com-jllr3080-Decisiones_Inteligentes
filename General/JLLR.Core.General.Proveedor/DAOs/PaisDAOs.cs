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
    /// Metodos de  Paises
    /// </summary>
    public class PaisDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Obtener  Paises
        /// </summary>
        /// <returns></returns>
        public IQueryable<PAIS> ObtenerPaises()
        {
            try
            {

                var paises = from pais in _entidad.PAIS
                                  select pais;

                return paises.OrderBy(m => m.DESCRIPCION);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
