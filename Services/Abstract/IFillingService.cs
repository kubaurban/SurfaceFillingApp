using Views.Abstract;

namespace Services.Abstract
{
    public interface IFillingService
    {
        float Kd { get; set; }
        float Ks { get; set; }
        int M { get; set; }
        int Z { get; set; }

        void FillSurface();
    }
}
