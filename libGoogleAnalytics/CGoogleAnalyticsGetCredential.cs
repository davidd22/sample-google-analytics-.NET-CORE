using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace libGoogleAnalytics
{
    internal static class CGoogleAnalyticsGetCredential
    {
        static string file_name = "client_secret_google_analytic.json";
        static string loginEmailAddress = "dudu.munsa@gmail.com";
        internal static async Task<UserCredential> GetCredential()
        {
            using (var stream = new FileStream(file_name, FileMode.Open, FileAccess.Read))
            {

                return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { AnalyticsReportingService.Scope.Analytics },
                    loginEmailAddress, CancellationToken.None,
                    new FileDataStore("GoogleAnalyticsApiConsole"));
            }
        }
    }
}
