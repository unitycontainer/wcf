using System.ServiceModel;

namespace Unity.Wcf.Tests.TestObjects
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        string GetData(int value);
    }
}
