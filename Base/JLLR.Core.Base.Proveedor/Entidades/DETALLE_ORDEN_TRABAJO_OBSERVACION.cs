//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JLLR.Core.Base.Proveedor.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETALLE_ORDEN_TRABAJO_OBSERVACION
    {
        public int DETALLE_ORDEN_TRABAJO_OBSERVACION_ID { get; set; }
        public string OBSERVACION { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION_OBSERVACION { get; set; }
        public Nullable<int> USUARIO_ID { get; set; }
        public Nullable<int> DETALLE_PRENDA_ORDEN_TRABAJO_ID { get; set; }
    
        public virtual DETALLE_PRENDA_ORDEN_TRABAJO DETALLE_PRENDA_ORDEN_TRABAJO { get; set; }
    }
}
