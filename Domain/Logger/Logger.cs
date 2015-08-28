using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Logger
{
   public class Logger
    {
        public static void SaveMessageToLog(string msg)
        {
            using (FileStream fs = new FileStream(@"D:\log.txt", FileMode.Append))
            {
                string tmp = string.Format("{0} : {1} ", DateTime.Now, msg);
                byte[] buff = Encoding.Unicode.GetBytes(tmp+"\n");
                fs.Write(buff,0, buff.Length);
            }
        }

    }
}
