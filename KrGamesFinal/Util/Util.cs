using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrGamesFinal.Util
{
    public class Util
    {
        public static string RetornarCarrinhoId()
        {
            if (HttpContext.Current.Session["CarrinhoId"] == null)
            {
                Guid novoGuid = Guid.NewGuid();
                HttpContext.Current.Session["CarrinhoId"] = novoGuid.ToString();
            }
            return HttpContext.Current.Session["CarrinhoId"].ToString();
        }

        internal static void ResetarGuid()
        {
            Guid novoGuid = Guid.NewGuid();
            HttpContext.Current.Session["CarrinhoId"] = novoGuid.ToString();
        }
    }
}