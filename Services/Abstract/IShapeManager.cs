using Models;

namespace Services.Abstract
{
    public interface IShapeManager
    {
        IEnumerable<Face> GetAllFaces();

        void AddFace(Face face);
    }
}