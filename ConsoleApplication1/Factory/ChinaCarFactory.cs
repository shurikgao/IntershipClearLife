using Domain.Domain;

namespace Factories.Factory 
{
    public class ChinaCarFactory
    {
        public static ChinaCar CreateNewChinaCar(string name, int engineVol, int tankVol, string bodyType)
            //Action<IProductOptions> optionalParams)
        {
            var chinaCar = new ChinaCar(name, engineVol, tankVol, bodyType);
            return chinaCar;
        }
    }
}