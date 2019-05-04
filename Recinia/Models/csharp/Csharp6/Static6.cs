using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace Recinia.Models.csharp.Csharp6
{
    public class Static6
    {

        public static void StaticMethod()
        {
            //csharp
            //Console.WriteLine("helle");
            //csharp6
            WriteLine("bonjouuur");
            //try { }
            //catch (Exception ex) { }
            //finally { }

        }
        public string FirstName { get; } = "Omar";
        public string LastName { get; } = "Karmous";
        public string FullName => FirstName + " " + LastName;
        //or it wass
        public string MyName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }



    }
}
