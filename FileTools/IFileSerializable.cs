namespace FileTools
{
    public interface IFileSerializable<T>
    {
        void SaveToFile(string filePath, ICollection<T>? collection);
        ICollection<T>? LoadFromFile(string filePath);
    }
}
