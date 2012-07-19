using System;
using System.Threading;

namespace DeadLock
{
    class Locker
    {
        private static readonly object A = new object();
        private static readonly object B = new object();

        private static readonly LockerA lockerA = new LockerA();
        private static readonly LockerB lockerB = new LockerB();

        private WaitHandle[] m_WaitHandles = new WaitHandle[] 
        {
            new AutoResetEvent(false),
        };

        public void WrongOrder1()
        {
            lock (A)
            {
                Thread.Sleep(1000);
                lock (B)
                {
                    Console.WriteLine("WrongOrder1");
                }
            }
        }

        public void WrongOrder2()
        {
            lock (B)
            {
                Thread.Sleep(1000);
                lock (A)
                {
                    Console.WriteLine("WrongOrder2");
                }
            }
        }

        public void LockThis1()
        {
            lock (lockerA)
            {
                Thread.Sleep(1000);
                lockerB.MethodB();
            }
        }

        public void LockThis2()
        {
            lock (lockerB)
            {
                Thread.Sleep(1000);
                lockerA.MethodA();
            }
        }

        public void LockThis3()
        {
            lock(lockerA)
            {
                new Thread(lockerA.MethodWaitA).Start(m_WaitHandles[0]);
                WaitHandle.WaitAny(m_WaitHandles);
            }
        }
        public void LockString1()
        {
            lock ("lock1")
            {
                Thread.Sleep(1000);
                lock ("lock2")
                {
                    Console.WriteLine("LockString1");
                }
            }
        }

        public void LockString2()
        {
            lock ("lock2")
            {
                Thread.Sleep(1000);
                lock ("lock1")
                {
                    Console.WriteLine("LockString2");
                }
            }
        }

        public void LockType1()
        {
            lock (typeof(int))
            {
                Thread.Sleep(1000);
                lock (typeof(double))
                {
                    Console.WriteLine("LockType1");
                }
            }
        }

        public void LockType2()
        {
            lock (typeof(double))
            {
                Thread.Sleep(1000);
                lock (typeof(int))
                {
                    Console.WriteLine("LockType2");
                }
            }
        }
    }
}