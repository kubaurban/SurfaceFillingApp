using System.Drawing;
using System.Numerics;

namespace Services.Extensions
{
    public static class ColorExtension
    {
        public static Vector3 ToVector(this Color color)
        {
            var R = (float)color.R / 255;
            var G = (float)color.G / 255;
            var B = (float)color.B / 255;

            return new(R, G, B);
        }
    }
}
