using Newtonsoft.Json;
using PactNet;
using PactNetProviderStateGenerator.Generators;

namespace PactNetProviderStateGenerator;

public static class RequestBuilderV3GeneratorExtension
{
    public static IRequestBuilderV3 WithRequest(this IRequestBuilderV3 requestBuilderV3, HttpMethod method, IGenerator generator)
    { 
        var json = JsonConvert.SerializeObject(generator);
        return requestBuilderV3.WithRequest(method, json);
    }

    public static IRequestBuilderV3 WithQuery(this IRequestBuilderV3 requestBuilderV3,
        string key, IGenerator generator)
    {
        var json = JsonConvert.SerializeObject(generator);
        return requestBuilderV3.WithQuery(key, json);
    }
}
