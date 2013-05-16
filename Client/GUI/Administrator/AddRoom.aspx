<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true" CodeBehind="AddRoom.aspx.cs" Inherits="Client.GUI.Administrator.AddRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>
Tilføj Lokale
</h2>
    <p>
        Navn:
        <asp:TextBox ID="RoomNameTextBox" runat="server"></asp:TextBox>
</p>
    <p>
        Kapacitet:
        <asp:TextBox ID="CapacityTextBox" runat="server"></asp:TextBox>
</p>
    <p>
        <asp:Button ID="AddRoomButton" runat="server" CssClass="availableButton" onclick="AddRoomButton_Click" Text="Tilføj Lokale" />
</p>
    <p>
        &nbsp;</p>
</asp:Content>
