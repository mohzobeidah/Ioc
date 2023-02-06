using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ioc
{
    public class DoSometing : IDoSomwthing
    {
       private readonly IRandomGuidProvider _IRandomGuidProvider  ;

       public DoSometing(IRandomGuidProvider IRandomGuidProvider )
       {
           _IRandomGuidProvider =IRandomGuidProvider;
       }
        void IDoSomwthing.PrintGuid()
        {
            Console.WriteLine(_IRandomGuidProvider.RandomGuid);
        }
    }
}