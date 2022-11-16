namespace Services.Abstract
{
    public interface IShapeParser
    {
        string LoadedFilename { get; }

        void LoadObj(string path);
    }
}