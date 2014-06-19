using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using Plugghest.Base2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plugghest.Modules.UserControl.DisplayPlugg.RichRichText
{
    public partial class Edit2 : PortalModuleBase
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
        public int EditCase { get; set; }

        private PHText PHText
        {
            get
            {
                var _PHText = new BaseHandler().GetCurrentVersionText(this.CurrentLanguage, this.ComponentID, ETextItemType.PluggComponentRichRichText);
                _PHText.Text = _PHText.Text == "(No text)" ? "(currently no text)" : _PHText.Text;

                return _PHText;
            }
        }
        public Page Parent_Page { get; set; }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            richrichtext.Text = this.PHText.Text;
        }

        protected void btnSaveRRt_Click(object sender, EventArgs e)
        {
            BaseHandler bh = new BaseHandler();
            PHText objPHtext = this.PHText; //new PHText(System.Net.WebUtility.HtmlDecode(richrichtext.Text), this.CurrentLanguage, ETextItemType.PluggComponentRichRichText);
            objPHtext.Text = richrichtext.Text;
            objPHtext.ModifiedByUserId = this.UserID;
            objPHtext.CultureCodeStatus = ECultureCodeStatus.HumanTranslated;
            bh.SavePhText(objPHtext);

            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(this.TabID, "", new string[] { "edit=1", "language=" + this.CurrentLanguage }));
        }

        protected void btnCanRRt_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(this.TabID, "", new string[] { "edit=1", "language=" + this.CurrentLanguage }));
        }
    }
}