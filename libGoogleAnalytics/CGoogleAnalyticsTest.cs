using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.AnalyticsReporting.v4.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace libGoogleAnalytics
{
    public static class CGoogleAnalyticsTest
    {
        public static void RunTest()
        {
            try
            {
                var credential = GetCredential().Result;
                using (var svc = new AnalyticsReportingService(
                    new BaseClientService.Initializer
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Google Analytics API Console"
                    }))
                {
                    var dateRange = new DateRange
                    {
                        StartDate = "2019-07-19",
                        EndDate = "2019-07-19"
                    };
                    var goals = new Metric
                    {
                        Expression = "ga:goal3Starts",
                        Alias = "call now goal"
                    };
                    var date = new Dimension { Name = "ga:date" };
                    var adContent = new Dimension { Name = "ga:adContent" };
                    var os = new Dimension { Name = "ga:operatingSystem" };
                    var time = new Dimension { Name = "ga:dateHourMinute" };

                    var reportRequest = new ReportRequest
                    {
                        DateRanges = new List<DateRange> { dateRange },
                        Dimensions = new List<Dimension> { date, adContent, os, time },
                        Metrics = new List<Metric> { goals },
                        ViewId = "183057978"
                    };
                    var getReportsRequest = new GetReportsRequest
                    {
                        ReportRequests = new List<ReportRequest> { reportRequest }
                    };
                    var batchRequest = svc.Reports.BatchGet(getReportsRequest);
                    var response = batchRequest.Execute();
                    foreach (var x in response.Reports.First().Data.Rows)
                    {
                        Console.WriteLine(string.Join(", ", x.Dimensions) +
                        "   " + string.Join(", ", x.Metrics.First().Values));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static async Task<UserCredential> GetCredential()
        {
            using (var stream = new FileStream("client_secret_google_analytic.json",
                 FileMode.Open, FileAccess.Read))
            {
                const string loginEmailAddress = "dudu.munsa@gmail.com";
                return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { AnalyticsReportingService.Scope.Analytics },
                    loginEmailAddress, CancellationToken.None,
                    new FileDataStore("GoogleAnalyticsApiConsole"));
            }
        }
    }
}
