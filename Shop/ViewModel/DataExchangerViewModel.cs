
using Azure.Messaging.ServiceBus;
using CommunityToolkit.Maui.Alerts;

namespace Shop.ViewModel;

public partial class DataExchangerViewModel : BaseViewModel//, IAsyncDisposable
{
    [ICommand]
    public void DisplaySheet()
        => Toast.Make("hello").Show();

    [ObservableProperty]
    private string device;

    [ObservableProperty]
    public string message;

    // connection string to your Service Bus namespace
    string connectionString = "Endpoint=sb://fedex-test.servicebus.windows.net/;SharedAccessKeyName=this-should-be-encrypted-on-device;SharedAccessKey=MDEezh1ANZ3f23PfTLiZH2f/ROH01hXCeW7tpAEx6iU=;EntityPath=new-products-topic";

    // name of the Service Bus topic
    string topicName = "new-products-topic";

    // name of the subscription to the topic
    string subscriptionName = "basictier";

    // the client that owns the connection and can be used to create senders and receivers
    ServiceBusClient client;

    // the processor that reads and processes messages from the subscription
    ServiceBusProcessor processor;

    public DataExchangerViewModel()
    {
        RegisterServiceBusEventhandler();
    }

    private async void RegisterServiceBusEventhandler()
    {
        // The Service Bus client types are safe to cache and use as a singleton for the lifetime
        // of the application, which is best practice when messages are being published or read
        // regularly.
        //
        // Create the clients that we'll use for sending and processing messages.
        client = new ServiceBusClient(connectionString);

        // create a processor that we can use to process the messages
        processor = client.CreateProcessor(topicName, subscriptionName, new ServiceBusProcessorOptions());

        try
        {
            // add handler to process messages
            processor.ProcessMessageAsync += MessageHandler;

            // add handler to process any errors
            processor.ProcessErrorAsync += ErrorHandler;

            // start processing 
            await processor.StartProcessingAsync();

         /*   Console.WriteLine("Wait for a minute and then press any key to end the processing");
            Console.ReadKey();

            // stop processing 
            Console.WriteLine("\nStopping the receiver...");
            await processor.StopProcessingAsync();
            Console.WriteLine("Stopped receiving messages");*/
        }
        finally
        {
            // Calling DisposeAsync on client types is required to ensure that network
            // resources and other unmanaged objects are properly cleaned up.
           // await processor.DisposeAsync();
           // await client.DisposeAsync();
        }
    }


    // handle received messages
    async Task MessageHandler(ProcessMessageEventArgs args)
    {
        string body = args.Message.Body.ToString();
        object token;
        args.Message.ApplicationProperties.TryGetValue("token", out token);


        Console.WriteLine($"Received: {body} from subscription: {subscriptionName}");

        if((string)token == "deviceone")
            Message = body;

        // complete the message. messages is deleted from the subscription. 
        await args.CompleteMessageAsync(args.Message);
    }

    // handle any errors when receiving messages
    Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Message = args.Exception.ToString();
        Console.WriteLine(args.Exception.ToString());
        return Task.CompletedTask;
    }

  
}