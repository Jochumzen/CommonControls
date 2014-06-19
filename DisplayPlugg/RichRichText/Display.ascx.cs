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
    public partial class Display : UserControlModuleBase
    {
        #region Properties
        private int order;
        public int Order
        {
            get { return order; }
            set
            {
                order = value;
                pnlRRtext.Controls.Add(new LiteralControl(this.HtmlString));
            }
        }
        public string HtmlString
        {
            get { return this.PHText == null ? "<div><div id=Latex" + (this.Order + 1) + " class='Main'>" + "Component " + this.Order + ": " + this.RichRichText + " </div></div>" : "<div><div id=Latex" + (this.Order + 1) + " class='Main'> " + "Component " + this.Order + ": " + this.RichRichText + " " + this.PHText.Text + " </div></div>"; }
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
                var _PHText = new BaseHandler().GetCurrentVersionText(this.CurrentLanguage, this.ComponentID, ETextItemType.PluggComponentRichRichText);
                _PHText.Text = _PHText.Text == "(No text)" ? "(currently no text)" : _PHText.Text;
                return _PHText;
            }
        }

        public string RichRichText
        {
            get
            {
                var lanText = Localization.GetString("ComponentText", this.LocalResourceFile + ".ascx." + this.CurrentLanguage + ".resx");
                return !string.IsNullOrEmpty(lanText) ? lanText : "RichRichText";
            }
        }
        public Page Parent_Page { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}