using FluentAssertions;
using PactNetProviderStateGenerator.Generators;
using Xunit;

namespace PactNetProviderStateGenerator.Tests.Generators;

public class GeneratorTests
{
    [Fact]
    public void ProviderState_WhenCalled_ReturnsGenerator()
    {
        const string example = "/ticket/WO1FN";
        const string expression = @"/ticket/${pnr}";

        var matcher = Generate.ProviderState(example, expression);

        matcher.Should().BeEquivalentTo(new ProviderStateGenerator(example, expression));
    }
}
