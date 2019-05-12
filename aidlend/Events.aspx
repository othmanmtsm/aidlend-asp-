<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter.master" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="Events"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server">
    <%-- header --%>
    <div id="banner-slider" class="owl-carousel banner-slider slider-default">
        <div class="banner-item" style="background-image:url('images/boys-daylight-facial-expression-1344275.jpg');" > 
            <div class="banner-content">
                <div class="container">
                    <div class="row">
                        <div class="col">
                            <h1 class="banner-title">Soyez le changement que vous voulez voir dans le monde.</h1>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- end header --%>
    <!-- events -->
    <div class="section section-padding events-section">
    <div class="container">
        <div class="row mb-4">
            <asp:DropDownList class="col-12 col-md-4" ID="DropDownList1" runat="server"></asp:DropDownList>
            <asp:DropDownList class="col-12 col-md-4" ID="DropDownList2" runat="server"></asp:DropDownList>
            <asp:Button class="btn col-12 col-md-2 ml-auto" Text="Filter" runat="server" OnClick="Unnamed_Click" />
        </div>
        <asp:panel ID="pnlEvents" class="row" runat="server">

        </asp:panel>
    </div>
    <div class="cta style-2">
        <div class="container">
            <div class="row">
                <div class="col-lg-9">
                    <h3 class="cta-title">Vous êtes un organisme de bienfaisance ou une personne qui organise un événement?</h3>
                </div>
                <div class="col-lg-3 text-right">
                    <a class="btn btn-white" href="EventSubmission.aspx">Soumettez événement</a>
                </div>
            </div>
        </div>
    </div>
    </div>
    <!-- events End -->
</form>
</asp:Content>

