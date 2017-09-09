using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.General;

namespace Web.Util
{
    public class Colecciones
    {


        /// <summary>
        /// Obtiene el tipo de  documentos
        /// </summary>
        /// <returns></returns>
        public List<TipoDocumentoVistaModelo> ObtenerTipoDocumentos()
        {
            try
            {
                 List<TipoDocumentoVistaModelo> _tipoDocumentoVistaModelos= new List<TipoDocumentoVistaModelo>();


                TipoDocumentoVistaModelo _tipoDocumentoApellidoPaterno = new TipoDocumentoVistaModelo();
                _tipoDocumentoApellidoPaterno.TipoBusquedaId = 2;
                _tipoDocumentoApellidoPaterno.Busqueda = "APELLIDOS";
                _tipoDocumentoVistaModelos.Add(_tipoDocumentoApellidoPaterno);


                TipoDocumentoVistaModelo _tipoDocumentoNumeroCedula = new TipoDocumentoVistaModelo();
                _tipoDocumentoNumeroCedula.TipoBusquedaId = 1;
                _tipoDocumentoNumeroCedula.Busqueda = "NUMERO DE DOCUMENTO";
                _tipoDocumentoVistaModelos.Add(_tipoDocumentoNumeroCedula);


                TipoDocumentoVistaModelo _tipoRazonSocial = new TipoDocumentoVistaModelo();
                _tipoRazonSocial.TipoBusquedaId =3 ;
                _tipoRazonSocial.Busqueda = "RAZON SOCIAL";
                _tipoDocumentoVistaModelos.Add(_tipoRazonSocial);


                TipoDocumentoVistaModelo _tipoDocumentoPorDefecto = new TipoDocumentoVistaModelo();
                _tipoDocumentoPorDefecto.TipoBusquedaId = -1;
                _tipoDocumentoPorDefecto.Busqueda = "NINGUNO";
                _tipoDocumentoVistaModelos.Add(_tipoDocumentoPorDefecto);


                return _tipoDocumentoVistaModelos;
            }
            catch (Exception ex)
            {
                
                throw;
            }

        }
    }
}