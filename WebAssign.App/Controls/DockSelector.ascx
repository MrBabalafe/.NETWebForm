<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DockSelector.ascx.cs" Inherits="WebAssign.App.Controls.DockSelector" %>

<asp:DropDownList ID="uxDocks" runat="server" Height="40px" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="uxDocks_SelectedIndexChanged"></asp:DropDownList>

<asp:DropDownList ID="uxSlips" runat="server" Height="40px" Width="200px" AutoPostBack="True" Visible="False"></asp:DropDownList>

<asp:Button ID="uxLeaseButton" runat="server" Text="Lease" OnClick="uxLeaseButton_Click" />
<br />
<asp:Label ID="uxError" runat="server" Text="Slip has already been leased!" ForeColor="Red" Visible="False"></asp:Label>

<br />
<br />
<br />

<h3>Leased Slips:</h3>

<asp:GridView ID="uxLeasedSlips" runat="server" Width="270px"></asp:GridView>

<br />
<br />

<h3>Your Leased Slips:</h3>
<asp:GridView ID="uxCustomersLeasedSlips" runat="server" Width="270px"></asp:GridView>
