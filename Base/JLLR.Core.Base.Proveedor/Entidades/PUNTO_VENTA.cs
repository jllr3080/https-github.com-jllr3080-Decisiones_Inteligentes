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
    
    public partial class PUNTO_VENTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PUNTO_VENTA()
        {
            this.CABECERA_FACTURACION = new HashSet<CABECERA_FACTURACION>();
            this.SECUENCIALES_SRI = new HashSet<SECUENCIALES_SRI>();
            this.REGLA = new HashSet<REGLA>();
            this.USUARIO = new HashSet<USUARIO>();
            this.CIERRE_MES = new HashSet<CIERRE_MES>();
        }
    
        public int PUNTO_VENTA_ID { get; set; }
        public Nullable<int> SUCURSAL_ID { get; set; }
        public string DESCRIPCION { get; set; }
        public string HORA_INICIO { get; set; }
        public string HORA_FIN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CABECERA_FACTURACION> CABECERA_FACTURACION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SECUENCIALES_SRI> SECUENCIALES_SRI { get; set; }
        public virtual SUCURSAL SUCURSAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGLA> REGLA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CIERRE_MES> CIERRE_MES { get; set; }
    }
}
