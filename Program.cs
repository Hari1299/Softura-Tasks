using System;
using System.Collections.Generic;
using System.Collections;
namespace CollectionsProject
{
    class Program
    {
            
        /// <summary>
        /// 
        /// </summary>
        /// 
       List<int> TakeNumbersFromUser()
        {
            List<int> numbers = new List<int>();
            int number = 0;
                do
                {
                    Console.WriteLine("Please enter a number.Enter a negative a number to quit(example -1");
                    try
                    {
                        number = Convert.ToInt32(Console.ReadLine());
                        int result = 10 / number;
                        if (number >= 0)
                            numbers.Add(number);
                    }
                    catch (DivideByZeroException dbz)
                    {
                        Console.WriteLine("We cannot divide a number by zero");
                        Console.WriteLine(dbz.Message);
                    }
                    catch (FormatException formatException)
                    {
                        Console.WriteLine("we are excepting number.Please enter a whole number");
                        Console.WriteLine(formatException.Message);
                    }
                    catch (OverflowException overflowexception)
                    {
                        Console.WriteLine("the number is too big");
                        Console.WriteLine(overflowexception.Message);
                    }
                } while (number >= 0);
                Console.WriteLine("the number of numbers entered is " + numbers.Count);
                if (numbers.Count == 0)
                   numbers = null;
                return numbers;
        }
        void SortGivenNumbers()
        {
            List<int> myNumbers = TakeNumbersFromUser();
            try
            {
                if (myNumbers != null)

                {
                    myNumbers.Sort();
                    PrintTheCollection(myNumbers);
                }
                else
                {
                    Console.WriteLine("the collection is empty");
                }
            }
            catch (NullReferenceException nrException)
            {
                Console.WriteLine("there are numbers to be sorted");
            }
            catch(Exception e)
            {
                Console.WriteLine("Cannot sort .Sorry");
            }
        }
        private void PrintTheCollection(List<int> myNumbers)
        {
            if (myNumbers.Count > 0)
            {
                foreach (var item in myNumbers)
                {
                    Console.WriteLine(item);
                }
            }
            else
                Console.WriteLine("nothing to print");
        }

        //static void Main(string[] args)
        //{
        //    new Program().SortGivenNumbers();
        //    // Console.WriteLine("Hello World!");
        //    Console.ReadKey();
        //}
    }
}

