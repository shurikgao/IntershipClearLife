using System;

namespace Domain.Domain.Proxy
{
    public class Driver
    {
        public bool AlcoTestPassed { get; private set; }
        public bool DriverLicence { get; private set; }
        public static string Name { get; private set; }

        public Driver(string name, bool alcoTestPassed, bool driverLicence)
        {
            AlcoTestPassed = alcoTestPassed;
            DriverLicence = driverLicence;
            Name = name;
        }
    }


    public class CarProxy : IDrive
    {
        private readonly Driver _driver;
        private readonly Car _realCar;


        public CarProxy(Driver driver, Car car)
        {
            _driver = driver;
            _realCar = car;
        }

        public void Drive()
        {
            if (_driver.DriverLicence != true)
                Console.WriteLine("{0,-20} Sorry!!! U have no rights to drive", Driver.Name);  //  FOR UnitTest Comment 
             //   throw new ApplicationException("U cannot drive");   FOR UnitTest Uncomment 
            if (_driver.AlcoTestPassed != true)
                Console.WriteLine("{0,-20} Sorry!!! U R Drunk. Do not touch anything", Driver.Name); //  FOR UnitTest Comment 
            //throw new ApplicationException("U R Drunk!!!");  FOR UnitTest Uncomment 
            _realCar.Drive();
        }
    }
}