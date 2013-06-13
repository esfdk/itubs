<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true" CodeBehind="PersonBookingList.aspx.cs" Inherits="Client.GUI.Administrator.PersonBookingList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>
    Konfigurering af bookinger</h2>
    <p>
        Email:
        <asp:TextBox ID="EmailTextBox" runat="server" Width="150px"></asp:TextBox>
&nbsp;<asp:Button ID="FindBookingsButton" runat="server" Text="Find bookinger" 
            onclick="FindBookingsButton_Click" CssClass="availableButton" />
</p>
    <p>
    <asp:GridView ID="PersonBookingListGridView" runat="server" CellPadding="4" 
            ForeColor="#333333" OnDataBound="GridView_OnDataBound" 
            OnRowCreated="GridView_RowCreated" Width="377px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Lokale" />
                <asp:BoundField HeaderText="Kapacitet" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField HeaderText="Person" />
                <asp:BoundField HeaderText="Tidspunkt" />
                <asp:BoundField HeaderText="Deltagere" ItemStyle-HorizontalAlign="Center"/>
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
    </p>
    <p>
        <asp:Button ID="ApproveBookingButton" runat="server" CssClass="availableButton" onclick="ApproveBookingButton_Click" Text="Godkend" />
&nbsp;<asp:Button ID="RejectBookingButton" runat="server" CssClass="availableButton" onclick="RejectBookingButton_Click" Text="Afvis" />
    </p>
</asp:Content>
