using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SectionManager.StaticClass {

    internal interface IServiceA {
        void UsefulMethod();
    }

    internal interface IServiceB {
        void UsefulMethod();
    }

    internal class ServiceA : IServiceA {
        public void UsefulMethod() {
            //some useful work
            Console.WriteLine("ServiceA-UsefulMethod");
        }
    }

    internal class ServiceB : IServiceB {
        public void UsefulMethod() {
            //some useful work
            Console.WriteLine("ServiceB-UsefulMethod");
        }
    }

    internal class Client {
        public IServiceA serviceA = null;
        public IServiceB serviceB = null;

        public void DoWork() {
            serviceA?.UsefulMethod();
            serviceB?.UsefulMethod();
        }
    }

    public class ServiceLocator {
        private static ServiceLocator locator = null;

        public static ServiceLocator Instance {
            get {
                // ServiceLocator itself is a Singleton
                if (locator == null) {
                    locator = new ServiceLocator();
                }
                return locator;
            }
        }

        private ServiceLocator() {
        }

        private Dictionary<Type, object> registry =
            new Dictionary<Type, object>();

        public void Register<T>(T serviceInstance) {
            registry[typeof(T)] = serviceInstance;
        }

        public T GetService<T>() {
            T serviceInstance = (T)registry[typeof(T)];
            return serviceInstance;
        }
    }

    /*static void Main(string[] args) {
        // register services with ServiceLocator
        ServiceLocator.Instance.Register<IServiceA>(new ServiceA());
        ServiceLocator.Instance.Register<IServiceB>(new ServiceB());

        //create client and get services 
        Client client = new Client();
        client.serviceA = ServiceLocator.Instance.GetService<IServiceA>();
        client.serviceB = ServiceLocator.Instance.GetService<IServiceB>();
        client.DoWork();

        Console.ReadLine();
    }*/


}
