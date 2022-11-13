using System.Drawing;
using System.Numerics;

namespace Services.Extensions
{
    public static class VectorExtension
    {
        public static Color ToColor(this Vector3 rgb)
        {
            var R = rgb.X > 1 ? 1 : rgb.X;
            var G = rgb.Y > 1 ? 1 : rgb.Y;
            var B = rgb.Z > 1 ? 1 : rgb.Z;

            return Color.FromArgb((int)(R * 255), (int)(G * 255), (int)(B * 255));
        }
    }
}
