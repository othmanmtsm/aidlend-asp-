<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
     
        
    <div class="page-header text-white mb-5" style="background-image:url('images/pexels-photo-754769.jpeg'); background-repeat:no-repeat; background-size:cover;background-position:center;" >
        <div class="container text-center">
            <h1 class="page-title">Profile</h1>
        </div>
    </div>

<div class="container">
    <div class="row">
        <div class="col-12 mb-5">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-12 col-lg-8 col-md-6">
                            <h3 class="mb-0 text-truncated"><%=username %></h3>
                            <p class="lead" runat="server" id="edupar"><%=education %> / <%=job %></p>
                            <asp:TextBox runat="server" ID="eduinp" placeholder="Ajouter une ecole" />
                            <asp:TextBox runat="server" ID="jobinp" placeholder="Ajouter un travail" />
                            <p runat="server" id="biopar">
                                <%=bio %>
                            </p>
                                <asp:TextBox runat="server" ID="bioinp" TextMode="MultiLine" Wrap="true" height="200px" placeholder="Ajouter une description" />
                        </div>
                        <div class="col-12 col-lg-4 col-md-6 text-center">
                            <asp:image ID="profilePic" Width="200px" Height="200px" runat="server" class="mx-auto rounded-circle img-fluid"></asp:image>
                            <br>
                        </div>
                        <asp:Button runat="server" ID="setProfileBtn" class="btn mt-4" Text="Set profile" OnClick="setProfileBtn_Click" />
                        <div class="col-12 col-lg-4">
                            <h3 class="mb-0"><%=events %></h3>
                            <small>Events</small>
                        </div>
                        <div class="col-12 col-lg-4">
                            <h3 class="mb-0"><%=donations %></h3>
                            <small>Donations</small>
                        </div>
                        <!--/col-->
                    </div>
                    <!--/row-->
                </div>
                <!--/card-block-->
            </div>
        </div>
    </div>
</div>
</form>
</asp:Content>

