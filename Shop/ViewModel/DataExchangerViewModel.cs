﻿
using Azure.Messaging.ServiceBus;

namespace Shop.ViewModel;

public partial class DataExchangerViewModel : BaseViewModel, IAsyncDisposable
{
    [ObservableProperty]
    private string device;

    [ObservableProperty]
    public string message;
    // connection string to your Service Bus namespace
    static string connectionString = "Endpoint=sb://fedex-test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=UvGmw9duXvzNEVcNvhDFVZ5/vc9bWu3uMJSzDp9eZg4=";

    // name of your Service Bus queue
    // name of your Service Bus topic
    static string topicName = "mytopic";

    // the client that owns the connection and can be used to create senders and receivers
    static ServiceBusClient client;

    // name of the subscription to the topic
    static string subscriptionName = "mysubscription";

    // the processor that reads and processes messages from the subscription
    static ServiceBusProcessor processor;

    public DataExchangerViewModel()
    {
        RegisterDataListener();
    }

    private async void RegisterDataListener()
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
        }
        catch(Exception e)
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
