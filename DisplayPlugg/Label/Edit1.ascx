<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit1.ascx.cs" Inherits="Plugghest.Modules.UserControl.DisplayPlugg.Label.Edit1" %>
<asp:Panel runat="server" ID="pnllabel" resourcekey="pnllabelResource1" >
    <asp:TextBox runat="server" ID="txtlabel" resourcekey="txtlabelResource1"></asp:TextBox>
    <asp:Button ID="btnLabelSave" runat="server" OnClick="btnLabelSave_Click" resourcekey="btnLabelSaveResource1" />
    <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click1" resourcekey="CancelResource1" />
    <asp:HiddenField ID="hdnlabel" runat="server" />
</asp:Panel>