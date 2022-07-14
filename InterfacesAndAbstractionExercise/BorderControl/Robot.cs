namespace BorderControl
{
    public class Robot
    {
        public string Model { get; set; }
        public string ID { get; set; }

        public Robot(string model,string id)
        {
            Model=model;
            ID=id;
        }
    }
}