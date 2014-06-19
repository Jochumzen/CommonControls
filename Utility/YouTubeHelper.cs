using Plugghest.Base2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plugghest.Modules.UserControl.Utility
{
    /// <summary>
    /// Common Utility Class for all YouTube Case
    /// </summary>
    public class YouTubeHelper
    {
        public static string GetIframeString(int YouTubeId, string _PageCultureCode)
        {
            BaseHandler bh = new BaseHandler();
            Plugghest.Base2.YouTube yt = bh.GetYouTubeByComponentId(YouTubeId);
            return yt != null ? yt.GetIframeString(_PageCultureCode) : "(currently no video)";
        }
    }
}