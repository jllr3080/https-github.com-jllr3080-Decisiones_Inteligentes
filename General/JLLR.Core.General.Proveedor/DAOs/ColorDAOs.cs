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
    /// Metodos de  color
    /// </summary>
    public class ColorDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Obtiene los  colores de las prendas
        /// </summary>
        /// <returns></returns>
        public IQueryable<COLOR> ObetenerColores()
        {
            try
            {
                var colores = from color in _entidad.COLOR
                              select color;

                return colores.OrderBy(m => m.DESCRIPCION);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
