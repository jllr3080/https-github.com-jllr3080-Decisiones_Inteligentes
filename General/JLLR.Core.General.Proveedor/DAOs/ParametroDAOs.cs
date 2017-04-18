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
    /// metodos de  los parametros
    /// </summary>
    public  class ParametroDAOs : BaseDAOs
    {
        /// <summary>
        /// dDeclaraciones  e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Obtiene los  parametros por descripcion
        /// </summary>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public PARAMETRO ObtenerParametroPorDescripcion(string descripcion)
        {
            try
            {
                var parametros = from parametro in _entidad.PARAMETRO
                    where parametro.DESCRIPCION == descripcion
                    select parametro;

                return parametros.FirstOrDefault();

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

    }
}

