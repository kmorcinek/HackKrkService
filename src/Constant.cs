namespace NancyTest
{
    public class Constant
    {
        public string kind = HackKrkModule.Constant;

        public int id { get; set; }
        public string type { get; set; }
        
        public Constant(string type)
        {
            this.id = ++HackKrkModule.Incrementer;
            this.type = type;
        }
    }
}