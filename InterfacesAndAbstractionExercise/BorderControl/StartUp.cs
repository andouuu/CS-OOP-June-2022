using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                string[] command=Console.ReadLine().Split(' ');
                if (command.Length==4)
                {
                    Citizen currCitizen = new Citizen(command[0]
                        , int.Parse(command[1]), command[2], command[3]);
                    buyers.Add(currCitizen);
                }
                else if (command.Length == 3)
                {
                    Rebel curRebel = new Rebel(command[0]
                        , int.Parse(command[1]), command[2]);
                    buyers.Add(curRebel);
                }
            }

            string cmd;
            while ((cmd=Console.ReadLine())!="End")
            {
                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == cmd);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
            int total = buyers.Sum(b => b.Food);
            Console.WriteLine(total);





























            //List<Robot> robots=new List<Robot>();
            //List<Pet> pets=new List<Pet>();
            //List<string> allBirthdates=new List<string>();
            //string cmd;
            //while ((cmd=Console.ReadLine())!="End")
            //{
            //    string[] parts=cmd.Split(' ');
            //    if (parts[0]=="Citizen")
            //    {
            //        Citizen currCitizen = new Citizen(parts[1]
            //            , int.Parse(parts[2]), parts[3], parts[4]);
            //        citizens.Add(currCitizen);
            //        allBirthdates.Add(parts[4]);
            //    }
            //    else if (parts[0]=="Robot")
            //    {
            //        Robot currRobot = new Robot(parts[1], parts[2]);
            //        robots.Add(currRobot);
            //    }
            //    else if (parts[0]=="Pet")
            //    {
            //        Pet currPet = new Pet(parts[1], parts[2]);
            //        pets.Add(currPet);
            //        allBirthdates.Add(parts[2]);
            //    }
            //}

            //string filterBirthdates = Console.ReadLine();
            //foreach (var birthdate in allBirthdates)   
            //{
            //    if (birthdate.EndsWith(filterBirthdates))
            //    {
            //        Console.WriteLine(birthdate);
            //    }
            //}
        }
    }
}
