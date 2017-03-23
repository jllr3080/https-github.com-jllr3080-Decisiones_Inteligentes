#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace JLLR.Core.Individuo.Servicio.Modelo
{
    /// <summary>
    /// modelo del  vendedor
    /// </summary>
    public class VendedorModelo
    {
        /// <summary>
        /// Vendedor id
        /// </summary>
        public int VendedorId { get; set; }

        /// <summary>
        /// EsEmpleado
        /// </summary>
        public bool EsEmpleado{ get; set; }

        /// <summary>
        /// Habilitado
        /// </summary>
        public bool Habilitado { get; set; }

        /// <summary>
        /// Individuo
        /// </summary>
        public IndividuoModelo Individuo{ get; set; }
    }
}