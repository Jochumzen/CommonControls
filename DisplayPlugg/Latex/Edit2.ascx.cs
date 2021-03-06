﻿using DotNetNuke.Entities.Modules;
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

        private PHLatex PHText
        {
            get
            {
                var _PHText = new BaseHandler().GetCurrentVersionLatexText(this.CurrentLanguage, this.ComponentID, ELatexItemType.PluggComponentLatex);
                _PHText.Text = _PHText.Text == "(No text)" ? "(currently no text)" : _PHText.Text;
                return _PHText;
            }
        }
        public Page Parent_Page { get; set; }
     
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            txtRRtext.Text = this.PHText.Text;
        }

        protected void btnSaveRRt_Click(object sender, EventArgs e)
        {
            BaseHandler bh = new BaseHandler();
            PHLatex latex = bh.GetCurrentVersionLatexText(this.CurrentLanguage, this.ComponentID, ELatexItemType.PluggComponentLatex);
            latex.CultureCodeStatus = ECultureCodeStatus.HumanTranslated;
            latex.ModifiedByUserId = this.UserID;
            latex.Text = System.Net.WebUtility.HtmlDecode(txtRRtext.Text);
            bh.SaveLatexText(latex);
            
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(this.TabID, "", new string[] { "edit=1", "language=" + this.CurrentLanguage }));

        }

        protected void btnCanRRt_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(this.TabID, "", new string[] { "edit=1", "language=" + this.CurrentLanguage }));
        }
    }
}