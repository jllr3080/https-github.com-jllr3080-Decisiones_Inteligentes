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
    /// Metodos de  tipo de direccion
    /// </summary>
    public class TipoDireccionDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Obtener  de tipos de direccion
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_DIRECCION> ObtenerTipoDirecciones()
        {
            try
            {

                var tipoDirecciones = from tipoDireccion in _entidad.TIPO_DIRECCION
                                      select tipoDireccion;

                return tipoDirecciones.OrderBy(m => m.DESCRIPCION);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
