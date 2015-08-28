using System;
using ActionImplementations;
using Domain.Domain;
using Domain.Domain.Decorator;
using Factories.Factory;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Infrastructure.IoC;
using RepositoryInterfaces;

namespace Presentation
{
    internal class DisplayInfo

    {
        static DisplayInfo()
        {
            ServiceLocator.RegisterAll();
            GermanyCarFactory = ServiceLocator.Get<GermanyCarFactory>();
            JapanCarFactory = ServiceLocator.Get<JapanCarFactory>();

            CarRepository = ServiceLocator.Get<ICarRepository>();
            DriverRepository = ServiceLocator.Get<IDriverRepository>();
            NHibernateProfiler.Initialize();
        }

        private static GermanyCarFactory GermanyCarFactory;
        private static JapanCarFactory JapanCarFactory;
        // private static ChinaCarFactory ChinaCarFactory;

        private static ICarRepository CarRepository;
        private static IDriverRepository DriverRepository;


        private static void Main(string[] args)
        {
            GermanyCarFactory = ServiceLocator.Get<GermanyCarFactory>();
            JapanCarFactory = ServiceLocator.Get<JapanCarFactory>();

            CarRepository = ServiceLocator.Get<ICarRepository>();
            DriverRepository = ServiceLocator.Get<IDriverRepository>();


            //Car testCar = new Car("Bmw", 3000, 70, "Sedan","GDR");
            //Car testCar1 = new Car("Audi", 2500, 80, "universal","FRG");
            //CarRepository.Save(testCar1);
            GermanyCar bmw = GermanyCarFactory.CreateNewGermanyCar("BMW", 3500, 100, "Sedan", "Germany", 98);
            var germanyCarFactory = new GermanyCarFactory(new EmailNotification());

            JapanCar honda = JapanCarFactory.CreateNewJapanCar("Honda", 2000, 70, "Hatchbag", "Japan", 99);
            var japanCarFactory = new JapanCarFactory(new SmsNotification());

            Driver testDriver = new Driver("UasiaWay", 21, bmw);
            Driver testDriver1 = new Driver("JoriK", 22, bmw);
            Driver testDriver2 = new Driver("Fed`ka", 23, honda);
            Driver testDriver3 = new Driver("Gri6ka", 24, honda);
            Driver testDriver4 = new Driver("Bor`ka", 25, honda);


            bmw.Drivers.Add(testDriver);
            bmw.Drivers.Add(testDriver1);
            honda.Drivers.Add(testDriver2);
            honda.Drivers.Add(testDriver3);
            honda.Drivers.Add(testDriver4);
            CarRepository.Save(bmw);
            CarRepository.Save(honda);
            CarRepository.Save(bmw);

            DriverRepository.UpdDriverAge(205, 28);
            DriverRepository.DeleteDriver(204);

            Console.ReadKey();


            GermanyCar audi = GermanyCarFactory.CreateNewGermanyCar("Audi", 2500, 80, "Universal", "Germany", 99);
            Console.WriteLine(new string('-', 30));

            //var JapanCarFactory = new JapanCarFactory(); 


            var ChinaCarFactory = new ChinaCarFactory();
            ChinaCar byd = ChinaCarFactory.CreateNewChinaCar("BYD", 1300, 50, "ChinaStyle", "China", 101);

            //
            SomeActions(audi, bmw, honda, byd);
        }

        private static void SomeActions(GermanyCar audi, GermanyCar bmw, JapanCar honda, ChinaCar byd)
        {
            TuneCar(audi);
            Console.WriteLine(new string('=', 30));
            TuneCar(bmw);
            Console.WriteLine(new string('=', 30));
            TuneCar(honda);
            Console.WriteLine(new string('=', 30));


            Console.WriteLine(new string('-', 30));
            Console.WriteLine("GermanyCar : " + bmw.Name);
            Console.WriteLine(bmw.Name + " engine: " + bmw.EngineIsStarted);
            Console.WriteLine(bmw.Name + " lights: " + bmw.lights);
            Console.WriteLine(new string('-', 30));
            bmw.CheckAllSystem();
            bmw.StartEngine();


            Console.WriteLine("JapanCar : " + honda.Name);
            Console.WriteLine(honda.Name + " engine: " + honda.EngineIsStarted);
            Console.WriteLine(honda.Name + " lights: " + honda.lights);
            Console.WriteLine(new string('-', 30));
            honda.CheckAllSystem();
            honda.StartEngine();
            honda.lights = false;

            Console.WriteLine("ChinaCar : " + byd.Name);
            Console.WriteLine(byd.Name + " engine: " + byd.EngineIsStarted);
            Console.WriteLine(byd.Name + " lights: " + byd.lights);
            Console.WriteLine(new string('-', 30));
            byd.CheckAllSystem();
            byd.StartEngine();

            Console.WriteLine(new string('-', 30));


            // audi.BattOk = false;
            //  byd.BattOk = false;
            Service srv = new Service();

            srv.Check(bmw);
            srv.Check(honda);
            srv.Check(byd);
            Console.WriteLine();
            srv.Check(audi);
            srv.Repair(audi);
            // Audi.checkAllSystem();
            srv.Check(audi);
            audi.StartEngine();
            Console.WriteLine();
            Console.WriteLine("!!! Start Engine !!!");
            Console.WriteLine(new string('-', 30));


            Console.WriteLine("     " + bmw);
            Console.WriteLine(honda.ToString());
            Console.WriteLine(byd.ToString());
            Console.WriteLine(audi.ToString());

            // Service.CashRegister bill = Service.CashRegister.payd;

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
    }
}