using System;
using Employees.classes;

namespace HelloCSharp
{
    public class Program
    {

        //delegate
        //Declare a function delagte will take reference of fuction with a return type of double
        delegate double MyFunction(double x); // delegate holds reference of functions


        //enum ==> set of constant values
        public enum colors
        {
            RED,
            GREEN, 
            BLUE
        }

        //struct
        public struct Point
        {
            public double X { get; }
            public double Y { get; }

            public Point(double x, double y) => (X, Y) = (x, y);
        }
            
        //entry point
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, CSharp!");
                //Create an object of type employee
                //calling constructor..
                //Employee emp1 = new Employee(101, "Shrey", "Pune");
                //Console.WriteLine(emp1.GetEmployees());

            //------------------------------------------------------------//

            // 1. C# types - (value type / reference type)
                int num = 123;
                object obj = num;   // boxing
                int i = (int)obj;   //unboxing

            //Console.WriteLine(obj);
            //Console.WriteLine(i);

            //------------------------------------------------------------//

            // 2. sample generic type
            /*
                try
                {
                    var s = new Stack<int>();
                    s.Push(1);  //stack contain 1
                    s.Push(2);  //stack contain 1, 2
                    s.Push(3);  //stack contain 1, 2, 3
                    Console.WriteLine(s.Pop());  //stack contain 1 ,2
                                                  Console.WriteLine(s.Pop());  //stack contain 1
                                                  Console.WriteLine(s.Pop());  //stack is empty
                                                  Console.WriteLine(s.Pop());  //Throws exception
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                catch (InvalidDataException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                finally 
                {
                    Console.WriteLine("Where you want to go from here?");
                } 
            */

            //------------------------------------------------------------//

            // 3. System generic types - collection

            List<string> cities = new List<string>();
            cities.Add("Mumbai");
            cities.Add("Pune");
            cities.Add("Chennai");
            cities.Add("Delhi");

            //foreach (var item in cities)
            //{
            //    Console.WriteLine(item);
            //}

            //------------------------------------------------------------//

            //LinQ

            //int[] scores = { 10, 20, 30, 04, 89, 22 };

            // LinQ usig query expression
            //IEnumerable<int> scores2 = from score in scores
            //                           where score > 20
            //                           orderby score descending
            //                           select score;

            //foreach (var item in scores2)
            //{
            //    Console.WriteLine(item);
            //}

            //IList<string> cities2 = from c in cities
            //                        where c.ToString() == "Delhi"
            //                        select c;

            //foreach (var item in cities)
            //{
            //    Console.WriteLine(item);
            //}

            IEnumerable<string> cities2 = from c in cities
                                    where c.ToString() == "Delhi"
                                    select c;

            //foreach (var item in cities2)
            //{
            //    Console.WriteLine(item);
            //}

            //method based expression
            IEnumerable<string> myCity = cities.Where(c => c == "MumKarjatbai");

            //foreach (var item in myCity)
            //{
            //    Console.WriteLine(item);
            //}

            //------------------------------------------------------------//

            // implementation of delagtes

            static double[] Apply(double[] a, MyFunction f)
            {
                var result = new double[a.Length];
                for (int i = 0; i < a.Length; i++)
                {
                    result[i] = f(a[i]);
                }
                return result;
            }

            double[] d = { 0.0, 1.1, 2.2, 3.3, 4.4, 5.5 };

            double[] squares = Apply(d, (x) =>  x * x);

            foreach (var item in squares)
            {
                Console.WriteLine(item);

            }

            Console.ReadLine();
        }
    }
}