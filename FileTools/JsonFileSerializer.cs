using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileTools
{
    public class JsonFileSerializer<T> : IFileSerializable<T>
    {
        public void LoadFromFile(string filePath, ref ICollection<T>? collection)
        {
            string json = File.ReadAllText(filePath);

            if (json is not null)
            {
                collection = JsonSerializer.Deserialize<ICollection<T>>(json);
            }
        }

        public void SaveToFile(string filePath, ref ICollection<T>? collection)
        {
            throw new NotImplementedException();
        }
    }
}
