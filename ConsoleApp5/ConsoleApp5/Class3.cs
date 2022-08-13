uusing System;
using System.Collections.Generic;


namespace Generics_Proj
{
    public class Gen_Stack
    {
        public static void Main()
        {
            StackDouble();
            StackString();
        }

        private static void StackString()
        {
            var stack = new Stack<string>();
            stack.Push("Fruits");
            stack.Push("Vegetables");

            while (stack.Count > 0)
            {
                Console.WriteLine("Popped string items: {0}", stack.Pop());
            }
        }

        private static void StackDouble()
        {
            var stack = new Stack<double>();
            stack.Push(1.2);
            stack.Push(2.2);
            stack.Push(3.2);
            stack.Push(4.2);

            while (stack.Count > 0)
            {
                double item = stack.Pop();
                Console.WriteLine("Popped Item: {0}", item);
            }
        }
    }
}