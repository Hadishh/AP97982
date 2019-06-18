﻿namespace A14
{
    /// <summary>
    /// ماشین حساب وقتی که جواب یک محاسبه
    /// را نشان میدهد وارد این وضعیت میشود
    /// </summary>
    public class ComputeState : CalculatorState
    {
        public ComputeState(Calculator calc) : base(calc) { }

        public override IState EnterEqual()
        {
            Calc.DisplayError("Syntax Error");
            return new ErrorState(this.Calc);
        }

        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }

        public override IState EnterZeroDigit()
        {
            Calc.Display = "0";
            return new StartState(this.Calc);
        }

        // #5 لطفا
        public override IState EnterOperator(char c) => this;

        public override IState EnterPoint()
        {
            Calc.Evalute();
            Calc.Display = "0.";
            return new PointState(this.Calc);
        }

    }
}