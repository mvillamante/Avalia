﻿<%@Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="editMovie.aspx.cs" Inherits="IT114L_MachineProblem.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%= ResolveUrl("~/front-end/styles/breakpoints.css") %>" />
    <link rel="stylesheet" href="<%= ResolveUrl("~/front-end/styles/manage-admin.css") %>" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
<%--    <div>
        <h2>Edit Movie Details</h2>
        
        <label for="poster">Poster</label>
        <asp:FileUpload ID="FileUpload1" runat="server" /><br /><br />

        <label for="title">Title</label>
        <asp:TextBox runat="server" ID="title_tb" required=""></asp:TextBox><br /><br />

        <label for="price">Price</label>
        <asp:TextBox runat="server" ID="price_tb" required=""></asp:TextBox><br /><br />

        <label for="synopsis">Synopsis</label>
        <asp:TextBox runat="server" ID="synopsis_tb" TextMode="MultiLine" required=""></asp:TextBox><br /><br />
        
        <label for="duration">Duration</label>
        <asp:TextBox runat="server" ID="duration_tb" required=""></asp:TextBox><br /><br />

        <label for="genres">Genres</label>
        <asp:TextBox runat="server" ID="genres_tb" required=""></asp:TextBox><br /><br />

        <button type="button" onclick="closePopup()">Cancel</button>
        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
     </div>--%>

    <div>
    <div class="popup-content">
        <h2>Edit Movie Details</h2>
        
        <label for="poster">Poster</label>
        <asp:FileUpload ID="FileUpload1" runat="server" /><br /><br />

        <label for="title">Title</label>
        <asp:TextBox runat="server" ID="title_tb" required=""></asp:TextBox><br /><br />

        <label for="price">Price</label>
        <asp:TextBox runat="server" ID="price_tb" required=""></asp:TextBox><br /><br />

        <label for="synopsis">Synopsis</label>
        <asp:TextBox runat="server" ID="synopsis_tb" TextMode="MultiLine" required=""></asp:TextBox><br /><br />
        
<%--        <label for="duration">Duration</label>
        <asp:TextBox runat="server" ID="duration_tb" required=""></asp:TextBox><br /><br />--%>

        <label for="genres">Genres</label>
        <asp:TextBox runat="server" ID="genres_tb" required=""></asp:TextBox><br /><br />

        <button type="button" onclick="closePopup()">Cancel</button>
        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
    </div>
</div>

    <script src="front-end/admin-Script.js"></script>
</asp:Content>
