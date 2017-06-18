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
    public class EntregaUrgenciaDAOs:BaseDAOs
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();

        /// <summary>
        /// Entrega  urgencia
        /// </summary>
        /// <returns></returns>
        public IQueryable<ENTREGA_URGENCIA> ObtenerEntregaUrgencias()
        {
            try
            {
                var entregaUrgencias = from entregaUrgencia in _entidad.ENTREGA_URGENCIA
                    select entregaUrgencia;

                return entregaUrgencias.OrderBy(m => m.DESCRIPCION);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
