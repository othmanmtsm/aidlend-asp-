<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter2.master" AutoEventWireup="true" CodeFile="Donate.aspx.cs" Inherits="Donate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server">


    <div class="section section-padding section-donation">
        <div class="container">
                    <div class="row">
                        <div class="col-lg-6 offset-lg-3">
                            <div class="section-header text-center">
                                <h3 class="section-title">FAIRE UN <span class="theme-color">DON</span></h3>
                                <p class="section-subtext">Moluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt</p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-8">
                                <div class="donation-section">
                                    <div class="payment-details">
                                        <asp:Panel runat="server" ID="transfer">
                                             <div class="row">
                                                <div class="col-md-6">
                                                    <p>Code du compte : <%=bnq %></p>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="mtn" runat="server" placeholder="Montant" type="number" />
                                                    <asp:TextBox ID="msg" runat="server" placeholder="Laisser un message" />
                                                </div>
                                            </div>
                                           
                                        </asp:Panel>
                                    </div>
                                </div>
                                <asp:button runat="server" class="btn btn-sm" OnClick="Unnamed_Click" Text="Submit" />
                        </div>
                        <div class="col-lg-4">
                            <h5 class="small-header">Instructions</h5>
                            <div class="instructions">
                                <div class="instruction">
                                    <p class="instruction-title">Faire un don</p>
                                    <p class="instruction-content">Envoyez de l'argent au numéro de compte, les cartes de crédit ne sont pas supportées pour le moment.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </div>
    </form>
</asp:Content>

