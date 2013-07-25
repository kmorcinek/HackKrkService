namespace NancyTest
{
    internal class Constant
    {
        public string kind = HackKrkModule.Constant;

        public int id { get; set; }
        public string type { get; set; }
        
        public Constant(string type, int id)
        {
            this.id = id;
            this.type = type;
        }
    }
}