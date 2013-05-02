<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TilføjLokale.aspx.cs" Inherits="Client.Administrator.TilføjLokale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>
Tilføj Lokale
</h2>
    <p>
        Navn:
        <asp:TextBox ID="LokaleTextBox" runat="server"></asp:TextBox>
</p>
    <p>
        Kapacitet:
        <asp:TextBox ID="KapacitetTextBox" runat="server"></asp:TextBox>
</p>
    <p>
        <asp:Button ID="TilføjLokaleButton" runat="server" CssClass="availabeButton" 
            onclick="TilføjLokale_Click" Text="Tilføj Lokale" />
</p>
    <p>
        &nbsp;</p>
</asp:Content>
