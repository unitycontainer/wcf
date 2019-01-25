namespace Unity.Wcf.Tests.TestObjects
{
    public class TestService : ITestService
    {
        public string GetData(int value) => $"Data:{value}";
    }
}
