using Microsoft.VisualBasic.CompilerServices;

namespace BorderControl
{
    public class Citizen:IBuyer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; }
        public Citizen(string name,int age,string id,string birthdate)
        {
            Name=name;
            Age=age;
            ID=id;
            Birthdate=birthdate;
            Food = 0;
        }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}