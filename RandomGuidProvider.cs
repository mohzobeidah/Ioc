using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ioc
{
    public interface IRandomGuidProvider
    {
        Guid RandomGuid {get;}
    }
    public class RandomGuidProvider : IRandomGuidProvider
    {
        public Guid RandomGuid => Guid.NewGuid();
    }
}