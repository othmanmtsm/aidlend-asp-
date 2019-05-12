<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter.master" AutoEventWireup="true" CodeFile="causePosted.aspx.cs" Inherits="causePosted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <%-- header --%>
        <div id="banner-slider" class="owl-carousel banner-slider slider-default">
            <div class="banner-item" style="background-image:url('images/hands-poor-poverty-9749.jpg');" > 
                <div class="banner-content">
                    <div class="container">
                        <div class="row">
                            <div class="col">
                                <h1 class="banner-title">Votre donation post a été envoyé à un administrateur pour le vérifier, il sera publié dès qu'un administrateur l'approuve.</h1>
                                <div class="button-group">
                                    <a class="btn btn-lg btn-border btn-white" href="Causes.aspx">Faire un don</a>
                                    <a class="btn btn-lg  btn-white" href="Events.aspx">Parcourir les evenements</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- end header --%>
</asp:Content>

