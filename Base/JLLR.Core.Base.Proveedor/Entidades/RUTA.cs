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
    
    public partial class RUTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RUTA()
        {
            this.VISITA = new HashSet<VISITA>();
        }
    
        public int RUTA_ID { get; set; }
        public Nullable<int> ZONA_ID { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<bool> ESTA_HABILITADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISITA> VISITA { get; set; }
        public virtual ZONA ZONA { get; set; }
    }
}
