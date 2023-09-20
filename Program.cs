using Azure.Core;
using Azure.Identity;
using Azure.Monitor.Ingestion;

string? endpoint = Environment.GetEnvironmentVariable("DEMO_DCE_URI");
if (string.IsNullOrEmpty(endpoint))
{
    Console.WriteLine("Initialize 'DEMO_DCE_URI' environment variable");
    return;
}
var endpointUri = new Uri(endpoint);

// This requires env vars: AZURE_TENANT_ID, AZURE_CLIENT_ID, AZURE_CLIENT_SECRET
// See: https://learn.microsoft.com/en-us/dotnet/api/azure.identity.environmentcredential?view=azure-dotnet
var credential = new EnvironmentCredential();

var client = new LogsIngestionClient(endpointUri, credential);

string? ruleId = Environment.GetEnvironmentVariable("DEMO_DCR_ID");
if (string.IsNullOrEmpty(ruleId))
{
    Console.WriteLine("Initialize 'DEMO_DCR_ID' environment variable");
    return;
}

string? streamName = Environment.GetEnvironmentVariable("DEMO_STREAM_NAME");
if (string.IsNullOrEmpty(streamName))
{
    Console.WriteLine("Initialize 'DEMO_STREAM_NAME' environment variable");
    return;
}

var data = BinaryData.FromObjectAsJson(
    new[]
    {
        new
        {
            TimeGenerated = DateTimeOffset.UtcNow,
            MyIntField = 12345,
            MyStringField = "Hello World, custom log!"
        }
    });

var response = await client.UploadAsync(
    ruleId,
    streamName,
    RequestContent.Create(data));

Console.WriteLine($"Logs sent, response status code: {response.Status}");