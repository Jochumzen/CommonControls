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
    public partial class Display : PortalModuleBase
    {
        #region Properties
        private int order;
        public int Order
        {
            get { return order; }
            set
            {
                order = value;
                pnlLabel.Controls.Add(new LiteralControl(this.HtmlString));
            }
        }
        public string HtmlString
        {
            get { return this.PHText == null ? "<div><div id=Latex" + (this.Order + 1) + " class='Main'>" + "Component " + this.Order + ": " + this.LabelText + " </div></div>" : "<div><div id=Latex" + (this.Order + 1) + " class='Main'> " + "Component " + this.Order + ": " + this.LabelText + " " + this.PHText.Text + " </div></div>"; }
        }
        private int _ComponentID;
        public int ComponentID
        {
            get { return _ComponentID; }
            set { _ComponentID = value; }
        }
        private int PluggID
        {
            get { return Convert.ToInt32(((DotNetNuke.Framework.CDefault)this.Parent_Page).Title); }
        }
        private string CurrentLanguage
        {
            get { return (this.Parent_Page as DotNetNuke.Framework.PageBase).PageCulture.Name; }
        }
        private Plugghest.Base2.PluggContainer PluggContainer
        {
            get { return new Plugghest.Base2.PluggContainer(this.CurrentLanguage, this.PluggID); }
        }
        private PHText PHText
        {
            get
            {
                var _PHText = new BaseHandler().GetCurrentVersionText(this.CurrentLanguage, this.ComponentID, ETextItemType.PluggComponentLabel);
                _PHText.Text = _PHText.Text == "(No text)" ? "(currently no text)" : _PHText.Text;
                return _PHText;
            }
        }
        public string LabelText
        {
            get {
                var lanText = Localization.GetString("LabelText", this.LocalResourceFile );
                return !string.IsNullOrEmpty(lanText)?lanText: "LabelText"; 
            }
        }
        public Page Parent_Page { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}