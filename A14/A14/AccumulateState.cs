using static System.Console;

namespace A14
{
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { }

        // #7 لطفا
        public override IState EnterEqual() => new ComputeState(this.Calc);
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');
        public override IState EnterNonZeroDigit(char c)
        {
            Calc.Display += c.ToString();
            return this;
        }

        // #9 لطفا!
        public override IState EnterOperator(char c) => this;
 
        public override IState EnterPoint()
        {
            Calc.Display += "0.";
            return new PointState(Calc);
        }
    }
}