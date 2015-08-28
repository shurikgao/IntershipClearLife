namespace Domain.Domain
{
   public class JapanCar : Car 
    {
        //public JapanCar(string make) : base(make)
        //{
        //    //Add further instructions here.
        //}

       public JapanCar(string name, int engineVol, int tankVol, string bodyType)
           : base(name, engineVol, tankVol, bodyType)
       {

       }

       public override void StartEngine()          // override params from base calss Car
        {
            base.StartEngine();
            lights = true;
        }

        public override bool lights      // property encapsulated
        {
            // get { return _lights; }  
             set
            {
                //_lights = engineIsStarted ? true : value;
                if (EngineIsStarted)
                {
                    base.Lights = true;
                }
                else
                {
                    base.Lights = value;
                }
        
            }
      
        }
      

         
  


    }
}
