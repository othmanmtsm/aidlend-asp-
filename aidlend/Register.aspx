<%@ Page Title="" Language="C#" MasterPageFile="~/global.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="page-header text-white mb-5" style="background-image:url('images/pexels-photo-1739842.jpeg'); background-repeat:no-repeat; background-size:cover;background-position:center;" >
        <div class="container text-center">
            <h1 class="page-title">Register</h1>
        </div>
    </div>

        <div class="section section-padding section-volunteer-registration">
            <div class="container">
                <div class="row">
                    <div class="col-lg-6 offset-lg-3">
                        <div class="section-header text-center">
                            <h3 class="section-title">DEVENEZ <span class="theme-color">BÉNÉVOLE</span></h3>
                            <p class="section-subtext">Remplir les champs ci-dessous et cliquer sur 'S'inscrire'</p>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <!-- Instruction -->
                    <div class="col-lg-6 sm-bottom-40">
                        <h5 class="small-header">INSTRUCTIONS</h5>
                        <div class="instructions">
                            <div class="instruction">
                                <p class="instruction-title">1. S'inscrire</p>
                                <p class="instruction-content">Soumettez le formulaire d'inscription pour créer votre compte</p>
                            </div>
                            <div class="instruction">
                                <p class="instruction-title">2. Creer à un événement</p>
                                <p class="instruction-content">Allez à la page des événements et vous trouverez un lien pour créer un événement au bas de la page. Remplissez les champs avec les informations sur l'événement et attendez que l'administrateur le confirme dans les prochaines 24h</p>
                            </div>
                            <div class="instruction">
                                <p class="instruction-title">3. Participer à un événement</p>
                                <p class="instruction-content">Rendez-vous à la page des événements et choisissez un événement près de chez vous, cliquez sur participer pour informer l’organisateur de votre intérêt.</p>
                            </div>
                        </div>
                    </div>
                    <!-- Instruction End -->

                    <!-- Volunteer Registration Form -->
                    <div class="col-lg-5 offset-lg-1">
                        <h5 class="small-header">S'inscrire</h5>
                        <asp:literal ID="StatusMessage" runat="server"></asp:literal>
                        <asp:Label ForeColor="Red" ID="regErr" runat="server"></asp:Label>
                        <form runat="server" id="volunteerRegistration" class="volunteer-registration" action="#" method="post">
                            <label>Username *<br/>
                              <asp:TextBox ID="txtName" name="name" placeholder="Enter your name" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter your name" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                            </label>
                            <label>Email *<br/>
                              <asp:TextBox ID="txtMail" name="mail" placeholder="Enter your email address" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter your email" ControlToValidate="txtMail"></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator1" runat="server" ErrorMessage="invalid email" ControlToValidate="txtMail" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"></asp:RegularExpressionValidator>
                            </label>
                            <label>Phone *<br/>
                              <asp:TextBox ID="txtPhone" name="phone" placeholder="+212 " runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter your phone number" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator2" runat="server" ErrorMessage="invalid phone number" ControlToValidate="txtPhone" ValidationExpression="(\+212|0)([ \-_/]*)(\d[ \-_/]*){9}"></asp:RegularExpressionValidator>
                            </label>
                            <label>Password *<br />
                              <asp:TextBox ID="txtPassword" type="password" name="password" placeholder="enter a secure password" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter your password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator3" runat="server" ErrorMessage="invalid password, must contain at least 8 upper and lower case" ControlToValidate="txtPassword" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$"></asp:RegularExpressionValidator>
                            </label>
                            <label>Confirm Password *<br />
                              <asp:TextBox ID="txtCPassword" type="password" name="password" placeholder="Confirm your password" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please enter your password" ControlToValidate="txtCPassword"></asp:RequiredFieldValidator>
                              <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password doesn't match" ControlToValidate="txtCPassword" ControlToCompare="txtPassword"></asp:CompareValidator>
                            </label>
                            <label>Add a picture and make it easier for charities to trust you<br/>
                                <asp:FileUpload ID="picUp" runat="server" />
                                <asp:label ID="imgErr" runat="server" ForeColor="red"></asp:label>
                            </label>
                            <asp:Button ID="Button1" runat="server" Text="S'inscrire" class="btn btn-sm" OnClick="Button1_Click" />
                            <br />
                            <br />
                            <label>Déjà membre ?
                                <a class="btn btn-sm" href="Login.aspx">S'authentifier</a>
                            </label>
                        </form>
                    </div>
                    <!-- Volunteer Registration Form End -->
                </div>
            </div>
        </div>
</asp:Content>

