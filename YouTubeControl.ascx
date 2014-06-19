<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YouTubeControl.ascx.cs" Inherits="Plugghest.Modules.UserControl.YouTubeControl" %>
<%--<%@ Register Src="AddNewComponent.ascx" TagPrefix="uc1" TagName="AddNewComponent" %>--%>

<asp:Label ID="Label1" runat="server" Text="Hiiiiiiiiiiiiiiii" BorderColor="#FF66CC"></asp:Label>

<asp:HiddenField ID="hdnlabel" runat="server" />
<asp:HiddenField ID="yttitle" runat="server" />
<asp:HiddenField ID="ytduration" runat="server" />
<asp:HiddenField ID="ytYouTubeCode" runat="server" />
<asp:HiddenField ID="ytAuthor" runat="server" />
<asp:HiddenField ID="ytYouTubeCreatedOn" runat="server" />
<asp:HiddenField ID="ytYouTubeComment" runat="server" />

<asp:Panel runat="server" ID="pnlYoutube">
    <asp:TextBox ID="txtYouTube" runat="server" />
    <input type="button" id="btnGetYoutubeVideo" value="Get Video" onclick="CheckURL(this);" />
    
    <h2 class="title"></h2>

    <h3 class="duration"></h3>
    <h6 class="YouTubeCode"></h6>
    <h7 class="Author"></h7>
    <h7 class="YouTubeCreatedOn"></h7>
    <h7 class="YouTubeComment"></h7>

    <script type="text/javascript">
        function CheckURL(Control) {

            var code = "";
            var url = $($(Control).parent()).find('input[type=text]').val();
            if (url.length == 11) {
                code = url;
            }
            else if (url.indexOf("www.youtube.com") > -1) {

                code = url.substr(url.length - 11, 11);
            }
            else {
                alert("Invalid URL");
            }
            if ($(Control).parent().find("iframe").length > 0) {
                $(Control).parent().find("iframe").remove();
            }
            $($($(Control).parent()).find("input[type=button]")).after("  <iframe style='display: block' width='420' height='345'src='http://www.youtube.com/embed/" + code + "'></iframe>");

            //$.ajax({
            //    url: "http://gdata.youtube.com/feeds/api/videos/" + code + "?v=2&alt=json",
            //    dataType: "jsonp",
            //    success: function (data) {
            //        alert(data);
            //    }
            //});
            $.getJSON('http://gdata.youtube.com/feeds/api/videos/' + code + '?v=2&alt=jsonc', function (data, status, xhr) {

                $($($(Control).parent()).find(".title")).html("title :<span id='title'>" + data.data.title + "</span><br />");
                $($($(Control).parent()).find(".duration")).html("duration :<span id='duration'>" + data.data.duration + "</span> Seconds<br />");
                $($($(Control).parent()).find(".YouTubeCode")).html("YouTube Code :<span id='YouTubeCode'>" + data.data.id + "</span><br />");
                $($($(Control).parent()).find(".Author")).html("Author :<span id='Author'>" + data.data.uploader + "</span><br />");
                $($($(Control).parent()).find(".YouTubeCreatedOn")).html("YouTube CreatedOn :<span id='YouTubeCreatedOn'>" + data.data.uploaded + "</span><br />");
                $($($(Control).parent()).find(".YouTubeComment")).html("YouTube Author Comment :<span id='YouTubeComment'>" + data.data.description + "</span><br />");
                // data contains the JSON-Object below
            });


        };

        function getYt() {

            var a = $("#title").text();
            $("#" + '<%=yttitle.ClientID%>').val(a);
            $("#" + '<%=ytduration.ClientID%>').val($("#duration").text());
            $("#" + '<%=ytYouTubeCode.ClientID%>').val($("#YouTubeCode").text());
            $("#" + '<%=ytAuthor.ClientID%>').val($("#Author").text());
            $("#" + '<%=ytYouTubeCreatedOn.ClientID%>').val($("#YouTubeCreatedOn").text());
            $("#" + '<%=ytYouTubeComment.ClientID%>').val($("#YouTubeComment").text());
        }
    </script>

    <asp:Button ID="btnYtSave" runat="server" Text="Save" OnClientClick="getYt()" OnClick="btnYtSave_Click" /><asp:Button ID="btnYtCaNCEL" runat="server" Text="Cancel" OnClick="Cancel_Click" />
</asp:Panel>

<asp:Button ID="BtnRemove" runat="server" Text="remove" OnClick="BtnRemove_Click" Visible="False" /><asp:Button ID="BtnEdit" runat="server" Text="edit" OnClick="BtnEdit_Click" Visible="False" />
<asp:Panel runat="server" ID="pnYoutubeIFrame" Visible="false"></asp:Panel>
<%--<uc1:addnewcomponent runat="server" id="AddNewComponent" />--%>