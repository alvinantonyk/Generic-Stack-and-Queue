using Generic_Task;

GenericQueue<ChatMessage> GQueue = new GenericQueue<ChatMessage>(10);
GenericStack<int> GStack = new GenericStack<int>(10);

int messageId = 0;

try
{
    while (true)
    {
        Console.WriteLine("Main Menu");
        Console.WriteLine("1. Stack");
        Console.WriteLine("2. Queue");
        Console.WriteLine("3. Exit");
        Console.Write("Input: ");

        var choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                HandleStackMenu();
                break;
            case 2:
                HandleQueueMenu();
                break;
            case 3:
                return;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

void HandleStackMenu()
{
    Console.WriteLine("Stack");
    Console.WriteLine("1. Push");
    Console.WriteLine("2. Pop");
    Console.WriteLine("3. Peek");
    Console.WriteLine("4. Check if Empty");
    Console.WriteLine("5. Return to Main Menu");
    Console.Write("Input: ");

    var input = Convert.ToInt32(Console.ReadLine());

    switch (input)
    {
        case 1:
            Console.WriteLine("Enter an integer");
            var number = 0;

            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Incorrect Input");
                break;
            }

            GStack.Push(number);
            break;

        case 2:
            var popped = GStack.Pop();
            Console.WriteLine($"{popped} popped from the stack.");
            break;
        case 3:
            var peeked = GStack.Peek();
            Console.WriteLine($"{peeked} is on top of the stack.");
            break;
        case 4:
            Console.WriteLine(GStack.IsEmpty());
            break;
        case 5:
            return;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}

void HandleQueueMenu()
{
    Console.WriteLine("Queue Operations:");
    Console.WriteLine("1. Enqueue");
    Console.WriteLine("2. Dequeue");
    Console.WriteLine("3. Check if Empty");
    Console.WriteLine("4. Check if Full");
    Console.WriteLine("5. Return to Main Menu");
    Console.Write("Input: ");

    var input = Convert.ToInt32(Console.ReadLine());

    switch (input)
    {
        case 1:
            Console.WriteLine("Enter message");
            string content = Console.ReadLine();
            GQueue.Enqueue(new ChatMessage
            {
                MessageId = ++messageId,
                Content = content,
                TimeStamp = DateTime.Now,
                SourceId = messageId
            });
            Console.WriteLine("ChatMessage enqueued.");
            break;
        case 2:
            ChatMessage dequeuedMessage = GQueue.Dequeue();
            if (dequeuedMessage == null)
            {
                Console.WriteLine("No message in queue");
                break;
            }
            Console.WriteLine($"Dequeued message: ID {dequeuedMessage.MessageId}, Content: {dequeuedMessage.Content}, TimeStamp: {dequeuedMessage.TimeStamp}, SourceId: {dequeuedMessage.SourceId}");
            break;
        case 3:
            Console.WriteLine(GQueue.IsEmpty());
            break;
        case 4:
            Console.WriteLine(GQueue.IsFull());
            break;
        case 5:
            return;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}