<%@ Page MasterPageFile="~/Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="Preferences.aspx.cs" Inherits="_3342_TermProject.Preferences" %>
<asp:Content ContentPlaceHolderId="ContentPlaceHolder1" runat="server">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="ContentPages.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="preferencesHeight">
    <h2>Preferences</h2>
    <span>Note: Clicking the "Apply Changes" Button Only Updates Your</span>
        <br />
    <span>General Preferences, Not Your Security Questions.</span>
        <br />
        <br />
    <asp:Label CssClass="errorPreferences" ID="error" runat="server"></asp:Label>
    <span style="font-weight:bold;">Login Preferences: </span>
    <asp:DropDownList CssClass="dropdown" ID="ddlLoginPreference" runat="server">
        <asp:ListItem Value="Auto">Auto Login</asp:ListItem>
        <asp:ListItem Value="Fast">Fast Login</asp:ListItem>
        <asp:ListItem Value="Manual">Manual Login</asp:ListItem>
    </asp:DropDownList>
    <br />
        <br />
    <span>*Fast Login autofills your username, but not your password</span>
        <br />
        <br />
        <br />
    <span style="font-weight:bold;">Who Can See What?</span>
        <br />
        <br />
    <span>Photos: </span>
    <asp:DropDownList CssClass="dropdown" ID="ddlPhotos" runat="server">
        <asp:ListItem Value="1">Public</asp:ListItem>
        <asp:ListItem Value="2">Friends Only</asp:ListItem>
        <asp:ListItem Value="5">Friends Of Friends</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <span>Profile Information: </span>
    <asp:DropDownList CssClass="dropdown" ID="ddlProfileInformation" runat="server">
        <asp:ListItem Value="1">Public</asp:ListItem>
        <asp:ListItem Value="2">Friends Only</asp:ListItem>
        <asp:ListItem Value="5">Friends Of Friends</asp:ListItem>
    </asp:DropDownList>
    <br />
        <br />
    <span>Contact Information: </span>
    <asp:DropDownList CssClass="dropdown" ID="ddlContactInfo" runat="server">
        <asp:ListItem Value="1">Public</asp:ListItem>
        <asp:ListItem Value="2">Friends Only</asp:ListItem>
        <asp:ListItem Value="5">Friends Of Friends</asp:ListItem>
    </asp:DropDownList>
        <br />
        <br />
        <br />
    <span style="font-weight:bold;">Theme</span>
        <br />
        <br />
    <span>Select Theme Color:</span>
    <asp:DropDownList CssClass="dropdown" ID="ddlTheme" runat="server">
        <asp:ListItem Value="Red">Red</asp:ListItem>
        <asp:ListItem Value="Blue">Blue</asp:ListItem>
        <asp:ListItem Value="Green">Green</asp:ListItem>
        <asp:ListItem Value="Purple">Purple</asp:ListItem>
    </asp:DropDownList>
    <br />
        <br />
    <span>Select Font:</span>
    <asp:DropDownList CssClass="dropdown" ID="ddlFont" runat="server">
        <asp:ListItem Value="Arial">Arial</asp:ListItem>
        <asp:ListItem Value="Century">Century</asp:ListItem>
        <asp:ListItem Value="Tahoma">Tahoma</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <span>Font Color:</span>
    <asp:DropDownList CssClass="dropdown" ID="ddlFontColor" runat="server">
        <asp:ListItem Value="Blue">Blue</asp:ListItem>
        <asp:ListItem Value="Black">Black</asp:ListItem>
        <asp:ListItem Value="Purple">Purple</asp:ListItem>
    </asp:DropDownList> 
    <div class="securityQuestions siteInfo">
    <span style="font-weight: bold;">Set Your Security Questions</span>
    <br />
    <br />
    <asp:Label ID="lblMothersName" runat="server" Text="What Is Your Mother's Maiden Name?"></asp:Label>
        <asp:TextBox CssClass="dropdown" ID="txtMaidenName" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblFathersMiddle" runat="server" Text="What Is Your Father's Middle Name?"></asp:Label>
    <asp:TextBox CssClass="dropdown" ID="txtFathersMiddle" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblStreet" runat="server" Text="What Street Did You Grow Up On?"></asp:Label>
    <asp:TextBox CssClass="dropdown" ID="txtStreet" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Button ID="btnSetSecurity" CssClass="button" runat="server" Text="Set Security Questions" OnClick="btnSetSecurity_Click" />
    </div>
    <asp:Button ID="btnApply" runat="server" CssClass="button preferenceApplyButton" Text="Apply Changes" OnClick="btnApply_Click" />
    </div>
    </form>
</body>
</html>
</asp:Content>