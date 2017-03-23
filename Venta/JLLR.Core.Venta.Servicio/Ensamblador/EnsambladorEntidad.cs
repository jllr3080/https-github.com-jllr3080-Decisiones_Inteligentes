#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using  modelo=JLLR.Core.Venta.Servicio.Modelo;
using modeloParametrizacion = JLLR.Core.Venta.Servicio.Modelo.Parametrizacion;
#endregion
namespace JLLR.Core.Venta.Servicio.Ensamblador
{
    /// <summary>
    /// Ingresa un modelo y devuleve una entidad
    /// </summary>
    public class EnsambladorEntidad
    {
        #region DECLARACIONES  E INSTANCIAS
        
        
        #endregion

        #region NEGOCIO
        #region ORDEN TRABAJO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.ORDEN_TRABAJO CrearOrdenTrabajo(modelo.OrdenTrabajoModelo m)
        {
            return new entidad.ORDEN_TRABAJO()
            {
               ORDEN_TRABAJO_ID = m.OrdenTrabajoId,
               CLIENTE_ID = m.ClienteModelo.ClienteId,
               TIPO_LAVADO_ID = m.TipoLavado.TipoLavadoId,
               PUNTO_VENTA_ID = m.PuntoVenta.PuntoVentaId,
               USUARIO_ID = m.Usuario.UsuarioId,
               SUCURSAL_ID = m.Sucursal.SucursalId,
               FECHA_ENTREGA = m.FechaEntrega,
               FECHA_INGRESO = m.FechaIngreso,
               NRO_IMPRESION = m.NumeroImpresion,
               NUMERO_ORDEN = m.NumeroOrden,
               ESTADO_PAGO_ID = m.EstadoPago.EstadoPagoId,
               SE_ENVIO = m.SeEnvio,
               ENVIO_MATRIZ = m.EnvioMatriz
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.ORDEN_TRABAJO> CrearOrdenesTrabajo(List<Modelo.OrdenTrabajoModelo> listadoModelo)
        {
            List<entidad.ORDEN_TRABAJO> listaEntidad = new List<entidad.ORDEN_TRABAJO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearOrdenTrabajo(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region DETALLE ORDEN TRABAJO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.DETALLE_ORDEN_TRABAJO CrearDetalleOrdenTrabajo(modelo.DetalleOrdenTrabajoModelo m)
        {
            List<entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION> _lisaDetalleOrdenTrabajoObservacion =
                CrearDetalleOrdenTrabajosObservacion(m.DetalleOrdenTrabajoObservacion);
            return new entidad.DETALLE_ORDEN_TRABAJO()
            {
                DETALLE_ORDEN_TRABAJO_ID = m.DetalleOrdenTrabajoId,
                ORDEN_TRABAJO_ID = m.OrdenTrabajo.OrdenTrabajoId,
                PRODUCTO_ID = m.Producto.ProductoId,
                COLOR_ID = m.Color.ColorId,
                CANTIDAD = m.Cantidad,
                VALOR_UNITARIO = m.ValorUnitario,
                PORCENTAJE_IMPUESTO = m.PorcentajeImpuesto,
                VALOR_TOTAL = m.ValorTotal,
                OBSERVACION = m.Observacion,
                PRODUCTO_TALLA_ID = m.ProductoTalla.ProductoTallaId,
                MARCA_ID = m.Marca.MarcaId,
                MATERIAL_ID = m.Material.MaterialId,
                TRATAMIENTO_ESPECIAL = m.TratamientoEspecial,
                NUMERO_INTERNO_PRENDA = m.NumeroInternoPrenda,
                SUAVIZANTE = m.Suavizante,
                DESENGRASANTE = m.Desengrasante,
                FIJADOR_COLOR = m.FijadorColor,
                NUMERO_LIBRAS = m.NumeroLibras,
                NUMERO_ORDEN_MANUAL = m.NumeroOrdenManual,
                DETALLE_ORDEN_TRABAJO_OBSERVACION = _lisaDetalleOrdenTrabajoObservacion


            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.DETALLE_ORDEN_TRABAJO> CrearDetalleOrdenesTrabajo(List<Modelo.DetalleOrdenTrabajoModelo> listadoModelo)
        {
            return listadoModelo.Select(CrearDetalleOrdenTrabajo).ToList();
        }

        #endregion

        #region DETALLA ORDEN TRABAJO OBSERVACION
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION CrearDetalleOrdenTrabajoObservacion(modelo.DetalleOrdenTrabajoObservacionModelo m)
        {
            return new entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION()
            {
               DETALLE_ORDEN_TRABAJO_OBSERVACION_ID = m.DetalleOrdenTrabajoObservacionId,
               DETALLE_ORDEN_TRABAJO_ID = m.DetalleOrdenTrabajoId,
               OBSERVACION = m.Observacion,
               USUARIO_ID = m.UsuarioId,
               FECHA_CREACION_OBSERVACION = m.FechaCreacionObservacion
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION> CrearDetalleOrdenTrabajosObservacion(List<Modelo.DetalleOrdenTrabajoObservacionModelo> listadoModelo)
        {
            List<entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION> listaEntidad = new List<entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearDetalleOrdenTrabajoObservacion(modelo));
            }
            return listaEntidad;

        }

        #endregion

        #region ORDEN TRABAJO COMISION
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.ORDEN_TRABAJO_COMISION CrearOrdenTrabajoComision(modelo.OrdenTrabajoComisionModelo m)
        {
            return new entidad.ORDEN_TRABAJO_COMISION()
            {
                ORDEN_TRABAJO_COMISION_ID = m.OrdenTrabajoComisionId,
                FECHA_GENERACION_COMISION = m.FechaGeneracionComision,
                USUARIO_ID = m.UsuarioId,
                VALOR = m.Valor,
                VENTA_COMISION_ID = m.VentaComision.VentaComisionId,
                ORDEN_TRABAJO_ID = m.OrdenTrabajo.OrdenTrabajoId
            
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.ORDEN_TRABAJO_COMISION> CrearOrdenesTrabajoComision(List<Modelo.OrdenTrabajoComisionModelo> listadoModelo)
        {
            return listadoModelo.Select(CrearOrdenTrabajoComision).ToList();
        }
        #endregion

        #region HISTORIAL REGLA
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.HISTORIAL_REGLA CrearHistorialRegla(modelo.HistorialReglaModelo m)
        {
            if (m == null)
                return null;
            return new entidad.HISTORIAL_REGLA()
            {
                HISTORIAL_REGLA_ID = m.HistorialReglaId,
                ORDEN_TRABAJO_ID = m.OrdenTrabajo.OrdenTrabajoId,
                ACCION_REGLA_ID = m.AccionRegla.AccionreglaId,
                FECHA_EJECUCION = m.FechaEjecucion,
                USUARIO_ID = m.UsuarioId


            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.HISTORIAL_REGLA> CrearHistorialReglas(List<Modelo.HistorialReglaModelo> listadoModelo)
        {
            return listadoModelo.Select(CrearHistorialRegla).ToList();
        }
        #endregion

        #region ORDEN TRABAJO DESCUENTO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.ORDEN_TRABAJO_DESCUENTO CrearOrdenTrabajoDescuento(modelo.OrdenTrabajoDescuentoModelo m)
        {
            if (m == null)
                return null;
            return new entidad.ORDEN_TRABAJO_DESCUENTO()
            {
                ORDEN_TRABAJO_DESCUENTO_ID = m.OrdenTrabajoDescuentoId,
                ORDEN_TRABAJO_ID = m.OrdenTrabajo.OrdenTrabajoId,
                HISTORIAL_REGLA_ID = m.HistorialRegla.HistorialReglaId,
                MOTIVO = m.Motivo,
                VALOR = m.Valor,
                PORCENTAJE_FRANQUICIA = m.PorcentajeFranquicia,
                PORDENTAJE_MATRIZ = m.PorcentajeMatriz,
                ESTADO_PROCESO = m.EstadoProceso,
                FECHA_CREACION = m.FechaCreacion,
                FECHA_ACTUALIZACION = m.FechaActualizacion,
                USUARIO_CREACION_ID = m.UsuarioCreacionId,
                USUARIO_MODIFICACION_ID = m.UsuarioActualizacionId
            

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.ORDEN_TRABAJO_DESCUENTO> CrearOrdenTrabajoDescuentos(List<Modelo.OrdenTrabajoDescuentoModelo> listadoModelo)
        {
            return listadoModelo.Select(CrearOrdenTrabajoDescuento).ToList();
        }
        #endregion

        #region APROBACION  DESCUENTO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.APROBACION_DESCUENTO CrearAprobacionDescuento(modelo.AprobacionDescuentoModelo m)
        {
            if (m == null)
                return null;
            return new entidad.APROBACION_DESCUENTO()
            {
               APROBACION_DESCUENTO_ID = m.AprobacionDescuentoId,
               ORDEN_TRABAJO_DESCUENTO_ID = m.OrdenTrabajoDescuento.OrdenTrabajoDescuentoId,
               ORDEN_TRABAJO_ID = m.OrdenTrabajo.OrdenTrabajoId,
               USUARIO_APROBACION_ID = m.usuarioAprobacionId,
               FECHA_APROBACION = m.FechaAprobacion,
               VALOR_FRANQUICIA_APROBACION = m.ValorFranquiciaAprobacion,
               VALOR_MATRIZ_APROBACION = m.ValorMatrizAprobacion
               
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.APROBACION_DESCUENTO> CrearAprobacionDescuentos(List<Modelo.AprobacionDescuentoModelo> listadoModelo)
        {
            return listadoModelo.Select(CrearAprobacionDescuento).ToList();
        }
        #endregion
        #endregion

        #region PARAMTRIZACION

        #region NUMERO ORDEN
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.NUMERACION_ORDEN CrearNumeroOrden(modeloParametrizacion.NumeroOrdenModelo m)
        {
            return new entidad.NUMERACION_ORDEN()
            {
               NUMERACION_ORDEN_ID = m.NumeroOrdenId,
               TIPO_LAVADO_ID = m.TipoLavado.TipoLavadoId,
               SUCURSAL_ID = m.SucursalId,
               PUNTO_VENTA_ID = m.PuntoVentaId,
               NUMERO_ORDEN = m.NumeroOden,
               NUMERO = m.Numero

               
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.NUMERACION_ORDEN> CrearNumerosOrden(List<modeloParametrizacion.NumeroOrdenModelo> listadoModelo)
        {
            List<entidad.NUMERACION_ORDEN> listaEntidad = new List<entidad.NUMERACION_ORDEN>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearNumeroOrden(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region VENTA COMISION
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.VENTA_COMISION CrearVentaComision(modeloParametrizacion.VentaComisionModelo m)
        {
            return new entidad.VENTA_COMISION()
            {
              VENTA_COMISION_ID = m.VentaComisionId,
              VENDEDOR_ID = m.VendedorId,
              FECHA_COMISION = m.FechaComision,
              ESTA_HABILITADO = m.EstaHabilitado,
              PORCENTAJE_COMISION = m.PorcentajeComision,
              SUCURSAL_ID = m.SucursalId,
              PUNTO_VENTA_ID = m.PuntoVentaId
              


            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.VENTA_COMISION> CrearVentaComisiones(List<modeloParametrizacion.VentaComisionModelo> listadoModelo)
        {
            List<entidad.VENTA_COMISION> listaEntidad = new List<entidad.VENTA_COMISION>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearVentaComision(modelo));
            }
            return listaEntidad;

        }
        #endregion


        #endregion
    }
}