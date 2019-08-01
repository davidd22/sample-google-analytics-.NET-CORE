using System;
using System.Collections.Generic;
using System.Text;

namespace libGoogleAnalytics
{
    public static class CDefinitionDimension
    {
        /// <summary>
        /// For manual campaign tracking, it is the value of the utm_content campaign tracking parameter. For AdWords autotagging, it is the first line of the text for the online Ad campaign. If you use mad libs for the AdWords content, it contains the keywords you provided for the mad libs keyword match. If you use none of the above, its value is (not set).
        /// </summary>
        public const string AD_CONTENT = "ga:adContent";

        /// <summary>
        /// The search query that triggered impressions.
        /// </summary>
        public const string GOOGLE_ADS_MATCHED_QUERY = "ga:adMatchedQuery";

        /// <summary>
        /// the user operating system.
        /// </summary>
        public const string OPERATING_SYSTEM = "ga:operatingSystem";

        /// <summary>
        /// date
        /// </summary>
        public const string DATE = "ga:date";

        /// <summary>
        /// time
        /// </summary>
        public const string TIME = "ga:dateHourMinute";

        /// <summary>
        /// The path of the referring URL (e.g., document.referrer). If someone places on their webpage a link to the property, this is the path of the page containing the referring link.
        /// </summary>
        public const string REFERRAL_PATH = "ga:referralPath";

        /// <summary>
        /// The full referring URL including the hostname and path.
        /// </summary>
        public const string FULL_REFERRAL = "ga:fullReferrer";

        /// <summary>
        /// For manual campaign tracking, it is the value of the utm_campaign campaign tracking parameter. For AdWords autotagging, it is the name(s) of the online ad campaign(s) you use for the property. If you use neither, its value is (not set).
        /// </summary>
        public const string CAMPAIGN = "ga:campaign";

        /// <summary>
        /// For manual campaign tracking, it is the value of the utm_id campaign tracking parameter.
        /// </summary>
        public const string CAMPAIGN_CODE = "ga:campaignCode";

        /// <summary>
        /// The source of referrals. For manual campaign tracking, it is the value of the utm_source campaign tracking parameter. For AdWords autotagging, it is google. If you use neither, it is the domain of the source (e.g., document.referrer) referring the users. It may also contain a port address. If users arrived without a referrer, its value is (direct).
        /// </summary>
        public const string SOURCE = "ga:source";

        /// <summary>
        /// The type of referrals. For manual campaign tracking, it is the value of the utm_medium campaign tracking parameter. For AdWords autotagging, it is cpc. If users came from a search engine detected by Google Analytics, it is organic. If the referrer is not a search engine, it is referral. If users came directly to the property and document.referrer is empty, its value is (none).
        /// </summary>
        public const string MEDIUM = "ga:medium";

        /// <summary>
        /// Combined values of ga:source and ga:medium.
        /// </summary>
        public const string SOURCE_MEDIUM = "ga:sourceMedium";

        /// <summary>
        /// For manual campaign tracking, it is the value of the utm_term campaign tracking parameter. For AdWords traffic, it contains the best matching targeting criteria. For the display network, where multiple targeting criteria could have caused the ad to show up, it returns the best matching targeting criteria as selected by Ads. This could be display_keyword, site placement, boomuserlist, user_interest, age, or gender. Otherwise its value is (not set).
        /// </summary>
        public const string KEYWORD = "ga:keyword";

        /// <summary>
        /// The social network name. This is related to the referring social network for traffic sources; e.g., Google+, Blogger.
        /// </summary>
        public const string SOCIAL_NETWORK = "ga:socialNetwork";

        /// <summary>
        /// A boolean, either Yes or No, indicates whether sessions to the property are from a social source.
        /// </summary>
        public const string HAS_SOCIAL_SOURCE_REFERRAL = "ga:hasSocialSourceReferral";
    }
}
