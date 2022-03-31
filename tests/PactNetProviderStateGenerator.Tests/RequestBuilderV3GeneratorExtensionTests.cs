using System.Net.Http;
using Moq;
using PactNet;
using PactNetProviderStateGenerator.Generators;
using Xunit;

namespace PactNetProviderStateGenerator.Tests;

public class RequestBuilderV3GeneratorExtensionTests
{
    private readonly Mock<IRequestBuilderV3> mockRequestBuilderV3;

    public RequestBuilderV3GeneratorExtensionTests()
    {
        this.mockRequestBuilderV3 = new Mock<IRequestBuilderV3>();
    }

    [Fact]
    public void WithRequest_WhenCalled_CallBaseWithJson()
    {
        var expected =
            "{\"pact:matcher:type\":\"type\",\"value\":\"/some/path\",\"pact:generator:type\":\"ProviderState\",\"expression\":\"/some/${path}\"}";
        this.mockRequestBuilderV3.Object.WithRequest(HttpMethod.Get,
            Generate.ProviderState("/some/path", "/some/${path}"));
        
        this.mockRequestBuilderV3.Verify(r=>r.WithRequest(HttpMethod.Get, expected));
    }

    [Fact]
    public void WithQuery_WhenCalled_CallBaseWithJson()
    {
        var expected =
            "{\"pact:matcher:type\":\"type\",\"value\":\"example\",\"pact:generator:type\":\"ProviderState\",\"expression\":\"${value}\"}";
        this.mockRequestBuilderV3.Object.WithQuery("key", Generate.ProviderState("example", "${value}"));
        
        this.mockRequestBuilderV3.Verify(r=>r.WithQuery("key", expected));
    }
}
