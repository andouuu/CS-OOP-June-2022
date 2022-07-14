using System;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phonesToCall = Console.ReadLine().Split(' ');
            string[] sitesToVisit = Console.ReadLine().Split(' ');

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            CallPhoneNumbers(phonesToCall, smartphone, stationaryPhone);
            BrowseWebsites(sitesToVisit, smartphone);
        }

        private static void BrowseWebsites(string[] sitesToVisit, Smartphone smartphone)
        {
            foreach (string url in sitesToVisit)
            {
                bool isNotValid = url.Any(ch => char.IsDigit(ch));

                if (isNotValid)
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartphone.BrowseTheWeb(url);
                }
            }
        }

        private static void CallPhoneNumbers(string[] phonesToCall, Smartphone smarthphone, StationaryPhone stationaryPhone)
        {
            foreach (string number in phonesToCall)
            {
                bool isValid = number.All(ch => char.IsDigit(ch));

                if (isValid)
                {
                    if (number.Length == 10)
                    {
                        smarthphone.CallOthers(number);
                    }
                    else if (number.Length == 7)
                    {
                        stationaryPhone.CallOthers(number);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }
    }
}