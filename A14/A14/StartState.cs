using System;

namespace A14
{
    /// <summary>
    /// این کلاس بطور کامل پیاده سازی شده است و نیاز به تغییر ندارد.
    /// تنها تغییرات لازم کامنت های شماست 
    /// </summary>
    public class StartState : CalculatorState
    {
        public StartState(Calculator calc) : base(calc) { }
        /// <summary>
        /// when equal key pressed go on compute stste
        /// </summary>
        /// <returns></returns>
        public override IState EnterEqual() => 
            ProcessOperator(new ComputeState(this.Calc));

        /// <summary>
        /// when 0 key pressed stay at this state
        /// </summary>
        /// <returns></returns>
        public override IState EnterZeroDigit()
        {
            this.Calc.Display = "0";
            return this;
        }
        /// <summary>
        /// when non zero digit entered go on accumelate state and recieve next characters
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }
        /// <summary>
        /// when operator entered evaluate past operator and add this to pending operators
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterOperator(char c) => 
            ProcessOperator(new ComputeState(this.Calc), c);

        /// <summary>
        /// when . pressed then go on point state
        /// </summary>
        /// <returns></returns>
        public override IState EnterPoint()
        {
            this.Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}