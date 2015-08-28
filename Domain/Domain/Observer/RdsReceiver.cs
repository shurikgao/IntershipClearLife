﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Observer
{
    class RdsReceiver : IRdsSubscriber
    {
        public string CarName { get; set; }
        public RdsReceiver(string carName)
        {
            CarName = carName;
        }
        public void Update(string newsText)
        {
            Console.WriteLine("RDS... Latest news  [{0, -4}]: {1}", CarName, newsText);
        }
    }
}
