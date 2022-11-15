using Services.Abstract;
using Services.Extensions;
using System.Drawing;
using System.Numerics;

namespace Services
{
    public class TextureFiller : IFiller
    {
        private readonly Bitmap _texture;

        public TextureFiller(string path) => _texture = new Bitmap(path);

        public Vector3 GetPixelColorVector(int x, int y) => _texture.GetPixel(x, y).ToVector();
    }
}
