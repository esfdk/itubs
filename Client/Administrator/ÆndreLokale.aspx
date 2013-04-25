<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ÆndreLokale.aspx.cs" Inherits="BookIT.ÆndreLokale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Ændre lokale</h2>
    <p>Navn
        <asp:TextBox ID="LokaleNavnTextBox" runat="server" ReadOnly="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Kapacitet
        <asp:TextBox ID="KapacitetTextBox" runat="server" 
            ontextchanged="TextBox5_TextChanged"></asp:TextBox>
    </p>
    <asp:Panel ID="Panel1" runat="server" Height="251px" style="margin-left: 27px" 
        Width="794px">

                <h3>Tilføj udstyr:</h3>

                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                    ForeColor="#333333" Width="512px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="Navn" />
                            <asp:BoundField HeaderText="Kommentar" />
                            <asp:BoundField HeaderText="Type" />
                            <asp:TemplateField>
                            <ItemTemplate>
                            <asp:CheckBox ID="CheckBox21" runat="server" />
                            </ItemTemplate>
                            </asp:TemplateField>
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
    </asp:Panel>
    <asp:Button ID="FjernUdstyrButton" runat="server" Text="Fjern udstyr" 
        CssClass="buttonStyle1" onclick="FjernUdstyr_Click" />
                        &nbsp;<asp:Button ID="TilføjUdstyrButton" runat="server" Text="Tilføj udstyr" 
                            onclick="TilføjUdstyr_Click" CssClass="buttonStyle1" />
    &nbsp;<asp:Button ID="AfslutButton" runat="server" Text="Afslut" 
        CssClass="buttonStyle1" onclick="Afslut_Click"/>
</asp:Content>
