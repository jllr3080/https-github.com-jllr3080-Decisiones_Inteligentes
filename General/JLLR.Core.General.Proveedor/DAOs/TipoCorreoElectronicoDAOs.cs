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
    /// Metodos de  tipo de correo electronico
    /// </summary>
    public class TipoCorreoElectronicoDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Obtener tipos de  correo electronico
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_CORREO_ELECTRONICO> ObtenerTiposCorreoElectronico()
        {
            try
            {
                var tiposCorreoElectronico = from tipoCorreoElectronico in _entidad.TIPO_CORREO_ELECTRONICO
                    select tipoCorreoElectronico;

                return tiposCorreoElectronico.OrderBy(m => m.DESCRIPCION);


            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
