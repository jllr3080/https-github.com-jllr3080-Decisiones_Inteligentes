#region using
using System;
using System.Linq;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.General.Proveedor.DAOs
{
    /// <summary>
    /// Metodos de  tipo de  rol  de individuo 
    /// </summary>
    public   class TipoRolIndividuoDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Obtener tipos de roles de  individuo
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_ROL_INDIVIDUO> ObtenerTipRolesIndividuo()
        {
            try
            {
                var tipoRolesIndividuo = from tipoRoleIndividuo in _entidad.TIPO_ROL_INDIVIDUO
                                         select tipoRoleIndividuo;

                return tipoRolesIndividuo.OrderBy(m => m.DESCRIPCION);


            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
