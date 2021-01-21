using System;
using System.Threading;

namespace RetryPattern
{
    public class Retry
    {
        public static TResult Do<TResult>(Func<TResult> func, int maxRetries = 3)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return func();
                }
                catch (Exception)
                {
                    TimeSpan delay;
                    if (++retryCount >= maxRetries)
                    {
                        throw;
                    }
                    //exponential delay
                    delay = TimeSpan.FromSeconds(Math.Pow(2, retryCount));
                    
                    Thread.Sleep(delay);
                }
            }
        }
    }
}