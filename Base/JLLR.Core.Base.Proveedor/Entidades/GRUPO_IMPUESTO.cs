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
    
    public partial class GRUPO_IMPUESTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GRUPO_IMPUESTO()
        {
            this.PROVEEDOR_IMPUESTO = new HashSet<PROVEEDOR_IMPUESTO>();
            this.PORCENTAJE_IMPUESTO = new HashSet<PORCENTAJE_IMPUESTO>();
        }
    
        public int GRUPO_IMPUESTO_ID { get; set; }
        public Nullable<int> IMPUESTO_ID { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<bool> HABILITADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROVEEDOR_IMPUESTO> PROVEEDOR_IMPUESTO { get; set; }
        public virtual IMPUESTO IMPUESTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORCENTAJE_IMPUESTO> PORCENTAJE_IMPUESTO { get; set; }
    }
}
