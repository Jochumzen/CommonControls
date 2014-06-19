using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework;
using DotNetNuke.Services.Localization;
using Plugghest.Base2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plugghest.Modules.UserControl.DisplayPlugg.Common
{
    public partial class AddNewComponent : UserControlModuleBase
    {
        public int Order { get; set; }

        private string AddNewAfter
        {
            get {
                var lanText = Localization.GetString("AddNewAfter", this.LocalResourceFile + ".ascx." + this.CurrentLanguage + ".resx");
                return string.Format("{0} {1}",!string.IsNullOrEmpty(lanText)?lanText: "Add new component After", this.Order); 
            }
        }

        private string AddNewBetween
        {
            get
            {
                var lanText = Localization.GetString("AddNewBetween", this.LocalResourceFile + ".ascx." + this.CurrentLanguage + ".resx");
                return string.Format("{0} {1} and {2}", !string.IsNullOrEmpty(lanText) ? lanText : "Add new component Between", this.Order, this.Order + 1);
            }
        }

        private bool _isLastComp;
        public bool isLastComp
        {
            get { return _isLastComp; }
            set
            {
                _isLastComp = value;
                lblbottom.Text = _isLastComp ? this.AddNewAfter : this.AddNewBetween;
            }
        }

        public int PluggID
        {
            get { return Convert.ToInt32(((DotNetNuke.Framework.CDefault)this.Parent_Page).Title); }
        }
        public string CurrentLanguage
        {
            get { return (this.Parent_Page as DotNetNuke.Framework.PageBase).PageCulture.Name; }
        }
        public PluggContainer PluggContainer
        {
            get { return new PluggContainer(this.CurrentLanguage, this.PluggID); }
        }

        public Page Parent_Page { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ddCoponentList.DataSource = Enum.GetNames(typeof(EComponentType)).Where(x => !x.Contains("NotSet"));
            ddCoponentList.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BaseHandler plugghandler = new BaseHandler();
            PluggComponent pc = new PluggComponent();
            pc.ComponentOrder = Order + 1;
            pc.ComponentType = (EComponentType)Enum.Parse(typeof(EComponentType), ddCoponentList.SelectedValue);
            plugghandler.AddComponent(this.PluggContainer, pc);
            //Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(this.TabID, "", new string[] { "edit=1", "language=" + this.CurrentLanguage }));
        }
    }
}