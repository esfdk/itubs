<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true" CodeBehind="Forplejning.aspx.cs" Inherits="Client.GUI.User.Forplejning" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Forplejning<asp:ScriptManager ID="ScriptManager1" runat="server">
       </asp:ScriptManager>
    </h2>
    <p>
        &nbsp;&nbsp;
        <asp:Image ID="BlueBox" runat="server" Height="30px" 
            ImageUrl="~/GUI/Images/BlåBoks.png" Width="30px" />
&nbsp;= Valgte&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="RedBox" runat="server" ImageUrl="~/GUI/Images/RødBoks.png" 
            Width="30px" />
&nbsp;= Ikke til rådighed</p>
    <p>type
        <asp:DropDownList ID="MorgenMadTypeDropDown" runat="server">
        </asp:DropDownList>
&nbsp; Lokale:
        <asp:TextBox ID="LokaleNavnTextBox" runat="server" ReadOnly="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Dato:<asp:TextBox ID="DatoTextBox" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" OnDataBound="GridView_OnDataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Navn"/>
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
                <asp:TemplateField HeaderText="Antal">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Pris per styk" />
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
    <script type='text/javascript'>
        //Your alert function
        function displayAlert() {
            alert("Your Message Here!");
        }
</script>
        &nbsp;<asp:Panel ID="Panel1" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ForplejningButton" runat="server" Text="Tilføj forplejning" 
            onclick="ForplejningButton_Click" CssClass="availabeButton" />
        &nbsp;<asp:Button ID="FortrydButton" runat="server" Text="Fortryd" 
            CssClass="availabeButton" onclick="Fortryd_Click" />
            <asp:ModalPopupExtender ID="FortrydButton_ModalPopupExtender" runat="server" 
            DynamicServicePath="" Enabled="True" TargetControlID="FortrydButton" 
            PopupControlID="Panel2">
        </asp:ModalPopupExtender>
            </asp:Panel>
    </p>
</asp:Content>
