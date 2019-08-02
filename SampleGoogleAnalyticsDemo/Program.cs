using Google.Apis.AnalyticsReporting.v4.Data;
using libGoogleAnalytics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleGoogleAnalyticsDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            string viewId = "[VIEW_ID]";
            string GoogleLoginUserName = "[USER_NAME]";
            CGoogleAnalyticsGetCredential.SetCredentialsFileName("[Your_Credential_File_Name.json]");


            DateTime from = new DateTime(2019, 07, 30);
            DateTime to = new DateTime(2019, 07, 30, 23, 59, 59);

            CGoogleAnalyticsReportRead cGoogleAnalyticsReportRead = new CGoogleAnalyticsReportRead(from
                                                                                                    , to
                                                                                                    , new CGoogleAnalyticsAuthDetails(GoogleLoginUserName, viewId)
                                                                                                    , null

                                                                                                   , new List<Dimension>()
                                                                                                    {
                                                                                                        new Dimension { Name = CDefinitionDimension.DATE}
                                                                                                      , new Dimension { Name = CDefinitionDimension.AD_CONTENT}
                                                                                                      , new Dimension { Name = CDefinitionDimension.OPERATING_SYSTEM }
                                                                                                      , new Dimension { Name = CDefinitionDimension.TIME}
                                                                                                      , new Dimension { Name = CDefinitionDimension.SOURCE}
                                                                                                      , new Dimension { Name = CDefinitionDimension.MEDIUM}
                                                                                                      , new Dimension { Name = CDefinitionDimension.KEYWORD}
                                                                                                     }

                                                                                                    );

            Task.Run(async () =>
            {

                List<Dictionary<string, object>> report = await cGoogleAnalyticsReportRead.Read();

                for (int i = 0; i < report.Count; i++)
                {

                    Console.WriteLine("---------------------------");

                    Console.WriteLine("OPERATING_SYSTEM: " + report[i][CDefinitionDimension.OPERATING_SYSTEM].ToString());
                    Console.WriteLine("SOURCE: " + report[i][CDefinitionDimension.SOURCE].ToString());
                    Console.WriteLine("MEDIUM: " + report[i][CDefinitionDimension.MEDIUM].ToString());
                    Console.WriteLine("AD_CONTENT: " + report[i][CDefinitionDimension.AD_CONTENT].ToString());
                    Console.WriteLine("KEYWORD: " + report[i][CDefinitionDimension.KEYWORD].ToString());
                    Console.WriteLine("---------------------------");

                }

            }).Wait();
        }
    }
}
