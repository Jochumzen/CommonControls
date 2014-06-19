using Plugghest.Base2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plugghest.Modules.UserControl
{
    public partial class YouTubeControl : System.Web.UI.UserControl
    {
        private EMode _Mode;

        public string Mode
        {
            get { return Enum.GetName(typeof(EMode), _Mode); }
            set
            {
                _Mode = (EMode)Enum.Parse(typeof(EMode), value);
                Initialize_this();
            }
        }

        public int Order { get; set; }


        public int YouTubeId { get; set; }

        private void Initialize_this()
        {
            switch (this._Mode)
            {
                case EMode.Edit1:
                    DisableallButtons();
                    BtnRemove.Visible = true;
                    BtnEdit.Visible = true;
                    pnlYoutube.Visible = false;
                    //AddNewComponent.Visible = false;
                    CaseDisplay();
                    //btnEdit1.Enabled = true;
                    break;
                case EMode.Edit2:
                    DisableallButtons();
                    //btnEdit2.Enabled = true;
                    break;
                case EMode.Display:
                
                    CaseDisplay();
                    //btnDisplay.Enabled = true;
                    break;

            }
        }

        private void CaseDisplay()
        {
            BaseHandler bh = new BaseHandler();
            YouTube yt = bh.GetYouTubeByComponentId(YouTubeId);
            pnYoutubeIFrame.Visible = true;
            pnYoutubeIFrame.Controls.Add(new LiteralControl(yt.GetIframeString((Page as DotNetNuke.Framework.PageBase).PageCulture.Name)));
        }

        private void DisableallButtons()
        {
            //foreach (var control in this.Controls.OfType<Button>())
            //    control.Enabled = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //AddNewComponent.Order = this.Order;
        }

        protected void btnYtSave_Click(object sender, EventArgs e)
        {

            //string curlan = (Page as DotNetNuke.Framework.PageBase).PageCulture.Name;
            //int pluggid = Convert.ToInt32(((DotNetNuke.Framework.CDefault)this.Page).Title);
            //PluggContainer p = new PluggContainer(curlan, pluggid);

            //List<PluggComponent> comps = p.GetComponentList();

            //BaseHandler bh = new BaseHandler();


            //List<object> objToadd = new List<object>();
            BaseHandler bh = new BaseHandler();
            YouTube yt = bh.GetYouTubeByComponentId(YouTubeId);
            if (yt == null)
                yt = new YouTube();
            try
            {
                yt.YouTubeTitle = yttitle.Value;
                yt.YouTubeDuration = Convert.ToInt32(ytduration.Value);
                yt.YouTubeCode = ytYouTubeCode.Value;
                yt.YouTubeAuthor = ytAuthor.Value;
                yt.YouTubeCreatedOn = Convert.ToDateTime(ytYouTubeCreatedOn.Value);
                yt.YouTubeComment = ytYouTubeComment.Value;
                yt.PluggComponentId = YouTubeId;
            }
            catch
            {

            }

            bh.SaveYouTube(yt);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void BtnRemove_Click(object sender, EventArgs e)
        {

        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            pnlYoutube.Visible = true;
            //AddNewComponent.Visible = false;
        }
    }
}