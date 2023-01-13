<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/login.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--webfonts-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:600italic,400,300,600,700&subset=latin,latin-ext' rel='stylesheet' type='text/css'>
</head>
<body style="background:#dbead5">
    <div class="main" style="background:#dbead5">
        <div class="login-form" style="background:#295D09">
            <h1 style="color:white">Kullanıcı Girişi</h1>
            <div class="head" style=" height:120px;width:120px">
                <img src="images/logo.jpeg" alt="" />
            </div>
            <form id="form1" runat="server">
                <input runat="server" id="txtKullaniciAdi" type="text" class="text" placeholder="Kullanıcı Adı" />
                <input runat="server" id="txtSifre" type="password" placeholder="Şifre" />
                <div class="submit">
                    <asp:Button ID="btnGiris" runat="server" BackColor="#dbead5"   Text="Giriş" ForeColor="#295D09" Font-Size="Large" Font-Names="Verdana" OnClick="btnGiris_Click" />
                </div>
                <p><asp:CheckBox ID="chkBeniHatirla" runat="server" style="color:white" Text="Beni Hatırla"/>&nbsp;&nbsp;&nbsp;<a href="#" style="color:white">Şifremi Unuttum ?</a></p>
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    <Scripts>
                        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
                    </Scripts>
                </telerik:RadScriptManager>
                <telerik:RadNotification ID="ntfUyari" runat="server" Text="Kullanıcı adı veya şifrenizi hatalı girdiniz.!!!" Position="Center"
                    AutoCloseDelay="0" Width="400px" Height="150px" Title="Bilgi Mesajı" EnableRoundedCorners="True" ContentIcon="warning" Font-Size="X-Large" Skin="MetroTouch" TitleIcon="warning">
                </telerik:RadNotification>
            </form>
        </div>
    </div>
</body>
</html>
