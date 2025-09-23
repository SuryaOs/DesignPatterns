using System.Collections.Concurrent;

namespace Concurrency;

/*
    safely shares work between the threads.
    one or more threads produce data and others consume it ensuring
        1) no data is lost
        2) no race conditions
        3) efficient thread usage
    keys:
        1) producer - generates data or tasks
        2) consumer - processes data or tasks
        3) queue - shared data structure
        4) inbuilt tools - BlockingCollection, Semaphore, Monitor
*/
/*
    In Modern .NET
    use async await -> let's the framework free the thread during I/O (db or http calls)
    use semaphoreslim for concurrency control
*/
/*
    Use blocking collection when writing 
        *multithreaded synchronous code
        *implementing low-level producer-consumer in console apps
        *okay with blocking threads
    Channel<T> is alternative for modern async friendly apps
    Semphore, await, task.whenALl
*/
public class ProducerConsumer
{
    private static BlockingCollection<int> _taskqueue = new();
    public static void Run()
    {
        Task Producer = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Producing {i}");
                _taskqueue.Add(i);
                Thread.Sleep(1000);
            }
            _taskqueue.CompleteAdding(); // signalling production is done
        });


        Task Consumer = Task.Run(() =>
        {
            foreach (var task in _taskqueue.GetConsumingEnumerable())
            {
                Console.WriteLine($"Consuming {task}");
                Thread.Sleep(1000);
            }
        });

        Task.WaitAll(Producer, Consumer);

        Console.WriteLine("All done");
    }
}