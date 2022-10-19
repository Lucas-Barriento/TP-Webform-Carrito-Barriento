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
        public string algo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio= new ArticuloNegocio();
            ListaArticulo = negocio.Listar();
            //dgvArticulos.DataSource = negocio.Listar();
            //dgvArticulos.DataBind();
            algo = Request.QueryString["id"].ToString();
            
        }

        //protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var id =  dgvArticulos.SelectedRow.Cells[0];
        //    var id2 = dgvArticulos.SelectedDataKey.Value.ToString();
        //}

    }
}