<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddNewComponent.ascx.cs" Inherits="Plugghest.Modules.UserControl.DisplayPlugg.Common.AddNewComponent" %>

<div style="float:left;"> <asp:Label ID="lblbottom" runat="server" resourcekey="lblbottomResource1"></asp:Label></div>
<div style="float:right;">
<asp:DropDownList ID="ddCoponentList" runat="server" resourcekey="ddCoponentListResource1"></asp:DropDownList>
<asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" resourcekey="btnAddResource1" />
    </div>
<hr/>
