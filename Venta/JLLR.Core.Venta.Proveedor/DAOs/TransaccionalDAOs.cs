#region using

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Venta.Proveedor.DTOs;
using Web.DTOs.Venta;

#endregion

namespace JLLR.Core.Venta.Proveedor.DAOs
{
    /// <summary>
    /// Metodos  generales de  venta
    /// </summary>
    public class TransaccionalDAOs:BaseDAOs
    {

        #region DECLARACIONES E INSTANCIAS

        private Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();
        private readonly OrdenTrabajoDAOs _ordenTrabajoDaOs = new OrdenTrabajoDAOs();
        private readonly DetalleOrdenTrabajoDAOs _detalleOrdenTrabajoDaOs = new DetalleOrdenTrabajoDAOs();
        private readonly  NumeroOrdenDAOs _numeroOrdenDaOs= new  NumeroOrdenDAOs();
        private readonly  DetalleOrdenTrabajoObservacionDAOs _detalleOrdenTrabajoObservacionDaOs= new DetalleOrdenTrabajoObservacionDAOs();
        #endregion


        #region TRANSACCIONAL

        /// <summary>
        /// Obtiene todas las observaciones  de las prendas por  
        /// </summary>
        /// <returns></returns>

        public IQueryable<DetalleOrdenTrabajoObservacionDTOs> ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId(int detalleOrdenTrabajoId)
        {
            try
            {
                var detalleOrdenTrabajoObservaciones =
                    from detalleOrdenTrabajoObservacion in _entidad.DETALLE_ORDEN_TRABAJO_OBSERVACION
                    join usuario in _entidad.USUARIO on detalleOrdenTrabajoObservacion.USUARIO_ID equals
                        usuario.USUARIO_ID
                    where detalleOrdenTrabajoObservacion.DETALLE_ORDEN_TRABAJO_ID == detalleOrdenTrabajoId
                    select
                        new DetalleOrdenTrabajoObservacionDTOs
                        {
                            NombreUsuario = usuario.NOMBRE_USUARIO,
                            DetalleOrdenTrabajoObservacion = detalleOrdenTrabajoObservacion
                        };

                return detalleOrdenTrabajoObservaciones;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Obtiene  todos los descuentos   que  estan por aprobarse
        /// </summary>
        /// <returns></returns>
        public IQueryable<OrdenTrabajoDescuentoDTO> ObtenerOrdenesTrabajoDescuentoPorEstadoProceso()
        {
            try
            {
                var ordenesTrabajoDescuento = from ordenTrabajoDescuento in _entidad.ORDEN_TRABAJO_DESCUENTO
                    join ordenTrabajo in _entidad.ORDEN_TRABAJO on ordenTrabajoDescuento.ORDEN_TRABAJO_ID equals
                        ordenTrabajo.ORDEN_TRABAJO_ID
                    join puntoVenta in _entidad.PUNTO_VENTA on ordenTrabajo.PUNTO_VENTA_ID equals
                        puntoVenta.PUNTO_VENTA_ID
                    where ordenTrabajoDescuento.ESTADO_PROCESO ==false
                                              select
                        new OrdenTrabajoDescuentoDTO
                        {
                            NombrePuntoVenta = puntoVenta.DESCRIPCION,
                            OrdenTrabajoDescuento = ordenTrabajoDescuento
                        };
            
                return ordenesTrabajoDescuento;

            }
            catch (Exception)
            {
                
                throw;
            }
        }



        /// <summary>
        /// Graba la orden  de trabajo de forma completa
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>
        /// <returns></returns>
        public ORDEN_TRABAJO GrabarOrdenTrabajoCompleta(OrdenTrabajoDTOs ordenTrabajoDtOs)
        {
            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    NUMERACION_ORDEN _numeracionOrden =
                        _numeroOrdenDaOs.ObtenerNumeroOrdenPorVariosParametros(
                            Convert.ToInt32(ordenTrabajoDtOs.OrdenTrabajo.TIPO_LAVADO_ID),
                            Convert.ToInt32(ordenTrabajoDtOs.OrdenTrabajo.SUCURSAL_ID),
                            Convert.ToInt32(ordenTrabajoDtOs.OrdenTrabajo.PUNTO_VENTA_ID));
                    if (ordenTrabajoDtOs.OrdenTrabajo.TIPO_LAVADO_ID==1)
                    ordenTrabajoDtOs.OrdenTrabajo.NUMERO_ORDEN ="S" + Convert.ToString(_numeracionOrden.NUMERO);
                    else if (ordenTrabajoDtOs.OrdenTrabajo.TIPO_LAVADO_ID == 2)
                     ordenTrabajoDtOs.OrdenTrabajo.NUMERO_ORDEN = "A" + Convert.ToString(_numeracionOrden.NUMERO);

                    ORDEN_TRABAJO ordenTrabajo = _ordenTrabajoDaOs.GrabarOrdenTrabajo(ordenTrabajoDtOs.OrdenTrabajo);

                    foreach (var detalleOrdenTrabajo in ordenTrabajoDtOs.DetalleOrdenTrabajos)
                    {
                        detalleOrdenTrabajo.ORDEN_TRABAJO_ID = ordenTrabajo.ORDEN_TRABAJO_ID;
                        DETALLE_ORDEN_TRABAJO _detalleOrdenTrabajo=  _detalleOrdenTrabajoDaOs.GrabarDetelleOrdenTrabajo(detalleOrdenTrabajo);
                        //foreach (var detalleOrdenTrabajoObservacion in detalleOrdenTrabajo.DETALLE_ORDEN_TRABAJO_OBSERVACION)
                        //{
                        //    detalleOrdenTrabajoObservacion.DETALLE_ORDEN_TRABAJO_ID =_detalleOrdenTrabajo.DETALLE_ORDEN_TRABAJO_ID;
                        //    _detalleOrdenTrabajoObservacionDaOs.GrabarDetalleOrdenTrabajoObservacion(detalleOrdenTrabajoObservacion);

                        //}

                        
                    }
                    _numeracionOrden.NUMERO += 1;
                    if (ordenTrabajoDtOs.OrdenTrabajo.TIPO_LAVADO_ID == 1)
                        _numeracionOrden .NUMERO_ORDEN= "S" + Convert.ToString(_numeracionOrden.NUMERO);
                    else if (ordenTrabajoDtOs.OrdenTrabajo.TIPO_LAVADO_ID == 2)
                        _numeracionOrden.NUMERO_ORDEN = "A" + Convert.ToString(_numeracionOrden.NUMERO);

                    _numeroOrdenDaOs.ActualizarNumeroOrden(_numeracionOrden);
                    transaction.Complete();

                    return ordenTrabajo;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        /// <summary>
        /// Obtiene todas las  ordenes  que estan lista para enviarse  a matriz
        /// </summary>
        /// <returns></returns>
        public List<OrdenTrabajoDTOs> ObtenerOrdenTrabajoPorEnvioMatriz(int puntoVentaId,int sucursalId)
        {
            try
            {
                var ordenesTrabajo = from ordenTrabajo in _entidad.ORDEN_TRABAJO
                    //join detalleOrdenTrabajo in _entidad.DETALLE_ORDEN_TRABAJO on ordenTrabajo.ORDEN_TRABAJO_ID equals detalleOrdenTrabajo.ORDEN_TRABAJO_ID
                    where ordenTrabajo.SE_ENVIO == false && ordenTrabajo.PUNTO_VENTA_ID== puntoVentaId && ordenTrabajo.SUCURSAL_ID==sucursalId
                                     select new OrdenTrabajoDTOs()
                    {
                        OrdenTrabajo = ordenTrabajo,
                        DetalleOrdenTrabajos = (List<DETALLE_ORDEN_TRABAJO>)(ordenTrabajo.DETALLE_ORDEN_TRABAJO)
                    };

                List <OrdenTrabajoDTOs> _ordenTrabajoDtOses = new List<OrdenTrabajoDTOs>();
                foreach (var objetoOrdenTrabajoDTOs in ordenesTrabajo)
                {
                    _ordenTrabajoDtOses.Add(objetoOrdenTrabajoDTOs);
                }

                return _ordenTrabajoDtOses;

            }
            catch (Exception ex)
            {
                
                throw;
            }

        }


        #region  VENTA COMISION

        /// <summary>
        /// Obtiene 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        public VENTA_COMISION ObtenerVentaComisionPorusuarioId(int usuarioId)
        {
            try
            {
                


                var ventasComision = (from usuario in _entidad.USUARIO
                             join individuo in _entidad.INDIVIDUO on usuario.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                             join individuoRol in _entidad.INDIVIDUO_ROL on individuo.INDIVIDUO_ID equals
                                 individuoRol.INDIVIDUO_ID
                             join vendedor in _entidad.VENDEDOR on individuo.INDIVIDUO_ID equals vendedor.INDIVIDUO_ID
                             join ventaComision in _entidad.VENTA_COMISION on vendedor.VENDEDOR_ID equals
                                 ventaComision.VENDEDOR_ID
                             where usuario.USUARIO_ID == usuarioId && individuoRol.INDIVIDUO_ROL_ID == 4  && ventaComision.ESTA_HABILITADO==true
                             select new
                             {
                                 venta_comision_id =ventaComision.VENTA_COMISION_ID,
                                  vendedorId= ventaComision.VENDEDOR_ID,
                                  fechaComision=ventaComision.FECHA_COMISION,
                                  estaHabilitado=ventaComision.ESTA_HABILITADO,
                                  procentajeComision= ventaComision.PORCENTAJE_COMISION,
                                  sucursalId=ventaComision.SUCURSAL_ID,
                                  puntoVentaId= ventaComision.PUNTO_VENTA_ID
                             }).AsEnumerable().Select(x => new VENTA_COMISION()
                             {
                                 VENTA_COMISION_ID = x.venta_comision_id,
                                 ESTA_HABILITADO = x.estaHabilitado,
                                 FECHA_COMISION = x.fechaComision,
                                 PUNTO_VENTA_ID = x.puntoVentaId,
                                 SUCURSAL_ID = x.sucursalId,
                                 VENDEDOR_ID = x.vendedorId
                                 
                                 
                             }).ToList();



                
                return ventasComision.FirstOrDefault();

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        #endregion

        #endregion

        #region REPORTES

        /// <summary>
        ///  Obtiene el reporte de prenda  y marcas 
        /// </summary>
        /// <param name="prendaId"></param>
        /// <param name="marcaId"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public IQueryable<PrendaMarcaDTOs> ObtenerPrendayMarcaPorVariosParametros(int prendaId, int marcaId, DateTime fecha)
        {
            try
            {
                var prendaMarcas = from ordenTrabajo in _entidad.ORDEN_TRABAJO
                    join detalleOrdenTrabajo in _entidad.DETALLE_ORDEN_TRABAJO on ordenTrabajo.ORDEN_TRABAJO_ID equals
                        detalleOrdenTrabajo.ORDEN_TRABAJO_ID
                    join producto in _entidad.PRODUCTO on detalleOrdenTrabajo.PRODUCTO_ID equals producto.PRODUCTO_ID
                    join puntoventa in _entidad.PUNTO_VENTA on ordenTrabajo.PUNTO_VENTA_ID equals
                        puntoventa.PUNTO_VENTA_ID
                    join marca in _entidad.MARCA on detalleOrdenTrabajo.MARCA_ID equals marca.MARCA_ID
                    join historialProceso in _entidad.HISTORIAL_PROCESO on ordenTrabajo.ORDEN_TRABAJO_ID equals
                        historialProceso.ORDEN_TRABAJO_ID
                    where detalleOrdenTrabajo.PRODUCTO_ID == prendaId
                    select new PrendaMarcaDTOs() {NumeroOrden = ordenTrabajo.NUMERO_ORDEN,FechaIngreso = ordenTrabajo.FECHA_INGRESO,NombreSucursal = puntoventa.DESCRIPCION,NombrePrenda = producto.NOMBRE,NombreMarca = marca.DESCRIPCION};

                return prendaMarcas;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Obtiene el reporte de   numero de  prendas por  fecha  desde y fecha hasta
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>

        public List<NumeroPrendaDTOs> ObtenerNumeroPrendasPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {

                
                var numeroPrendas = _entidad.ESTADISTICA_PRENDA(fechaDesde, fechaHasta);
                
                List<NumeroPrendaDTOs>  _numeroPrendaDtOses= new List<NumeroPrendaDTOs>();
                foreach (var numeroPrenda in numeroPrendas)
                {
                    NumeroPrendaDTOs _numeroPrendaDtOs= new NumeroPrendaDTOs();
                    _numeroPrendaDtOs.Cantidad = numeroPrenda.CANTIDAD;
                    _numeroPrendaDtOs.NombreProducto = numeroPrenda.NOMBRE;
                    _numeroPrendaDtOses.Add(_numeroPrendaDtOs);
                }
                

                

                //var numeroPrendas = from ordenTrabajo in _entidad.ORDEN_TRABAJO
                //                    join detalleOrdenTrabajo in _entidad.DETALLE_ORDEN_TRABAJO on ordenTrabajo.ORDEN_TRABAJO_ID equals
                //                        detalleOrdenTrabajo.ORDEN_TRABAJO_ID
                //                    join producto in _entidad.PRODUCTO on detalleOrdenTrabajo.PRODUCTO_ID equals producto.PRODUCTO_ID
                //                    join historialProceso in _entidad.HISTORIAL_PROCESO on ordenTrabajo.ORDEN_TRABAJO_ID equals
                //                        historialProceso.ORDEN_TRABAJO_ID
                //                    //where ordenTrabajo.PUNTO_VENTA_ID == 
                //                    select new NumeroPrendaDTOs {NombreProducto = producto.NOMBRE,Cantidad = detalleOrdenTrabajo.CANTIDAD};

                return _numeroPrendaDtOses;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Obtiene el  reporte de   estadp de  cuenta 
        /// </summary>
        /// <param name="puntoventaId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>
        public List<EstadoCuentaDTOs> ObtenerEstadoCuentaPorVariosParametros(int puntoventaId, DateTime fechaDesde,
            DateTime fechaHasta)
        {
            try
            {


                var estadosCuenta = _entidad.ESTADO_CUENTA(puntoventaId,fechaDesde, fechaHasta);
                List<EstadoCuentaDTOs> _estadoCuentaDtOses = new List<EstadoCuentaDTOs>();
                foreach (var estadoCuenta in estadosCuenta)
                {
                    EstadoCuentaDTOs _estadoCuentaDtOs= new EstadoCuentaDTOs();
                    _estadoCuentaDtOs.NumeroOrden = estadoCuenta.NUMERO_ORDEN;
                    _estadoCuentaDtOs.Detalle = estadoCuenta.DETALLE;
                    _estadoCuentaDtOs.FechaIngreso = estadoCuenta.FECHA_INGRESO;
                    _estadoCuentaDtOs.NumeroPrenda = estadoCuenta.CANTIDAD;
                    _estadoCuentaDtOs.Valor = estadoCuenta.VALOR;
                    _estadoCuentaDtOses.Add(_estadoCuentaDtOs);

                }
                ////group new { p, bp } by new { p.SomeId } into pg
                //var estadosCuenta = from ordenTrabajo in _entidad.ORDEN_TRABAJO
                //                    join detalleOrdenTrabajo in _entidad.DETALLE_ORDEN_TRABAJO on ordenTrabajo.ORDEN_TRABAJO_ID equals
                //                        detalleOrdenTrabajo.ORDEN_TRABAJO_ID
                //                    join producto in _entidad.PRODUCTO on detalleOrdenTrabajo.PRODUCTO_ID equals producto.PRODUCTO_ID
                //                    join historialProceso in _entidad.HISTORIAL_PROCESO on ordenTrabajo.ORDEN_TRABAJO_ID equals
                //                        historialProceso.ORDEN_TRABAJO_ID
                //                    where ordenTrabajo.PUNTO_VENTA_ID == puntoventaId && historialProceso.ETAPA_PROCESO_ID != 9
                //                   select new EstadoCuentaDTOs { NumeroOrden = ordenTrabajo.NUMERO_ORDEN,Valor = detalleOrdenTrabajo.VALOR_TOTAL,NumeroPrenda = detalleOrdenTrabajo.CANTIDAD,FechaIngreso = ordenTrabajo.FECHA_INGRESO,Detalle = "Prueba" };

                return _estadoCuentaDtOses;
                

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }




        /// <summary>
        /// Obtiene  la orden de  trabajo por  numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public IQueryable<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(string numeroOrden, int puntoVentaId)
        {
            try
            {
                var ordenesTrabajo = from ordenTrabajo in _entidad.ORDEN_TRABAJO
                                     join detalleOrdenTrabajo in _entidad.DETALLE_ORDEN_TRABAJO on ordenTrabajo.ORDEN_TRABAJO_ID equals
                                     detalleOrdenTrabajo.ORDEN_TRABAJO_ID
                                     join cliente in _entidad.CLIENTE on ordenTrabajo.CLIENTE_ID equals cliente.CLIENTE_ID
                                     join individuo in _entidad.INDIVIDUO on cliente.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                                     join tipoLavado in _entidad.TIPO_LAVADO on ordenTrabajo.TIPO_LAVADO_ID equals tipoLavado.TIPO_LAVADO_ID
                                     join producto in _entidad.PRODUCTO on detalleOrdenTrabajo.PRODUCTO_ID equals producto.PRODUCTO_ID
                                     join productoTalla in _entidad.PRODUCTO_TALLA on detalleOrdenTrabajo.PRODUCTO_TALLA_ID equals
                                     productoTalla.PRODUCTO_TALLA_ID
                                     join color in _entidad.COLOR on detalleOrdenTrabajo.COLOR_ID equals color.COLOR_ID
                                     join marca in _entidad.MARCA on detalleOrdenTrabajo.MARCA_ID equals marca.MARCA_ID
                                     join material in _entidad.MATERIAL on detalleOrdenTrabajo.MATERIAL_ID equals material.MATERIAL_ID
                                     join estadoPago in _entidad.ESTADO_PAGO on ordenTrabajo.ESTADO_PAGO_ID equals estadoPago.ESTADO_PAGO_ID
                                     join direccion in _entidad.DIRECCION on  individuo.INDIVIDUO_ID equals  direccion.INDIVIDUO_ID
                                     join telefono in  _entidad.TELEFONO on individuo.INDIVIDUO_ID equals telefono.INDIVIDUO_ID
                                     join email in  _entidad.E_MAIL on individuo.INDIVIDUO_ID equals email.INDIVIDUO_ID
                                     join puntoVenta in _entidad.PUNTO_VENTA on ordenTrabajo.PUNTO_VENTA_ID equals puntoVenta.PUNTO_VENTA_ID
                                     join usuario in _entidad.USUARIO on ordenTrabajo.USUARIO_ID equals usuario.USUARIO_ID
                                     where ordenTrabajo.NUMERO_ORDEN == numeroOrden && ordenTrabajo.PUNTO_VENTA_ID == puntoVentaId

                                     select new ConsultaOrdenTrabajoDTOs
                                     {
                                         TipoLavado = tipoLavado.DESCRIPCION,
                                         EstadoPago = estadoPago.DESCRIPCION,
                                         Marca = marca.DESCRIPCION,
                                         NumeroOrden = ordenTrabajo.NUMERO_ORDEN,
                                         FechaIngreso = ordenTrabajo.FECHA_INGRESO,
                                         FechaEntrega = ordenTrabajo.FECHA_ENTREGA,
                                         ValorUnitario = detalleOrdenTrabajo.VALOR_UNITARIO,
                                         Cantidad = detalleOrdenTrabajo.CANTIDAD,
                                         Color = color.DESCRIPCION,
                                         ValorTotal = detalleOrdenTrabajo.VALOR_TOTAL,
                                         Observacion = detalleOrdenTrabajo.OBSERVACION,
                                         Prenda = producto.NOMBRE,
                                         NombreCliente = individuo.PRIMER_CAMPO + " " + individuo.SEGUNDO_CAMPO + " " + individuo.TERCER_CAMPO + " " + individuo.CUARTO_CAMPO,
                                         EstadoPagoId = ordenTrabajo.ESTADO_PAGO_ID,
                                         OrdenTrabajoId = ordenTrabajo.ORDEN_TRABAJO_ID,
                                         DetalleOrdenTrabajoId = detalleOrdenTrabajo.DETALLE_ORDEN_TRABAJO_ID,
                                         Direccion = direccion.DESCRIPCION_DIRECCION,
                                         CorreoElectronico = email.DIRECCION_CORREO_ELECTRONICO,
                                         Telefono = telefono.NUMERO_TELEFONO,
                                         NombrePuntoVenta = puntoVenta.DESCRIPCION,
                                         NombreUsuario = usuario.NOMBRE_USUARIO
                                     };
                return ordenesTrabajo;


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene  
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public IQueryable<ConsultaOrdenTrabajoDTOs> ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(DateTime fechaDesde, int sucursalId)
        {
            try
            {
            var ordenesTrabajo = from ordenTrabajo in _entidad.ORDEN_TRABAJO
                join detalleOrdenTrabajo in _entidad.DETALLE_ORDEN_TRABAJO on ordenTrabajo.ORDEN_TRABAJO_ID equals
                detalleOrdenTrabajo.ORDEN_TRABAJO_ID
                join cliente in _entidad.CLIENTE on ordenTrabajo.CLIENTE_ID equals cliente.CLIENTE_ID
                join individuo in _entidad.INDIVIDUO on cliente.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                join tipoLavado in _entidad.TIPO_LAVADO on ordenTrabajo.TIPO_LAVADO_ID equals tipoLavado.TIPO_LAVADO_ID
                join producto in _entidad.PRODUCTO on detalleOrdenTrabajo.PRODUCTO_ID equals producto.PRODUCTO_ID
                join productoTalla in _entidad.PRODUCTO_TALLA on detalleOrdenTrabajo.PRODUCTO_TALLA_ID equals
                productoTalla.PRODUCTO_TALLA_ID
                join color in _entidad.COLOR on detalleOrdenTrabajo.COLOR_ID equals color.COLOR_ID
                join marca in _entidad.MARCA on detalleOrdenTrabajo.MARCA_ID equals marca.MARCA_ID
                join material in _entidad.MATERIAL on detalleOrdenTrabajo.MATERIAL_ID equals material.MATERIAL_ID
                join estadoPago in _entidad.ESTADO_PAGO on ordenTrabajo.ESTADO_PAGO_ID equals estadoPago.ESTADO_PAGO_ID
                where EntityFunctions.TruncateTime(ordenTrabajo.FECHA_INGRESO) == fechaDesde && ordenTrabajo.PUNTO_VENTA_ID==sucursalId   
                select  new ConsultaOrdenTrabajoDTOs { TipoLavado = tipoLavado.DESCRIPCION,EstadoPago = estadoPago.DESCRIPCION,Marca = marca.DESCRIPCION,NumeroOrden = ordenTrabajo.NUMERO_ORDEN,FechaIngreso = ordenTrabajo.FECHA_INGRESO,FechaEntrega = ordenTrabajo.FECHA_ENTREGA,ValorUnitario = detalleOrdenTrabajo.VALOR_UNITARIO,Cantidad = detalleOrdenTrabajo.CANTIDAD,Color = color.DESCRIPCION,ValorTotal = detalleOrdenTrabajo.VALOR_TOTAL,Observacion = detalleOrdenTrabajo.OBSERVACION,Prenda = producto.NOMBRE,NombreCliente = individuo.PRIMER_CAMPO + " "+ individuo.SEGUNDO_CAMPO + " "+individuo.TERCER_CAMPO + " "+individuo.CUARTO_CAMPO};

                //EntityFunctions.TruncateTime(p.date) == dateWithoutTime
            return ordenesTrabajo;


            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        #endregion
    }
}
