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
    
    public partial class PRODUCTO_VS_GRUPO_PRODUCTO
    {
        public int PRODUCTO_VS_GRUPO_PRODUCTO_ID { get; set; }
        public Nullable<int> PRODUCTO_ID { get; set; }
        public Nullable<int> GRUPO_PRODUCTO_ID { get; set; }
    
        public virtual GRUPO_PRODUCTO GRUPO_PRODUCTO { get; set; }
        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
