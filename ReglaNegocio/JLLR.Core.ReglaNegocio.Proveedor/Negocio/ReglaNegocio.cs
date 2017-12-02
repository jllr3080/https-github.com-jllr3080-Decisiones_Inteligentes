#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.ReglaNegocio.Proveedor.DAOs;
using JLLR.Core.ReglaNegocio.Proveedor.DTOs;

#endregion

namespace JLLR.Core.ReglaNegocio.Proveedor.Negocio
{
    /// <summary>
    /// Reglas de  negocio
    /// </summary>
    public class ReglaNegocio
    {
        #region DECLARACIONES E INSTANCIAS

        private readonly  TransaccionalDAOs _transaccionalDaOs= new TransaccionalDAOs();
        private readonly  ReglaDAOs _reglaDaOs= new ReglaDAOs();
        #endregion


        #region REGLA

        /// <summary>
        /// Obtiene la promocion por  Id
        /// </summary>
        /// <param name="reglaId"></param>
        /// <returns></returns>
        public REGLA ObtenerReglaPorId(int reglaId)
        {
            try
            {
                return _reglaDaOs.ObtenerReglaPorId(reglaId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion      

        #region TRANSACCIONAL

        /// <summary>
        /// Obtiene  las  promociones  vigentes 
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>

        public IQueryable<REGLA> ObtenerPromocionesVigentes(int puntoVentaId, int sucursalId)
        {
            try
            {
                 return  _transaccionalDaOs.ObtenerPromocionesVigentes(puntoVentaId,sucursalId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtener las reglas para aplicar     
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public IQueryable<ReglaDTOs> ObtenerReglasPorPuntoVentaIdYSucursalId(int puntoVentaId, int sucursalId)
        {
            try
            {

                return _transaccionalDaOs.ObtenerReglasPorPuntoVentaIdYSucursalId(puntoVentaId, sucursalId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #region ADMINISTRACION PROMOCIONES

        /// <summary>
        /// Grabar promociones
        /// </summary>
        /// <param name="reglaCompletaDtOs"></param>
        public void GrabarPromocionesCompleta(ReglaCompletaDTOs reglaCompletaDtOs)
        {
            try
            {
                _transaccionalDaOs.GrabarPromocionesCompleta(reglaCompletaDtOs);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Actualizar promociones
        /// </summary>
        /// <param name="reglaCompletaDtOs"></param>
        public void ActualizarPromocionesCompleta(ReglaCompletaDTOs reglaCompletaDtOs)
        {
            try
            {
                _transaccionalDaOs.ActualizarPromocionesCompleta(reglaCompletaDtOs);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Obtiene las promociones
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>

        public IQueryable<ReglaCompletaDTOs> ObtenerPromociones(int puntoVentaId)
        {
            try
            {
                return _transaccionalDaOs.ObtenerPromociones(puntoVentaId);

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        #endregion
        #endregion

        #region REGLA NEGOCIO

        /// <summary>
        /// Ejeuta las  reglas  de  negocio
        /// </summary>
        /// <param name="parametroEntradaReglaNegocio"></param>
        /// <returns></returns>
        public ParametroSalidaReglaNegocioDTOs EjecucionReglaNegocio(ParametroEntradaReglaNegocioDTOs parametroEntradaReglaNegocio)
        {

            try
            {

                ParametroSalidaReglaNegocioDTOs _parametroSalidaReglaNegocio = new ParametroSalidaReglaNegocioDTOs();
                _parametroSalidaReglaNegocio.ValorUnitario = parametroEntradaReglaNegocio.ValorUnitario;
                _parametroSalidaReglaNegocio.ValorTotal = parametroEntradaReglaNegocio.ValorTotal;
                _parametroSalidaReglaNegocio.ProductoId = parametroEntradaReglaNegocio.ProductoId;
                _parametroSalidaReglaNegocio.Cantidad = parametroEntradaReglaNegocio.Cantidad;

                //Promocion de ternos
                if (parametroEntradaReglaNegocio.ProductoId == Convert.ToInt32(Util.Enum.Producto.Terno))
                {
                   ReglaDTOs  reglaDtOs =_transaccionalDaOs.ObtenerReglasPorParametrosEntrada(parametroEntradaReglaNegocio);
                    parametroEntradaReglaNegocio.ValorPromocion = reglaDtOs.Porcentaje;
                    decimal cociente = Convert.ToDecimal(parametroEntradaReglaNegocio.Cantidad / 3);
                    decimal residuo = Convert.ToDecimal(parametroEntradaReglaNegocio.Cantidad % 3);
                    string numStr = cociente.ToString();
                    int parteEnteraCociente = int.Parse(numStr.Split('.')[0]);
                    //No es promocion
                    if (cociente < 1)
                    {
                        _parametroSalidaReglaNegocio.ValorTotalPagar = _parametroSalidaReglaNegocio.ValorTotal;
                        _parametroSalidaReglaNegocio.ValorDescuento = 0;
                        _parametroSalidaReglaNegocio.NombrePromocion = "NINGUNA";
                        _parametroSalidaReglaNegocio.PromocionId = 0;
                    }
                    //Es promocion
                    else if (cociente >= 1 && residuo == 0)
                    {
                        _parametroSalidaReglaNegocio.ValorTotalPagar = parametroEntradaReglaNegocio.ValorPromocion *
                                                                       parteEnteraCociente;
                        _parametroSalidaReglaNegocio.ValorDescuento = parametroEntradaReglaNegocio.ValorTotal -
                                                                      _parametroSalidaReglaNegocio.ValorTotalPagar;
                        _parametroSalidaReglaNegocio.NombrePromocion = reglaDtOs.NombreRegla;
                        _parametroSalidaReglaNegocio.PromocionId = reglaDtOs.ReglaId;
                    }
                    //Es promocion  y adicional   no tiene promocion porque no es la cantidad  de 
                    // prendas  para ser exacata la promocion
                    else
                    {
                        _parametroSalidaReglaNegocio.ValorTotalPagar = (parametroEntradaReglaNegocio.ValorPromocion *
                                                                        parteEnteraCociente) +
                                                                       (residuo *
                                                                        parametroEntradaReglaNegocio.ValorUnitario);
                        _parametroSalidaReglaNegocio.ValorDescuento = parametroEntradaReglaNegocio.ValorTotal -
                                                                      _parametroSalidaReglaNegocio.ValorTotalPagar;
                        _parametroSalidaReglaNegocio.NombrePromocion = reglaDtOs.NombreRegla;
                        _parametroSalidaReglaNegocio.PromocionId = reglaDtOs.ReglaId;

                    }

                }
                //Promocion de  edredones
                else if (parametroEntradaReglaNegocio.ProductoId ==
                         Convert.ToInt32(Util.Enum.Producto.EdredonUnaPlazaYMedia) ||
                         parametroEntradaReglaNegocio.ProductoId ==
                         Convert.ToInt32(Util.Enum.Producto.EdredonDosPlazasYMedia) ||
                         parametroEntradaReglaNegocio.ProductoId == Convert.ToInt32(Util.Enum.Producto.EdredonTresPlazas) ||
                         parametroEntradaReglaNegocio.ProductoId == Convert.ToInt32(Util.Enum.Producto.EdredonPlumon) || parametroEntradaReglaNegocio.ProductoId == Convert.ToInt32(Util.Enum.Producto.EdredonUnaPlaza))
                {
                    ReglaDTOs reglaDtOs = _transaccionalDaOs.ObtenerReglasPorParametrosEntrada(parametroEntradaReglaNegocio);
                    parametroEntradaReglaNegocio.ValorPromocion = reglaDtOs.Porcentaje;
                    decimal valorDescuento = (Convert.ToDecimal(parametroEntradaReglaNegocio.ValorTotal)*
                                              Convert.ToDecimal(parametroEntradaReglaNegocio.ValorPromocion))/100;
                    _parametroSalidaReglaNegocio.ValorTotalPagar = Convert.ToDecimal(parametroEntradaReglaNegocio.ValorTotal)-Convert.ToDecimal(valorDescuento);
                    _parametroSalidaReglaNegocio.ValorDescuento = valorDescuento;
                    _parametroSalidaReglaNegocio.NombrePromocion = reglaDtOs.NombreRegla;
                    _parametroSalidaReglaNegocio.PromocionId = reglaDtOs.ReglaId;

                }
                //Promocion de  Camisas
                else if (parametroEntradaReglaNegocio.ProductoId == Convert.ToInt32(Util.Enum.Producto.Camisa))
                {
                    ReglaDTOs reglaDtOs = _transaccionalDaOs.ObtenerReglasPorParametrosEntrada(parametroEntradaReglaNegocio);
                    parametroEntradaReglaNegocio.ValorPromocion = reglaDtOs.Porcentaje;
                    decimal cociente = Convert.ToDecimal(parametroEntradaReglaNegocio.Cantidad / 5);
                    decimal residuo = Convert.ToDecimal(parametroEntradaReglaNegocio.Cantidad % 5);
                    string numStr = cociente.ToString();
                    int parteEnteraCociente = int.Parse(numStr.Split('.')[0]);
                    //No es promocion
                    if (cociente < 1)
                    {
                        _parametroSalidaReglaNegocio.ValorTotalPagar = _parametroSalidaReglaNegocio.ValorTotal;
                        _parametroSalidaReglaNegocio.ValorDescuento = 0;
                        _parametroSalidaReglaNegocio.NombrePromocion = "NINGUNA";
                        _parametroSalidaReglaNegocio.PromocionId = 0;
                    }
                    //Es promocion
                    else if (cociente >= 1 && residuo == 0)
                    {
                        _parametroSalidaReglaNegocio.ValorTotalPagar = parametroEntradaReglaNegocio.ValorPromocion *
                                                                       parteEnteraCociente;
                        _parametroSalidaReglaNegocio.ValorDescuento = parametroEntradaReglaNegocio.ValorTotal -
                                                                      _parametroSalidaReglaNegocio.ValorTotalPagar;
                        _parametroSalidaReglaNegocio.NombrePromocion = reglaDtOs.NombreRegla;
                        _parametroSalidaReglaNegocio.PromocionId = reglaDtOs.ReglaId;
                    }
                    //Es promocion  y adicional   no tiene promocion porque no es la cantidad  de 
                    // prendas  para ser exacata la promocion
                    else
                    {
                        _parametroSalidaReglaNegocio.ValorTotalPagar = (parametroEntradaReglaNegocio.ValorPromocion *
                                                                        parteEnteraCociente) +
                                                                       (residuo *
                                                                        parametroEntradaReglaNegocio.ValorUnitario);
                        _parametroSalidaReglaNegocio.ValorDescuento = parametroEntradaReglaNegocio.ValorTotal -
                                                                      _parametroSalidaReglaNegocio.ValorTotalPagar;
                        _parametroSalidaReglaNegocio.NombrePromocion = reglaDtOs.NombreRegla;
                        _parametroSalidaReglaNegocio.PromocionId = reglaDtOs.ReglaId;

                    }
                }
                else
                {
                    _parametroSalidaReglaNegocio.ValorTotalPagar = _parametroSalidaReglaNegocio.ValorTotal;
                    _parametroSalidaReglaNegocio.ValorDescuento = 0;
                    _parametroSalidaReglaNegocio.NombrePromocion = "NINGUNA";
                    _parametroSalidaReglaNegocio.PromocionId = 0;
                }



                return _parametroSalidaReglaNegocio;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion           
    }
}
