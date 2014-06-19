using Plugghest.Base2;
using Plugghest.Modules.UserControl.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plugghest.Modules.UserControl.DisplayPlugg.YouTube
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Edit1View : System.Web.UI.UserControl
    {
        #region Properties
        public int YoutubeComID
        {
            set
            {
                pnlDisplayYouTube.Controls.Add(new LiteralControl(YouTubeHelper.GetIframeString(value, this.PageCultureName)));
            }
        }

        private string PageCultureName
        {
            get
            {
                return (Page as DotNetNuke.Framework.PageBase).PageCulture.Name;
            }
        }

        private int _Order;

        /// <summary>
        /// Order of component.
        /// </summary>
        public int Order
        {
            get { return _Order; }
            set
            {
                _Order = value;
                //string html = string.Format("<div><div id=Youtube{0} class='Main'>{1} {2}: YouTube", this._Order, this.ComponentText, this._Order);
                //pnlOrdertitle.Controls.Add(new LiteralControl(html));
                //AddNewComponent.Order = this._Order;
            }
        }

        /// <summary>
        /// ComponentText Based on Globalization.
        /// </summary>
        private string ComponentText
        {
            get { return "Component"; }
        }
        #endregion

        public Edit1View()
        {

        }

        /// <summary>
        /// To set Control members at Initialization level.
        /// </summary>
        public void Initialize_this()
        {
          
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}