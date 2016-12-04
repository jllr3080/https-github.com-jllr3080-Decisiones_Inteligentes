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
    /// Metodos de  tipo de  lavados
    /// </summary>
    public class TipoLavadoDAOs : BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Obtener  de tipos de lavado
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_LAVADO> ObtenerTiposLavado()
        {
            try
            {

                var tipoLavados = from tipoLavado in _entidad.TIPO_LAVADO
                                 select tipoLavado;

                return tipoLavados.OrderBy(m=>m.DESCRIPCION);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
             
    }
}
