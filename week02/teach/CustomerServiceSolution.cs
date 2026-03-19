/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerServiceSolution {
    public static void Run() {
        // Test Cases

        // Test 1: Default max size when invalid value provided
        Console.WriteLine("Test 1: Default max size");
        var service = new CustomerServiceSolution(0);
        Console.WriteLine($"Max size should be 10: {service.GetMaxSize()}");
        Console.WriteLine("Expected: 10");
        Console.WriteLine("=================");

        // Test 2: Add customers and serve them
        Console.WriteLine("Test 2: Add and serve customers");
        service = new CustomerServiceSolution(3);
        service.AddNewCustomer("Alice", "A123", "Login issue");
        service.AddNewCustomer("Bob", "B456", "Payment problem");
        Console.WriteLine($"Queue after adding: {service}");
        service.ServeCustomer(); // Should display Alice
        service.ServeCustomer(); // Should display Bob
        Console.WriteLine($"Queue after serving: {service}");
        Console.WriteLine("=================");

        // Test 3: Serve from empty queue
        Console.WriteLine("Test 3: Serve from empty queue");
        service = new CustomerServiceSolution(3);
        service.ServeCustomer(); // Should display error
        Console.WriteLine("=================");

        // Test 4: Add to full queue
        Console.WriteLine("Test 4: Add to full queue");
        service = new CustomerServiceSolution(2);
        service.AddNewCustomer("Charlie", "C789", "Refund");
        service.AddNewCustomer("David", "D012", "Update info");
        service.AddNewCustomer("Eve", "E345", "New account"); // Should display error
        Console.WriteLine($"Queue: {service}");
        Console.WriteLine("=================");

        // Test 5: Valid max size
        Console.WriteLine("Test 5: Valid max size");
        service = new CustomerServiceSolution(5);
        Console.WriteLine($"Max size: {service.GetMaxSize()}");
        Console.WriteLine("Expected: 5");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerServiceSolution(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    public int GetMaxSize() {
        return _maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId}): {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Add a new customer with provided details to the queue.
    /// </summary>
    /// <param name="name">Customer name</param>
    /// <param name="accountId">Account ID</param>
    /// <param name="problem">Problem description</param>
    private void AddNewCustomer(string name, string accountId, string problem) {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        // Need to check if there are customers in our queue
        if (_queue.Count <= 0) // Defect 2 - Need to check queue length
        {
            Console.WriteLine("No Customers in the queue");
        }
        else {
            // Need to read and save the customer before it is deleted from the queue
            var customer = _queue[0];
            _queue.RemoveAt(0); // Defect 1 - Delete should be done after
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}