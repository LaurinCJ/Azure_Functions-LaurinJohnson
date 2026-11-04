namespace GameLibrary.Business;

public class CloudManager
{
    private readonly IHttpClientFactory httpClientFactory;

    public CloudManager(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    // TODO: Write one method per Azure function using the named
    // client httpClientFactory.CreateClient("AzureFunctions").
    // Keep the HttpClient calls in this business layer, not in the console.
    // See AZURE_SETUP.txt for the intended contracts.
}
