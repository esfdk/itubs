<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true" CodeBehind="EditRoom.aspx.cs" Inherits="Client.GUI.Administrator.EditRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Ændre Lokale</h2>
    <p>Navn
        <asp:TextBox ID="RoomNameTextBox" runat="server"/>
&nbsp;&nbsp;&nbsp; Kapacitet
        <asp:TextBox ID="CapacityTextBox" runat="server"/>
        <asp:Button ID="SaveButton" runat="server" onclick="SaveButton_Click" style="margin-left: 21px" Text="Gem" Width="78px" Height="21px" />
    </p>
    <asp:Panel ID="Panel1" runat="server" Height="251px" style="margin-left: 27px" Width="794px">
                <h3>udstyr:</h3>
                    <asp:GridView ID="EditRoomGridView" runat="server" CellPadding="4" OnDataBound="GridView_OnDataBound" OnRowCreated="GridView_RowCreated" ForeColor="#333333" Width="512px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="Navn" />
                            <asp:BoundField HeaderText="Type" />
                            <asp:BoundField HeaderText="Status" />
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
    <asp:Button ID="AddRemoveButton" runat="server" CssClass="availableButton" onclick="AddRemoveButton_Click" />
                        &nbsp;&nbsp;<asp:Button ID="FinishButton" runat="server" Text="Afslut" CssClass="availableButton" onclick="FinishButton_Click"/>
</asp:Content>
