<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit1.ascx.cs" Inherits="Plugghest.Modules.UserControl.DisplayPlugg.RichRichText.Edit1" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/texteditor.ascx" %>
<asp:Panel runat="server" ID="pnlRRT" resourcekey="pnlRRTResource1" >
    <dnn:texteditor runat="server" id="richrichtext"></dnn:texteditor>
    <asp:Button ID="btnSaveRRt" runat="server"  OnClick="btnSaveRRt_Click" resourcekey="btnSaveRRtResource1" />
    <asp:Button ID="btnCanRRt" runat="server"  OnClick="btnCanRRt_Click" resourcekey="btnCanRRtResource1" />
</asp:Panel>