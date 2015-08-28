using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Decorator
{

    public abstract class TuningElements<TITuning> : ITuning where TITuning : ITuning 
    {
        protected TITuning Input;

        protected TuningElements(TITuning i)
        {
           Input = i;
        }

        public abstract void AddTuning();
    }

    public class AirConditioner : TuningElements<Car>
    {
        public AirConditioner(Car i) : base(i)
        {
        }

        public override void AddTuning()
        {
            
            Input.AddTuning();
            Console.WriteLine("AirConditioner installed in "+ Input.Name);
        }
    }

    public class Parctronic : TuningElements<Car>
    {
        public Parctronic(Car i)
            : base(i)
        {
        }

        public override void AddTuning()
        {
            Input.AddTuning();
            Console.WriteLine("Parktronic installed in " + Input.Name);
        }
    }

    public class AlarmSystem : TuningElements<Car>
    {
        public AlarmSystem(Car i)
            : base(i)
        {
        }

        public override void AddTuning()
        {
            Input.AddTuning();
            Console.WriteLine("AlarmSystem installed in "+ Input.Name);
        }
    }

    
}
