<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="page-header text-white mb-5" style="background-image:url('images/pexels-photo-2180863.jpeg'); background-repeat:no-repeat; background-size:cover;background-position:center;" >
        <div class="container text-center">
            <h1 class="page-title">Parametres</h1>
        </div>
    </div>
    
    <asp:Panel runat="server" ID="adminsett">
        <div class="container">
            <div class="row">
                <div class="col-12 mb-5">
                    <h3>Parametres admin</h3>
                    <div class="tabs tab-pill style-3">
                        <div class="row">
                            <div class="col-md-3">
                            <div class="nav flex-column nav-pills" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                                <a class="nav-link active show" id="v-pills-charity-tab" data-toggle="pill" href="#v-pills-event" role="tab" aria-controls="v-pills-charity" aria-selected="true">Evenements requests</a>
                                <a class="nav-link" id="v-pills-volunteer-tab" data-toggle="pill" href="#v-pills-volunteer" role="tab" aria-controls="v-pills-volunteer" aria-selected="false">Donations requests</a>
                            </div>
                            </div>
                            <div class="col-md-9">
                            <div class="tab-content" id="v-pills-tabContent">
                                <div class="tab-pane fade active show" id="v-pills-event" role="tabpanel" aria-labelledby="v-pills-charity-tab">
                                    <asp:Panel ID="eventsRev" class="row" runat="server">
                                          
                                    </asp:Panel>
                                </div>
                                <div class="tab-pane fade" id="v-pills-volunteer" role="tabpanel" aria-labelledby="v-pills-volunteer-tab">
                                    <div class="row">
                                        <div class="col-12">
                                            <asp:Panel ID="donationsRev" class="causes causes-list" runat="server">
                                          
                                            </asp:Panel>    
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" id="usersett" >
        <div class="container">
            <div class="row">
                <div class="col-12 mb-5">
                    <h3>Parametres utilisateur</h3>
                    <div class="tabs tab-pill style-3">
                        <div class="row">
                            <div class="col-md-3">
                            <div class="nav flex-column nav-pills" id="v-pills-tab1" role="tablist" aria-orientation="vertical">
                                <a class="nav-link active show" id="v-pills-charity-tab1" data-toggle="pill" href="#v-pills-event1" role="tab" aria-controls="v-pills-charity" aria-selected="true">Événements auxquels je fais partie</a>
                                <a class="nav-link" id="v-pills-volunteer-tab1" data-toggle="pill" href="#v-pills-voluntee1" role="tab" aria-controls="v-pills-volunteer" aria-selected="false">Dons que j'ai faits</a>
                            </div>
                            </div>
                            <div class="col-md-9">
                            <div class="tab-content" id="v-pills-tabContent1">
                                <div class="tab-pane fade active show" id="v-pills-event1" role="tabpanel" aria-labelledby="v-pills-charity-tab">
                                    <asp:Panel ID="Panel1" class="row" runat="server">

                                    </asp:Panel>
                                </div>
                                <div class="tab-pane fade" id="v-pills-voluntee1" role="tabpanel" aria-labelledby="v-pills-volunteer-tab">
                                    <div class="row">
                                        <div class="col-12">
                                            <asp:Panel ID="Panel2" class="causes causes-list" runat="server">
                                          
                                            </asp:Panel>    
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

</asp:Content>

