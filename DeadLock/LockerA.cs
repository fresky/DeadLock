using System;
using System.Threading;

namespace DeadLock
{
    class LockerA
    {
        public void MethodA()
        {
            lock (this)
            {
                Console.WriteLine("MethodA");
            }
        }

        public void MethodWaitA(object waitHandle)
        {
            lock (this)
            {
                Console.WriteLine("MethodWaitA");
                (waitHandle as AutoResetEvent).Set();
            }
        }
    }
}