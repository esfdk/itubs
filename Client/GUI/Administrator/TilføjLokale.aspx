<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true" CodeBehind="Tilf�jLokale.aspx.cs" Inherits="Client.GUI.Administrator.Tilf�jLokale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>
Tilf�j Lokale
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
        <asp:Button ID="Tilf�jLokaleButton" runat="server" CssClass="availableButton" 
            onclick="Tilf�jLokale_Click" Text="Tilf�j Lokale" />
</p>
    <p>
        &nbsp;</p>
</asp:Content>
