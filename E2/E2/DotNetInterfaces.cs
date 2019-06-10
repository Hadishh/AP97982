using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace E2
{
    public static class DotNetInterfaces
    {
        public static IEnumerable<long> GetElapsedTimes(int max=100)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            yield return 0;
            
            for(int i = 1; i <= max; i++)
            {
                sw.Stop();
                long elapsedMiliseconds = sw.ElapsedMilliseconds;
                sw = Stopwatch.StartNew();
                yield return elapsedMiliseconds;
            }
            sw.Stop();
            
        }
    }
}