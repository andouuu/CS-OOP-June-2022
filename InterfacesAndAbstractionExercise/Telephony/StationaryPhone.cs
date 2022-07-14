using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StationaryPhone:ICallable
    {
        
        public void CallOthers(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}