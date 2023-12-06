using System;
using System.Collections;
using System.Collections.Generic;
using DesignPatterns.BehavioralPatterns;
using DesignPatterns.CreationalPatterns;

namespace DesignPatterns
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DP Sample");

            //TestSingletonMultiThread();
            //TestObserver();
            TestStrategy();
        }

        #region Singleton
        public static void TestSingletonMultiThread()
        {
            Thread process1 = new Thread(() =>
            {
                Singleton instance1 = Singleton.GetInstance("Tread1");
                Console.WriteLine(instance1.Value);
                Console.WriteLine($"Instance 1 HashCode: {instance1.GetHashCode()}");
            });
            Thread process2 = new Thread(() =>
            {
                Singleton instance2 = Singleton.GetInstance("Tread2");
                Console.WriteLine(instance2.Value);
                Console.WriteLine($"Instance 2 HashCode: {instance2.GetHashCode()}");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
        }
        #endregion

        #region Observer
        public static void TestObserver()
        {
            // The client code.
            var subject = new Subject();
            var observerA = new ConcreteObserverA();
            subject.Attach(observerA);

            var observerB = new ConcreteObserverB();
            subject.Attach(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Detach(observerB);

            subject.SomeBusinessLogic();
        }
        #endregion

        #region Strategy
        public static void TestStrategy()
        {
            // The client code picks a concrete strategy and passes it to the
            // context. The client should be aware of the differences between
            // strategies in order to make the right choice.
            var context = new Context();

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }
        #endregion
    }


}