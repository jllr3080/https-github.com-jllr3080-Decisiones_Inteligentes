#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.ReglaNegocio.Servicio.Modelo;

#endregion

namespace JLLR.Core.ReglaNegocio.Servicio.DTOs
{
    public class ReglaCompletaDTOs
    {
        /// <summary>
        /// Regla
        /// </summary>
        [DataMember]
        public ReglaModelo Regla { get; set; }

        /// <summary>
        /// Accione reglas
        /// </summary>
        [DataMember]
        public List<AccionReglaModelo> AccionReglas { get; set; }
    }


}