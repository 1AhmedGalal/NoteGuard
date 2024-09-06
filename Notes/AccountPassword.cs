using System.Text.Json.Serialization;

namespace Notes
{
    public sealed record AccountPassword : Note
    {
        private string _websiteName;
        private string _emailOrUsername;
        private string _password;
        public string WebsiteName { get { return _websiteName; } }
        public string EmailOrUserName { get { return _emailOrUsername; } }
        public string Password { get { return _password; } }

        [JsonConstructor]
        public AccountPassword(string? websiteName, string? emailOrUsername, string? password) : base()
        {
            _websiteName = websiteName ?? "";
            _emailOrUsername = emailOrUsername ?? "";
            _password = password ?? "";
        }

        public AccountPassword(string? websiteName, string? emailOrUsername, string? password, int id) : base(id)
        {
            _websiteName = websiteName ?? "";
            _emailOrUsername = emailOrUsername ?? "";
            _password = password ?? "";
        }
    }
}
