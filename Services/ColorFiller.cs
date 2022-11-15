using Services.Abstract;
using Services.Extensions;
using System.Drawing;
using System.Numerics;

namespace Services
{
    public class ColorFiller : IFiller
    {
        private readonly Color _color;

        public ColorFiller(Color color) => _color = color;

        public Vector3 GetPixelColorVector(int x, int y) => _color.ToVector();
    }
}
