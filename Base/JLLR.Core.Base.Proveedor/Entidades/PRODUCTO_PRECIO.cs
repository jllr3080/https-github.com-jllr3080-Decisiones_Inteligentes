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
    
    public partial class PRODUCTO_PRECIO
    {
        public int PRODUCTO_PRECIO_ID { get; set; }
        public Nullable<int> PRODUCTO_ID { get; set; }
        public Nullable<decimal> PRECIO { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public Nullable<bool> ESTA_HABILITADO { get; set; }
        public Nullable<bool> MODIFICABLE { get; set; }
        public Nullable<int> PRODUCTO_TALLA_ID { get; set; }
    
        public virtual PRODUCTO PRODUCTO { get; set; }
        public virtual PRODUCTO_TALLA PRODUCTO_TALLA { get; set; }
    }
}