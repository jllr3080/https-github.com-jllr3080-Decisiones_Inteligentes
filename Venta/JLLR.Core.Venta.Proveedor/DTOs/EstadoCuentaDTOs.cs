﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace JLLR.Core.Venta.Proveedor.DTOs
{
    /// <summary>
    /// Estado de  cuenta 
    /// </summary>
    public class EstadoCuentaDTOs
    {
        /// <summary>
        /// Numero de Orden
        /// </summary>
        public string NumeroOrden { get; set; }

        /// <summary>
        /// Fecha de  Ingreso
        /// </summary>
        public DateTime? FechaIngreso { get; set; }

        /// <summary>
        /// Fecha de  Ingreso
        /// </summary>
        public decimal? ValorTotal{ get; set; }


        /// <summary>
        /// ValorFranquicia
        /// </summary>
        public decimal? ValorFranquicia { get; set; }

        /// <summary>
        /// ValorQuimica
        /// </summary>
        public decimal? ValorQuimica { get; set; }

        /// <summary>
        /// ValorIndustriales
        /// </summary>
        public decimal? ValorIndustriales{ get; set; }

        /// <summary>
        /// Fecha de  Ingreso
        /// </summary>
        public int? NumeroPrenda{ get; set; }

        /// <summary>
        /// Detalle
        /// </summary>
        public string Detalle{ get; set; }
    }

}
