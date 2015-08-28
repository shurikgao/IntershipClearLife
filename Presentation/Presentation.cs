using System;
using Domain.Domain;
using Domain.Domain.Decorator;
using Domain.Domain.Observer;
using Domain.Domain.Proxy;
using Factories.Factory;
using Infrastructure.IoC;

namespace Presentation
{
    internal class DisplayInfo

    {
        private static GermanyCarFactory GermanyCarFactory;
        private static JapanCarFactory JapanCarFactory;
        // private static ChinaCarFactory ChinaCarFactory;
        private static RDSTransmitter RdsTrans;

        private static void Main(string[] args)
        {
            ServiceLocator.RegisterAll();
            GermanyCarFactory = ServiceLocator.Get<GermanyCarFactory>();
            JapanCarFactory = ServiceLocator.Get<JapanCarFactory>();

            GermanyCar bmw = GermanyCarFactory.CreateNewGermanyCar("BMW", 3500, 100, "Sedan");

            GermanyCar audi = GermanyCarFactory.CreateNewGermanyCar("Audi", 2500, 80, "Universal");

            JapanCar honda = JapanCarFactory.CreateNewJapanCar("Honda", 2000, 70, "Hatchbag");

            var ChinaCarFactory = new ChinaCarFactory();
            ChinaCar byd = ChinaCarFactory.CreateNewChinaCar("BYD", 1300, 50, "ChinaStyle");

            TuneCar(audi);
            Console.WriteLine(new string('=', 30));
            //TuneCar(bmw);
            //Console.WriteLine(new string('=', 30));
            //TuneCar(honda);
            //Console.WriteLine(new string('=', 30));

            // Germany car info

            #region

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("GermanyCar : " + bmw.Name);
            Console.WriteLine(bmw.Name + " engine: " + bmw.EngineIsStarted);
            Console.WriteLine(bmw.Name + " lights: " + bmw.lights);
            Console.WriteLine(new string('-', 30));
            bmw.CheckAllSystem();
            bmw.StartEngine();

            #endregion

            // Japan car info

            #region

            Console.WriteLine("JapanCar : " + honda.Name);
            Console.WriteLine(honda.Name + " engine: " + honda.EngineIsStarted);
            Console.WriteLine(honda.Name + " lights: " + honda.lights);
            Console.WriteLine(new string('-', 30));
            honda.CheckAllSystem();
            honda.StartEngine();
            honda.lights = false;

            #endregion

            // China car info

            #region

            Console.WriteLine("ChinaCar : " + byd.Name);
            Console.WriteLine(byd.Name + " engine: " + byd.EngineIsStarted);
            Console.WriteLine(byd.Name + " lights: " + byd.lights);
            Console.WriteLine(new string('-', 30));
            byd.CheckAllSystem();
            byd.StartEngine();

            #endregion

            Console.WriteLine(new string('-', 30));

            audi.BattOk = false;
            byd.BattOk = false;
            Service srv = new Service();

            // Service check

            #region

            srv.Check(bmw);
            srv.Check(honda);
            srv.Check(byd);
            Console.WriteLine();
            srv.Check(audi);
            srv.Repair(audi);
            srv.Check(audi);
            Console.WriteLine();

            #endregion

            Console.WriteLine("!!! Start Engine !!!");
            Console.WriteLine(new string('-', 30));

            Console.WriteLine("     " + bmw);
            Console.WriteLine(honda.ToString());
            Console.WriteLine(byd.ToString());
            Console.WriteLine(audi.ToString());

            Console.WriteLine(new string('-', 30));
            UseProxy(bmw, audi, honda);

            // Observer RDS

            #region

            Console.WriteLine(new string('=', 30));
            RdsTrans = new RDSTransmitter();
            RdsTrans.Subscribe(audi.Receiver);
            RdsTrans.Subscribe(byd.Receiver);
            RdsTrans.LastNews = DateTime.Now + " Have an ice day ";
            RdsTrans.UnSubscribe(byd.Receiver);
            RdsTrans.LastNews = "Weather for this evening";
            Console.WriteLine(new string('=', 30));

            #endregion

            // Template method

            #region

            bmw.StartAirConditioner();
            audi.StartAirConditioner();
            honda.StartAirConditioner();
            Console.WriteLine(audi.ToString());

            #endregion

            Console.ReadLine();
        }

        private static void TuneCar(Car car)
        {
            ITuning air = new AirConditioner(car);
            air.AddTuning();
            ITuning alarm = new AlarmSystem(car);
            alarm.AddTuning();
            ITuning park = new Parctronic(car);
            park.AddTuning();
        }

        private static void UseProxy(Car car1, Car car2, Car car3)
        {
            var car = new CarProxy(new Driver("Otto  ", true, false), car1);
            car.Drive();
            car = new CarProxy(new Driver("Adolf  ", false, true), car2);
            car.Drive();
            car = new CarProxy(new Driver("To-Iama_To_Kanava  ", true, true), car3);
            car.Drive();
            Console.WriteLine(new string('-', 30));
        }
    }
}