namespace Artisanal.Web
{
    public static class SD
    {
        public static string ProductAPIBase { get; set; } = "https://localhost:7101";
        public static string AuthAPIBase { get; set; } = "http://localhost:5126";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
