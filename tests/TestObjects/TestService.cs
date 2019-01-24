using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Wcf.Tests.TestObjects
{
    public class TestService : ITestService
    {
        public string GetData(int value)
        {
            throw new NotImplementedException();
        }
    }
}
