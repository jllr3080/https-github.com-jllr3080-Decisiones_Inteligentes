using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Venta.Negocio;

namespace Web.Venta
{
    /// <summary>
    /// Descripción breve de ManejadorImagen
    /// </summary>
    public class ManejadorImagen : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["Registro"] != null)
            {
                DetalleOrdenTrabajoFotografiaVistaModelo detalleOrdenTrabajoFotografia =
                    (DetalleOrdenTrabajoFotografiaVistaModelo) (context.Session["Registro"]);
                byte[] imagen = detalleOrdenTrabajoFotografia.ImagenPrenda;
                context.Response.ContentType = "image/png";
                context.Response.OutputStream.Write(imagen, 0, imagen.Length);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}