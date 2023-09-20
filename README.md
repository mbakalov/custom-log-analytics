# Custom Log Analytics

Sample for creating a custom table in Azure Monitor Log Analytics and programmatically populating it with data.

1. Follow the [Send data to Azure Monitor Logs with Logs ingestion API (Azure portal)](https://learn.microsoft.com/en-us/azure/azure-monitor/logs/tutorial-logs-ingestion-portal) tutorial to create:

    1. AAD application

    1. Data Collection Endpoint (DCE)

    1. Custom table in your Log Analytics Workspace

    1. Data Collection Rule (DCR)

    1. Give AAD app access to the DCR (AAD app seems to be required, it didn't work for me when I tried using regular user account with e.g. `AzureCliCredential`)

1. Then use the sample console app in the this repo to send data:

    1. Initialize environment variables:

        1. `AZURE_TENANT_ID` - from your AAD app

        1. `AZURE_CLIENT_ID` - from your AAD app

        1. `AZURE_CLIENT_SECRET` - from your AAD app

        1. `DEMO_DCE_URI` - from the tutorial

        1. `DEMO_DCR_ID` - from the tutorial

        1. `DEMO_STREAM_NAME` - from the tutorial
    
    1. `dotnet run` to send test log entry

    1. Wait a few minutes until logs are fully ingested in Azure Monitor