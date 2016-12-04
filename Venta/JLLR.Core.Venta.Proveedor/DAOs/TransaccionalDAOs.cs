﻿#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Venta.Proveedor.DTOs;

#endregion

namespace JLLR.Core.Venta.Proveedor.DAOs
{
    /// <summary>
    /// Metodos  generales de  venta
    /// </summary>
    public class TransaccionalDAOs
    {

        #region DECLARACIONES E INSTANCIAS

        private Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();
        private readonly OrdenTrabajoDAOs _ordenTrabajoDaOs = new OrdenTrabajoDAOs();
        private readonly DetalleOrdenTrabajoDAOs _detalleOrdenTrabajoDaOs = new DetalleOrdenTrabajoDAOs();

        #endregion


        #region TRANSACCIONAL

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

                    ORDEN_TRABAJO ordenTrabajo = _ordenTrabajoDaOs.GrabarOrdenTrabajo(ordenTrabajoDtOs.OrdenTrabajo);

                    foreach (var detalleOrdenTrabajo in ordenTrabajoDtOs.DetalleOrdenTrabajos)
                    {
                        detalleOrdenTrabajo.ORDEN_TRABAJO_ID = ordenTrabajo.ORDEN_TRABAJO_ID;

                        _detalleOrdenTrabajoDaOs.GrabarDetelleOrdenTrabajo(detalleOrdenTrabajo);
                    }

                    transaction.Complete();

                    return ordenTrabajo;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        #endregion

        #region REPORTES

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
                where ordenTrabajo.FECHA_ENTREGA >= fechaDesde && ordenTrabajo.PUNTO_VENTA_ID==sucursalId
                select  new ConsultaOrdenTrabajoDTOs { TipoLavado = tipoLavado.DESCRIPCION,EstadoPago = estadoPago.DESCRIPCION,Marca = marca.DESCRIPCION,NumeroOrden = ordenTrabajo.NUMERO_ORDEN,FechaIngreso = ordenTrabajo.FECHA_INGRESO,FechaEntrega = ordenTrabajo.FECHA_ENTREGA,ValorUnitario = detalleOrdenTrabajo.VALOR_UNITARIO,Cantidad = detalleOrdenTrabajo.CANTIDAD,Color = color.DESCRIPCION,ValorTotal = detalleOrdenTrabajo.VALOR_TOTAL,Observacion = detalleOrdenTrabajo.OBSERVACION,Prenda = producto.NOMBRE,NombreCliente = individuo.PRIMER_CAMPO + " "+ individuo.SEGUNDO_CAMPO + " "+individuo.TERCER_CAMPO + " "+individuo.CUARTO_CAMPO};
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