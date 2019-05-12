<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter2.master" AutoEventWireup="true" CodeFile="EventsReview.aspx.cs" Inherits="EventsReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="section section-padding events-section">
    <div class="container">
        <asp:Panel ID="eventsRev" class="row" runat="server">
                    <%--<nav class="navigation pagination">
                        <div class="nav-links">
                            <a class="prev page-numbers" href="#"><i class="fa fa-angle-left"></i></a>
                            <a class="page-numbers" href="#">1</a>
                            <span class="page-numbers current">2</span>
                            <a class="page-numbers" href="#">3</a>
                            <a class="next page-numbers" href="#"><i class="fa fa-angle-right"></i></a>
                        </div>
                    </nav>--%>
        </asp:Panel>
    </div>
</div>
</asp:Content>

