using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsProject
{
    class UnderstandingStack
    {
       Stack<string> myStack;
       public UnderstandingStack()
        {
            myStack = new Stack<string>();

        }
        void AddItemsToStack()
        {
            myStack.Push("Blue");
            myStack.Push("Red");
            myStack.Push("Purple");
            myStack.Push("Yellow");
        }

        void PrintStack()
        {
            //foreach (var item in myStack)
            //{
            //    Console.WriteLine(item);
            //}
            while (myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop());
            }
            Console.WriteLine(myStack.Count);
        }
        static void Main(string[] a)
        {
            UnderstandingStack understandingStack = new UnderstandingStack();
            understandingStack.AddItemsToStack();
            understandingStack.PrintStack();
            Console.ReadKey();
        }
    }
}
