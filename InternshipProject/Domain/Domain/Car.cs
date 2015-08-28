using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Domain.Decorator;

namespace Domain.Domain
{
    public class Car : Entity, ITuning
    {
        protected bool Lights;
        private bool _engineIsStarted;

        protected virtual bool SystemOk { get; set; }

        public virtual bool GetSystemStatus()
        {
            return SystemOk;
        }

        protected virtual bool BattOk { get; set; }

        public virtual bool GetBattStatus()
        {
            return true;
        }

        public virtual void SetBattStatus(bool value)
        {
            BattOk = value;
        }

        private IList<Driver> _drivers = new List<Driver>();

        public Car(string name, int engineVol, int tankVol, string bodyType, string countryOfOrigin)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name is required.");
            if (engineVol <= 0)
                throw new ArgumentException("engineVol must be > 0.");
            if (tankVol <= 0)
                throw new ArgumentException("TankVol must be > 0.");
            if (!bodyType.Any())
                throw new ArgumentException("Assign bodyType to a car.");
            if (!countryOfOrigin.Any())
                throw new ArgumentException("Assign countryOfOrigin to a car.");

            Name = name;
            EngineVol = engineVol;
            TankVol = tankVol;
            BodyType = bodyType;
            CountryOfOrigin = countryOfOrigin;
        }

        [Obsolete]
        protected Car()
        {
        }

        public virtual string Name { get; protected set; }
        public virtual int EngineVol { get; protected set; }
        public virtual int TankVol { get; protected set; }
        public virtual string BodyType { get; protected set; }
        public virtual string CountryOfOrigin { get; protected set; }

        public virtual IList<Driver> Drivers
        {
            get { return _drivers; }
        }

        //public virtual void AddDriver(Driver driver)
        //{
        //    _drivers.Add(driver);
        //}

        public virtual void CheckAllSystem()
        {
            if (GetBattStatus() /* && tirePressure>2*/)
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
            /*try
            {
            Console.WriteLine("Please add fuel:");
            int vol = Convert.ToInt32(Console.ReadLine());
           
                if (vol == 0)
                {
                    throw new Exception("Attempted to start engin with no fuel.");
                    //_engineIsStarted = false;
                }
                
                else
                { 
                    if (vol > 60)
                    {
                    throw new Exception ("Too much fuel.");
                    } 

                    else
                    {
                    _engineIsStarted = true;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
             */

            if (SystemOk)
            {
                _engineIsStarted = true;
            }
            else
            {
                _engineIsStarted = false;
                Console.WriteLine("You have problems. need service");
            }
        }


        public virtual bool lights // property encapsulated
        {
            get { return Lights; } // _lights = field
            set { Lights = value; }
        }

        public virtual bool EngineIsStarted // readonly
        {
            get { return _engineIsStarted; }
        }


        public override string ToString()
        {
            return "Car:" + Name + " " + BodyType + " / engine: " + EngineIsStarted + " / lights:" + lights;
        }

        public virtual void AddTuning()
        {
            Console.WriteLine(new string('+', 10));
            Console.WriteLine("Car " + Name + " ready for tune");
        }
    }
}