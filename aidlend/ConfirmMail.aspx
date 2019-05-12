<%@ Page Title="" Language="C#" MasterPageFile="~/global.master" AutoEventWireup="true" CodeFile="ConfirmMail.aspx.cs" Inherits="ConfirmMail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page-header text-white mb-5" style="background-image:url('images/pexels-photo-1739842.jpeg'); background-repeat:no-repeat; background-size:cover;background-position:center;" >
        <div class="container text-center">
            <h1 class="page-title">Register</h1>
        </div>
    </div>
    <asp:Panel runat="server" ID="confrmsend">
        <div class="container">
            <div class="row mt-5 mb-5">
                <div class="col-12">
                    <h4>Un email de confirmation est envoye a votre email</h4>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="cnfrmaccnt">
        <div class="container">
            <div class="row mt-5 mb-5">
                <div class="col-12">
                    <h4>Votre email est confirme</h4>
                    <a class="btn" href="Login.aspx">Clickez ici pour s'authentifier</a>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

