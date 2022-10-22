using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebGrease.Css.Ast.Selectors;

namespace TPWebformCarrito_BARRIENTO
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        public List<ArticuloCarrito> ListaCarrito = new List<ArticuloCarrito>();
        public int idSeleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaCarrito = CarritoSession();
            bool existente = false;
            ArticuloNegocio negocio= new ArticuloNegocio();
            ListaArticulo = negocio.Listar();

            if (Request.QueryString["id"] != null)
            {
                idSeleccionado = int.Parse(Request.QueryString["id"]);
                ArticuloCarrito aux = new ArticuloCarrito();

                foreach ( var art in ListaCarrito)
                {
                     if (art.Id == idSeleccionado)
                    {
                        art.Cantidad++;
                        
                        existente = true;
                        //envia cambios a session
                        Session.Add("ArticulosEnCarrito", ListaCarrito);
                    }
                }
                if (!existente)
                {   // con el idSeleccionado busca el objeto a agregar  
                    Articulo obj = ListaArticulo.Find((x) => x.Id == idSeleccionado);
                    //aux.Id=idSeleccionado;
                    aux.Id = idSeleccionado;
                    aux.Descripcion = (string)obj.Descripcion;
                    aux.Nombre = (string)obj.Nombre;
                    aux.Precio = (decimal)obj.Precio;
                    aux.ImagenUrl = (string)obj.ImagenUrl;
                    aux.Codigo = (string)obj.Codigo;
                    aux.categoria = (Categoria)obj.categoria;
                    aux.marca = (Marca)obj.marca;
                    aux.Cantidad = (int)1;
                    ListaCarrito.Add(aux);
                    Session.Add("ArticulosEnCarrito", ListaCarrito);

                }
            }   

        }

        //se fija si en session ya hay una lista de art y si no, le asigna una vacia
        public List<ArticuloCarrito> CarritoSession()
        {
            List<ArticuloCarrito> Carrito = Session["ArticulosEnCarrito"] != null ? (List<ArticuloCarrito>)(Session["ArticulosEnCarrito"]) : new List<ArticuloCarrito>();
            return Carrito;
        }

    }
}