<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWebformCarrito_BARRIENTO.Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<%--    <style>
    .oculto{
        display: none;
    }
</style>
    <asp:GridView runat="server" ID="dgvArticulos" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto"/>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" /> 
        </Columns>
        
    </asp:GridView>--%>



<div class="row row-cols-1 row-cols-md-3 g-4">
   <% foreach (Dominio.Articulo art in ListaArticulo)
              {  %> 
  <div class="col">   
    <div class="card">
        
      <img src="<%:art.ImagenUrl %>" class="card-img-top" alt="...">
      <div class="card-body">
        <h5 class="card-title"> <%:art.Nombre %></h5>
        <p class="card-text"><%:art.Descripcion %></p>
        <p class="card-text">$<%:art.Precio %></p>
        <a href="Default.aspx?id=<%:art.Id%>">Agregar</a>
      </div>
    </div>
  </div>
         <% }  %>
</div>


</asp:Content>
