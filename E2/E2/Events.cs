using System;
using System.Collections.Generic;
using System.Timers;

namespace E2
{
    public class DuplicateNumberDetector
    {
        Dictionary<int, int> Numbers = new Dictionary<int, int>();
        public void AddNumber(int n)
        {
            if (Numbers.ContainsKey(n))
            {
                Numbers[n]++;
                if(DuplicateNumberAdded != null)
                    DuplicateNumberAdded(Numbers[n]);
            }
            else
                Numbers.Add(n, 0);
            return;
        }

        public event Action<int> DuplicateNumberAdded;
    }
}