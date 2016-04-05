<%@ Page MasterPageFile="~/Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TermProject.styleTester" %>
<asp:Content ContentPlaceHolderId="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="ContentPages.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login">
            <table>
                <colgroup>
                    <col span="1" style="width: 225px;" />
                </colgroup>
                <tr>
                    <td>Email</td>
                    <td>Password</td>
                </tr>
                <tr>
                    <td><asp:TextBox CssClass="textbox" ID="txtEmail" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox CssClass="textbox" ID="txtPassword" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="btnLogin" CssClass="loginButton" runat="server" Text="Login"/></td>
                </tr>
                <tr>
                    <td><asp:CheckBox ID="chkStayLoggedIn" runat="server" Text="Keep Me Logged In!" /></td>
                    <td><a href="">Forgot Your Password?</a></td>
                </tr>
            </table>
        </div>
        <div class="siteInfo">
            <h2>Stay Connected With New And Old Friends!</h2>
            <h3>Let Your Friends Know What You're Up To</h3>
            <h3>[Something witty and meaningful]</h3>
        </div>
        <div class="userRegistration" >
            <span class="OR">OR</span>
            <h2>Make An Account</h2>
            <span>* Your Email Address Will Be Your Username</span>
            <br /> <br />
            <table class="registrationInfo">
                <tr>
                    <td>First Name: </td>
                    <td><asp:TextBox CssClass="textbox" ID="txtFirstName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Last Name: </td>
                    <td><asp:TextBox CssClass="textbox" ID="txtLastName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email Address: </td>
                    <td><asp:TextBox CssClass="textbox" ID="txtNewAccountEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password: </td>
                    <td><asp:TextBox CssClass="textbox" ID="txtNewAccountPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Address: </td>
                    <td><asp:TextBox CssClass="textbox" ID="txtAddress" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Phone Number: </td>
                    <td><asp:TextBox CssClass="textbox" ID="txtPhoneNumber" runat="server"></asp:TextBox></td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnCreateAccount" runat="server" Text="Create Acccount" Height="40px" Width="150px"/>
        </div>
    </form>
</body>
</html>
</asp:Content>