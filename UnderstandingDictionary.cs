using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsProject
{
    class UnderstandingDictionary
    {
        Dictionary<int, string> d1 = new Dictionary<int, string>();
        Dictionary<int, Movies> d2 = new Dictionary<int, Movies>();
        void AddItemsToDictionary()
        {
            d1.Add(101, "Hari");
            d1.Add(102, "Haran");
            d2.Add(101, new Movies());
            //d2.Add(101, new Movie());//key cannot be duplicated and cannot eb null
            d2[101].Id = 101;
            d2[101].TakeMovieDetails();
        }
        void OtherMethods()
        {
            bool result = d1.ContainsKey(101);
            Console.WriteLine("Has 101 as key?? " + result);
            Console.WriteLine("Please enter a key to fetch value");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(d1[key]);
            Console.WriteLine("The count of the dictionary is " + d1.Count);
        }
        void PrintDataFromDisctionary()
        {
            foreach (var item in d1.Keys)
            {
                Console.WriteLine(item + " " + d1[item]);
            }
            Console.WriteLine("--------------------");
            foreach (var item in d2.Keys)
            {
                Console.WriteLine(item + " " + d2[item]);
            }
        }
        static void Main(string[] a)
        {
            UnderstandingDictionary ud = new UnderstandingDictionary();
            ud.AddItemsToDictionary();
            ud.PrintDataFromDisctionary();
            //ud.OtherMethods();
            Console.ReadKey();

        }
       }
}
