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
    
    public partial class TIPO_LAVADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_LAVADO()
        {
            this.NUMERACION_ORDEN = new HashSet<NUMERACION_ORDEN>();
            this.ORDEN_TRABAJO = new HashSet<ORDEN_TRABAJO>();
        }
    
        public int TIPO_LAVADO_ID { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<bool> ESTA_HABILITADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NUMERACION_ORDEN> NUMERACION_ORDEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDEN_TRABAJO> ORDEN_TRABAJO { get; set; }
    }
}
