﻿using static System.Console;

namespace A14
{
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { }

        public override IState EnterEqual() => ProcessOperator(new ComputeState(this.Calc));

        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');

        public override IState EnterNonZeroDigit(char c)
        {
            Calc.Display += c.ToString();
            return this;
        }

        public override IState EnterOperator(char c) => ProcessOperator(new ComputeState(this.Calc));
 
        public override IState EnterPoint()
        {
            Calc.Display += ".";
            return new PointState(Calc);
        }
    }
}