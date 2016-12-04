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
    /// Metodos  de tipo de  genero
    /// </summary>
    public class TipoGeneroDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Obtener  de tipos de genero
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_GENERO> ObtenerTipoGeneros()
        {
            try
            {

                var tipoGeneros = from tipoGenero in _entidad.TIPO_GENERO
                                           select tipoGenero;

                return tipoGeneros.OrderBy(m => m.DESCRIPCION);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
