#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.General;

#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Individuo
{
    public class IndividuoRolVistaModelo
    {
        /// <summary>
        /// IndividuoRolId
        /// </summary>
        
        public int IndividuoRolId { get; set; }

        /// <summary>
        /// Tipo de rol individuo
        /// </summary>
        
        public TipoRolIndividuoVistaModelo TipoRolIndividuo { get; set; }

        /// <summary>
        /// IndividuoId
        /// </summary>
        
        public int? IndividuoId { get; set; }
    }
}
