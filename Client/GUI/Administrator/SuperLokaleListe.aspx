<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true" CodeBehind="SuperLokaleListe.aspx.cs" Inherits="Client.GUI.Administrator.SuperLokaleListe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 760px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Konfigurering af lokaler</h2>
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField HeaderText="Lokale" />
                        <asp:BoundField HeaderText="Kapacitet" />
                        <asp:BoundField HeaderText="Udstyr" />
                        <asp:BoundField HeaderText="Kommentar" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#f47a07" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
            <td>
                <asp:Button ID="�ndreLokaleButton" runat="server" Text="�ndre" CssClass="availabeButton" 
                    Width="89px" onclick="�ndreLokale_Click" />
                <br />
                <br />
                <asp:Button ID="Tilf�jLokaleButton" runat="server" Text="Tilf�j" CssClass="availabeButton" 
                    Width="89px" onclick="Tilf�jLokale_Click" />
                <br />
                <br />
                <asp:Button ID="SletLokaleButton" runat="server" Text="Slet" CssClass="availabeButton" 
                    Width="89px" onclick="SletLokale_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
