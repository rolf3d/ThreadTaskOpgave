using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
    public static void Main()
    {
        Thread.CurrentThread.Name = "Main";

        // Create a task and supply a user delegate by using a lambda expression. 
        Task taskA = new Task(() => DoTaskA());
        // Start the task.
        taskA.Start();

        // Output a message from the calling thread.
        Console.WriteLine("Hello from thread '{0}'.",
                          Thread.CurrentThread.Name);


        //wait for the task (taskA to finish)
        taskA.Wait();

    }
    /// <summary>
    /// metode til at teste ContinueWith() med
    /// </summary>
    /// <param name="task"></param>
    private static void DoMoreTask(Task task)
    {
        DoTaskB();
    }

    private static void DoTaskA()
    {
        for (int i = 0; i < 50; i++)
        {
            udskriv("AAA", i);
        }
    }

    private static void DoTaskB()
    {
        for (int i = 0; i < 50; i++)
        {

            udskriv("BBB", i);
        }
    }

    private static void DoTaskC()
    {
        for (int i = 0; i < 50; i++)
        {
            udskriv("CCC", i);
        }
    }

    /// <summary>
    /// udskriver teksten for den pågældende metode samt hvilket nr i for loopet 
    /// udskriver trådens id  Thread.CurrentThread.ManagedThreadId)
    /// </summary>
    /// <param name="taskName"></param>
    /// <param name="i"></param>
    private static void udskriv(string taskName, int i)
    {
        Console.WriteLine($"Task {taskName} i:{i} Thread:" + Thread.CurrentThread.ManagedThreadId);
    }

}
