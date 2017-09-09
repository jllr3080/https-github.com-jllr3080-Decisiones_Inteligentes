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
    public class MesDAOs:BaseDAOs
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();



        /// <summary>
        /// Obtiene los meses de  cierre
        /// </summary>
        /// <returns></returns>
        public IQueryable<MES> ObtenerMeses()
        {
            try
            {
                var meses = from mes in _entidad.MES
                    select mes;

                return meses.OrderBy(m=>m.DESCRIPCION);

            }
            catch (Exception)
            {
                    
                throw;
            }
        }

    }
}
