using System;

namespace Value_Equality_Struct_Example
{
    class Program
    {
        // The following example shows how to implement value equality in a struct (value type)

        // For structs, the default implementation of Object.Equals(Object) 
        // (which is the overridden version in System.ValueType) performs a value equality check 
        // by using reflection to compare the values of every field in the type. 

        // When an implementer overrides the virtual Equals method in a struct, 
        // the purpose is to provide a more efficient means of performing the value equality check 
        // and optionally to base the comparison on some subset of the struct's field or properties.

        // The == and != operators cannot operate on a struct unless the struct explicitly overloads them.

        static void Main(string[] args)
        {
            TwoDPoint pointA = new TwoDPoint(3, 4);
            TwoDPoint pointB = new TwoDPoint(3, 4);
            int i = 5;

            // Compare using virtual Equals, static Equals, and == and != operators.
            // True:
            Console.WriteLine("pointA.Equals(pointB) = {0}", pointA.Equals(pointB));
            // True:
            Console.WriteLine("pointA == pointB = {0}", pointA == pointB);
            // True:
            Console.WriteLine("object.Equals(pointA, pointB) = {0}", object.Equals(pointA, pointB));
            // False:
            Console.WriteLine("pointA.Equals(null) = {0}", pointA.Equals(null));
            // False:
            Console.WriteLine("(pointA == null) = {0}", pointA == null);
            // True:
            Console.WriteLine("(pointA != null) = {0}", pointA != null);
            // False:
            Console.WriteLine("pointA.Equals(i) = {0}", pointA.Equals(i));
            // CS0019:
            // Console.WriteLine("pointA == i = {0}", pointA == i);

            // Compare unboxed to boxed.
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            list.Add(new TwoDPoint(3, 4));
            // True:
            Console.WriteLine("pointA.Equals(list[0]): {0}", pointA.Equals(list[0]));

            // Compare nullable to nullable and to non-nullable.
            TwoDPoint? pointC = null;
            TwoDPoint? pointD = null;
            // False:
            Console.WriteLine("pointA == (pointC = null) = {0}", pointA == pointC);
            // True:
            Console.WriteLine("pointC == pointD = {0}", pointC == pointD);

            TwoDPoint temp = new TwoDPoint(3, 4);
            pointC = temp;
            // True:
            Console.WriteLine("pointA == (pointC = 3,4) = {0}", pointA == pointC);

            pointD = temp;
            // True:
            Console.WriteLine("pointD == (pointC = 3,4) = {0}", pointD == pointC);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
