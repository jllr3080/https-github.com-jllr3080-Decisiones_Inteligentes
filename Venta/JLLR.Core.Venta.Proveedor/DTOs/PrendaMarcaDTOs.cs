#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace JLLR.Core.Venta.Proveedor.DTOs
{

    public class PrendaMarcaDTOs
    {
        /// <summary>
        /// NumeroOrden
        /// </summary>
        public string NumeroOrden { get; set; }

        /// <summary>
        /// FechaIngreso
        /// </summary>
        public DateTime? FechaIngreso{ get; set; }

        /// <summary>
        /// NombrePrenda
        /// </summary>
        public string  NombrePrenda{ get; set; }

        /// <summary>
        /// NombreSucursal
        /// </summary>
        public string NombreSucursal { get; set; }

        /// <summary>
        /// Nombre Marca
        /// </summary>
        public string NombreMarca { get; set; }
    }

}

