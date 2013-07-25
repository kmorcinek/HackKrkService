namespace NancyTest
{
    internal class Constant
    {
        public Constant(int id, string type)
        {
            this.id = id;
            this.type = type;
        }

        public int id { get; set; }
        public string kind { get; set; }
        public string type { get; set; }
    }
}