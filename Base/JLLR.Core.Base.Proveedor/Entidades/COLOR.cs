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
    
    public partial class COLOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COLOR()
        {
            this.DETALLE_PRENDA_ORDEN_TRABAJO = new HashSet<DETALLE_PRENDA_ORDEN_TRABAJO>();
        }
    
        public int COLOR_ID { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<bool> ESTA_HABILITADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_PRENDA_ORDEN_TRABAJO> DETALLE_PRENDA_ORDEN_TRABAJO { get; set; }
    }
}
