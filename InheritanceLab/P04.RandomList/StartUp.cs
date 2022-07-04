using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList=new RandomList(){"ando","banso","lanbo"};
            Console.WriteLine(randomList.RandomString());
        }
    }
}
