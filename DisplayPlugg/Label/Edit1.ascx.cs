using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using Plugghest.Base2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plugghest.Modules.UserControl.DisplayPlugg.Label
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
        public int EditCase { get; set; }

        public PHText PHText
        {
            get { return new BaseHandler().GetCurrentVersionText(this.CurrentLanguage, this.ComponentID, ETextItemType.PluggComponentLabel); }
        }

        public Page Parent_Page { get; set; }
        #endregion
        // Delegate declaration
        public delegate void OnButtonClick(System.Web.UI.UserControl strValue);
        public event OnButtonClick btnHandler;


        protected void Page_Load(object sender, EventArgs e)
        {
            txtlabel.Text = this.PHText.Text;
        }

        protected void btnLabelSave_Click(object sender, EventArgs e)
        {
            ETextItemType ItemType = ETextItemType.PluggComponentLabel;
            string txt = txtlabel.Text;
            UpdatePHText(ItemType, txt);
        }

        public void UpdatePHText(ETextItemType ItemType, string txt)
        {
            var itemid = Convert.ToInt32(this.ComponentID);

            List<PluggComponent> comps = this.PluggContainer.GetComponentList();
            PluggComponent cToAdd = comps.Find(x => x.PluggComponentId == itemid);
            BaseHandler bh = new BaseHandler();

            var comtype = cToAdd.ComponentType;

            PHText phText = this.PHText;

            phText.Text = txt;
            phText.CultureCodeStatus = ECultureCodeStatus.GoogleTranslated;
            phText.CreatedByUserId = this.UserID;
            bh.SavePhTextInAllCc(phText);
            // bh.SavePhText(phText);
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(this.TabID, "", new string[] { "edit=1", "language=" + this.CurrentLanguage }));
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void Cancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(this.TabID, "", new string[] { "edit=1", "language=" + this.CurrentLanguage }));
        }
    }
}