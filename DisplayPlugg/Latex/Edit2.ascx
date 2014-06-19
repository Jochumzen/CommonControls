<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit2.ascx.cs" Inherits="Plugghest.Modules.UserControl.DisplayPlugg.Latex.Edit2" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/texteditor.ascx" %>
<asp:Panel runat="server" ID="pnlletex"  resourcekey="pnlletexResource1">
    <dnn:texteditor runat="server" id="txtRRtext"></dnn:texteditor>
    <asp:Button ID="btnSaveRRt" runat="server"  OnClick="btnSaveRRt_Click" resourcekey="btnSaveRRtResource1" />
    <asp:Button ID="btnCanRRt" runat="server"  OnClick="btnCanRRt_Click" resourcekey="btnCanRRtResource1" />
</asp:Panel>
