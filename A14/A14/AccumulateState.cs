using static System.Console;

namespace A14
{
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { }
        /// <summary>
        /// when equal pressed then procees pending operator and go on compute state
        /// </summary>
        /// <returns></returns>
        public override IState EnterEqual() => ProcessOperator(new ComputeState(this.Calc));
        /// <summary>
        /// when zero enterd stay at this and add 0 to your number string
        /// </summary>
        /// <returns></returns>
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');
        /// <summary>
        /// adding entered number to num string and accumelate digits
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterNonZeroDigit(char c)
        {
            Calc.Display += c.ToString();
            return this;
        }
        /// <summary>
        /// cumpute operator c and evaluate past operator and add c to pending operator
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterOperator(char c) => ProcessOperator(new ComputeState(this.Calc), c);
        /// <summary>
        /// when point pressed enter point state
        /// </summary>
        /// <returns></returns>
        public override IState EnterPoint()
        {
            Calc.Display += ".";
            return new PointState(Calc);
        }
    }
}