<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Main</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- header --%>
    <div id="banner-slider" class="owl-carousel banner-slider slider-default">
        <div class="banner-item banner-item-1">
            <div class="banner-content">
                <div class="container">
                    <div class="row">
                        <div class="col">
                            <h1 class="banner-title">DONNER UNE MAIN D'AIDE À CEUX QUI EN ONT BESOIN</h1>
                            <div class="button-group">
                                <a class="btn btn-lg btn-border btn-white" href="Causes.aspx">Faire un don</a>
                                <a class="btn btn-lg btn-simple btn-white play-video" href="Events.aspx"><i class="fa fa-play"></i>Parcourir les evenements</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- end header --%>
    <!-- Compact Urgent Cause -->
        <div class="section compact-urgent-cause theme-bg">
            <div class="container">
                <div class="row">
                    <div class="col">
                        <div class="cause-information">
                            <h3>Cause urgente</h3>
                            <h5><%=urgTtl %></h5>
                            <div class="text-state-items">
                                <p class="text-state-item">Goal: <%=urgGoal %> DH</p>
                                <p class="text-state-item">Collected: <%=urgCollected %> DH</p>
                            </div>
                        </div>
                        <div class="compact-progress">
                            <div class="progress-rounded style-2">
                                <div class="progress-value"><%=(double.Parse(urgCollected)*100)/double.Parse(urgGoal) %>%<span>Collected</span></div>
                                <svg><circle class="progress-cicle" cx="100" cy="100" r="90" stroke-width="20" fill="none" role="slider" aria-orientation="vertical" aria-valuemin="0" aria-valuemax="l00" aria-valuenow="<%=(double.Parse(urgCollected)*100)/double.Parse(urgGoal) %>"/></svg>
                            </div>
                        </div>
                        <div class="compact-cause-countdown">
                            <div class="countdown countdown-compact" data-time="<%=urgDate %>"></div>
                            <a class="btn btn-white" href="Cause.aspx?cause=<%=urgId %>">Faire un don</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Compact Urgent Cause End -->
        

    

    <div class="section section-padding news-event-section">
            <div class="container">
                <div class="row">
                    <div class="col-lg-6 offset-lg-3">
                        <div class="section-header text-center">
                            <h3 class="section-title">Événements auxquels j'ai participé</h3>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                            <asp:panel ID="prtsEvnts" class="verticle-scroll verticle-scroll-events" runat="server">
                               
                            </asp:panel>
                    </div>
                </div>
            </div>
        </div>







    <div class="section section-bg section-bg-1 text-white fact-default">
            <div class="overlay-black section-padding">
                <div class="container">
                    <div class="row">
                        <div class="col">
                            <div class="section-header text-center">
                                <h3 class="section-title"><span class="theme-color">DONNEZ UNE MAIN D'AIDE À CEUX QUI EN ONT BESOIN!</span></h3>
                                <p class="section-subtext">Donner nous libère du territoire familier de nos propres besoins en ouvrant notre esprit aux mondes inexpliqués occupés par les besoins des autres.</p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-10 offset-lg-1">
                            <div class="counter-items">
                                <div class="row">
                                    <div class="col-md-4 col-sm-6">
                                        <div class="counter-item">
                                            <div class="counter-icon">
                                                <i class="fa fa-users"></i>
                                            </div>
                                            <span class="fact-number"><span class="count" data-form="0" data-to="<%=volunteers %>"></span></span>
                                            <p class="fact-name">Bénévoles</p>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-6">
                                        <div class="counter-item">
                                            <div class="counter-icon">
                                                <i class="fa fa-object-group"></i>
                                            </div>
                                            <span class="fact-number"><span class="count" data-form="0" data-to="<%=causes %>"></span></span>
                                            <p class="fact-name">Dons</p>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-6">
                                        <div class="counter-item">
                                            <div class="counter-icon">
                                                <i class="fa fa-coffee"></i>
                                            </div>
                                            <span class="fact-number"><span class="count" data-form="0" data-to="<%=events %>"></span></span>
                                            <p class="fact-name">Événements</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <!-- Recent Cause -->
        <div class="section section-padding causes-section">
            <div class="container">
                <div class="row">
                    <div class="col-lg-6 offset-lg-3">
                        <div class="section-header text-center">
                            <h3 class="section-title"><span class="theme-color">DONS</span> RÉCENTS</h3>
                        </div>
                    </div>
                </div>
                <div class="row" id="dons" runat="server">

                </div>
                <div class="row">
                    <div class="col">
                        <div class="text-center">
                            <a class="btn" href="Causes.aspx">Voir tous</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Recent Cause End -->
</asp:Content>

