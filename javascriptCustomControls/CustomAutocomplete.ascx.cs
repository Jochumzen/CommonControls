using Plugghest.Base2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plugghest.Modules.UserControl.javascriptCustomControls
{
    public partial class CustomAutocomplete : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public static IEnumerable<PHText> GetPlugg_Author()
        //{
        //    var dbo = new BaseHandler().
        //    return dbo.;
        //}

        [WebMethod]
        public static IEnumerable<cAuto> AllName(string startsWith, string maxRows)
        {
            List<cAuto> a = new List<cAuto>();
            a.Add(new cAuto { Name = "aaa", category = "TiTle" });
            a.Add(new cAuto { Name = "bbb", category = "TiTle" });
            a.Add(new cAuto { Name = "ccc", category = "TiTle" });
            a.Add(new cAuto { Name = "ddd", category = "TiTle" });
            a.Add(new cAuto { Name = "eee", category = "TiTle" });
            a.Add(new cAuto { Name = "fff", category = "TiTle" });
            a.Add(new cAuto { Name = "ggg", category = "TiTle" });
            a.Add(new cAuto { Name = "aaa", category = "Author" });
            a.Add(new cAuto { Name = "bbb", category = "Author" });
            a.Add(new cAuto { Name = "ccc", category = "Author" });
            a.Add(new cAuto { Name = "ddd", category = "Author" });
            a.Add(new cAuto { Name = "eee", category = "Author" });
            a.Add(new cAuto { Name = "fff", category = "Author" });
            a.Add(new cAuto { Name = "ggg", category = "Author" });
            a.Add(new cAuto { Name = "hhh", category = "Author" });
            return a.Where(x => x.Name.StartsWith(startsWith));
        }
    }
    public class cAuto
    {
        public string Name;
        public string category;
    }
}