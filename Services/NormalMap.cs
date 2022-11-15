using Services.Extensions;
using System.Drawing;
using System.Numerics;

namespace Services
{
    public class NormalMap
    {
        private readonly Bitmap _normalMap;

        public NormalMap(string path) => _normalMap = new Bitmap(path);

        public Vector3 GetPixelColorVector(int x, int y)
        {
            var colorVector = _normalMap.GetPixel(x, y).ToVector();
            return new(colorVector.X * 2 - 1, colorVector.Y * 2 - 1, colorVector.Z);
        }
    }
}
