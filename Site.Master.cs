using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;
using Dominio;
using Negocio;

namespace TPWebformCarrito_BARRIENTO
{
    public partial class SiteMaster : MasterPage
    {
        public int idSeleccionado { get; set; }
        public List<ArticuloCarrito> ListaCarrito = new List<ArticuloCarrito>();

        public decimal TotalCarrito()
        {
            decimal tot = 0;
            foreach (var art in CarritoSession())
            {
                tot += art.Precio*art.Cantidad;
            }

            return tot;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["idQuitar"] != null)
            {
                idSeleccionado = int.Parse(Request.QueryString["idQuitar"]);
                ListaCarrito = CarritoSession();
                Session.Add("ArticulosEnCarrito",(ListaCarrito.FindAll(x => x.Id != idSeleccionado)));
            }
            else if (Request.QueryString["vaciarCarrito"] != null)
            {
                ListaCarrito.Clear();
                Session.Add("ArticulosEnCarrito",null);
            }   
            
        }
        public List<ArticuloCarrito> CarritoSession()
        {   
            List<ArticuloCarrito> Carrito = Session["ArticulosEnCarrito"] != null ? (List<ArticuloCarrito>)(Session["ArticulosEnCarrito"]) : new List<ArticuloCarrito>();
            return Carrito;
        }

        

    }
}