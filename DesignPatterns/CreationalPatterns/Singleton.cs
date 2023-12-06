using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns
{
    // Use case: control access to some shared resource, eg. database connnection, logging, configuration settings
    // Implementations:
    // 1. Make the default constructor private, to prevent other objects from using the new operator with the Singleton class
    // 2. Create a static creation method that acts as a constructor

    public class Singleton
    {
        public string Value { get; set; }

        private static Singleton _instance; // Private static field for storing the singleton instance

        private static readonly object _lock = new object();

        private Singleton() // The Singleton’s constructor should be hidden from the client code
        {
            Console.WriteLine("Singleton instance created.");
        }

        // Public static method to get the singleton instance
        // Can adjust extra logic here, eg. limitation(more than one of instance)
        public static Singleton GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock) // Thread lock for multi-thread support
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                        _instance.Value = value;
                    }
                    return _instance;
                }
            }
            return _instance;
        }
    }
}
