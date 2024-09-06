using System.Collections;

namespace NoteHandlers
{
    public class NoteStorage : IEnumerable<Note>
    {
        private static readonly NoteStorage _instance = new NoteStorage();
        private List<WebsiteLink> _websiteLinks;
        private List<AccountPassword> _accountPasswords;
        private List<StandardNote>? _standardNotes;
       
        private NoteStorage()
        {
            _websiteLinks = new List<WebsiteLink>();
            _accountPasswords = new List<AccountPassword>();
            _standardNotes = new List<StandardNote>();
            NoteTypeHandled = null;
        }

        public static NoteStorage Instance { get { return _instance; } }

        public NoteType? NoteTypeHandled { get; set; }

        public IEnumerator<Note> GetEnumerator()
        {
            if(NoteTypeHandled is null)
            {
                throw new Exception("Please Choose The Type Of Notes!");
            }
            else if(NoteTypeHandled == NoteType.Standard)
            {
                foreach(StandardNote note in _standardNotes)
                    yield return note;
            }
            else if(NoteTypeHandled == NoteType.AccountPassword)
            {
                foreach (AccountPassword note in _accountPasswords)
                    yield return note;
            }
            else
            {
                foreach (WebsiteLink note in _websiteLinks)
                    yield return note;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void SaveAllNotes(string folderPath)
        {
            if (NoteTypeHandled is null)
            {
                throw new Exception("Please Choose A Type");
            }
            else if (NoteTypeHandled == NoteType.Standard)
            {
                IFileSerializable<StandardNote> fileSerializable = new JsonFileSerializer<StandardNote>();
                string filePath = folderPath + @"\standard.json";
                fileSerializable.SaveToFile(filePath, _standardNotes);
            }
            else if (NoteTypeHandled == NoteType.AccountPassword)
            {
                IFileSerializable<AccountPassword> fileSerializable = new JsonFileSerializer<AccountPassword>();
                string filePath = folderPath + @"\accountPasswords.json";
                fileSerializable.SaveToFile(filePath, _accountPasswords);
            }
            else if (NoteTypeHandled == NoteType.WebsiteLink)
            {
                IFileSerializable<WebsiteLink> fileSerializable = new JsonFileSerializer<WebsiteLink>();
                string filePath = folderPath + @"\websiteLinks.json";
                fileSerializable.SaveToFile(filePath, _websiteLinks);
            }
            
        }

        public void LoadAllNotes(string folderPath)
        {
            IFileSerializable<StandardNote> fileSerializable1 = new JsonFileSerializer<StandardNote>();
            string filePath = folderPath + @"\standard.json";
            _standardNotes = (List<StandardNote>?)fileSerializable1.LoadFromFile(filePath) ?? new List<StandardNote>();

            IFileSerializable<AccountPassword> fileSerializable2 = new JsonFileSerializer<AccountPassword>();
            filePath = folderPath + @"\accountPasswords.json";
            _accountPasswords = (List<AccountPassword>?)fileSerializable2.LoadFromFile(filePath) ?? new List<AccountPassword>();

            IFileSerializable<WebsiteLink> fileSerializable3 = new JsonFileSerializer<WebsiteLink>();
            filePath = folderPath + @"\websiteLinks.json";
            _websiteLinks = (List<WebsiteLink>?)fileSerializable3.LoadFromFile(filePath) ?? new List<WebsiteLink>();

        }

        public void AddNote(Note note)
        {
            if(note is StandardNote standardNote)
            {
                _standardNotes!.Add(standardNote);
            }
            else if(note is WebsiteLink link)
            {
                _websiteLinks.Add(link);
            }
            else if(note is AccountPassword accountPassword)
            {
                _accountPasswords.Add(accountPassword);
            }
            else
            { 
                throw new NotImplementedException("Invalid Type!"); 
            }
        }

        public void RemoveNote(int idx)
        {
            if (NoteTypeHandled is null)
            {
                throw new NotImplementedException("Invalid Type!");
            }
            else if (NoteTypeHandled == NoteType.Standard)
            {
                _standardNotes!.RemoveAt(idx);
            }
            else if (NoteTypeHandled == NoteType.WebsiteLink)
            {
                _websiteLinks!.RemoveAt(idx);
            }
            else if (NoteTypeHandled == NoteType.AccountPassword)
            {
                _accountPasswords!.RemoveAt(idx);
            }
            
        }

        public Note GetNote(int idx)
        {
            if (NoteTypeHandled is null)
            {
                throw new NotImplementedException("Invalid Type!");
            }
            else if (NoteTypeHandled == NoteType.Standard)
            {
                return _standardNotes![idx];
            }
            else if (NoteTypeHandled == NoteType.WebsiteLink)
            {
                return _websiteLinks![idx];
            }
            else 
            {
                return _accountPasswords![idx];
            }
        }
    }
}
