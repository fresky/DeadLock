using System;
using System.Threading;

namespace DeadLock
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //wrongOrderExample();

            //lockThisExample();

            //lockStringExample();

            //lockTypeExample();

            //lockThisEventExample();
        }


        private static void wrongOrderExample()
        {
            new Thread(new Locker().WrongOrder1).Start();
            new Thread(new Locker().WrongOrder2).Start();
        }

        private static void lockThisExample()
        {
            new Thread(new Locker().LockThis1).Start();
            new Thread(new Locker().LockThis2).Start();
        }

        private static void lockStringExample()
        {
            new Thread(new Locker().LockString1).Start();
            new Thread(new Locker().LockString2).Start();
        }

        private static void lockTypeExample()
        {
            new Thread(new Locker().LockType1).Start();
            new Thread(new Locker().LockType2).Start();
        }

        private static void lockThisEventExample()
        {
            new Locker().LockThis3();
        }

    }
}
