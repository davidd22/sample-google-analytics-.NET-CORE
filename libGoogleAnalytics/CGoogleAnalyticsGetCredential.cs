﻿using Google.Apis.AnalyticsReporting.v4;
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
    public static class CGoogleAnalyticsGetCredential
    {
        static string CredentialsFileName = null;
        static string loginEmailAddress = null;
        internal static async Task<UserCredential> GetCredential()
        {
            using (var stream = new FileStream(CredentialsFileName, FileMode.Open, FileAccess.Read))
            {

                return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { AnalyticsReportingService.Scope.Analytics },
                    loginEmailAddress, CancellationToken.None,
                    new FileDataStore("GoogleAnalyticsApiConsole"));
            }
        }

        public static void SetCredentialsFileName(string name)
        {
            if (CredentialsFileName == null)
                CredentialsFileName = name;
        }
        public static void SetLoginEmailAddress(string address)
        {
            if (loginEmailAddress == null)
                loginEmailAddress = address;
        }
    }
}
