using System;

namespace Domain.Domain
{
    public class JapanCar : Car
    {
        public virtual int Safety { get; protected set; }

        public JapanCar(string name, int engineVol, int tankVol, string bodyType, string countryOfOrigin,
            int percentOfSafety)
            : base(name, engineVol, tankVol, bodyType, countryOfOrigin)
        {
            Safety = percentOfSafety;
        }

        public override void StartEngine() // override params from base calss Car
        {
            base.StartEngine();
            lights = true;
        }

        public override bool lights // property encapsulated
        {
            
            set
            {
                //_lights = engineIsStarted ? true : value;
                if (EngineIsStarted)
                {
                    Lights = true;
                }
                else
                {
                    Lights = value;
                }
            }
        }


        [Obsolete]
        protected JapanCar()
        {
        }
    }
}