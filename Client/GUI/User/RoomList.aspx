<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true"
    CodeBehind="RoomList.aspx.cs" Inherits="Client.GUI.User.RoomList" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%-- Source for script: http://www.dotnetcurry.com/ShowArticle.aspx?ID=149 --%>
    <script type="text/javascript">
        function checkDate(sender, args) {
            if (sender._selectedDate < new Date()) {
                alert("Du kan ikke vælge en dag før i dag!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format));
            }}
    </script>

    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />  
    <h2>
        Lokaleliste
    </h2>
    <p>
        <asp:Image ID="RedBox" runat="server" ImageUrl="~/GUI/Images/HvidBoks.png" />
&nbsp;= Ledig&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="WhiteBox" runat="server" BorderColor="Black" BorderStyle="None" 
            BorderWidth="1px" ImageUrl="~/GUI/Images/BlåBoks.png" />
&nbsp;= Dine bookinger&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="BlueBox" runat="server" ImageUrl="~/GUI/Images/RødBoks.png" />
        &nbsp;= Booket</p>
    <p>
         Dato(mm/dd/YYYY):
         <asp:TextBox ID="DateTextBox" AutoPostBack="true" OnTextChanged="DateChanged" runat="server"/>
         <ajaxToolkit:CalendarExtender ID="DateCalendarExtender" TargetControlID="DateTextBox" Format="MM/dd/yyyy" runat="server" OnClientDateSelectionChanged="checkDate" />  
    </p>
    <asp:GridView ID="RoomGridView" runat="server" CellPadding="4" ForeColor="#333333" OnDataBound="GridView_OnDataBound" OnRowCreated="GridView_RowCreated" AllowPaging="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField HeaderText="Navn" />
            <asp:BoundField HeaderText="Kapacitet" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField HeaderText="Udstyr" />
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
    <p1>
        <asp:Button ID="BookLokaleButton" runat="server" CssClass="availableButton" 
            onclick="BookLokaleButton_Click" Text="Book Valgte" />
    </p1>
</asp:Content>
