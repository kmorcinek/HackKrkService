namespace NancyTest
{
    public class Invoke
    {
        public Invoke(int id, string function)
        {
            this.kind = "constant";
            this.id = id;
            this.function = function;
        }

        public int id { get; set; }
        public string kind { get; set; }
        public string function { get; set; } 
    }
}