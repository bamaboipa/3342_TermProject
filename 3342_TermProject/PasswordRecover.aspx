<%@ Page MasterPageFile="~/Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="PasswordRecover.aspx.cs" Inherits="_3342_TermProject.PasswordRecover" %>
<asp:Content ID="Content1" ContentPlaceHolderId="ContentPlaceHolder1" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="ContentPages.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="divQuestion" class="siteInfo" aria-atomic="true" style="text-align: center" runat="server" visible="false">
            <asp:Label ID="lblSecQuest" runat="server" ></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtSecAnswer" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblResponseQuestion" runat="server" Visible="false"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnAnswer" runat="server" Text="Submit" OnClick="btnAnswer_Click" />
            <br />
        </div>
        <div id="divEmail" class="siteInfo" aria-atomic="true" style="text-align:center" runat="server" visible="false">
             <asp:Label ID="lblEmail" runat="server" Text="Enter Your Email"></asp:Label><br /><br />
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblResponseEmail" runat="server" Visible="false"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnSubmitEmail" runat="server" OnClick="btnSubmitEmail_Click" Text="Submit" /><br />
        </div>
        <div id="divPassword" class="siteInfo" aria-atomic="true" style="text-align:center" runat="server" visible="false">
            <asp:Label ID="lblUpdatePass" runat="server" Text="Enter Your New Password"></asp:Label><br /><br />
             <asp:TextBox ID="txtUpdatePass" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblResponsePass" runat="server" Visible="false"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnGetPassword" runat="server" Text="Submit" OnClick="btnGetPassword_Click" /><br />
        </div>
    </form>
</body>
</html>
    </asp:Content>
