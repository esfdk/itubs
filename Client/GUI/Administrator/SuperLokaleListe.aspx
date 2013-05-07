<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true" CodeBehind="SuperLokaleListe.aspx.cs" Inherits="Client.GUI.Administrator.SuperLokaleListe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function confirmRoomDeletion() {
            if (confirm("Er du sikker på, at du vil slette lokale det valgte lokale?") == true) {
                return true;
            }
            return false;
        }
</script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 406px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Konfigurering af lokaler</h2>
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                    OnDataBound="GridView_OnDataBound" OnRowCreated="GridView_RowCreated" Width="627px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField HeaderText="Lokale" />
                        <asp:BoundField HeaderText="Kapacitet" />
                        <asp:BoundField HeaderText="Udstyr" />
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
                <asp:Button ID="ÆndreLokaleButton" runat="server" Text="Ændre" CssClass="availableButton" 
                    Width="89px" onclick="ÆndreLokale_Click" />
                <br />
                <br />
                <asp:Button ID="TilføjLokaleButton" runat="server" Text="Tilføj" CssClass="availableButton" 
                    Width="89px" onclick="TilføjLokale_Click" />
                <br />
                <br />
                <asp:Button ID="SletLokaleButton" runat="server" Text="Slet" CssClass="availableButton" 
                    Width="89px" onclick="SletLokale_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>