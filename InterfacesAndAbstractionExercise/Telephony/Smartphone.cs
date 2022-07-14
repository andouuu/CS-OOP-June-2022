using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class Smartphone : IBrowseable,ICallable
    {
        
        public void BrowseTheWeb(string url)
        {
            Console.WriteLine($"Browsing: {url}!");
        }

        public void CallOthers(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}