﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Decisiones_Inteligentes : DbContext
    {
        public Decisiones_Inteligentes()
            : base("name=Decisiones_Inteligentes")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CONTROL_USUARIO> CONTROL_USUARIO { get; set; }
        public virtual DbSet<ARQUEO_CAJA> ARQUEO_CAJA { get; set; }
        public virtual DbSet<CUENTA_POR_COBRAR> CUENTA_POR_COBRAR { get; set; }
        public virtual DbSet<DETALLE_ARQUEO_CAJA> DETALLE_ARQUEO_CAJA { get; set; }
        public virtual DbSet<HISTORIAL_CUENTA_POR_COBRAR> HISTORIAL_CUENTA_POR_COBRAR { get; set; }
        public virtual DbSet<HISTORIAL_CUENTA_POR_PAGAR> HISTORIAL_CUENTA_POR_PAGAR { get; set; }
        public virtual DbSet<CABECERA_FACTURACION> CABECERA_FACTURACION { get; set; }
        public virtual DbSet<CABECERA_MOVIMIENTO_FACTURA> CABECERA_MOVIMIENTO_FACTURA { get; set; }
        public virtual DbSet<CABECERA_MOVIMIENTO_FE> CABECERA_MOVIMIENTO_FE { get; set; }
        public virtual DbSet<CABECERA_MOVIMIENTO_TRIBUTARIO> CABECERA_MOVIMIENTO_TRIBUTARIO { get; set; }
        public virtual DbSet<DETALLE_IMPUESTO_MOVIMIENTO_FACTURA> DETALLE_IMPUESTO_MOVIMIENTO_FACTURA { get; set; }
        public virtual DbSet<DETALLE_MOVIMIENTO_FACTURA> DETALLE_MOVIMIENTO_FACTURA { get; set; }
        public virtual DbSet<SECUENCIALES_SRI> SECUENCIALES_SRI { get; set; }
        public virtual DbSet<CIUDAD> CIUDAD { get; set; }
        public virtual DbSet<CLIENTE> CLIENTE { get; set; }
        public virtual DbSet<DIRECCION> DIRECCION { get; set; }
        public virtual DbSet<E_MAIL> E_MAIL { get; set; }
        public virtual DbSet<EMPLEADO> EMPLEADO { get; set; }
        public virtual DbSet<ESTADO> ESTADO { get; set; }
        public virtual DbSet<INDIVIDUO> INDIVIDUO { get; set; }
        public virtual DbSet<INDIVIDUO_BANCO> INDIVIDUO_BANCO { get; set; }
        public virtual DbSet<INDIVIDUO_ROL> INDIVIDUO_ROL { get; set; }
        public virtual DbSet<PAIS> PAIS { get; set; }
        public virtual DbSet<PARROQUIA> PARROQUIA { get; set; }
        public virtual DbSet<PROVEEDOR> PROVEEDOR { get; set; }
        public virtual DbSet<PROVEEDOR_IMPUESTO> PROVEEDOR_IMPUESTO { get; set; }
        public virtual DbSet<TELEFONO> TELEFONO { get; set; }
        public virtual DbSet<VENDEDOR> VENDEDOR { get; set; }
        public virtual DbSet<AGENDA_VISITA> AGENDA_VISITA { get; set; }
        public virtual DbSet<HISTORIAL_PROCESO> HISTORIAL_PROCESO { get; set; }
        public virtual DbSet<PROCESO> PROCESO { get; set; }
        public virtual DbSet<VISITA> VISITA { get; set; }
        public virtual DbSet<BANCO> BANCO { get; set; }
        public virtual DbSet<COLOR> COLOR { get; set; }
        public virtual DbSet<CONDICION_IMPUESTO> CONDICION_IMPUESTO { get; set; }
        public virtual DbSet<DIA> DIA { get; set; }
        public virtual DbSet<ENTREGA_URGENCIA> ENTREGA_URGENCIA { get; set; }
        public virtual DbSet<ESPECIALIDAD_EMPLEADO> ESPECIALIDAD_EMPLEADO { get; set; }
        public virtual DbSet<ESTADO_CIVIL> ESTADO_CIVIL { get; set; }
        public virtual DbSet<ESTADO_COMPROBANTE_ELECTRONICO> ESTADO_COMPROBANTE_ELECTRONICO { get; set; }
        public virtual DbSet<ESTADO_PAGO> ESTADO_PAGO { get; set; }
        public virtual DbSet<ETAPA_PROCESO> ETAPA_PROCESO { get; set; }
        public virtual DbSet<FORMA_PAGO> FORMA_PAGO { get; set; }
        public virtual DbSet<GRUPO_IMPUESTO> GRUPO_IMPUESTO { get; set; }
        public virtual DbSet<IMPUESTO> IMPUESTO { get; set; }
        public virtual DbSet<MARCA> MARCA { get; set; }
        public virtual DbSet<MATERIAL> MATERIAL { get; set; }
        public virtual DbSet<MENSAJE> MENSAJE { get; set; }
        public virtual DbSet<MODELO> MODELO { get; set; }
        public virtual DbSet<MONEDA> MONEDA { get; set; }
        public virtual DbSet<NIVEL_EDUCACION> NIVEL_EDUCACION { get; set; }
        public virtual DbSet<PARAMETRO> PARAMETRO { get; set; }
        public virtual DbSet<PORCENTAJE_IMPUESTO> PORCENTAJE_IMPUESTO { get; set; }
        public virtual DbSet<PORCENTAJE_IMPUESTO_SUCURSAL> PORCENTAJE_IMPUESTO_SUCURSAL { get; set; }
        public virtual DbSet<PUNTO_VENTA> PUNTO_VENTA { get; set; }
        public virtual DbSet<RUTA> RUTA { get; set; }
        public virtual DbSet<SUCURSAL> SUCURSAL { get; set; }
        public virtual DbSet<TIPO_AMBIENTE> TIPO_AMBIENTE { get; set; }
        public virtual DbSet<TIPO_COMPROBANTE> TIPO_COMPROBANTE { get; set; }
        public virtual DbSet<TIPO_CORREO_ELECTRONICO> TIPO_CORREO_ELECTRONICO { get; set; }
        public virtual DbSet<TIPO_CUENTA_BANCARIA> TIPO_CUENTA_BANCARIA { get; set; }
        public virtual DbSet<TIPO_DIRECCION> TIPO_DIRECCION { get; set; }
        public virtual DbSet<TIPO_EMISION> TIPO_EMISION { get; set; }
        public virtual DbSet<TIPO_GENERO> TIPO_GENERO { get; set; }
        public virtual DbSet<TIPO_IDENTIFICACION> TIPO_IDENTIFICACION { get; set; }
        public virtual DbSet<TIPO_INDIVIDUO> TIPO_INDIVIDUO { get; set; }
        public virtual DbSet<TIPO_LAVADO> TIPO_LAVADO { get; set; }
        public virtual DbSet<TIPO_MENSAJE> TIPO_MENSAJE { get; set; }
        public virtual DbSet<TIPO_REGLA> TIPO_REGLA { get; set; }
        public virtual DbSet<TIPO_ROL_INDIVIDUO> TIPO_ROL_INDIVIDUO { get; set; }
        public virtual DbSet<TIPO_TELEFONO> TIPO_TELEFONO { get; set; }
        public virtual DbSet<UNIDAD_MEDIDA> UNIDAD_MEDIDA { get; set; }
        public virtual DbSet<ZONA> ZONA { get; set; }
        public virtual DbSet<GRUPO_PRODUCTO> GRUPO_PRODUCTO { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<PRODUCTO_PRECIO> PRODUCTO_PRECIO { get; set; }
        public virtual DbSet<PRODUCTO_VS_GRUPO_PRODUCTO> PRODUCTO_VS_GRUPO_PRODUCTO { get; set; }
        public virtual DbSet<TIPO_PRODUCTO> TIPO_PRODUCTO { get; set; }
        public virtual DbSet<ACCION_REGLA> ACCION_REGLA { get; set; }
        public virtual DbSet<REGLA> REGLA { get; set; }
        public virtual DbSet<ACCESO> ACCESO { get; set; }
        public virtual DbSet<ACCESO_PERFIL> ACCESO_PERFIL { get; set; }
        public virtual DbSet<HISTORIAL_USUARIO> HISTORIAL_USUARIO { get; set; }
        public virtual DbSet<MODULO> MODULO { get; set; }
        public virtual DbSet<PERFIL> PERFIL { get; set; }
        public virtual DbSet<PREGUNTA_SEGURIDAD> PREGUNTA_SEGURIDAD { get; set; }
        public virtual DbSet<SUBMODULO> SUBMODULO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<USUARIO_PERFIL> USUARIO_PERFIL { get; set; }
        public virtual DbSet<USUARIO_PREGUNTA_SEGURIDAD> USUARIO_PREGUNTA_SEGURIDAD { get; set; }
        public virtual DbSet<USUARIO_SEGURIDAD> USUARIO_SEGURIDAD { get; set; }
        public virtual DbSet<APROBACION_DESCUENTO> APROBACION_DESCUENTO { get; set; }
        public virtual DbSet<DETALLE_ORDEN_TRABAJO_OBSERVACION> DETALLE_ORDEN_TRABAJO_OBSERVACION { get; set; }
        public virtual DbSet<DETALLE_PRENDA_ORDEN_TRABAJO> DETALLE_PRENDA_ORDEN_TRABAJO { get; set; }
        public virtual DbSet<DETALLE_TRABAJO_FOTOGRAFIA> DETALLE_TRABAJO_FOTOGRAFIA { get; set; }
        public virtual DbSet<DETALLE_VENTA_COMISION_INDUSTRIALES> DETALLE_VENTA_COMISION_INDUSTRIALES { get; set; }
        public virtual DbSet<HISTORIAL_RECLAMO_REPROCESO_PRENDA> HISTORIAL_RECLAMO_REPROCESO_PRENDA { get; set; }
        public virtual DbSet<HISTORIAL_REGLA> HISTORIAL_REGLA { get; set; }
        public virtual DbSet<NUMERACION_ORDEN> NUMERACION_ORDEN { get; set; }
        public virtual DbSet<ORDEN_TRABAJO_DESCUENTO> ORDEN_TRABAJO_DESCUENTO { get; set; }
        public virtual DbSet<VENTA_COMISION> VENTA_COMISION { get; set; }
        public virtual DbSet<VENTA_COMISION_INDUSTRIALES> VENTA_COMISION_INDUSTRIALES { get; set; }
        public virtual DbSet<DETALLE_HISTORIAL_REPROCESO> DETALLE_HISTORIAL_REPROCESO { get; set; }
        public virtual DbSet<TIPO_REPROCESO> TIPO_REPROCESO { get; set; }
        public virtual DbSet<HISTORIAL_REPROCESO> HISTORIAL_REPROCESO { get; set; }
        public virtual DbSet<APLICACION_PAGO> APLICACION_PAGO { get; set; }
        public virtual DbSet<MES> MES { get; set; }
        public virtual DbSet<CIERRE_MES> CIERRE_MES { get; set; }
        public virtual DbSet<CUENTA_POR_PAGAR> CUENTA_POR_PAGAR { get; set; }
        public virtual DbSet<ORDEN_TRABAJO_COMISION> ORDEN_TRABAJO_COMISION { get; set; }
        public virtual DbSet<DETALLE_ORDEN_TRABAJO> DETALLE_ORDEN_TRABAJO { get; set; }
        public virtual DbSet<ORDEN_TRABAJO> ORDEN_TRABAJO { get; set; }
    
        public virtual ObjectResult<ESTADISTICA_PRENDA_Result> ESTADISTICA_PRENDA(Nullable<System.DateTime> fECHADESDE, Nullable<System.DateTime> fECHAHASTA, Nullable<int> sUCURSALID)
        {
            var fECHADESDEParameter = fECHADESDE.HasValue ?
                new ObjectParameter("FECHADESDE", fECHADESDE) :
                new ObjectParameter("FECHADESDE", typeof(System.DateTime));
    
            var fECHAHASTAParameter = fECHAHASTA.HasValue ?
                new ObjectParameter("FECHAHASTA", fECHAHASTA) :
                new ObjectParameter("FECHAHASTA", typeof(System.DateTime));
    
            var sUCURSALIDParameter = sUCURSALID.HasValue ?
                new ObjectParameter("SUCURSALID", sUCURSALID) :
                new ObjectParameter("SUCURSALID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ESTADISTICA_PRENDA_Result>("ESTADISTICA_PRENDA", fECHADESDEParameter, fECHAHASTAParameter, sUCURSALIDParameter);
        }
    
        public virtual ObjectResult<ESTADO_CUENTA_Result> ESTADO_CUENTA(Nullable<int> pUNTOVENTAID, Nullable<System.DateTime> fECHADESDE, Nullable<System.DateTime> fECHAHASTA)
        {
            var pUNTOVENTAIDParameter = pUNTOVENTAID.HasValue ?
                new ObjectParameter("PUNTOVENTAID", pUNTOVENTAID) :
                new ObjectParameter("PUNTOVENTAID", typeof(int));
    
            var fECHADESDEParameter = fECHADESDE.HasValue ?
                new ObjectParameter("FECHADESDE", fECHADESDE) :
                new ObjectParameter("FECHADESDE", typeof(System.DateTime));
    
            var fECHAHASTAParameter = fECHAHASTA.HasValue ?
                new ObjectParameter("FECHAHASTA", fECHAHASTA) :
                new ObjectParameter("FECHAHASTA", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ESTADO_CUENTA_Result>("ESTADO_CUENTA", pUNTOVENTAIDParameter, fECHADESDEParameter, fECHAHASTAParameter);
        }
    
        public virtual ObjectResult<ESTADO_CUENTA_V1_Result> ESTADO_CUENTA_V1(Nullable<int> pUNTOVENTAID, Nullable<System.DateTime> fECHADESDE, Nullable<System.DateTime> fECHAHASTA)
        {
            var pUNTOVENTAIDParameter = pUNTOVENTAID.HasValue ?
                new ObjectParameter("PUNTOVENTAID", pUNTOVENTAID) :
                new ObjectParameter("PUNTOVENTAID", typeof(int));
    
            var fECHADESDEParameter = fECHADESDE.HasValue ?
                new ObjectParameter("FECHADESDE", fECHADESDE) :
                new ObjectParameter("FECHADESDE", typeof(System.DateTime));
    
            var fECHAHASTAParameter = fECHAHASTA.HasValue ?
                new ObjectParameter("FECHAHASTA", fECHAHASTA) :
                new ObjectParameter("FECHAHASTA", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ESTADO_CUENTA_V1_Result>("ESTADO_CUENTA_V1", pUNTOVENTAIDParameter, fECHADESDEParameter, fECHAHASTAParameter);
        }
    }
}
