<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWebformCarrito_BARRIENTO.Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <asp:TextBox ID="txtBoxBuscar" runat="server" ></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
    <br />
<div class="row row-cols-1 row-cols-md-3 g-4">  
   <% foreach (Dominio.Articulo art in ListaArticulo)
              {  %> 
  <div class="col">   
    <div class="card">
      <img src="<%:art.ImagenUrl %>" class="card-img-top" alt="No disponible" onerror="this.src">
      <div class="card-body">
        <h5 class="card-title"> <%:art.Nombre %></h5>
        <p class="card-text"><%:art.Descripcion%></p>
        <p class="card-text">$<%:art.Precio.ToString("N2")%></p>
          <button><a href="Default.aspx?id=<%:art.Id%>">Agregar</a></button>
      </div>
    </div>
  </div>
         <% }  %>
</div>


</asp:Content>
