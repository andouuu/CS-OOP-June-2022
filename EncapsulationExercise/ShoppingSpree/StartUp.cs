using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people=new List<Person>();
            List<Product> products=new List<Product>();
            string[] allPeople = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            string[] allProducts= Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < allPeople.Length; i++)
            {
                Person currPerson = null;
                try
                {
                    string[] currSplit = allPeople[i].Split("=");
                    currPerson = new Person(currSplit[0], int.Parse(currSplit[1]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                people.Add(currPerson);
            }
            for (int i = 0; i < allProducts.Length; i++)
            {
                Product currProduct = null;
                try
                {
                    string[] currSplit = allProducts[i].Split("=");
                    currProduct = new Product(currSplit[0], int.Parse(currSplit[1]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                products.Add(currProduct);
            }

            string cmd = Console.ReadLine();
            while (cmd!="END")
            {
                string[] command = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currPersonsName=command[0];
                string currProductsName=command[1];
                people
                    .Find(x=>x.Name==currPersonsName)
                    .Buy(products.Find(x=>x.Name==currProductsName));
                cmd = Console.ReadLine();
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
