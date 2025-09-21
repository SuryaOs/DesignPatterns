using System.Collections.Concurrent;

namespace Concurrency.ThreadPool;

/*

TL;DR:
    1) what - pool of reusable threads
    2) why - avoids thread creation overhead
    3) C# - threadpool, task.run, parallel.foreach
    4) use case - background jobs, servers, queues

1) What is thread pool?
Threadpool maintains pool(collection) of
    pre-created, reusable threads
that can execute tasks concurrently without worrying about constantly creating and destorying threads

tldr: when you run a task, instead of creating new thread, re-use thread from threadpool

2) Why use thread pool?
    *Thread reuse - less overhead from thread creation
    *Controlled Concurrency - avoids memory or cpu overload
    *Scalable - efficient for high-volume task systems
    *Common In .NET - built in ThreadPool and Tasks API.

3) In .NET Environment
    Task.Run() => uses threadpool from System.Threading.ThreadPool

4) use case in LLD
    * background job workers
    * email or notification senders
    * thumbnail processing
*/
public class SimpleThreadPool
{
    // Thread-safe, blocking queue holding action delegates (tasks to run)
    private BlockingCollection<Action> _taskQueue;

    // Fixed-size array of threads
    private readonly Thread[] _workers;

    public SimpleThreadPool(int numberOfThreads)
    {
        _taskQueue = new();
        _workers = new Thread[numberOfThreads];
        for (int i = 0; i < numberOfThreads; i++)
        {
            // each worker thread pulls task from the queue and runs them
            // isBackground = true -> app can exit even if threads are running
            _workers[i] = new Thread(Work) { IsBackground = true };
            _workers[i].Start();
        }
    }

    // worker thread loops forever waiting for tasks.
    private void Work()
    {
        // blocks when queue is empty and resumes when task is added
        // the loop stops when queue is marked as CompleteAdding() .. line no : 86
        foreach (var task in _taskQueue.GetConsumingEnumerable())
        {
            try
            {
                task();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Task failed: {ex.Message}");
            }
        }
    }

    public void Submit(Action task)
    {
        // checks is completeadding() is not called to prevent adding after shutdown
        if (!_taskQueue.IsAddingCompleted)
        {
            _taskQueue.Add(task);
        }
    }

    public void Shutdown()
    {
        // tells the queue: we're done adding tasks
        // causes all workers to finish their current tasks and exit their loops
        _taskQueue.CompleteAdding();
        foreach (var thread in _workers)
        {
            // waits for each thread to finish before continuing
            thread.Join();
        }
    }
}

public class ThreadPoolFacade
{
    public static void Run()
    {
        var pool = new SimpleThreadPool(3);
        for (int i = 1; i <= 10; i++)
        {
            // i is one shared variable in memory.heap
            // so creatiing a local copy gives each lambda independent value
            int tasks = i;
            pool.Submit(() =>
            {
                Console.WriteLine(
                    $"Task {tasks} started on Thread {Thread.CurrentThread.ManagedThreadId}"
                );
                Thread.Sleep(1000);
                Console.WriteLine($"Task {tasks} finished");
            });
        }
        pool.Shutdown();
        Console.WriteLine("All tasks completed. Pool shut down");
    }
}
