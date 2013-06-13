<%@ Page Title="Ab" Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true"
    CodeBehind="EquipmentList.aspx.cs" Inherits="Client.GUI.Administrator.EquipmentList" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="width: 100%">
            <div style="float:left; width:34%; height:100%; border-right: 3px solid orange;">
                            
                            <h2>Udstyrsliste</h2>
                            &nbsp;Udstyrstype
                            <asp:DropDownList ID="EquipmentListTypeDropDown" runat="server">
                            </asp:DropDownList>
                            <br />
                
                            <asp:GridView ID="EquipmentListGridView" runat="server" CellPadding="4" 
                                ForeColor="#333333" OnDataBound="GridView_OnDataBound" GridLines="Both" 
                                Width="332px" OnRowCreated="GridView_RowCreated">
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
                
                            <br />
                
                            <asp:Button ID="DeleteEquipmentButton" runat="server" Text="Slet udstyr" CssClass="availableButton" onclick="DeleteEquipmentButton_Click" />
                            &nbsp;<asp:Button ID="ChangeEquipmentButton" runat="server" Text="Ændre udstyr" onclick="ChangeEquipmentButton_Click" CssClass="availableButton" />
            </div>
            <div style=" width: 40px;"></div>

            <div style="float:right; width:58%; margin-top: 0px;">
                <h2>Tilføj udstyr</h2>
                <p>Navn:
                    <asp:TextBox ID="EquipmentNameTextBox" runat="server"></asp:TextBox>
                </p>
                <p>Kommentar:</p>
                <p>
                    <asp:TextBox ID="CommentTextBox" runat="server" Height="142px" TextMode="MultiLine" Width="405px" style="margin-top: 0px"/>
                </p>
                <p>
                    Kan udlånes:<asp:CheckBox ID="BookableCheckBox" runat="server"/>
                </p>
                <p>Udstyrstype:
                    <asp:DropDownList ID="EquipmentTypeDropDown" runat="server"/>
                </p>
                <p>
                    <asp:Button ID="AddEquipmentButton" runat="server" Text="Tilføj udstyr" onclick="AddEquipmentButton_Click" CssClass="availableButton" />
                </p>
                </div>
    </div>
</asp:Content>
