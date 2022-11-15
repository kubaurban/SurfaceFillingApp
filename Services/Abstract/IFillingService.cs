namespace Services.Abstract
{
    public interface IFillingService
    {
        IFiller Filler { get; set; }

        void EagerLoadFillingAlgorithm();
        void FillSurface();
        void ApplyNormalMap(NormalMap map);
        void DisableNormalMap();
    }
}
