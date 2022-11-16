namespace Services.Abstract
{
    public interface IFillingService
    {
        IFiller Filler { get; set; }

        void EagerLoadFillingAlgorithm();
        void FreeEagerlyLoadedData();
        void FillSurface();
        void ApplyNormalMap(NormalMap map);
        void DisableNormalMap();
    }
}
