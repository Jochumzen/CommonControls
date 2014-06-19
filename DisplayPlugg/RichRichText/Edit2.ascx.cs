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
    public partial class Edit2 : UserControlModuleBase
    {
        #region Properties
        private ECultureCodeStatus _CultureCodeStatus;

        public ECultureCodeStatus CultureCodeStatus
        {
            get { return _CultureCodeStatus; }
            set
            {
                _CultureCodeStatus = value;
                var flag = _CultureCodeStatus == ECultureCodeStatus.GoogleTranslated ? AddGooleTranslateButton() : CreateBtnImproveHumGoogleTrans();
            }
        }
        private int _Order;
        public int Order
        {
            get { return _Order; }
            set
            {
                _Order = value;
                pnlRichRichTextEdit2.Controls.Add(new LiteralControl(string.Format("<div><div id=RichRichText" + this.Order + " class='Main'>" + this.ComponentText + " " + this.Order + " : " + this.RichRichText + " " + value + "</div></div> ")));
            }
        }

        private string RichRichText
        {
            get
            {
                var lanText = Localization.GetString("RichRichText", this.LocalResourceFile);
                return !string.IsNullOrEmpty(lanText) ? lanText : "RichRichText";
            }
        }
        private string ComponentText
        {
            get
            {
                var lanText = Localization.GetString("ComponentText", this.LocalResourceFile);
                return !string.IsNullOrEmpty(lanText) ? lanText : "Component";
            }
        }
        private string ImpGooleTranslate
        {
            get
            {
                var lanText = Localization.GetString("ImpGooleTranslate", this.LocalResourceFile);
                return !string.IsNullOrEmpty(lanText) ? lanText : "Improve google Translation";
            }
        }
        private string GoogleTransOk
        {
            get
            {
                var lanText = Localization.GetString("GoogleTransOk", this.LocalResourceFile);
                return !string.IsNullOrEmpty(lanText) ? lanText : "Google translation is OK";
            }
        }
        private string ImpHumanTxt
        {
            get
            {
                var lanText = Localization.GetString("ImpHumanTxt", this.LocalResourceFile);
                return !string.IsNullOrEmpty(lanText) ? lanText : "Improve Human Translation Text";
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
        public Plugghest.Base2.PluggContainer PluggContainer
        {
            get { return new Plugghest.Base2.PluggContainer(this.CurrentLanguage, this.PluggID); }
        }
        public int ComponentID { get; set; }

        private PHText PHText
        {
            get
            {
                var _PHText = new BaseHandler().GetCurrentVersionText(this.CurrentLanguage, this.ComponentID, ETextItemType.PluggComponentRichRichText);
                _PHText.Text = _PHText.Text == "(No text)" ? "(currently no text)" : _PHText.Text;
                this.CultureCodeStatus = _PHText.CultureCodeStatus;
                return _PHText;
            }
        }

        public Page Parent_Page { get; set; }

        #endregion

        private bool AddGooleTranslateButton()
        {
            try
            {
                Button btnImpHumTras = new Button();
                btnImpHumTras.CssClass = "googletrans";
                btnImpHumTras.ID = "btnrtIGT" + this.Order;
                btnImpHumTras.Text = this.ImpGooleTranslate;
                btnImpHumTras.Click += (s, e) => { ImpGoogleTrans(); };
                pnlRichRichTextEdit2.Controls.Add(btnImpHumTras);
                CreateBtnGoogleT();

            }
            catch
            {
                return false;
            }
            return true;
        }

        private void CreateBtnGoogleT()
        {
            Button btnGT = new Button();
            btnGT.CssClass = "googleTrasok";
            btnGT.ID = "btnGTText" + this.Order;
            btnGT.Text = this.GoogleTransOk;
            btnGT.Click += (s, e) => { GoogleTranText(this.PHText); };
            pnlRichRichTextEdit2.Controls.Add(btnGT);
        }

        private void GoogleTranText(PHText txt)
        {
            BaseHandler bh = new BaseHandler();
            txt.CultureCodeStatus = ECultureCodeStatus.HumanTranslated;
            bh.SavePhText(txt);
        }

        private bool CreateBtnImproveHumGoogleTrans()
        {
            try
            {
                Button btnImpHumTras = new Button();
                btnImpHumTras.CssClass = "btnhumantrans";
                btnImpHumTras.ID = "btnlbl" + this.Order;
                btnImpHumTras.Text = this.ImpHumanTxt;
                btnImpHumTras.Click += (s, e) => { ImpGoogleTrans(); };
                pnlRichRichTextEdit2.Controls.Add(btnImpHumTras);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void ImpGoogleTrans()
        {
            string text = this.PHText.Text;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}