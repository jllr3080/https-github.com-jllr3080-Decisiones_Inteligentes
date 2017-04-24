#region using
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
    /// <summary>
    /// Metodos  de  Usuario Perfil
    /// </summary>
    public class UsuarioPerfilDAOs:BaseDAOs
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();

        /// <summary>
        /// Graba  Usuario Perfil
        /// </summary>
        /// <param name="usuarioPerfil"></param>
        public void GrabarUsuarioPerfil(USUARIO_PERFIL usuarioPerfil)
        {
            try
            {
                _entidad.USUARIO_PERFIL.Add(usuarioPerfil);
                _entidad.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
