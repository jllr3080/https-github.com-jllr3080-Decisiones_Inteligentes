#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.General
{
    public class SucursalVistaModelo
    {

        /// <summary>
        /// Id de la sucursal
        /// </summary>
        
        public int SucursalId { get; set; }

        /// <summary>
        /// Descripcion de la sucursal
        /// </summary>
        
        public string Descripcion { get; set; }

        /// <summary>
        /// Esta habilitado
        /// </summary>
        
        public bool? EstaHabilitado { get; set; }

        /// <summary>
        /// Puntos de  venta
        /// </summary>
        
        public List<PuntoVentaVistaModelo> PuntosVenta { get; set; }
    }
}