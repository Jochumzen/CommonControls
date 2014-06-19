<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit2.ascx.cs" Inherits="Plugghest.Modules.UserControl.DisplayPlugg.RichRichText.Edit2" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/texteditor.ascx" %>
<asp:Panel ID="pnlRichRichTextEdit2" runat="server" resourcekey="pnlRichRichTextEdit2Resource1"></asp:Panel>
    <dnn:texteditor runat="server" id="richrichtext"></dnn:texteditor>
    <asp:Button ID="btnSaveRRt" runat="server"  OnClick="btnSaveRRt_Click" resourcekey="btnSaveRRtResource1" />
    <asp:Button ID="btnCanRRt" runat="server"  OnClick="btnCanRRt_Click" resourcekey="btnCanRRtResource1" />
</asp:Panel>