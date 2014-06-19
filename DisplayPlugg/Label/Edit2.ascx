<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit2.ascx.cs" Inherits="Plugghest.Modules.UserControl.DisplayPlugg.Label.Edit2" %>
<asp:Panel ID="pnlLabelEdit2" runat="server"  resourcekey="pnlLabelEdit2Resource1"></asp:Panel>
    <asp:TextBox runat="server" ID="txtlabel" resourcekey="txtlabelResource1"></asp:TextBox>
    <asp:Button ID="btnLabelSave" runat="server" OnClick="btnLabelSave_Click" resourcekey="btnLabelSaveResource1" />
    <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click" resourcekey="CancelResource1" />
    <asp:HiddenField ID="hdnlabel" runat="server" />
</asp:Panel>