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
    
    public partial class HISTORIAL_PROCESO
    {
        public int HISTORIAL_PROCESO_ID { get; set; }
        public Nullable<long> ORDEN_TRABAJO_ID { get; set; }
        public Nullable<int> ETAPA_PROCESO_ID { get; set; }
        public Nullable<System.DateTime> FECHA_REGISTRO { get; set; }
        public Nullable<System.DateTime> FECHA_INICIO { get; set; }
        public Nullable<System.DateTime> FECHA_FIN { get; set; }
        public string NUMERO_ORDEN { get; set; }
        public string TEXTO { get; set; }
    
        public virtual ETAPA_PROCESO ETAPA_PROCESO { get; set; }
        public virtual ORDEN_TRABAJO ORDEN_TRABAJO { get; set; }
    }
}
