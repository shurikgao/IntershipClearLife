using Domain.Domain.Decorator;

namespace Domain.Domain
{
    public class ChinaCar : Car
    {
        //public ChinaCar(string make) : base(make)
        //{

        //}

        public ChinaCar(string name, int engineVol, int tankVol, string bodyType)
            : base(name, engineVol, tankVol, bodyType)
        {
        }

        public override void CheckAllSystem()
        {
            //base.checkAllSystem();
            SystemOk = true;
        }

        /*public override bool checkAllSystem
        {
           set
            {
                base.checkStstem = false;
            }
        }*/

        
    }
}