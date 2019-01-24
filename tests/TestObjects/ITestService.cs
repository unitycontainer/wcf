using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Wcf.Tests.TestObjects
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        string GetData(int value);
    }
}
