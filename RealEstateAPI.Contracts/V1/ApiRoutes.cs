public class ApiRoutes
{
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = Root + "/" + Version;

    public static class VGData
    {
        public const string QueryProperty = Base + "/vg/history";
        public const string QueryLocality = Base + "/vg/locality";
        public const string QueryStrata = Base + "/vg/strata";
    }

    // GNAF Context
    public static class Query
    {
        public const string QueryLocality = Base + "/search/locality";
        public const string QueryStreet = Base + "/search/street";
        public const string QueryPostcode = Base + "/search/postcode";

    }

}