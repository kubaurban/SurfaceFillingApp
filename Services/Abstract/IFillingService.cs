using System.Numerics;
using Views.Enums;

namespace Services.Abstract
{
    public interface IFillingService
    {
        float Kd { get; set; }
        float Ks { get; set; }
        int M { get; set; }
        Vector3 LightSource { get; set; }
        Vector3 Il { get; set; }
        IFiller Filler { get; set; }
        FillingMethod Filling { get; set; }
        InterpolationMethod Interpolation { get; set; }

        void ComputeInterpolationCoeffitients();
        void SetParameters(float kd, float ks, int m, Vector3 lightSource, Vector3 il, FillingMethod filling, IFiller filler, InterpolationMethod interpolation);
        void FillSurface();
        void ApplyNormalMap(NormalMap map);
        void DisableNormalMap();
    }
}
