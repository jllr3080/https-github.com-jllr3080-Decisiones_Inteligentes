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
    
    public partial class APROBACION_DESCUENTO
    {
        public long APROBACION_DESCUENTO_ID { get; set; }
        public Nullable<long> ORDEN_TRABAJO_DESCUENTO_ID { get; set; }
        public Nullable<long> ORDEN_TRABAJO_ID { get; set; }
        public Nullable<int> USUARIO_APROBACION_ID { get; set; }
        public Nullable<System.DateTime> FECHA_APROBACION { get; set; }
        public Nullable<decimal> VALOR_FRANQUICIA_APROBACION { get; set; }
        public Nullable<decimal> VALOR_MATRIZ_APROBACION { get; set; }
    
        public virtual ORDEN_TRABAJO_DESCUENTO ORDEN_TRABAJO_DESCUENTO { get; set; }
        public virtual ORDEN_TRABAJO ORDEN_TRABAJO { get; set; }
    }
}