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

    public class CGoogleAnalyticsReportRead
    {
        DateTime from;
        DateTime to;

        string viewId;
        List<Metric> metrics;
        List<Dimension> dimensions;
        public CGoogleAnalyticsReportRead(DateTime from
                                        , DateTime to
                                        , string viewId
                                        , List<Metric> metrics
                                        , List<Dimension> dimensions
            )
        {
            this.from = from;
            this.to = to;
            this.viewId = viewId;
            this.metrics = metrics;
            this.dimensions = dimensions;
        }

        public async Task<List<Dictionary<string, object>>> Read()
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();

            try
            {
                var credential = await CGoogleAnalyticsGetCredential.GetCredential();

                using (var svc = new AnalyticsReportingService(
                    new BaseClientService.Initializer
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Google Analytics API Console"
                    }))
                {
                    var dateRange = new DateRange
                    {
                        StartDate = from.ToString("yyyy-MM-dd"),
                        EndDate = to.ToString("yyyy-MM-dd")
                    };


                    var reportRequest = new ReportRequest
                    {
                        DateRanges = new List<DateRange> { dateRange },
                        Dimensions = dimensions,
                        Metrics = metrics,
                        ViewId = viewId
                    };
                    var getReportsRequest = new GetReportsRequest
                    {
                        ReportRequests = new List<ReportRequest> { reportRequest }
                    };
                    var batchRequest = svc.Reports.BatchGet(getReportsRequest);
                    var response = batchRequest.Execute();

                    if (response.Reports.First().Data.Rows == null)
                        return null;

                    foreach (var x in response.Reports.First().Data.Rows)
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();

                        for (int i = 0; i < dimensions.Count; i++)
                            row.Add(dimensions[i].Name, x.Dimensions[i]);

                        result.Add(row);
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
