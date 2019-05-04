using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Services
{
    public interface IMyService
    {
        Guid MyGuid { get; set; }
    }
    public class MyService : IMyService
    {
        public Guid MyGuid { get ; set ; }
        public MyService()
        {
            this.MyGuid = Guid.NewGuid();
        }
    }
}
