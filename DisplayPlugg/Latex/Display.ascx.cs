using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using Plugghest.Base2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plugghest.Modules.UserControl.DisplayPlugg.Latex
{
    public partial class Display : PortalModuleBase
    {

        private int order;

        public int Order
        {
            get { return order; }
            set
            {
                order = value;
                pnlLatex.Controls.Add(new LiteralControl(this.HtmlString));
            }
        }

        public string HtmlString
        {
            get { return this.PhLat == null ? "<div><div id=Latex" + (this.Order + 1) + " class='Main'>" + "Component " + this.Order + ": " + this.LatexText + " </div></div>" : "<div><div id=Latex" + (this.Order + 1) + " class='Main'> " + "Component " + this.Order + ": " + this.LatexText + " " + this.PhLat.Text + "</div></div>"; }
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
        private PHLatex PhLat
        {
            get
            {
                var PHText = new BaseHandler().GetCurrentVersionLatexText(this.CurrentLanguage, this.ComponentID, ELatexItemType.PluggComponentLatex);
                PHText.Text = PHText.Text == "(No text)" ? "(currently no text)" : PHText.Text;
                return PHText;
            }
        }
        public int TabID { get; set; }
        public string LatexText
        {
            get
            {
                var lanText = Localization.GetString("LatexText", this.LocalResourceFile);
                return !string.IsNullOrEmpty(lanText) ? lanText : "Latex";
            }
        }

        public Page Parent_Page { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}