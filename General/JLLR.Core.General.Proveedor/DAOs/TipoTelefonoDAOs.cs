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
    /// Metodos de  tipo de  telefono
    /// </summary>
    public class TipoTelefonoDAOs : BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Obtener  de tipos de telefono
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_TELEFONO> ObtenerTiposTelefonos()
        {
            try
            {

                var tipoTelefonos = from tipoTelefono in _entidad.TIPO_TELEFONO
                                  select tipoTelefono;

                return tipoTelefonos.OrderBy(m=>m.DESCRIPCION);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
