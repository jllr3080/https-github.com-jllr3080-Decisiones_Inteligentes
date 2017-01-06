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
    
    public partial class INDIVIDUO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INDIVIDUO()
        {
            this.CLIENTE = new HashSet<CLIENTE>();
            this.DIRECCION = new HashSet<DIRECCION>();
            this.E_MAIL = new HashSet<E_MAIL>();
            this.EMPLEADO = new HashSet<EMPLEADO>();
            this.INDIVIDUO_ROL = new HashSet<INDIVIDUO_ROL>();
            this.INDIVIDUO_BANCO = new HashSet<INDIVIDUO_BANCO>();
            this.TELEFONO = new HashSet<TELEFONO>();
            this.USUARIO = new HashSet<USUARIO>();
        }
    
        public int INDIVIDUO_ID { get; set; }
        public Nullable<int> TIPO_IDENTIFICACION_ID { get; set; }
        public Nullable<int> TIPO_INDIVIDUO_ID { get; set; }
        public string PRIMER_CAMPO { get; set; }
        public string SEGUNDO_CAMPO { get; set; }
        public string TERCER_CAMPO { get; set; }
        public string CUARTO_CAMPO { get; set; }
        public string NUMERO_IDENTIFICACION { get; set; }
        public Nullable<bool> HABILITADO { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public Nullable<System.DateTime> FECHA_MODIFICACION { get; set; }
        public Nullable<int> USUARIO_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE> CLIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIRECCION> DIRECCION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<E_MAIL> E_MAIL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLEADO> EMPLEADO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INDIVIDUO_ROL> INDIVIDUO_ROL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INDIVIDUO_BANCO> INDIVIDUO_BANCO { get; set; }
        public virtual TIPO_IDENTIFICACION TIPO_IDENTIFICACION { get; set; }
        public virtual TIPO_INDIVIDUO TIPO_INDIVIDUO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TELEFONO> TELEFONO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }
    }
}
