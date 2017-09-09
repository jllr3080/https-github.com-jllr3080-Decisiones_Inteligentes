#region using
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.FlujoProceso.Proveedor.DTOs;

#endregion
namespace JLLR.Core.FlujoProceso.Proveedor.DAOs
{
    /// <summary>
    /// Metodos  generales
    /// </summary>
    public class TransaccionalDAOs:BaseDAOs
    {
        #region Declaracion e Instancias
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();
        private readonly  HistorialProcesoDAOs _historialProcesoDaOs= new HistorialProcesoDAOs();
        private readonly  HistorialReprocesoDAOs _historialReprocesoDaOs= new HistorialReprocesoDAOs();
        #endregion

        #region REPORTES

        /// <summary>
        /// Obtiene el historial de prendas 
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="fechaRegistro"></param>
        /// <param name="etapaProcesoId"></param>
        /// <returns></returns>
        public List<HistorialProcesoDTOs> ObtenerHistorialProcesoPrendasPorVariosParametros(int sucursalId,
            int puntoVentaId, DateTime fechaRegistro, int etapaProcesoId)
        {
            try
            {
                var historialProcesos = from historialProceso in _entidad.HISTORIAL_PROCESO
                    join puntoVenta in _entidad.PUNTO_VENTA on historialProceso.PUNTO_VENTA_ID equals
                        puntoVenta.PUNTO_VENTA_ID
                    join etapaProceso in _entidad.ETAPA_PROCESO on historialProceso.ETAPA_PROCESO_ID equals
                        etapaProceso.ETAPA_PROCESO_ID
                    where
                        historialProceso.SUCURSAL_ID == sucursalId && historialProceso.PUNTO_VENTA_ID == puntoVentaId &&
                        historialProceso.ETAPA_PROCESO_ID == etapaProcesoId
                    select new HistorialProcesoDTOs() {NumeroOrden = historialProceso.NUMERO_ORDEN,OrdenTrabajoId =historialProceso.ORDEN_TRABAJO_ID,NombrePuntoVenta = puntoVenta.DESCRIPCION,FechaRegistro = historialProceso.FECHA_REGISTRO,NumeroPrendas = 0,UsuarioRecibeId = historialProceso.USUARIO_RECIBE_ID,UsuarioEntregaId = historialProceso.USUARIO_ENTREGA_ID};

                List < HistorialProcesoDTOs > _listaHistorialProcesoDtOses= new List<HistorialProcesoDTOs>();


                foreach (var objetoHistorialProcesoDTOs in historialProcesos)
                {

                    HistorialProcesoDTOs _historialProcesoDtOs= new HistorialProcesoDTOs();
                    _historialProcesoDtOs = objetoHistorialProcesoDTOs;
                    var detalleOrdenesTrabajo = from detalleOrdenTrabajo in _entidad.DETALLE_ORDEN_TRABAJO
                        where detalleOrdenTrabajo.ORDEN_TRABAJO_ID == objetoHistorialProcesoDTOs.OrdenTrabajoId
                        select detalleOrdenTrabajo;

                    _historialProcesoDtOs.NumeroPrendas =Convert.ToInt32(detalleOrdenesTrabajo.Sum(m => m.CANTIDAD));
                    _historialProcesoDtOs.UsuarioEntrega =
                        _entidad.USUARIO.Find(Convert.ToInt32(objetoHistorialProcesoDTOs.UsuarioEntregaId)).NOMBRE_USUARIO;

                    _historialProcesoDtOs.UsuarioRecibe =
                        _entidad.USUARIO.Find(Convert.ToInt32(objetoHistorialProcesoDTOs.UsuarioRecibeId)).NOMBRE_USUARIO;
                    _listaHistorialProcesoDtOses.Add(_historialProcesoDtOs);

                }

                return _listaHistorialProcesoDtOses;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        #endregion

        #region  TRANSACCIONAL

        
        /// <summary>
        /// Graba  el historial de  los reprocesos
        /// </summary>
        /// <param name="historialReprocesoDtOs"></param>
        public void GrabarHistorialReprocesos(HistorialReprocesoDTOs historialReprocesoDtOs)
        {
            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
                {
                    try
                    {

                        HISTORIAL_PROCESO historialProceso =_historialProcesoDaOs.GrabarHistorialProceso(historialReprocesoDtOs.HistorialProceso);

                        foreach (HISTORIAL_REPROCESO  historialReproceso in historialReprocesoDtOs.HistorialReprocesos)
                        {
                            historialReproceso.HISTORIAL_PROCESO_ID = historialProceso.HISTORIAL_PROCESO_ID;
                            _historialReprocesoDaOs.GrabarHistorialReproceso(historialReproceso);
                        }
                        
                        transaction.Complete();
                    
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

         }



        /// <summary>
        /// Obtiene el lsitado de  las ordenes de reproceso
        /// </summary>
        /// <param name="detalleOrdenTrabajoId"></param>
        /// <returns></returns>
        public IQueryable<DetalleHistorialReprocesoDTOs> ObtenerDetalleHistorialReprocesosPorDetalleOrdenTrabajoId(
            int detalleOrdenTrabajoId)
        {

            try
            {
                var detalleHistorialReprocesos = from historialReproceso in _entidad.HISTORIAL_REPROCESO
                    join detalleHistorialReproceso in _entidad.DETALLE_HISTORIAL_REPROCESO on
                        historialReproceso.HISTORIAL_REPROCESO_ID equals
                        detalleHistorialReproceso.HISTORIAL_REPROCESO_ID
                    join tipoReproceso in _entidad.TIPO_REPROCESO on detalleHistorialReproceso.TIPO_REPROCESO_ID equals
                        tipoReproceso.TIPO_REPROCESO_ID
                                                 where historialReproceso.DETALLE_PRENDA_ORDEN_TRABAJO_ID== detalleOrdenTrabajoId
                                                 select new DetalleHistorialReprocesoDTOs()
                    {
                        Motivo = detalleHistorialReproceso.MOTIVO,
                        TipoMotivoProceso = tipoReproceso.DESCRIPCION
                                                 };
                return detalleHistorialReprocesos;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Reporte de  reproceso por prenda
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>
        public IQueryable<ReprocesoDTOs> ObtenerReprocesoPorVariosParametros(int puntoVentaId, DateTime fechaDesde,DateTime fechaHasta)
        {
            try
            {
                var reprocesos = from HP in _entidad.HISTORIAL_PROCESO
                    join HRP in _entidad.HISTORIAL_REPROCESO on HP.HISTORIAL_PROCESO_ID equals HRP.HISTORIAL_PROCESO_ID
                    join DHR in _entidad.DETALLE_HISTORIAL_REPROCESO on HRP.HISTORIAL_REPROCESO_ID equals
                        DHR.HISTORIAL_REPROCESO_ID
                    join DP in _entidad.DETALLE_PRENDA_ORDEN_TRABAJO on HRP.DETALLE_PRENDA_ORDEN_TRABAJO_ID equals
                        DP.DETALLE_PRENDA_ORDEN_TRABAJO_ID
                    join C in _entidad.COLOR on DP.COLOR_ID equals C.COLOR_ID
                    join M in _entidad.MARCA on DP.MARCA_ID equals M.MARCA_ID
                    join TP in _entidad.TIPO_REPROCESO on DHR.TIPO_REPROCESO_ID equals TP.TIPO_REPROCESO_ID
                    join DOT in _entidad.DETALLE_ORDEN_TRABAJO on DP.DETALLE_ORDEN_TRABAJO_ID equals
                        DOT.DETALLE_ORDEN_TRABAJO_ID
                    join P in _entidad.PRODUCTO on DOT.PRODUCTO_ID equals P.PRODUCTO_ID
                    where
                        HP.PUNTO_VENTA_ID == puntoVentaId &&
                        EntityFunctions.TruncateTime(HP.FECHA_REGISTRO) >= fechaDesde &&
                        EntityFunctions.TruncateTime(HP.FECHA_REGISTRO) <= fechaHasta
                    select new ReprocesoDTOs()
                    {
                        NumeroOrden = HP.NUMERO_ORDEN,
                        TratamientoEspecial = DP.TRATAMIENTO_ESPECIAL,
                        Motivo = DHR.MOTIVO,
                        InformacionVisual = DP.INFORMACION_VISUAL,
                        EstadoPrenda = DP.ESTADO_PRENDA,
                        TipoReproceso = TP.DESCRIPCION,
                        NombrePrenda = P.NOMBRE,
                        Marca = M.DESCRIPCION,
                        Color = C.DESCRIPCION,
                        FechaReproceso = HP.FECHA_REGISTRO
                    };

                return reprocesos;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion
    }
}
