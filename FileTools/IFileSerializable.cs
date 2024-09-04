namespace FileTools
{
    public interface IFileSerializable<T>
    {
        void SaveToFile(string filePath, ref ICollection<T> collection);
        void LoadFromFile(string filePath, ref ICollection<T> collection);
    }
}
