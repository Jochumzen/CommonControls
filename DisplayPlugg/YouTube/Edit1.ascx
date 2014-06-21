<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit1.ascx.cs" Inherits="Plugghest.Modules.UserControl.DisplayPlugg.YouTube.Edit1" %>

  <script type="text/javascript">
      $(document).ready(function () {
          if ($('#'+'<%=txtYouTube.ClientID %>').val().length > 5) {
              $('#btnGetYoutubeVideo').trigger('click');
          }
      });

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

<asp:HiddenField ID="hdnlabel" runat="server" />
<asp:HiddenField ID="yttitle" runat="server" />
<asp:HiddenField ID="ytduration" runat="server" />
<asp:HiddenField ID="ytYouTubeCode" runat="server" />
<asp:HiddenField ID="ytAuthor" runat="server" />
<asp:HiddenField ID="ytYouTubeCreatedOn" runat="server" />
<asp:HiddenField ID="ytYouTubeComment" runat="server" />
<asp:Panel runat="server" ID="pnlYoutube"  resourcekey="pnlYoutubeResource1" >
    <asp:TextBox ID="txtYouTube" runat="server"  resourcekey="txtYouTubeResource1" />

    <input type="button" id="btnGetYoutubeVideo" value="Get Video" onclick="CheckURL(this);" />
    <h2   class="title"></h2>

    <h3   class="duration"> </h3>
    <h6  class="YouTubeCode"></h6>
    <h7  class="Author"></h7>
    <h7  class="YouTubeCreatedOn"></h7>
    <h7   class="YouTubeComment"></h7>

    <asp:Button ID="btnYtSave" runat="server"  OnClientClick="getYt()" OnClick="btnSave_Click" resourcekey="btnYtSaveResource1" />
    <asp:Button ID="btnYtCaNCEL" runat="server" OnClick="btnCancel_Click" resourcekey="btnYtCaNCELResource1" />
</asp:Panel>









































































<%--<asp:HiddenField ID="hdnlabel" runat="server" />
<asp:HiddenField ID="yttitle" runat="server" />
<asp:HiddenField ID="ytduration" runat="server" />
<asp:HiddenField ID="ytYouTubeCode" runat="server" />
<asp:HiddenField ID="ytAuthor" runat="server" />
<asp:HiddenField ID="ytYouTubeCreatedOn" runat="server" />
<asp:HiddenField ID="ytYouTubeComment" runat="server" />


<asp:Panel runat="server" ID="pnlYoutube">
    <asp:TextBox ID="txtYouTube" runat="server" />
    <input type="button" id="btnGetYoutubeVideo" value="Get Video" onclick="CheckURL(this);" />
</asp:Panel>

<asp:Panel runat="server" ID="pnlDisplayYouTube">

</asp:Panel>

<asp:Panel runat="server" ID="pnlYoutubeDetail">
    <h2 class="title"></h2>
    <h3 class="duration"></h3>
    <h6 class="YouTubeCode"></h6>
    <h7 class="Author"></h7>
    <h7 class="YouTubeCreatedOn"></h7>
    <h7 class="YouTubeComment"></h7>
</asp:Panel>

<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>--%>