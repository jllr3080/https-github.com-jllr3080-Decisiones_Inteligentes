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
    /// Metodos de  tipo de  identificacion
    /// </summary>
    public  class TipoIdentificacionDAOs : BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Obtener  de tipos de lavado
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_IDENTIFICACION> ObtenerTipoIdentificaciones()
        {
            try
            {

                var tipoIdentificaciones = from tipoIdentificacion in _entidad.TIPO_IDENTIFICACION
                                           where tipoIdentificacion.POR_DEFECTO==true
                                  select tipoIdentificacion;

                return tipoIdentificaciones.OrderBy(m=>m.DESCRIPCION);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
