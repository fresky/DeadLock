using System;

namespace DeadLock
{
    class LockerB
    {
        public void MethodB()
        {
            lock (this)
            {
                Console.WriteLine("MethodB");
            }
        }
    }
}