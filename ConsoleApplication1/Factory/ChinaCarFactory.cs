using Domain.Domain;

namespace Factories.Factory 
{
    public class ChinaCarFactory
    {
        public static ChinaCar CreateNewChinaCar(string name, int engineVol, int tankVol, string bodyType, string countryOfOrigin, int percentOfOriginalPieces)
            //Action<IProductOptions> optionalParams)
        {
            var chinaCar = new ChinaCar(name, engineVol, tankVol, bodyType, countryOfOrigin, percentOfOriginalPieces);
            return chinaCar;
        }

        public static int percentOfOriginalPieces { get; set; }
    }
}