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
    
    public partial class CONTROL_USUARIO
    {
        public long CONTROL_USUARIO_ID { get; set; }
        public Nullable<int> USUARIO_ID { get; set; }
        public Nullable<System.DateTime> FECHA_INGRESO { get; set; }
        public string OPERACION { get; set; }
        public string ERROR { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
    }
}
