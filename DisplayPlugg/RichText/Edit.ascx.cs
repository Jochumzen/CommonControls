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
    public partial class Edit : UserControlModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnrichtext.Value = this.PHText.Text;
        }

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
        public PHText PHText
        {
            get
            {
                var _PHText = new BaseHandler().GetCurrentVersionText(this.CurrentLanguage, this.ComponentID, ETextItemType.PluggComponentRichText);
                _PHText.Text = _PHText.Text == "(No text)" ? "(currently no text)" : _PHText.Text;
                return _PHText;
            }
        }
        public Page Parent_Page { get; set; }

        #endregion
        // Delegate declaration
        public delegate void OnButtonClick(System.Web.UI.UserControl strValue);
        public event OnButtonClick btnHandler;

        protected void btnSaveRt_Click(object sender, EventArgs e)
        {
            ETextItemType ItemType = ETextItemType.PluggComponentRichText;
            string txt = hdnrichtext.Value;
            UpdatePHtext(ItemType, txt);
        }

        protected void btnCanRt_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(this.TabID, "", new string[] { "edit=1", "language=" + this.CurrentLanguage }));
        }

        private void UpdatePHtext(ETextItemType ItemType, string txt)
        {
            var itemid = Convert.ToInt32(this.ComponentID);

            List<PluggComponent> comps = this.PluggContainer.GetComponentList();
            PluggComponent cToAdd = comps.Find(x => x.PluggComponentId == itemid);
            BaseHandler bh = new BaseHandler();

            var comtype = cToAdd.ComponentType;

            PHText phText = bh.GetCurrentVersionText(this.CurrentLanguage, itemid, ItemType);

            phText.Text = txt;
            phText.CultureCodeStatus = ECultureCodeStatus.GoogleTranslated;
            phText.CreatedByUserId = this.UserID;
            if (this.EditCase == 2)
            {
                phText.CultureCodeStatus = ECultureCodeStatus.HumanTranslated;
                bh.SavePhText(phText);
            }
            else
                bh.SavePhTextInAllCc(phText);
            // bh.SavePhText(phText);
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(this.TabID, "", new string[] { "edit=1", "language=" + this.CurrentLanguage }));
        }

    }
}