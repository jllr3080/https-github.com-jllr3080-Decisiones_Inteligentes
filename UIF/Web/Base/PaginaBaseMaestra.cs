#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
#endregion
namespace Web.Base
{
    /// <summary>
    /// Pagina maestra base
    /// </summary>
    public class PaginaBaseMaestra: MasterPage
    {

        public PaginaBaseMaestra()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-EC");
            System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
        }

        protected virtual new BaseSeguridad User
        {
            get
            {
                // return HttpContext.Current.User as CustomPrincipal;
                return Session["Contexto"] as BaseSeguridad;
            }
        }
    }
}