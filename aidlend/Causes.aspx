<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter.master" AutoEventWireup="true" CodeFile="Causes.aspx.cs" Inherits="Causes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">


            <%-- header --%>
            <div id="banner-slider" class="owl-carousel banner-slider slider-default">
                <div class="banner-item" style="background-image:url('images/hands-poor-poverty-9749.jpg');" > 
                    <div class="banner-content">
                        <div class="container">
                            <div class="row">
                                <div class="col">
                                    <h1 class="banner-title">Faire un don est le signe ultime de la solidarité. L'action a plus de poids que les mots.</h1>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-- end header --%>
        <!-- Causes -->
        <div class="section section-padding causes-section">
            <div class="container">
                <div class="row mb-4">
                    <asp:DropDownList class="col-12 col-md-4" ID="DropDownList1" runat="server"></asp:DropDownList>
                    <asp:Button class="btn col-12 col-md-2 ml-auto" Text="Filter" runat="server" OnClick="Unnamed_Click" />
                </div>
                <asp:Panel runat="server" ID="causess" class="row">

                </asp:Panel>
            </div>
            <div class="cta style-2">
        <div class="container">
            <div class="row">
                <div class="col-lg-9">
                    <h3 class="cta-title">Vous êtes un organisme de bienfaisance ou une personne qui organise un événement?</h3>
                </div>
                <div class="col-lg-3 text-right">
                    <a class="btn btn-white" href="CauseSubmission.aspx">Soumettez donation</a>
                </div>
            </div>
        </div>
    </div>
        </div>
        <!-- Causes End -->
            </form>
</asp:Content>

