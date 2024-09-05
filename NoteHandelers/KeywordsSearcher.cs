using System.Collections;

namespace NoteHandlers
{
    public class KeywordsSearcher : IEnumerable<StandardNote>
    {
        private Keyword _keyword;
        public KeywordsSearcher(Keyword keyword)
        {
            _keyword = keyword;
        }

        public IEnumerator<StandardNote> GetEnumerator()
        {
            NoteStorage noteStorage = NoteStorage.Instance;
            noteStorage.NoteTypeHandled = NoteType.Standard;
            foreach(StandardNote note in noteStorage)
            {
                if(note.HasKeyword(_keyword))
                    yield return note;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
