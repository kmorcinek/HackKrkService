namespace NancyTest
{
    public class BoolConstant : Constant
    {
        public bool value { get; set; }

        public BoolConstant(bool value)
            : base(HackKrkModule.Bool)
        {
            this.value = value;
        }
    }
}