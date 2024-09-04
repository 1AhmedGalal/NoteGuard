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
        public ICollection<T>? LoadFromFile(string filePath)
        {
            ICollection<T>? collection = null;
            string json = File.ReadAllText(filePath);

            if (json is not null)
                collection = JsonSerializer.Deserialize<ICollection<T>>(json);
            
            return collection;
        }

        public void SaveToFile(string filePath, ICollection<T>? collection)
        {
            if (collection is null)
                throw new Exception("No Collection Was Found");

            string json = JsonSerializer.Serialize(collection, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(filePath, json);

        }
    }
}
