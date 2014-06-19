using DotNetNuke.Common.Utilities;
using DotNetNuke.UI.Utilities;
using Plugghest.Base2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




namespace Plugghest.Modules.UserControl.DisplayPlugg.Common
{
    public partial class OrderTitle : System.Web.UI.UserControl
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
                string html = string.Format("<div><div id={0}{1} class='Main'>{2} {3}: {0}</div></div>", Enum.GetName(typeof(EComponentType), this.ComponentType), this._Order, this.ComponentText, this._Order);
                pnlOrdertitle.Controls.Add(new LiteralControl(html));
            }
        }

        /// <summary>
        /// ComponentText Based on Globalization.
        /// </summary>
        private string ComponentText
        {
            get { return "Component"; }
        }
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
        public int UserID { get; set; }

        private PHText PHText
        {
            get
            {
                var _PHText = new BaseHandler().GetCurrentVersionText(this.CurrentLanguage, this.ComponentID, ETextItemType.PluggComponentLabel);
                _PHText.Text = _PHText.Text == "(No text)" ? "(currently no text)" : _PHText.Text;
                return _PHText;
            }
        }

        public Page Parent_Page { get; set; }
        #endregion

        // Delegate declaration
        public delegate void OnButtonClick(System.Web.UI.UserControl strValue);
        // Event declaration
        public event OnButtonClick btnHandler;


        protected void Page_Load(object sender, EventArgs e)
        {
            //BtnEdit.Attributes.Add("onclick", "return " + UrlUtils.PopUpUrl("www.google.com" , this, DotNetNuke.Entities.Portals.PortalSettings.Current, true, false, 390, 670));

        }

        protected void BtnRemove_Click(object sender, EventArgs e)
        {
            BaseHandler plugghandler = new BaseHandler();
            plugghandler.DeleteComponent(this.PluggContainer, this.Order);
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(this.TabID, "", new string[] { "edit=1", "language=" + this.CurrentLanguage }));
        }

        public void BtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(this.TabID, "", new string[] { "edit=11","s=true","cid="+this.ComponentID ,"language=" + this.CurrentLanguage }));

            //var feedEditControl = ControlRepository.SingleInstance_AllEdit1[this.ComponentType];
            //feedEditControl.GetType().GetProperty("Order", BindingFlags.Public | BindingFlags.Instance).SetValue(feedEditControl, this.Order, null);
            //feedEditControl.GetType().GetProperty("ComponentID", BindingFlags.Public | BindingFlags.Instance).SetValue(feedEditControl, this.ComponentID, null);
            //feedEditControl.GetType().GetProperty("UserID", BindingFlags.Public | BindingFlags.Instance).SetValue(feedEditControl, this.UserID, null);
            //if (btnHandler != null)
            //    btnHandler(feedEditControl);

            ////var Popup = this.Parent.FindControl("pnlEditPopup");
            ////Popup.Controls.Clear();
            ////Popup.Controls.Add(feedEditControl);
            ////string script = " $('#Component_Edit_to_pop').bPopup({appendTo: 'form', closeClass: 'ui-dialog-titlebar-close', speed: 650, transition: 'slideIn', zIndex: 2, modalClose: true});";
            ////ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", script, true);

            #region old
            //switch (this.ComponentType)
            //{
            //    case EComponentType.YouTube:
            //        var YoutubeEdit = (Plugghest.Modules.UserControl.DisplayPlugg.YouTube.Edit1)LoadControl(Plugghest.Base2.UserControlRoot.YouTube.Edit);
            //        if (btnHandler != null)
            //            btnHandler(YoutubeEdit);
            //        return;
            //    case EComponentType.RichText:
            //        var RichTextEdit = (Plugghest.Modules.UserControl.DisplayPlugg.RichText.Edit)LoadControl(Plugghest.Base2.UserControlRoot.RichText.Edit1);
            //        if (btnHandler != null)
            //            btnHandler(RichTextEdit);
            //        return;
            //    case EComponentType.RichRichText:
            //        var RichRichText = (Plugghest.Modules.UserControl.DisplayPlugg.RichRichText.Edit1)LoadControl(Plugghest.Base2.UserControlRoot.RichRichText.Edit1);
            //        if (btnHandler != null)
            //            btnHandler(RichRichText);
            //        return;
            //    case EComponentType.Latex:
            //        var Latex = (Plugghest.Modules.UserControl.DisplayPlugg.Latex.Edit1)LoadControl(Plugghest.Base2.UserControlRoot.Latex.Edit1);
            //        if (btnHandler != null)
            //            btnHandler(Latex);
            //        return;
            //    case EComponentType.Label:
            //        var Label = (Plugghest.Modules.UserControl.DisplayPlugg.Label.Edit1)LoadControl(Plugghest.Base2.UserControlRoot.Label.Edit1);
            //        if (btnHandler != null)
            //            btnHandler(Label);
            //        return;
            //}

            //if (null != prop && prop.CanWrite)
            //{
            //    prop.SetValue(feedEditControl, this.Order, null);
            //}
            // Check if event is null
            #endregion
            // Write some text to output
        }
    }
}