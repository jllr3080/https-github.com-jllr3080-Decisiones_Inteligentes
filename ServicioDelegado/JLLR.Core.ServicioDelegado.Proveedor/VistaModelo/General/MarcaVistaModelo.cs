using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.General
{
    public class MarcaVistaModelo
    {

        /// <summary>
        /// Id de la marca del producto
        /// </summary>
      
        public int MarcaId { get; set; }

        /// <summary>
        /// Descripcion 
        /// </summary>
      
        public string Descripcion { get; set; }

        /// <summary>
        /// Esta habilitado 
        /// </summary>
      
        public bool? EstaHabilitado { get; set; }
    }
}
