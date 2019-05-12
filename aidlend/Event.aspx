<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter.master" AutoEventWireup="true" CodeFile="Event.aspx.cs" Inherits="Event" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server">



    <div class="banner-item" style="background-image:url('<%=img %>'); background-repeat:no-repeat; background-size:cover;">
        <div class="banner-content">
            <div class="container text-center">
                <h1 class="banner-title"><%=title %></h1>
                <p class="banner-subtext"><%=description %></p>
               
                <div class="button-group">
                    <asp:LinkButton runat="server" ID="LinkButton1" Text="Participer" class="btn" OnClick="Participate_Click" />
                    <a class="btn btn-border btn-white" href="#trgt">Plus d'informations</a>
                </div>
            </div>
        </div>
    </div>

<%-- event --%>
<div class="section section-padding events-section">
    <div id="trgt" class="container">
        <div class="row">
            <div class="col-lg-8">
                <div class="events event-single">
                    <div class="event">
                        <p><b><%=description %></b></p>
                        <p style="font-size:130%; word-spacing:5px; line-height:30px;"><%=body %></p> 
                    </div>
                    <!-- Share on social -->
                    <div class="share-on">
                       
                    </div>
                    <!-- Comments -->
                    <asp:Panel runat="server" id="comments" class="cause-donation">
                     <h3>Commentaires</h3>

                    </asp:Panel>
					<asp:TextBox runat="server" TextMode="MultiLine" Wrap="true" id="addCom" placeholder="Ajouter un commentaire" />
                    <asp:Button runat="server" Text="Commenter" class="btn" OnClick="Unnamed1_Click" />
                </div>
            </div>
            <div class="col-lg-4">
                <aside class="sidebar widget-area">
                    <!-- Fund Raising States Widget -->
                    <div class="widget widget_event_countdown">
                        <div class="countdown countdown-widget" data-time="<%=date %>"></div>
                        <asp:LinkButton runat="server" ID="LinkButton2" Text="Participer" class="btn" OnClick="Participate_Click" />
                    </div>

                    <!-- Event Information Widget -->
                    <div class="widget widget_event_information style-2">
                        <h3 class="widget-title text-center">Event Informations</h3>
                        <p class="widget-subtext text-center"><%=title %></p>
                        <div class="event-information">
                            <p><i class="fa fa-calendar"></i> <b>Date:</b> <%=date %></p>
                            <p><i class="fa fa-clock-o"></i> <b>Time:</b> 10 AM - 4 PM</p>
                            <p><i class="fa fa-map-marker"></i> <b>Adress:</b> <%=location %></p>
                            <p><i class="fa fa-user"></i> <b>Organizer:</b><%=organizer %></p>
                            <p><i class="fa fa-check"></i> <b>Category:</b><%=category %></p>
                        </div>
                    </div>
                </aside>
            </div>
        </div>
    </div>
</div>
<!-- events End -->

<asp:Panel runat="server" ID="nrml">
    <div class="cta style-1">
        <div class="overlay">
            <div class="container text-center">
                <h3 class="cta-title">+<%=participants %> People already participated in this event<br/>Join them now!</h3>
                <asp:LinkButton runat="server" ID="Participate" Text="Participer" class="btn" OnClick="Participate_Click" />
            </div>
        </div>
    </div>
</asp:Panel>

<asp:Panel runat="server" ID="admin">
    <div class="cta style-1">
        <div class="overlay">
            <div class="container text-center">
                <h3 class="cta-title">Admin parametres</h3>
                <asp:LinkButton runat="server" ID="acptBtn" Text="Accepter" class="btn" OnClick="acptBtn_Click" />
                <asp:LinkButton runat="server" ID="dltBtn" Text="Supprimer" class="btn" OnClick="dltBtn_Click" />
            </div>
        </div>
    </div>
</asp:Panel>
</form>

</asp:Content>

