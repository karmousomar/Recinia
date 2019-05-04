using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Models.csharp
{
    public class AccessModifiers
    {
        //public modifiers
        public String PublicString { get; set; }
        public void PublicMethod()
        {

        }
        //private modifier not allowed in maincontroller
        private String PrivateString { get; set; }
        public void PrivateMethod(){}
        // protected modifier
        protected String ProtectedString { get; set; }
        protected void ProtectedMethod() { }
    }
    public class Access:AccessModifiers
    {
        public Access()
        {
            PrivateMethod();
            ProtectedString = "hello";
            ProtectedMethod();
        }
        
    }
}
