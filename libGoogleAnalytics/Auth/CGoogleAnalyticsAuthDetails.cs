using System;
using System.Collections.Generic;
using System.Text;

namespace libGoogleAnalytics
{
    public class CGoogleAnalyticsAuthDetails
    {
        public string UserName { get; private set; }
        public string ViewId { get; private set; }

        public CGoogleAnalyticsAuthDetails(string userName, string viewId)
        {
            this.UserName = userName;
            this.ViewId = viewId;
        }
    }
}
