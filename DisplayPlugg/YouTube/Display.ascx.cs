using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Plugghest.Modules.UserControl.Utility;

namespace Plugghest.Modules.UserControl.DisplayPlugg.YouTube
{
    /// <summary>
    /// For Displaying YouTube Components.
    /// </summary>
    public partial class Display : System.Web.UI.UserControl
    {
        #region Properties
        public int YTComponentId
        {
            set
            {
                pnYoutubeIFrame.Controls.Add(new LiteralControl(YouTubeHelper.GetIframeString(Convert.ToInt32(value), this.PageCultureName)));
            }
        }

        private string PageCultureName
        {
            get
            {
                return (this.Parent_Page as DotNetNuke.Framework.PageBase).PageCulture.Name;
            }
        }
        public Page Parent_Page { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}