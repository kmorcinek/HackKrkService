namespace NancyTest
{
    public class Invoke
    {
        public string kind = HackKrkModule.Invoke;

        public int function { get; set; }
        public int[] arguments { get; set; }
        public int id { get; set; }

        public Invoke(int function, int[] arguments)
        {
            this.function = function;
            this.arguments = arguments;

            var functions = new Functions();

            int x = arguments[0];
            var unwrappedX = (IntConstant)HackKrkModule.GetConstant(x);

            int y = arguments[1];
            var unwrappedY = (IntConstant)HackKrkModule.GetConstant(y);

            var func = functions.IdToFunction[this.function];
            var result = func.Invoke(unwrappedX.value, unwrappedY.value);

            var constant = new IntConstant(result);
            
            HackKrkModule._storage.Add(constant.id, constant);

            this.id = constant.id;
        }
    }
}