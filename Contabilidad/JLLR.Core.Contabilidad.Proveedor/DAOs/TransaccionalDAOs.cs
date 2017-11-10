#region using
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Contabilidad.Proveedor.DTOs;

#endregion
namespace JLLR.Core.Contabilidad.Proveedor.DAOs
{
    /// <summary>
    /// Metodos  generales 
    /// </summary>
    public class TransaccionalDAOs : BaseDAOs
    {
        #region DECLARACIONES E INSTANCIAS
        private readonly CuentaPorCobrarDAOs _cuentaPorCobrarDaOs = new CuentaPorCobrarDAOs();
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();
        private readonly  CuentaPorPagarDAOs _cuentasPorPagarDaOs= new CuentaPorPagarDAOs();
        private readonly  HistorialCuentaPorCobrarDAOs _historialCuentaPorCobrarDaOs= new HistorialCuentaPorCobrarDAOs();
        private readonly  HistorialCuentaPorPagarDAOs _historialCuentaPorPagarDaOs= new HistorialCuentaPorPagarDAOs();
        #endregion


        #region TRANSACCIONAL

        /// <summary>
        /// Graba el asiento tanto  positivo como negativo
        /// </summary>
        public void GrabarAsiento(AsientoDTOs asientoDtOs)
        {
            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    CUENTA_POR_COBRAR cuentaPorCobrar=  _cuentaPorCobrarDaOs.GrabarCuentaPorCobrar(asientoDtOs.CuentaPorCobrar);


                    if (asientoDtOs.HistorialCuentaPorCobrar != null)
                    {
                        asientoDtOs.HistorialCuentaPorCobrar.CUENTA_POR_COBRAR_ID = cuentaPorCobrar.CUENTA_POR_COBRAR_ID;
                        _historialCuentaPorCobrarDaOs.GrabarHistorialCuentaPorCobrar(asientoDtOs.HistorialCuentaPorCobrar);
                    }
                    

                    CUENTA_POR_PAGAR cuentaPorPagar= _cuentasPorPagarDaOs.GrabarCuentaPorPagar(asientoDtOs.CuentaPorPagar);

                    if (asientoDtOs.HistorialCuentaPorPagar != null)
                    {
                        asientoDtOs.HistorialCuentaPorPagar.CUENTA_POR_PAGAR_ID = cuentaPorPagar.CUENTA_POR_PAGAR_ID;
                        _historialCuentaPorPagarDaOs.GrabarHistorialCuentaPorPagar(asientoDtOs.HistorialCuentaPorPagar);
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
        /// Graba la cuenta por pagar  
        /// </summary>
        /// <param name="cuentaPorCobrarDtOs"></param>
        /// <returns></returns>
        public CUENTA_POR_COBRAR GrabarCuentaPorCobrarCompleta(CuentaPorCobrarDTOs cuentaPorCobrarDtOs)
        {
            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    CUENTA_POR_COBRAR cuentaPorCobrar =
                        _cuentaPorCobrarDaOs.GrabarCuentaPorCobrar(cuentaPorCobrarDtOs.CuentaPorCobrar);

             
                   
                    transaction.Complete();

                    return cuentaPorCobrarDtOs.CuentaPorCobrar;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        /// <summary>
        /// Obtiene  el historial de cuenta por cobrar  por numero de identificacion
        /// </summary>
        public List<CuentaPorCobrarDTOs> ObtenerHistorialCuentaPorCobrarPorNumeroidentificacion( string numeroIdentificacion)
        {
            try
            {
                var cuentasPorCobrar = from cuentaPorCobrar in _entidad.CUENTA_POR_COBRAR
                                       join historialCuentaPorCobrar in _entidad.HISTORIAL_CUENTA_POR_COBRAR on
                                           cuentaPorCobrar.CUENTA_POR_COBRAR_ID equals historialCuentaPorCobrar.CUENTA_POR_COBRAR_ID
                                       join cliente in _entidad.CLIENTE on cuentaPorCobrar.CLIENTE_ID equals cliente.CLIENTE_ID
                                       join individuo in _entidad.INDIVIDUO on cliente.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                                       where individuo.NUMERO_IDENTIFICACION == numeroIdentificacion
                                       select new CuentaPorCobrarDTOs() { HistorialCuentaPorCobrar = historialCuentaPorCobrar, CuentaPorCobrar = cuentaPorCobrar ,Cliente = individuo.PRIMER_CAMPO + individuo.SEGUNDO_CAMPO+ individuo.TERCER_CAMPO+ individuo.CUARTO_CAMPO};

                List<CuentaPorCobrarDTOs> _listaCuentaPorCobrarDtOses = new List<CuentaPorCobrarDTOs>();

                foreach (var objetoCuentaPorCobrar in cuentasPorCobrar)
                {
                    _listaCuentaPorCobrarDtOses.Add(objetoCuentaPorCobrar);

                }

                return _listaCuentaPorCobrarDtOses;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        public  List<CuentaPorCobrarDTOs> ObtenerHistorialCuentaPorCobrarPorNumeroOrden(string numeroOrden)
        {
            try
            {
                var cuentasPorCobrar = from cuentaPorCobrar in _entidad.CUENTA_POR_COBRAR
                    join historialCuentaPorCobrar in _entidad.HISTORIAL_CUENTA_POR_COBRAR on
                        cuentaPorCobrar.CUENTA_POR_COBRAR_ID equals historialCuentaPorCobrar.CUENTA_POR_COBRAR_ID
                    join cliente in _entidad.CLIENTE on cuentaPorCobrar.CLIENTE_ID equals cliente.CLIENTE_ID
                    join individuo in _entidad.INDIVIDUO on cliente.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                    where cuentaPorCobrar.NUMERO_ORDEN == numeroOrden
                                       select new CuentaPorCobrarDTOs() { HistorialCuentaPorCobrar = historialCuentaPorCobrar, CuentaPorCobrar = cuentaPorCobrar, Cliente = individuo.PRIMER_CAMPO + individuo.SEGUNDO_CAMPO + individuo.TERCER_CAMPO + individuo.CUARTO_CAMPO };

                List<CuentaPorCobrarDTOs> _listaCuentaPorCobrarDtOses=  new List<CuentaPorCobrarDTOs>();

                foreach (var objetoCuentaPorCobrar in cuentasPorCobrar)
                {
                    _listaCuentaPorCobrarDtOses.Add(objetoCuentaPorCobrar);

                }

                return _listaCuentaPorCobrarDtOses;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<CuentaPorCobrarDTOs> ObtenerHistorialCuentaPorCobrarPorVariosParametros(string numeroOrden,int puntoVentaId, int sucursalId)
        {
            try
            {
                var cuentasPorCobrar = from cuentaPorCobrar in _entidad.CUENTA_POR_COBRAR
                                       join historialCuentaPorCobrar in _entidad.HISTORIAL_CUENTA_POR_COBRAR on
                                           cuentaPorCobrar.CUENTA_POR_COBRAR_ID equals historialCuentaPorCobrar.CUENTA_POR_COBRAR_ID
                                       join cliente in _entidad.CLIENTE on cuentaPorCobrar.CLIENTE_ID equals cliente.CLIENTE_ID
                                       join individuo in _entidad.INDIVIDUO on cliente.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                                       where cuentaPorCobrar.NUMERO_ORDEN == numeroOrden && cuentaPorCobrar.PUNTO_VENTA_ID==puntoVentaId && cuentaPorCobrar.SUCURSAL_ID==sucursalId
                                       select new CuentaPorCobrarDTOs() { HistorialCuentaPorCobrar = historialCuentaPorCobrar, CuentaPorCobrar = cuentaPorCobrar, Cliente = individuo.PRIMER_CAMPO + individuo.SEGUNDO_CAMPO + individuo.TERCER_CAMPO + individuo.CUARTO_CAMPO };

                List<CuentaPorCobrarDTOs> _listaCuentaPorCobrarDtOses = new List<CuentaPorCobrarDTOs>();

                foreach (var objetoCuentaPorCobrar in cuentasPorCobrar)
                {
                    _listaCuentaPorCobrarDtOses.Add(objetoCuentaPorCobrar);

                }

                return _listaCuentaPorCobrarDtOses;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<CuentaPorPagarDTOs> ObtenerHistorialCuentaPorPagarPorVariosParametros(string numeroOrden, int puntoVentaId, int sucursalId)
        {
            try
            {
                var cuentasPorPagar = from cuentaPorPagar in _entidad.CUENTA_POR_PAGAR
                                       join historialCuentaPorPagar in _entidad.HISTORIAL_CUENTA_POR_PAGAR on cuentaPorPagar.CUENTA_POR_PAGAR_ID equals historialCuentaPorPagar.CUENTA_POR_PAGAR_ID
                                       join proveedor in _entidad.PROVEEDOR on cuentaPorPagar.PROVEDOR_ID equals proveedor.PROVEEDOR_ID
                                       join individuo in _entidad.INDIVIDUO on proveedor.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                                       where cuentaPorPagar.NUMERO_ORDEN == numeroOrden && cuentaPorPagar.SUCURSAL_ID==sucursalId && cuentaPorPagar.PUNTO_VENTA_ID==puntoVentaId
                                      select new CuentaPorPagarDTOs() { HistorialCuentaPorPagar = historialCuentaPorPagar, CuentaPorPagar = cuentaPorPagar, proveedor = individuo.PRIMER_CAMPO + individuo.SEGUNDO_CAMPO + individuo.TERCER_CAMPO + individuo.CUARTO_CAMPO };

                List<CuentaPorPagarDTOs> _listaCuentaPorPagarDtOses = new List<CuentaPorPagarDTOs>();

                foreach (var objetoCuentaPorPagar in cuentasPorPagar)
                {
                    _listaCuentaPorPagarDtOses.Add(objetoCuentaPorPagar);

                }

                return _listaCuentaPorPagarDtOses;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene el historial de las cuentas por  cobrar por numero de  orden
        /// </summary>
        /// <param name="numeroOrden"></param>
        public List<CuentaPorPagarDTOs> ObtenerHistorialCuentaPorPagarPorNumeroOrden(string numeroOrden)
        {
            try
            {
                var cuentasPorPagar = from cuentaPorPagar in _entidad.CUENTA_POR_PAGAR
                                      join historialCuentaPorPagar in _entidad.HISTORIAL_CUENTA_POR_PAGAR on cuentaPorPagar.CUENTA_POR_PAGAR_ID equals historialCuentaPorPagar.CUENTA_POR_PAGAR_ID
                                      join proveedor in _entidad.PROVEEDOR on cuentaPorPagar.PROVEDOR_ID equals proveedor.PROVEEDOR_ID
                                      join individuo in _entidad.INDIVIDUO on proveedor.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                                      where cuentaPorPagar.NUMERO_ORDEN == numeroOrden
                                      select new CuentaPorPagarDTOs() { HistorialCuentaPorPagar = historialCuentaPorPagar, CuentaPorPagar = cuentaPorPagar, proveedor = individuo.PRIMER_CAMPO + individuo.SEGUNDO_CAMPO + individuo.TERCER_CAMPO + individuo.CUARTO_CAMPO };

                List<CuentaPorPagarDTOs> _listaCuentaPorPagarDtOses = new List<CuentaPorPagarDTOs>();

                foreach (var objetoCuentaPorPagar in cuentasPorPagar)
                {
                    _listaCuentaPorPagarDtOses.Add(objetoCuentaPorPagar);

                }

                return _listaCuentaPorPagarDtOses;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtener  las cuentas  por  cobrar  por  fecha desde y  hasta  y el punto de  venta
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<CuentaPorPagarDTOs> ObtenerCuentaPorPagarPorFechas(DateTime fechaDesde, DateTime fechaHasta,
            int sucursalId)
        {

            try
            {
                var cuentasPorPagar = from cuentaPorPagar in _entidad.CUENTA_POR_PAGAR
                                      join historialCuentaPorPagar in _entidad.HISTORIAL_CUENTA_POR_PAGAR on cuentaPorPagar.CUENTA_POR_PAGAR_ID equals historialCuentaPorPagar.CUENTA_POR_PAGAR_ID
                                      join proveedor in _entidad.PROVEEDOR on cuentaPorPagar.PROVEDOR_ID equals proveedor.PROVEEDOR_ID
                                      join individuo in _entidad.INDIVIDUO on proveedor.INDIVIDUO_ID equals individuo.INDIVIDUO_ID
                                      where cuentaPorPagar.PUNTO_VENTA_ID==sucursalId && EntityFunctions.TruncateTime(cuentaPorPagar.FECHA_CREACION) >=fechaDesde  && EntityFunctions.TruncateTime(cuentaPorPagar.FECHA_CREACION) <= fechaHasta
                                      select new CuentaPorPagarDTOs() { HistorialCuentaPorPagar = historialCuentaPorPagar, CuentaPorPagar = cuentaPorPagar, proveedor = individuo.PRIMER_CAMPO + individuo.SEGUNDO_CAMPO + individuo.TERCER_CAMPO + individuo.CUARTO_CAMPO };

                List<CuentaPorPagarDTOs> _listaCuentaPorPagarDtOses = new List<CuentaPorPagarDTOs>();

                foreach (var objetoCuentaPorPagar in cuentasPorPagar)
                {
                    _listaCuentaPorPagarDtOses.Add(objetoCuentaPorPagar);

                }

                return _listaCuentaPorPagarDtOses;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }



        /// <summary>
        /// Obtiene las aplicaciones de pago para ser validadas
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="mesId"></param>
        /// <returns></returns>
        public IQueryable<AplicacionPagoDTOs> ObtenerAplicacionPagosPorPuntoVentaIdYMesId(int puntoVentaId, int mesId)
        {
            try
            {
                var aplicacionPagos = from aplicacionPago in _entidad.APLICACION_PAGO
                    join cierreMes in _entidad.CIERRE_MES on aplicacionPago.CIERRE_MES_ID equals cierreMes.CIERRE_MES_ID
                    join usuario in _entidad.USUARIO on aplicacionPago.USUARIO_APLICA_ID equals usuario.USUARIO_ID
                    join puntoVenta in _entidad.PUNTO_VENTA on cierreMes.PUNTO_VENTA_ID equals puntoVenta.PUNTO_VENTA_ID
                    join mes in _entidad.MES on cierreMes.MES_ID equals mes.MES_ID
                    where cierreMes.PUNTO_VENTA_ID == puntoVentaId && cierreMes.MES_ID == mesId
                    select new AplicacionPagoDTOs()
                    {
                        PuntoVenta = puntoVenta.DESCRIPCION,
                        Mes = mes.DESCRIPCION,
                        FechaCierreMes = cierreMes.FECHA_CREACION,
                        ValorCierre = cierreMes.VALOR,
                        UsuarioAplicacion = usuario.NOMBRE_USUARIO,
                        AplicacionPago = aplicacionPago
                    };  

                return aplicacionPagos;
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        #endregion
    }
}
