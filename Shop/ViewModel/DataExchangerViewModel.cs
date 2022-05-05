
using Azure.Messaging.ServiceBus;

namespace Shop.ViewModel;

public partial class DataExchangerViewModel : BaseViewModel, IAsyncDisposable
{

    [ObservableProperty]
    public string message;
    // connection string to your Service Bus namespace
    static string connectionString = "Endpoint=sb://mobileshop.servicebus.windows.net/;SharedAccessKeyName=someKey;SharedAccessKey=li7j4whIdrbMH6uedrC5XFeJukgeh8VaTUGOYmbeVik=";

    // name of your Service Bus queue
    static string queueName = "somequeue";

    // the client that owns the connection and can be used to create senders and receivers
    static ServiceBusClient client;

    // the processor that reads and processes messages from the queue
    static ServiceBusProcessor processor;

    public DataExchangerViewModel()
    {
        RegisterDataListener();
    }

    private async void RegisterDataListener()
    {
        // Create the client object that will be used to create sender and receiver objects
        client = new ServiceBusClient(connectionString);

        // create a processor that we can use to process the messages
        processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

        try
        {
            // add handler to process messages
            processor.ProcessMessageAsync += MessageHandler;

            // add handler to process any errors
            processor.ProcessErrorAsync += ErrorHandler;

            // start processing 
            await processor.StartProcessingAsync();


        }
        catch (Exception e)
        {
            Message = e.Message;
        }
    }
    async Task MessageHandler(ProcessMessageEventArgs args)
    {
        string body = args.Message.Body.ToString();
        Console.WriteLine($"Received: {body}");

        Message = body;


        // complete the message. messages is deleted from the queue. 
        await args.CompleteMessageAsync(args.Message);
    }

    Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Message = (args.Exception.ToString());
        return Task.CompletedTask;
    }

public async ValueTask DisposeAsync()
    {
        // stop processing 
        Console.WriteLine("\nStopping the receiver...");
        await processor.StopProcessingAsync();
        Console.WriteLine("Stopped receiving messages");

        // Calling DisposeAsync on client types is required to ensure that network
        // resources and other unmanaged objects are properly cleaned up.
        await processor.DisposeAsync();
        await client.DisposeAsync();
    }
}
