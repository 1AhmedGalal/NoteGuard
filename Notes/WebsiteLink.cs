using System.Text.Json.Serialization;

namespace Notes
{
    public sealed record WebsiteLink : Note
    {
        private string _websiteName;
        private string _websiteUrl;

        public string WebsiteName { get { return _websiteName; } }

        public string WebsiteUrl { get { return _websiteUrl; } }

        public WebsiteLink(string? websiteName, string? websiteUrl) : base()
        {
            this._websiteName = websiteName ?? "";
            this._websiteUrl = websiteUrl ?? "";
        }

        [JsonConstructor]
        public WebsiteLink(string? websiteName, string? websiteUrl, int id) : base(id)
        {
            this._websiteName = websiteName ?? "";
            this._websiteUrl = websiteUrl ?? "";
        }
    }
}
