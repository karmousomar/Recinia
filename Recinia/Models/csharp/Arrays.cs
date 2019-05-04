using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Models.csharp
{
    public class Arrays
    {
        // declare array
        String [] firstArray;
        //declare and initialize array
        String[] secondarray = new string[2];
        //declare and initialize array Inline
        String[] thirdarray = {"0","1","2","3"};
        public void MethodArrays()
        {
            firstArray[0] = "hi";
            firstArray[2] = "goodbye";
            secondarray[0] = "bye";
            secondarray[1] = "bye";
            secondarray[2] = "bye";
            foreach (var omar in thirdarray)
            {
                Console.WriteLine(omar);
            }
        }
    }
}
