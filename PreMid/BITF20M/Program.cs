using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITF20M
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> list = new List<int>();
            //List<string> list2 = new List<string>();

            //Dictionary<int, string> dictionary1 = new Dictionary<int, string>();
            //dictionary1.Add(1, "1234");
            //dictionary1.Add(2, "1234");

            //Dictionary<string, Double> dictionary2 = new Dictionary<string, double>();
            //dictionary2.Add("1", 2.34);
            //dictionary2.Add("2", 3.15);


            //var first = new First();
            //var second = new Second();
            //var third = new Third();

            //using (var testDisposable = new TestDisposable())
            //{
            //    Console.WriteLine("In using block");
            //}

            //if(true)
            //{
            //    var testDisposable = new TestDisposable();
            //    Console.WriteLine("in if block");
            //}
            //Console.WriteLine("out of block");

            var third = new Third();

            //var inst = new ChildOne();
        }
    }


    public abstract class BaseOne
    {
        static BaseOne()
        {
            Console.WriteLine("Base static ctor");
        }

        public BaseOne()
        {
            Console.WriteLine("Base Ctor");
        }
        public abstract void Foo();
    }

    public class ChildOne : BaseOne
    {
        public ChildOne()
        {
            Console.WriteLine("Child ctor");
        }
        public override void Foo()
        {
            throw new NotImplementedException();
        }
    }

    public class TestDisposable : IDisposable
    {
        public TestDisposable()
        {
            Console.WriteLine("TestDisposable ctor");
        }
        public void Dispose()
        {
            Console.WriteLine("TestDisposable Dispose()");
        }
        ~TestDisposable()
        {
            Console.WriteLine("TestDisposable ~ctor()");
        }
    }

    public class Test
    {
        public void Run()
        {
            Func<string, int, double, bool> createStudent = DoSomething1;

            var result = createStudent.Invoke("Hussain", 23, 3.4);

            Action<string, int, double> action1 = ReturnNothing;

            DoSomething2("PUCIT", (name, age, cgpa) =>
            {
                return false;
            });
        }

        public bool DoSomething1(string name, int age, double gpa)
        {
            return false;
        }

        public void DoSomething2(string institute, Func<string, int, double, bool> studentCreator)
        {
            bool checkSomeValue = true;

            if (checkSomeValue)
            {
                studentCreator.Invoke("", 12, 3.1);
            }

            return;
        }

        public void ReturnNothing(string a, int b, double c) { }
    }

    public interface IRequestHandler<T>
        where T: RequestDTO
    {
        byte[] ReceiveRequest();
        bool SendRequest(T obj);
        bool SendRequests(T[] obj);
    }

    public class RequestDTO
    {
        public string RequestCode { get; set; }
    }

    public class Email : RequestDTO
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Content { get; set; }
    }
    public class Sms : RequestDTO
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Content { get; set; }
    }

    public class RequestHandler<T> : IRequestHandler<T>
        where T : RequestDTO
    {
        public byte[] ReceiveRequest()
        {
            return new byte[] { Convert.ToByte(2123) };
        }

        public bool SendRequest(T obj)
        {
            return true;
        }

        public bool SendRequests(T[] objs)
        {
            try
            {
                foreach (var obj in objs)
                {
                    SendRequest(obj);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }
    }


    public class First
    {
        static First()
        {
            Console.WriteLine("Static First() is called");
        }

        public First()
        {
            Console.WriteLine("First() is called");
        }
    }

    public class Second : First
    {
        static Second()
        {
            Console.WriteLine("Static Second() is called");
        }

        public Second()
        {
            Console.WriteLine("Second() is called");
        }
    }
    public class Third : Second
    {
        static Third()
        {
            Console.WriteLine("Static Third() is called");
        }

        public Third()
        {
            Console.WriteLine("Third() is called");
        }
    }

}
