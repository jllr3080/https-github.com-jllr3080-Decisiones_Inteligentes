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
    
    public partial class TIPO_DIRECCION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_DIRECCION()
        {
            this.DIRECCION = new HashSet<DIRECCION>();
        }
    
        public int TIPO_DIRECCION_ID { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<bool> POR_DEFECTO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIRECCION> DIRECCION { get; set; }
    }
}
