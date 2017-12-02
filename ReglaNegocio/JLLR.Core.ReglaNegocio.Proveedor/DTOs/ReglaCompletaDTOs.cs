
#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.ReglaNegocio.Proveedor.DTOs
{
    public  class ReglaCompletaDTOs
    {

        /// <summary>
        /// Regla
        /// </summary>
        public REGLA Regla { get; set; }

        /// <summary>
        /// Accione reglas
        /// </summary>
        public List<ACCION_REGLA> AccionReglas { get; set; }

    }
}
