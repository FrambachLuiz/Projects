using Xunit;

namespace DemoCode.Tests.Demo.Collection_Testing
{
    [CollectionDefinition("MemoryCalculator Collection")]
    public class MemoryCalculatorCollection : ICollectionFixture<MemoryCalculatorFixture>
    {
    }
}
