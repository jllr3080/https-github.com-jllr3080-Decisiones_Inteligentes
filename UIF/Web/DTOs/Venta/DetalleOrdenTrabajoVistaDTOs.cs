using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.DTOs.Venta
{
    public class DetalleOrdenTrabajoVistaDTOs
    {

        /// <summary>
        /// Cantidad
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Producto
        /// </summary>
        public string Producto { get; set; }

        /// <summary>
        /// Id del producto
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// ColorId
        /// </summary>
        public int ColorId { get; set; }

        /// <summary>
        /// Marca
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// MarcaId
        /// </summary>
        public int MarcaId { get; set; }

        /// <summary>
        /// Marca
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// MarcaId
        /// </summary>
        public int MaterialId { get; set; }

        /// <summary>
        /// ValorUnitario
        /// </summary>
        public decimal ValorUnitario { get; set; }

        /// <summary>
        /// ValorUnitario
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Observacion
        /// </summary>
        public string Observacion { get; set; }




    }
}