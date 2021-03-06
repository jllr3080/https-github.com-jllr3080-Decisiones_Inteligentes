﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modeloParametrizacion = JLLR.Core.Inventario.Servicio.Modelo.Parametrizacion;
using modeloGeneral = JLLR.Core.General.Servicio.Modelo; 

#endregion
namespace JLLR.Core.Inventario.Servicio.Ensamblador
{

    /// <summary>
    /// Ingresa una  entidad y lo transforma en un modelo
    /// </summary>
    public class EnsambladorModelo
    {
       
        #region  PRODUCTO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modeloParametrizacion.ProductoModelo CrearProducto(entidad.PRODUCTO e)
        {
            modeloGeneral.ModeloModelo modelo = new modeloGeneral.ModeloModelo
            {
                ModeloId = Convert.ToInt32(e.MODELO_ID)
            };
            modeloParametrizacion.TipoProductoModelo tipoProducto = new modeloParametrizacion.TipoProductoModelo
            {
                TipoProductoId = Convert.ToInt32(e.TIPO_PRODUCTO_ID)
            };
            modeloGeneral.MaterialModelo material = new modeloGeneral.MaterialModelo
            {
                MaterialId = Convert.ToInt32(e.MATERIAL_ID)
            };
            modeloGeneral.MarcaModelo marca = new modeloGeneral.MarcaModelo
            {
                MarcaId = Convert.ToInt32(e.MARCA_ID)
            };
            return new modeloParametrizacion.ProductoModelo
            {
               ProductoId = e.PRODUCTO_ID,
               FechaCreacion = e.FECHA_CREACION,
               Nombre = e.NOMBRE,
               PedirMedida = e.PEDIR_MEDIDA,
               Modelo = modelo,
               TipoProducto = tipoProducto,
               Material = material,
               Marca = marca,
               Visible = e.VISIBLE,
               PrendaEspecial = e.PRENDA_ESPECIAL,
               TiempoEntrega = e.TIEMPO_ENTREGA,
               NumeroPrendas = e.NUMERO_PRENDAS,
               UsuarioId = e.USUARIO_ID,
               EstaHabilitado = e.ESTA_HABILITADO
               
               


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modeloParametrizacion.ProductoModelo> CrearProductos(IQueryable<entidad.PRODUCTO> listadoEntidad)
        {
            List<modeloParametrizacion.ProductoModelo> listaModelo = new List<modeloParametrizacion.ProductoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearProducto(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  PRODUCTO PRECIO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modeloParametrizacion.ProductoPrecioModelo CrearProductoPrecio(entidad.PRODUCTO_PRECIO e)
        {
           
            modeloParametrizacion.ProductoModelo _productoModelo= new modeloParametrizacion.ProductoModelo();
            _productoModelo.ProductoId =Convert.ToInt32(e.PRODUCTO_ID);

        

            return new modeloParametrizacion.ProductoPrecioModelo
            {
                ProductoPrecioId = e.PRODUCTO_PRECIO_ID,
                Producto = _productoModelo,
                FechaCreacion = e.FECHA_CREACION,
                EstaHabilitado = e.ESTA_HABILITADO,
                Modificable = e.MODIFICABLE,
                Precio = e.PRECIO
                
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modeloParametrizacion.ProductoPrecioModelo> CrearProductosPrecio(IQueryable<entidad.PRODUCTO_PRECIO> listadoEntidad)
        {
            List<modeloParametrizacion.ProductoPrecioModelo> listaModelo = new List<modeloParametrizacion.ProductoPrecioModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearProductoPrecio(entidad));
            }
            return listaModelo;

        }

        #endregion

        
    }
}