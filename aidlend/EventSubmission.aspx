<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter.master" AutoEventWireup="true" CodeFile="EventSubmission.aspx.cs" Inherits="EventSubmission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page-header text-white mb-5" style="background-image:url('images/pexels-photo-1166990.jpeg'); background-repeat:no-repeat; background-size:cover;background-position:center;" >
        <div class="container text-center">
            <h1 class="page-title">Poster un evenement</h1>
        </div>
    </div>
    <div class="section-padding">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <form runat="server">
                            <p>
                                <label>Event Thumbnail *
                                    <asp:FileUpload ID="eventImg" runat="server" />
                                    <asp:requiredfieldvalidator runat="server" errormessage="Thumbnail required" ForeColor="red" ControlToValidate="eventImg"></asp:requiredfieldvalidator>
                                </label>
                            </p>
                            <p>
                                <label>Event Title *
                                    <asp:TextBox ID="eventTitle" placeholder="Title of your event" runat="server" />
                                    <asp:requiredfieldvalidator runat="server" errormessage="Title required" ForeColor="red" ControlToValidate="eventTitle"></asp:requiredfieldvalidator>
                                </label>
                            </p>
                            <p>
                                <label>Body *
                                    <asp:TextBox ID="eventBody" TextMode="MultiLine" Wrap="true" height="400px" placeholder="Write your article" runat="server" />
                                    <asp:requiredfieldvalidator runat="server" errormessage="Body required" ForeColor="red" ControlToValidate="eventBody"></asp:requiredfieldvalidator>
                                </label>
                            </p>
                            <p>
                                <label>Add a description *
                                    <asp:TextBox ID="eventDescription" placeholder="Event description" runat="server" />
                                    <asp:requiredfieldvalidator runat="server" errormessage="Description required" ForeColor="red" ControlToValidate="eventDescription"></asp:requiredfieldvalidator>
                                </label>
                            </p>
                            <p>
                                <label>Date *
                                    <asp:TextBox runat="server" type="date" ID="eventDate" />
                                    <asp:requiredfieldvalidator runat="server" errormessage="Date required" ForeColor="red" ControlToValidate="eventDate"></asp:requiredfieldvalidator>
                                </label>
                            </p>
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>
                                        <label>Organization *<br>
                                            <asp:TextBox ID="eventOrganizer" placeholder="Organizer" runat="server" />
                                            <asp:requiredfieldvalidator runat="server" errormessage="Organization required" ForeColor="red" ControlToValidate="eventOrganizer"></asp:requiredfieldvalidator>
                                        </label>
                                    </p>
                                </div>
                                <div class="col-sm-6">
                                    <p>
                                        <label>Category *<br>
                                            <asp:dropdownlist ID="eventCategory" runat="server"></asp:dropdownlist>
                                            <asp:requiredfieldvalidator runat="server" errormessage="Category required" ForeColor="red" ControlToValidate="eventCategory"></asp:requiredfieldvalidator>
                                        </label>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>
                                        <label>City *<br>
                                            <asp:dropdownlist ID="eventCity" runat="server"></asp:dropdownlist>
                                            <asp:requiredfieldvalidator runat="server" errormessage="City required" ForeColor="red" ControlToValidate="eventCity"></asp:requiredfieldvalidator>
                                        </label>
                                    </p>
                                </div>
                                <div class="col-sm-6">
                                    <p>
                                        <label>Adress *<br>
                                            <asp:TextBox ID="eventAdress" placeholder="Adress" runat="server" />
                                            <asp:requiredfieldvalidator runat="server" errormessage="Adress required" ForeColor="red" ControlToValidate="eventAdress"></asp:requiredfieldvalidator>
                                        </label>
                                    </p>
                                </div>
                            </div>
                            <div class="share-on">
                                <p style="font-size:larger; font-weight:bold; margin-top:5%;">Additional Media</p>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>
                                        <label>Images <br>
                                            <asp:fileupload Enabled="false" ID="imgMedia" runat="server"></asp:fileupload>
                                        </label>
                                    </p>
                                </div>
                                <div class="col-sm-6">
                                    <p>
                                        <label>Youtube videos <br>
                                            <asp:TextBox Enabled="false" ID="youtubeUrl" placeholder="Youtube url" runat="server" />
                                        </label>
                                    </p>
                                </div>
                            </div>
                            <asp:Button ID="submitEvnt" class="btn btn-sm" runat="server" Text="Submit event" OnClick="submitEvnt_Click"  />
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

