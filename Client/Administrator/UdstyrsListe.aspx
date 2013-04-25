<%@ Page Title="Ab" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="UdstyrsListe.aspx.cs" Inherits="BookIT.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 70%;
            margin-top: 0px;
            height: 231px;
        }
        .style3
        {
            width: 416px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Udstyrsliste
    </h2>
    <p>
        &nbsp;</p>
    <table class="style1">
        <tr>
            <td class="style3">
                
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                                GridLines="Both" Width="451px">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField HeaderText="Navn" />
                                    <asp:BoundField HeaderText="Kommentar" />
                                    <asp:TemplateField HeaderText="Type"></asp:TemplateField>
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
                
                            <asp:Button ID="SletUdstyrButton" runat="server" Text="Slet udstyr" 
                                CssClass="buttonStyle1" onclick="SletUdstyrButton_Click" />
                            &nbsp;<asp:Button ID="ÆndreUdstyrButton" runat="server" Text="Ændre udstyr" 
                                onclick="ÆndreUdstyrButton_Click" CssClass="buttonStyle1" />
            </td>
            <td>
            <h2>Tilføj udstyr</h2>
                <p>Navn:
                    <asp:TextBox ID="UdstyrsNavnTextBox" runat="server"></asp:TextBox>
                </p>
                <p>Kommentar:</p>
                <p>
                    <asp:TextBox ID="KommentarTextBox" runat="server" Height="142px" TextMode="MultiLine" 
                        Width="405px"></asp:TextBox>
                </p>
                <p>Udstyrstype:
                    <asp:DropDownList ID="UdstyrsTypeDropDown" runat="server">
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Button ID="TilføjUdstyrButton" runat="server" Text="Tilføj udstyr" 
                        onclick="TilføjUdstyrButton_Click" CssClass="buttonStyle1" />
                </p>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
