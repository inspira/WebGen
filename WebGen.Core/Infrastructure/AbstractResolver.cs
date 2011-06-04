using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebGen.Core.Infrastructure
{
    public class AbstractResolver
    {
        public AbstractResolver For<T1>()
        {
            throw new NotImplementedException();
        }

        public void Use<T1>()
        {
            throw new NotImplementedException();
        }
    }
}
