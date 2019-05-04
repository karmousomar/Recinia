using Recinia.Models.Interface;
using System;

namespace Recinia.Models.csharp
{
    public class MyInterface : IInterface
    {
        private double amount;
        private string value;
        public MyInterface(double amount,string value)
        {
            this.amount = 10.20;
            this.value = "My first app";
        }
        public double GetValue()
        {
            throw new System.NotImplementedException();
        }

        public void ShowValue()
        {
            Console.WriteLine($"My value is :{value}");

        }
    }
    public class MyInterface2 : IInterface
    {
        public double GetValue()
        {
            throw new NotImplementedException();
        }

        public void ShowValue()
        {
            throw new NotImplementedException();
        }
    }
}
