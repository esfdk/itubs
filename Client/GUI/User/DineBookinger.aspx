<%@ Page Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true" CodeBehind="DineBookinger.aspx.cs" Inherits="Client.GUI.User.DineBookinger" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Dine bookinger
    </h2>
    <p>
    </p>
    <p>
        &nbsp;&nbsp;
        <table class="style1">
            <tr>
                <td class="style2">
                    <asp:GridView ID="GridView1" OnRowDataBound="GridView1_OnRowDataBound" runat="server" CellPadding="4" ForeColor="#333333" 
                        Width="674px" OnDataBound="GridView_OnDataBound">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="Lokale" />
                            <asp:BoundField HeaderText="Kapacitet" SortExpression="KapacitetID" />
                            <asp:BoundField HeaderText="Booket" />
                            <asp:BoundField HeaderText="Status" />
                            <asp:BoundField HeaderText="Forplejning" />
                            <asp:BoundField HeaderText="Udstyr" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#f47a07" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="blue" Font-Bold="True" ForeColor="blue" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
                <td>
                    <table class="style1">
                        <tr>
                            <td>
                    <asp:Button ID="ÆndreBookButton" runat="server" Text="Ændre booking" 
                        Width="160px" margin="20px" onclick="ÆndreBookButton_Click" 
                                    CssClass="availabeButton" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Button ID="SletBookingButton" runat="server" 
                        Text="Slet booking" Width="160px" onclick="SletBookingButton_Click" 
                                    CssClass="availabeButton" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Button ID="ForplejningButton" runat="server" Text="Tilføj forplejning" 
                        Width="160px" onclick="ForplejningButton_Click" CssClass="availabeButton" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Button ID="UdstyrButton" runat="server" Text="Tilføj udstyr" 
                        Width="160px" onclick="UdstyrButton_Click" CssClass="availabeButton" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Button ID="SendGodkendButton" runat="server" Text="Send til godkendelse" 
                        Width="160px" onclick="SendGodkendButton_Click" CssClass="availabeButton" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </p>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 778px;
        }
    </style>
</asp:Content>

