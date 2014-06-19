using Plugghest.Base2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Plugghest.Modules.UserControl.DisplayPlugg
{
    public class ControlRepository : System.Web.UI.UserControl
    {
        private static ControlRepository _Instance;
        public static Dictionary<EComponentType, System.Web.UI.UserControl> SingleInstance_AllEdit1
        {
            get
            {
                //if (_Instance == null)
                _Instance = new ControlRepository();
                return _Instance.ALLControls;
            }
        }

        private Dictionary<EComponentType, System.Web.UI.UserControl> ALLControls;

        private ControlRepository()
        {
            Initialize_Control();
        }

        void Initialize_Control()
        {
            Dictionary<EComponentType, System.Web.UI.UserControl> ALLEdits = new Dictionary<EComponentType, System.Web.UI.UserControl>();
            ALLEdits.Add(EComponentType.Latex, (Plugghest.Modules.UserControl.DisplayPlugg.Latex.Edit1)LoadControl(Plugghest.Base2.UserControlRoot.Latex.Edit1));
            ALLEdits.Add(EComponentType.Label, (Plugghest.Modules.UserControl.DisplayPlugg.Label.Edit1)LoadControl(Plugghest.Base2.UserControlRoot.Label.Edit1));
            ALLEdits.Add(EComponentType.RichRichText, (Plugghest.Modules.UserControl.DisplayPlugg.RichRichText.Edit1)LoadControl(Plugghest.Base2.UserControlRoot.RichRichText.Edit1));
            ALLEdits.Add(EComponentType.RichText, (Plugghest.Modules.UserControl.DisplayPlugg.RichText.Edit)LoadControl(Plugghest.Base2.UserControlRoot.RichText.Edit1));
            ALLEdits.Add(EComponentType.YouTube, (Plugghest.Modules.UserControl.DisplayPlugg.YouTube.Edit1)LoadControl(Plugghest.Base2.UserControlRoot.YouTube.Edit));

            this.ALLControls = ALLEdits;
        }



    }
}