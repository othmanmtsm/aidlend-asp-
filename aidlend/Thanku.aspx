<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter.master" AutoEventWireup="true" CodeFile="Thanku.aspx.cs" Inherits="Thanku" %>

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
                                <h1 class="banner-title">Merci pour votre donation.</h1>
                                <div class="button-group">
                                    <a class="btn btn-lg btn-border btn-white" href="Causes.aspx">Faire un autre don</a>
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

