<%@ Page Language="C#" MasterPageFile="~/GUI/Site.Master" AutoEventWireup="true" CodeBehind="YourBookings.aspx.cs" Inherits="Client.GUI.User.YourBookings" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript" type="text/javascript">
        function confirmBookingDeletion() {
            if (confirm("Er du sikker på, at du vil slette den valgte booking?") == true) {
                return true;
            }
            return false;
        }
</script>
    <h2>
        Dine bookinger
    </h2>
        &nbsp;&nbsp;
        <table class="style1">
            <tr>
                <td class="style2">
                    <asp:GridView ID="YourBookingsGridView" OnRowDataBound="GridView_RowCreated" 
                        runat="server" CellPadding="4" ForeColor="#333333" Width="674px" 
                        OnDataBound="GridView_OnDataBound">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="Lokale" />
                            <asp:BoundField HeaderText="Deltagere"/>
                            <asp:BoundField HeaderText="Tidspunkt" />
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
                </td>
                <td>
                    <table class="style1">
                        <tr>
                            <td>
                    <asp:Button ID="ChangeBookingButton" runat="server" Text="Ændre Booking" Width="160px" margin="20px" onclick="ChangeBookingButton_Click" 
                                    CssClass="availableButton" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Button ID="DeleteBookingButton" runat="server" Text="Slet Booking" Width="160px" onclick="DeleteBookingButton_Click" CssClass="availableButton" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Button ID="CateringButton" runat="server" Text="Tilføj Forplejning" Width="160px" onclick="CateringButton_Click" CssClass="availableButton" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Button ID="EquipmentButton" runat="server" Text="Tilføj Udstyr" Width="160px" onclick="EquipmentButton_Click" CssClass="availableButton" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
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

