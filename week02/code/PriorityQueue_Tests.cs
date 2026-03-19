using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue 3 items with priorities 1,5,10 and dequeue all.
    // Expected Result: Dequeue returns high-priority first (10), then 5, then 1.
    // Defect(s) Found: On initial code, Dequeue did not remove element and skipped last index in loop.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("medium", 5);
        priorityQueue.Enqueue("high", 10);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("medium", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple values with equal highest priority, then dequeue with empty queue check.
    // Expected Result: Among ties, the first enqueued highest-priority item is dequeued first (FIFO), and empty queue throws InvalidOperationException with proper message.
    // Defect(s) Found: On initial code, Dequeue used ">=" and selected later same-priority item; also did not throw on empty by returning nothing.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("first", 3);
        priorityQueue.Enqueue("second", 3);
        priorityQueue.Enqueue("highest", 5);
        priorityQueue.Enqueue("third", 3);

        Assert.AreEqual("highest", priorityQueue.Dequeue());
        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("third", priorityQueue.Dequeue());

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException when dequeuing from empty queue.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    // Add more test cases as needed below.
}