using System;
using Domain.Domain;
using InterfaceActions.Actions;
using Domain.Logger;

namespace ActionImplementations
{
    public class SmsNotification : INotifyUsersAction2
    {
        public void Notify(GermanyCar germanyCar)
        {
            Console.WriteLine("Send SMS: Congrats. GERMANY!");
            Console.WriteLine(new string('-', 30));
            Logger.SaveMessageToLog("SMS was sended");
        }

        public void Notify(JapanCar japanCar)
        {
            Console.WriteLine("Send SMS: Congrats  New JAPAN car is available!");
            Console.WriteLine(new string('-', 30));
            Logger.SaveMessageToLog("SMS was sended");
        }
    }
}