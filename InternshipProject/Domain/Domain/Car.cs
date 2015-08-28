using System;
using System.Linq;
using Domain.Domain.Decorator;
using Domain.Domain.Observer;
using Domain.Domain.Proxy;
using Domain.Domain.TemplateMethod;

namespace Domain.Domain
{
    public class Car : ITuning, IStartAirConditioner
    {
        protected bool Lights;
        private bool _engineIsStarted;
        //string _make;
        //int vol = 0;
        public bool SystemOk;
        public bool BattOk = true;
        public IRdsSubscriber Receiver;

        //public Car(String make2)
        //{
        //    make = make2;
        //    // this make = make;
        //} 


        //public string make
        //{
        //    get { return _make; }
        //    set { _make = value; }
        //}

        public Car(string name, int engineVol, int tankVol, string bodyType)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name is required.");
            if (engineVol <= 0)
                throw new ArgumentException("engineVol must be > 0.");
            if (tankVol <= 0)
                throw new ArgumentException("TankVol must be > 0.");
            if (!bodyType.Any())
                throw new ArgumentException("Assign bodyType to a car.");

            Name = name;
            EngineVol = engineVol;
            TankVol = tankVol;
            BodyType = bodyType;
            Receiver = new RdsReceiver(name);
        }

        public string Name { get; private set; }
        public int EngineVol { get; private set; }
        public int TankVol { get; private set; }
        public string BodyType { get; private set; }


        public virtual void CheckAllSystem()
        {
            if (BattOk /* && tirePressure>2*/)
                SystemOk = true;
            else
                SystemOk = false;
        }

        public virtual bool CheckStstem
        {
            get { return SystemOk; }
            set { SystemOk = value; }
        }

        public virtual void StartEngine()
        {
           
            if (SystemOk)
            {
                _engineIsStarted = true;
            }
            else
            {
                _engineIsStarted = false;
                Console.WriteLine("You have problems. Need service");
            }
        }


        public virtual bool lights // property encapsulated
        {
            get { return Lights; } // _lights = field
            set { Lights = value; }
        }

        public bool EngineIsStarted // readonly
        {
            get { return _engineIsStarted; }
            //set { _make = value; }
        }

        public override string ToString()
        {
            return "Car:" + Name + " " + BodyType + " / engine: " + EngineIsStarted + " / lights:" + lights;
        }

        public void StartAirConditioner()
        {
            CheckAllSystem();
            StartEngine();
            CloseWindows();
            Console.WriteLine("AirConditioner is working. t=20°");
        }

        private void CloseWindows()
        {
            Console.WriteLine(Name + "  All Windows are closed");
        }

        public void AddTuning()
        {
            Console.WriteLine(new string('+', 10));
            Console.WriteLine("Car "+ Name + " ready for tune");
            
        }

        public void Drive()
        {
            Console.WriteLine("{0,-20} Let`s Go - o - o -o -o.",Driver.Name);
        }

        
    }
}