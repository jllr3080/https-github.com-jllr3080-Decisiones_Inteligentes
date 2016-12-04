#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Seguridad.Proveedor.DTOs;
#endregion
namespace JLLR.Core.Seguridad.Proveedor.DAOs
{

    /// <summary>
    /// Varios  metodos del modulo de  seguridades
    /// </summary>
    public class TransaccionalDAOs:BaseDAOs
    {

        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private Decisiones_Inteligentes entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Ingresa al sistema 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        public UsuarioDTOs IngresoSistema(string nombreusuario, string claveUsuario, int puntoVentaId, int sucursalId)
        {
            try
            {
                var usuarios = from usuario in entidad.USUARIO
                               join usuarioPerfil in entidad.USUARIO_PERFIL on usuario.USUARIO_ID equals usuarioPerfil.USUARIO_ID
                               join perfil in entidad.PERFIL on usuarioPerfil.PERFIL_ID equals perfil.PERFIL_ID
                               join accesoPerfil in entidad.ACCESO_PERFIL on perfil.PERFIL_ID equals accesoPerfil.PERFIL_ID
                               join acceso in entidad.ACCESO on accesoPerfil.ACCESO_ID equals acceso.ACCESO_ID
                               join modulo in entidad.MODULO on acceso.MODULO_ID equals modulo.MODULO_ID
                               join submodulo in entidad.SUBMODULO on acceso.SUBMODULO_ID equals submodulo.SUBMODULO_ID
                               join sucursal in entidad.SUCURSAL on usuario.SUCURSAL_ID equals sucursal.SUCURSAL_ID
                               join puntoVenta in entidad.PUNTO_VENTA on usuario.PUNTO_VENTA_ID equals puntoVenta.PUNTO_VENTA_ID
                               where usuario.NOMBRE_USUARIO==nombreusuario && usuario.CLAVE_USUARIO== claveUsuario
                               select new UsuarioDTOs {UsuarioId = usuario.USUARIO_ID,SucursalId = usuario.SUCURSAL_ID,PuntoVentaId = usuario.PUNTO_VENTA_ID,NombreUsuario = usuario.NOMBRE_USUARIO, NombreSucursal = sucursal.DESCRIPCION,NombrePuntoVenta = puntoVenta.DESCRIPCION,HoraFinPuntoVenta = puntoVenta.HORA_FIN, HoraInicioPuntoVenta = puntoVenta.HORA_INICIO};
                return usuarios.FirstOrDefault();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Genera el menu  de acuerdo al usuario  revisa  el perfil
        /// </summary>
        /// <param name="usuarioId"></param>
        public IQueryable<AccesoDTOs> GenerarMenu(int usuarioId)
        {

            try
            {
                var accesos = from usuario in entidad.USUARIO
                    join usuarioPerfil in entidad.USUARIO_PERFIL on usuario.USUARIO_ID equals usuarioPerfil.USUARIO_ID
                    join accesoPerfil in entidad.ACCESO_PERFIL on usuarioPerfil.PERFIL_ID equals accesoPerfil.PERFIL_ID
                    join acceso in entidad.ACCESO on accesoPerfil.ACCESO_ID equals acceso.ACCESO_ID
                    join modulo in entidad.MODULO on acceso.MODULO_ID equals modulo.MODULO_ID
                    join submodulo in entidad.SUBMODULO on acceso.SUBMODULO_ID equals submodulo.SUBMODULO_ID
                    where usuario.USUARIO_ID == usuarioId && usuario.HABILITADO == true
                    select new AccesoDTOs {AccesoId = acceso.ACCESO_ID,Acceso = acceso.DESCRIPCION,ModuloId =modulo.MODULO_ID,Modulo = modulo.DESCRIPCION,SubModulo = submodulo.DESCRIPCION,SubmoduloId = submodulo.SUBMODULO_ID,Url = acceso.URL};
                return accesos;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
