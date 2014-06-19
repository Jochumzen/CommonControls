<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit1View.ascx.cs" 
    Inherits="Plugghest.Modules.UserControl.DisplayPlugg.YouTube.Edit1View" %>
<%--<%@ Register Src="../../Common/AddNewComponent.ascx" TagPrefix="uc1" TagName="AddNewComponent" %>--%>

<asp:Panel runat="server" ID="pnlOrdertitle"  resourcekey="pnlOrdertitleResource1"></asp:Panel>
<hr />
<asp:Button ID="BtnRemove" runat="server" Text="Remove Component"  resourcekey="BtnRemoveResource1" />
<asp:Button ID="BtnEdit" runat="server" Text="Edit"  resourcekey="BtnEditResource1" />
<hr />
<asp:Panel runat="server" ID="pnlDisplayYouTube"  resourcekey="pnlDisplayYouTubeResource1">
</asp:Panel>
<hr />
<%--<asp:Panel runat="server" ID="pnlYoutubeDetail">
    <uc1:AddNewComponent runat="server" id="AddNewComponent" />
</asp:Panel>--%>

