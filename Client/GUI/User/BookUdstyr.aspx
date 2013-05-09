<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true" CodeBehind="BookUdstyr.aspx.cs" Inherits="Client.GUI.User.BookUdstyr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Book udstyr</h2>
    <p>&nbsp;
        <asp:Image ID="Image1" runat="server" ImageUrl="~/GUI/Images/Bl�Boks.png" />
&nbsp;= Dine bookinger&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image2" runat="server" ImageUrl="~/GUI/Images/R�dBoks.png" />
&nbsp;= Ikke til r�dighed</p>
    <p>Udstyrstype
        <asp:DropDownList ID="UdstyrsTypeDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SelectedTypeChanged"/>
&nbsp;&nbsp;&nbsp; Lokale:
        <asp:TextBox ID="LokaleTextBox" runat="server" ReadOnly="True"></asp:TextBox>
&nbsp;Dato:
        <asp:TextBox ID="DatoTextBox" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" OnDataBound="GridView_OnDataBound" OnRowCreated="GridView_RowCreated">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
            <asp:BoundField HeaderText="Navn" />
            <asp:BoundField HeaderText="Type" />
            <asp:TemplateField HeaderText="09:00">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox9" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="10:00" >
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox10" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="11:00" >
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox11" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="12:00" >
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox12" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="13:00" >
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox13" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="14:00" >
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox14" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="15:00" >
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox15" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="16:00" >
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox16" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="17:00" >
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox17" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="18:00" >
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox18" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="19:00" >
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox19" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="20:00" >
                    <ItemTemplate>
                            <asp:CheckBox ID="CheckBox20" runat="server" />
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
    </p>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;<asp:Button ID="�ndringerButton" runat="server" Text="Tilf�j �ndringer" 
        CssClass="availableButton" onclick="�ndringerButton_Click" />
&nbsp;<asp:Button ID="FortrydButton" runat="server" Text="Fortryd" 
        CssClass="availableButton" onclick="FortrydButton_Click" />
</asp:Content>