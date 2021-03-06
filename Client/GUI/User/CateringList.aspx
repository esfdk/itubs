<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true" CodeBehind="CateringList.aspx.cs" Inherits="Client.GUI.User.CateringList" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Forplejning<asp:ScriptManager ID="ScriptManager1" runat="server">
       </asp:ScriptManager>
    </h2>
    <p>
        &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/GUI/Images/HvidBoks.png" />
        &nbsp;= Ledig&nbsp;&nbsp;&nbsp;
        <asp:Image ID="BlueBox" runat="server" Height="20px" 
            ImageUrl="~/GUI/Images/Bl�Boks.png" Width="20px" />
        &nbsp;= Dine forplejninger&nbsp;&nbsp;&nbsp;
        <asp:Image ID="RedBox" runat="server" ImageUrl="~/GUI/Images/R�dBoks.png" 
            Width="20px" />
        &nbsp;= Ikke til r�dighed
    </p>
    <p>
        &nbsp; Lokale:
        <asp:TextBox ID="RoomNameTextBox" runat="server" ReadOnly="True"></asp:TextBox>
        &nbsp;&nbsp;&nbsp; Dato:<asp:TextBox ID="DateTextBox" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:GridView ID="CateringListGridView" runat="server" CellPadding="4" 
            ForeColor="#333333" OnDataBound="GridView_OnDataBound" 
            OnRowCreated="GridView_RowCreated" Width="953px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Navn"/>
                <asp:TemplateField HeaderText="09:00" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox9" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="10:00" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox10" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="11:00" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox11" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="12:00" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox12" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="13:00" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox13" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="14:00" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox14" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="15:00" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox15" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="16:00" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox16" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="17:00" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox17" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="18:00" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox18" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="19:00" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox19" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="20:00" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox20" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Antal" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:TextBox ID="AmountTextBox" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Pris" ItemStyle-HorizontalAlign="Center"/>
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
    <asp:Panel ID="Panel1" runat="server">
        <asp:Button ID="AddCateringButton" runat="server" Text="Tilf�j Forplejning" onclick="AddCateringButton_Click" CssClass="availableButton" />
        &nbsp;<asp:Button ID="DeleteCateringButton" runat="server" CssClass="availableButton" onclick="DeleteCateringButton_Click" Text="Slet Forplejning" />
        &nbsp;<asp:Button ID="CancelButton" runat="server" Text="Fortryd" CssClass="availableButton" onclick="Cancel_Click" />
            <br />
            </asp:Panel>
    </asp:Content>
