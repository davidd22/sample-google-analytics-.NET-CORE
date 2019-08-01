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
            CGoogleAnalyticsReportRead cGoogleAnalyticsReportRead = new CGoogleAnalyticsReportRead(new DateTime(2019, 07, 30)
                                                                                                    , new DateTime(2019, 07, 30, 23, 59, 59)
                                                                                                    , "183057978"
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
