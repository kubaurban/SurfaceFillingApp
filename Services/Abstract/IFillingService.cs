using System.Numerics;
using Views.Abstract;

namespace Services.Abstract
{
    public interface IFillingService
    {
        float Kd { get; set; }
        float Ks { get; set; }
        int M { get; set; }
        Vector3 LightSource { get; set; }
        Vector3 Io { get; set; }
        Vector3 Il { get; set; }

        void SetParameters(float kd, float ks, int m, Vector3 lightSource, Vector3 io, Vector3 il);
        void FillSurface();
    }
}
