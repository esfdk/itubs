<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true" CodeBehind="EditEquipment.aspx.cs" Inherits="Client.GUI.Administrator.EditEquipment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Ændre Udstyr</h2>
    <p>Navn:
        <asp:TextBox ID="EquipmentNameTextBox" runat="server"></asp:TextBox>
    </p>
    <p>Kommentar:</p>
    <p>
        <asp:TextBox ID="CommentTextBox" runat="server" Height="145px" TextMode="MultiLine" 
            Width="468px"></asp:TextBox>
    </p>
    <p>
        Kan udlånes:<asp:CheckBox ID="BookableCheckBox" 
            runat="server" />
&nbsp;</p>
    <p>Udstyrstype
        <asp:DropDownList ID="EquipmentTypeDropDown" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="SaveChancesButton" runat="server" Text="Gem Ændringer" 
            CssClass="availableButton" onclick="SaveChangesButton_Click" />
    &nbsp;<asp:Button ID="CancelButton" runat="server" CssClass="availableButton" 
            onclick="CancelButton_Click" Text="Fortryd" />
    </p>
</asp:Content>
