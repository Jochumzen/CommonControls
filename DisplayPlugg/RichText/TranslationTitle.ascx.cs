using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using Plugghest.Base2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plugghest.Modules.UserControl.DisplayPlugg.RichText
{
    public partial class TranslationTitle : PortalModuleBase
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
                var lanText = Localization.GetString("ComponentText", this.LocalResourceFile );
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

        public Enum EnumPluggComponent { get; set; }


        public int TabID { get; set; }
        public int EditCase { get; set; }

        public PHText PHText
        {
            get { return new BaseHandler().GetCurrentVersionText(this.CurrentLanguage, this.ComponentID, ETextItemType.PluggComponentRichText); }
        }

        public Page Parent_Page { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.PHText.CultureCodeStatus == ECultureCodeStatus.GoogleTranslated)
            { btnGoogleTransOk.Visible = true; btnImproveGoogleText.Visible = true; btnImproveHumanText.Visible = false; }
            if (this.PHText.CultureCodeStatus == ECultureCodeStatus.HumanTranslated)
            {btnImproveHumanText.Visible = true; btnGoogleTransOk.Visible = false; btnImproveGoogleText.Visible = false;}
        }

        protected void btnGoogleTransOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "test=2", "language=" + this.CurrentLanguage }));
        }

        protected void btnImproveGoogleText_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "edit=2",  "trans=" + this.ComponentID, "language=" + this.CurrentLanguage }));
        }

        protected void btnImproveHumanText_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId, "", new string[] { "edit=2", "trans=" + this.ComponentID, "language=" + this.CurrentLanguage }));
        }
    }
}