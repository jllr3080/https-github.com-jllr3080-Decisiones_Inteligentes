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
    /// Metodos de  tipod e reproceso
    /// </summary>
    public class TipoReprocesoDAOs:BaseDAOs
    {

        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Obtiene los tipos de  reproceso
        /// </summary>
        /// <returns></returns>
        public IQueryable<TIPO_REPROCESO> ObtenerTipoReprocesos()
        {
            try
            {
                var tipoReprocesos = from tipoReproceso in _entidad.TIPO_REPROCESO
                                     where tipoReproceso.ESTA_HABILITADO==true
                                     select tipoReproceso;


                return tipoReprocesos.OrderBy(m => m.DESCRIPCION);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
