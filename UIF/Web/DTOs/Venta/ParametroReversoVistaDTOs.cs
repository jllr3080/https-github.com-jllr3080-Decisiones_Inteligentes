﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.DTOs.Venta
{
    public class ParametroReversoVistaDTOs
    {
        /// <summary>
        /// Numero de  orden
        /// </summary>
        public string NumeroOrden { get; set; }
        /// <summary>
        /// sucursalId
        /// </summary>
        public int SucursalId { get; set; }

        /// <summary>
        /// PuntoVentaId
        /// </summary>
        public int PuntoVentaId { get; set; }
        /// <summary>
        /// OrdenTrabajoId
        /// </summary>
        public int OrdenTrabajoId { get; set; }
        /// <summary>
        /// Texto
        /// </summary>
        public string Texto { get; set; }
        /// <summary>
        /// usuarioId
        /// </summary>
        public int UsuarioId { get; set; }
    }
}