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
    /// Metodos  de  la tabla de materiales
    /// </summary>
    public class MaterialDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Obtiene los materiales  de los porductos 
        /// </summary>
        /// <returns></returns>
        public IQueryable<MATERIAL> ObtenerMateriales()
        {
            try
            {

                var materiales = from material in _entidad.MATERIAL
                                 select material;

                return materiales;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
