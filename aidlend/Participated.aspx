<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter.master" AutoEventWireup="true" CodeFile="Participated.aspx.cs" Inherits="Participated" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="page-header text-white mb-5" style="background-image:url('images/pexels-photo-1166990.jpeg'); background-repeat:no-repeat; background-size:cover;background-position:center;" >
    <div class="container text-center">
        <h1 class="page-title">veuillez assister à l'événement</h1>
    </div>
</div>
<form runat="server">
<div style="height:20vh;">

</div>
<div class="container">
<div class="row">
    <div id="irntable" class="col-12 text-center" runat="server">
        <h3>Merci <%=user %> pour participer a l evenement <%=evnt %></h3>
        <p>Nom : <%=user %></p>
        <p>Evenement : <%=evnt %></p>
        <p>Date : <%=DateTime.Now %></p>
        <h4>Veuillez apporter ceci avec vous le jour de l'événement</h4>
    </div>
</div>
<asp:Button Text="imprimer" class="btn" runat="server" ID="print" OnClick="print_Click" />
</div>
<div style="height:20vh;">

</div>
</form>
</asp:Content>

