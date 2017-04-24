#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Seguridad.Proveedor.DAOs
{
    public class UsuarioDAOS : BaseDAOs
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();

        /// <summary>
        /// Graba el usuario
        /// </summary>
        /// <param name="usuario"></param>
        public USUARIO GrabarUsuario(USUARIO usuario)
        {
           
                try
                {
                    _entidad.USUARIO.Add(usuario);
                    _entidad.SaveChanges();
                    return usuario;
                }
                catch (Exception ex)
                {

                    throw;
                }

           
        }
    }
}
