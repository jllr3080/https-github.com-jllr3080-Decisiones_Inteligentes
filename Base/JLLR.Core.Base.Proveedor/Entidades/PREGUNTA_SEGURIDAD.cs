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
    
    public partial class PREGUNTA_SEGURIDAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PREGUNTA_SEGURIDAD()
        {
            this.USUARIO_PREGUNTA_SEGURIDAD = new HashSet<USUARIO_PREGUNTA_SEGURIDAD>();
        }
    
        public int PREGUNTA_SEGURIDAD_ID { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<bool> HABILITADA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO_PREGUNTA_SEGURIDAD> USUARIO_PREGUNTA_SEGURIDAD { get; set; }
    }
}
