using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Models.csharp
{
    public class FirstClass
    {
        private String Name;
        private String FamilyName;
        //properties
        public String val;
        
        public string namechange
        {
            get{ return Name; }
            set{ Name = val; }
        }
        public FirstClass(String Nom,String prénom)
        {
            Name= Nom;
            FamilyName = prénom;
        }
        public FirstClass()
        {

        }
        //return method
        public bool TrueFalse(int val)
        {
            if (val>5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //void methode
        public void NoReturen(String Value)
        {
            Console.WriteLine($"The value is :{Value}");
        }
    }
}
