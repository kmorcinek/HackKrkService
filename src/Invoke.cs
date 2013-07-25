namespace NancyTest
{
    public class Invoke
    {
        public string kind = HackKrkModule.Invoke;

        public int function { get; set; }
        public dynamic arguments { get; set; }
        public int id { get; set; }

        public Invoke(int function, dynamic arguments)
        {
            this.function = function;
            this.arguments = arguments;

            var functions = new Functions();

            int x = arguments[0];
            int y = arguments[1];

            var constant = new Constant(HackKrkModule.Integer, functions.IdToFunction[this.function].Invoke(x, y));
            
            this.id = constant.id;
        }
    }
}