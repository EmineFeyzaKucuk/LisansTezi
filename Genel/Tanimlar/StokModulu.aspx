<%@ Page Title="" Language="C#" MasterPageFile="~/Genel/MasterPage/tema.master" AutoEventWireup="true" CodeFile="StokModulu.aspx.cs" Inherits="Genel_Tanimlar_StokModulu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphModal" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBaslik" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBaslik2" Runat="Server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="tab"> 
        <asp:Menu ID="menuTab" runat="server" Orientation="Horizontal" OnMenuItemClick="menuTab_MenuItemClick"> 
            <Items> 
                <asp:MenuItem Text="Aylık Etkinlik Takvimi" Value="0"></asp:MenuItem> 
                <asp:MenuItem Text="Haftalık Etkinlik Takvimi" Value="1"></asp:MenuItem> 
                <asp:MenuItem Text="Günlük Etkinlik Takvimi" Value="2"></asp:MenuItem> 
            </Items> 
            <StaticMenuItemStyle BackColor="#cccccc" ForeColor="#333333" /> 
            <StaticSelectedStyle BackColor="#999999" ForeColor="White" /> 
        </asp:Menu> 
        <div style="border-top: 3px solid #999; margin-top: -2px;"> 
        </div> 
</div>
    <div class="multiview"> 
        <asp:MultiView ID="mvTab" runat="server" ActiveViewIndex="0"> 
            <asp:View ID="vAylikTakvim" runat="server"> 
            <br /> 
            Birinci View kontrolü ile oluşturulan "Tab" öğesi tıklandığında "Aylık Etkinlik Takvimi" içeriğine ulaşılabilir.
           </asp:View> 
            <asp:View ID="vHaftalikTakvim" runat="server"> 
            <br /> 
            İkinci View kontrolü ile oluşturulan "Tab" öğesi tıklandığında "Haftalık Etkinlik Takvimi" içeriğine ulaşılabilir. 
            </asp:View> 
            <asp:View ID="vGunlukTakvim" runat="server"> 
            <br /> 
            Üçüncü View kontrolü ile oluşturulan "Tab" öğesi tıklandığında "Günlük Etkinlik Takvimi" içeriğine ulaşılabilir. 
           </asp:View> 
            </asp:MultiView> 
<br /> 
</div>




















      <%--  <asp:MultiView 
    ID="MultiView1"
    runat="server"
    ActiveViewIndex="0"  >
   <asp:View ID="Tab1" runat="server"  >
        <table width="600" height="400" cellpadding=0 cellspacing=0>
            <tr valign="top">
                <td class="TabArea" style="width: 600px">
                    <br />
                    <br />
                    TAB VIEW 1
                    INSERT YOUR CONENT IN HERE
                    CHANGE SELECTED IMAGE URL AS NECESSARY
                </td>
            </tr>
        </table>
     </asp:View>
    <asp:View ID="Tab2" runat="server">
        <table width="600px" height="400px" cellpadding=0 cellspacing=0>
            <tr valign="top">
                <td class="TabArea" style="width: 600px">
                <br />
                <br />
                    TAB VIEW 2
                    INSERT YOUR CONENT IN HERE
                    CHANGE SELECTED IMAGE URL AS NECESSARY
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="Tab3" runat="server">
        <table width="600px" height="400px" cellpadding=0 cellspacing=0>
            <tr valign="top">
                <td class="TabArea" style="width: 600px">
                <br />
                <br />
                  TAB VIEW 3
                  INSERT YOUR CONENT IN HERE
                  CHANGE SELECTED IMAGE URL AS NECESSARY
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>--%>

</asp:Content>

