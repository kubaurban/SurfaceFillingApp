using System.Numerics;

namespace Services.Abstract
{
    public interface IFiller
    {
        Vector3 GetPixelColorVector(int x, int y);
    }
}