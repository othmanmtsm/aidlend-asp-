<%@ Page Title="" Language="C#" MasterPageFile="~/headerfooter.master" AutoEventWireup="true" CodeFile="CauseSubmission.aspx.cs" Inherits="CauseSubmission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="page-header text-white mb-5" style="background-image:url('images/pexels-photo-2084702.jpeg'); background-repeat:no-repeat; background-size:cover;background-position:center;" >
            <div class="container text-center">
                <h1 class="page-title">Poster une demande de don</h1>
            </div>
        </div>
        <div class="section-padding">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <form runat="server">
                            <p>
                                <label>Cause Thumbnail *
                                    <asp:FileUpload ID="eventImg" runat="server" />
                                    <asp:requiredfieldvalidator runat="server" errormessage="Thumbnail required" ForeColor="red" ControlToValidate="eventImg"></asp:requiredfieldvalidator>
                                </label>
                            </p>
                            <p>
                                <label>Cause Title *
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
                                        <label>Organizer *<br>
                                            <asp:TextBox ID="eventOrganizer" placeholder="Organizer" runat="server" />
                                            <asp:requiredfieldvalidator runat="server" errormessage="Organizer required" ForeColor="red" ControlToValidate="eventOrganizer"></asp:requiredfieldvalidator>
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
                                        <label>Adress *<br>
                                            <asp:TextBox ID="eventAdress" placeholder="Adress" runat="server" />
                                            <asp:requiredfieldvalidator runat="server" errormessage="Adress required" ForeColor="red" ControlToValidate="eventAdress"></asp:requiredfieldvalidator>
                                        </label>
                                    </p>
                                </div>
                                <div class="col-sm-6">
                                    <p>
                                        <label>Goal (DH) *<br>
                                            <asp:TextBox runat="server" ID="goal" type="number" />
                                            <asp:requiredfieldvalidator runat="server" errormessage="Goal required" ForeColor="red" ControlToValidate="goal"></asp:requiredfieldvalidator>
                                        </label>
                                    </p>
                                </div>
                                <div class="col-sm-6">
                                    <p>
                                        <label>Code carte bancaire *<br>
                                            <asp:TextBox runat="server" ID="card"/>
                                            <asp:requiredfieldvalidator runat="server" errormessage="Credit card required" ForeColor="red" ControlToValidate="card"></asp:requiredfieldvalidator>
                                            <asp:RegularExpressionValidator ControlToValidate="card" ValidationExpression="^(\d{4}[- ]){3}\d{4}|\d{16}$" ForeColor="red" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Card non valid"></asp:RegularExpressionValidator>
                                        </label>
                                    </p>
                                </div>
                            </div>
                            
                            <asp:Button ID="submitCause" class="btn btn-sm" runat="server" Text="Submit event" OnClick="submitCause_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

