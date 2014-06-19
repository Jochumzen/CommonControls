<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="Plugghest.Modules.UserControl.DisplayPlugg.RichText.Edit" %>
<script>
    $(document).ready(function () {
        $('#editor').html($('#' + '<%=hdnrichtext.ClientID%>').val());
    })

function getRichtext() {
          $('#' + '<%=hdnrichtext.ClientID%>').val($('#editor').html());
      }
    </script>
<asp:HiddenField ID="hdnrichtext" runat="server" />
<asp:Panel ID="richtextbox" runat="server"  resourcekey="richtextboxResource1" >
    <div class='container'>
        <div class='hero-unit'>

            <div id='alerts'></div>
            <div class='btn-toolbar' data-role='editor-toolbar' data-target='#editor'>


                <div class='btn-group'>
                    <a class='btn' data-edit='bold' title='Bold (Ctrl/Cmd+B)'><i class='icon-bold'></i></a>
                    <a class='btn' data-edit='italic' title='Italic (Ctrl/Cmd+I)'><i class='icon-italic'></i></a>

                </div>
                <div class='btn-group'>
                    <a class='btn' data-edit='insertunorderedlist' title='Bullet list'><i class='icon-list-ul'></i></a>
                    <a class='btn' data-edit='insertorderedlist' title='Number list'><i class='icon-list-ol'></i></a>

                </div>

                <div class='btn-group'>
                    <a class='btn dropdown-toggle' data-toggle='dropdown' title='Hyperlink'><i class='icon-link'></i></a>
                    <div class='dropdown-menu input-append'>
                        <input class='span2' placeholder='URL' type='text' data-edit='createLink' />
                        <button class='btn' type='button'>Add</button>
                    </div>
                    <a class='btn' data-edit='unlink' title='Remove Hyperlink'><i class='icon-cut'></i></a>

                </div>


                <div class='btn-group'>
                    <a class='btn' data-edit='undo' title='Undo (Ctrl/Cmd+Z)'><i class='icon-undo'></i></a>
                    <a class='btn' data-edit='redo' title='Redo (Ctrl/Cmd+Y)'><i class='icon-repeat'></i></a>
                </div>

            </div>

            <div id='editor'>
               Go ahead&hellip;
            </div>
            <br />

        </div>



    </div>
    <asp:Button ID="btnSaveRt" OnClientClick="getRichtext()" runat="server" Text="Save" OnClick="btnSaveRt_Click"  resourcekey="btnSaveRtResource1" />
    <asp:Button ID="btnCanRt" runat="server" Text="Cancel" OnClick="btnCanRt_Click" Height="27px"  resourcekey="btnCanRtResource1" />
</asp:Panel>