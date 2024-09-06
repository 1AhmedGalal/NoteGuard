using System.Text;
using System.Text.Json.Serialization;

namespace Notes
{
    public sealed record StandardNote : Note
    {
        private List<Keyword> _keywords;
        private string _subject;
        private string _content;
        
        public string Subject { get { return _subject; } }
        public string Content { get { return _content; } }
        public List<Keyword> Keywords { get { return _keywords; } }

        public StandardNote(string? subject, string? content) : base()
        {
            _subject = subject ?? "";
            _content = content ?? "" ;
            _keywords = new List<Keyword>();
            _populateKeyWords();
        }

        [JsonConstructor]
        public StandardNote(string? subject, string? content, int id) : base(id)
        {
            _subject = subject ?? "";
            _content = content ?? "";
            _keywords = new List<Keyword>();
            _populateKeyWords();
        }

        public bool HasKeyword(Keyword keyword) => _keywords.Contains(keyword);
        private void _populateKeyWords()
        {
            bool isKeyword(char c) => c != ' ' && c != '\r' && c != '\n' && c != '\b' && c != '\t';
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _content.Length; i++)
            {
                if (_content[i] == '#')
                {
                    i++;

                    while(i < _content.Length && isKeyword(_content[i]))
                    {
                        sb.Append(_content[i]);
                        i++;
                    }

                    _keywords.Add(new Keyword(sb.ToString()));
                    sb.Clear();
                    i--;
                }
            }
        }

    }
}
