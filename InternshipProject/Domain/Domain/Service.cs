using System;
using System.Globalization;

namespace Domain.Domain
{
    public class Service
    {
        public void Check(Car car)
        {
            if (car.GetSystemStatus())
            {
                Console.WriteLine("Car's systems are OK..." + car.Name);
                Console.WriteLine(new string('-', 30));
            }
            else
            {
                //string composite = "Info={0,-20} deffect={1,15}";
                Console.WriteLine("Info=Service is needed - {0,-13} deffect = Battery{1,8}", car.Name, car.GetBattStatus());
                //Console.WriteLine("Service is needed.  " + car.Name + " Battery_ " + car.BattOk);
                Console.WriteLine(new string('-', 30));
            }
            //return true;
        }

        public void Repair(Car car)
        {
            if (car.GetBattStatus() == false)
            {
                car.SetBattStatus( true);
            }
            car.CheckAllSystem();
            CashRegister bill = CashRegister.Payd;
            bill.AddBill(200);
            Console.WriteLine(" {0,26} Repaired.  Please pay:{1,14}", car.Name, bill.BillSize.ToString("C", CultureInfo.CurrentCulture));
            //bill.AddBill(200); 
           // Console.WriteLine("please pay:" + bill.BillSize.ToString("C",CultureInfo.CurrentCulture));
            bill.ResetCashRegister();


        }

        public sealed class CashRegister                                             // class with Singleton pattern
        {
            private static readonly CashRegister PrintBill = new CashRegister();   // Singleton

            static CashRegister()
            {
                
            }

            public void AddBill(int price)
            {
                BillSize += price;
            }
            public void ResetCashRegister()
            {
                BillSize = 0;
            }
            private CashRegister()
            {
                BillSize = 0;
            }

            
            public int BillSize { get; private set; }          

            public static CashRegister Payd
            {
                get { return PrintBill; }
            }
        }
    }
}
