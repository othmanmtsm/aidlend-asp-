<%@ Page Title="" Language="C#" MasterPageFile="~/global.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page-header text-white mb-5" style="background-image:url('images/pexels-photo-1525715.jpeg'); background-repeat:no-repeat; background-size:cover;background-position:center;" >
        <div class="container text-center">
            <h1 class="page-title">LOGIN</h1>
        </div>
    </div>
    <div class="container">
    <div class="row">
            <form runat="server" class="col-8 mb-5 mt-5 mx-auto" action="#" method="post">
                <h5 class="small-header">Login</h5>
                <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="False">
                    <asp:Literal ID="Msg" runat="server"></asp:Literal>
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="loginForm" Visible="False">
                    <label>Username *<br/>
                        <asp:TextBox ID="txtName" name="username" placeholder="Enter your username" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter your email" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                    </label>
                    <label>Password *<br/>
                        <asp:TextBox ID="txtPassword" type="password" name="password" placeholder="enter a secure password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter your password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator3" runat="server" ErrorMessage="invalid password, must contain at least 8 upper and lower case" ControlToValidate="txtPassword" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$"></asp:RegularExpressionValidator>
                    </label>
                    <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-sm" OnClick="Button1_Click" />
                    <br />
                    <br />
                    <label>Vous n'avez pas de compte?
                        <a class="btn btn-sm" href="Register.aspx">Register</a>
                    </label>
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="logout" Visible="False">
                    <asp:Button ID="logoutBtn" runat="server" Text="logout" CssClass="btn btn-sm" OnClick="logoutBtn_Click" />
                </asp:PlaceHolder>
            </form>
    </div>
</div>

</asp:Content>



