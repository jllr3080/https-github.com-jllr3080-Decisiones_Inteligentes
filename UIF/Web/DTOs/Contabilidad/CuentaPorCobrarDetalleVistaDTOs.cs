using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.DTOs.Contabilidad
{
    public class CuentaPorCobrarDetalleVistaDTOs
    {


        /// <summary>
        /// Cliente
        /// </summary>
        public string NumeroOrden { get; set; }

        /// <summary>
        /// Cliente
        /// </summary>
        public string Cliente { get; set; }

        /// <summary>
        /// Direccion
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// NumeroTelefonos
        /// </summary>
        public string NumeroTelefonos { get; set; }



        /// <summary>
        /// IndividuoId
        /// </summary>
        public int? IndividuoId { get; set; }

        /// <summary>
        /// Saldo
        /// </summary>

        public decimal? Saldo { get; set; }

        /// <summary>
        /// Valor
        /// </summary>

        public decimal? Valor { get; set; }


    }
}