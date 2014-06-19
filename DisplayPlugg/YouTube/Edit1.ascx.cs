using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using Plugghest.Base2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plugghest.Modules.UserControl.DisplayPlugg.YouTube
{
    public partial class Edit1 : PortalModuleBase
    {
        #region Properties
        /// <summary>
        /// Order of component.
        /// </summary>
        private int _Order;
        public int Order
        {
            get { return _Order; }
            set
            {
                _Order = value;
            }
        }

        /// <summary>
        /// ComponentText Based on Globalization.
        /// </summary>
        private string ComponentText
        {
            get
            {
                var lanText = Localization.GetString("ComponentText", this.LocalResourceFile);
                return !string.IsNullOrEmpty(lanText) ? lanText : "Component";
            }
        }
        public int UserID { get; set; }

        public EComponentType ComponentType { get; set; }
        public int ComponentID { get; set; }

        public int PluggID
        {
            get { return Convert.ToInt32(((DotNetNuke.Framework.CDefault)this.Parent_Page).Title); }
        }
        public string CurrentLanguage
        {
            get { return (this.Parent_Page as DotNetNuke.Framework.PageBase).PageCulture.Name; }
        }
        public Plugghest.Base2.PluggContainer PluggContainer
        {
            get { return new Plugghest.Base2.PluggContainer(this.CurrentLanguage, this.PluggID); }
        }
        public int TabID { get; set; }

        private Base2.YouTube _YouTube
        {
            get
            {
                var _yt = new BaseHandler().GetYouTubeByComponentId(this.ComponentID);
                return _yt = _yt != null ? _yt : new Base2.YouTube();
            }
        }
        public Page Parent_Page { get; set; }

        #endregion
        // Delegate declaration
        public delegate void OnButtonClick(System.Web.UI.UserControl strValue);
        public event OnButtonClick btnHandler;


        protected void Page_Load(object sender, EventArgs e)
        {
            LoadComponent();
        }

        protected void LoadComponent()
        {
            yttitle.Value = this._YouTube.YouTubeTitle;
            ytduration.Value = Convert.ToString(this._YouTube.YouTubeDuration);
            ytYouTubeCode.Value = this._YouTube.YouTubeCode;
            ytAuthor.Value = this._YouTube.YouTubeAuthor;
            ytYouTubeCreatedOn.Value = this._YouTube.YouTubeCreatedOn.ToString();
            ytYouTubeComment.Value = this._YouTube.YouTubeComment;
            txtYouTube.Text = this._YouTube.YouTubeCode;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<PluggComponent> comps = this.PluggContainer.GetComponentList();

            BaseHandler bh = new BaseHandler();
            List<object> objToadd = new List<object>();
            Plugghest.Base2.YouTube yt = bh.GetYouTubeByComponentId(this.ComponentID);
            if (yt == null)
                yt = new Plugghest.Base2.YouTube();
            try
            {
                yt.YouTubeTitle = yttitle.Value;
                yt.YouTubeDuration = Convert.ToInt32(ytduration.Value);
                yt.YouTubeCode = ytYouTubeCode.Value;
                yt.YouTubeAuthor = ytAuthor.Value;
                yt.YouTubeCreatedOn = Convert.ToDateTime(ytYouTubeCreatedOn.Value);
                yt.YouTubeComment = ytYouTubeComment.Value;
                yt.PluggComponentId = this.ComponentID;
            }
            catch
            {

            }

            bh.SaveYouTube(yt);

            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(this.TabID, "", new string[] { "edit=1", "language=" + this.CurrentLanguage }));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(this.TabID, "", new string[] { "edit=1", "language=" + this.CurrentLanguage }));
        }


    }
}