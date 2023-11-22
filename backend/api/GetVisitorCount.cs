using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;


namespace Api.Function;
public class GetVisitorCount
{
    private readonly ILogger _logger;

    // public GetVisitorCount(ILoggerFactory loggerFactory)
    // {
    //     _logger = loggerFactory.CreateLogger<GetVisitorCount>();
    // }
    public GetVisitorCount(ILogger<GetVisitorCount> logger)
    {
        _logger = logger;
    }

    [Function("GetVisitorCount")]
    public async Task<UpdatedCounter> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
    [CosmosDBInput("AzureResume","Counter", Connection = "CosmosDbConnectionString", Id = "1",
            PartitionKey = "1")] Counter counter)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        response.Headers.Add("Access-Control-Allow-Origin", "*");
        string jsonString = JsonSerializer.Serialize(counter);
        await response.WriteStringAsync(jsonString);
        counter.Count += 1;
        return new UpdatedCounter()
        {
            NewCounter = counter,
            HttpResponse = response
        };
    }
}
