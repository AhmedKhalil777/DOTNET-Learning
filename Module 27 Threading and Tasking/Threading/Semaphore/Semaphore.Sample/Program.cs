// See https://aka.ms/new-console-template for more information
//Theads to be controlled

using Semaphore.Sample;

var threadManager = new ThreadsManager(3, 3);

for (int i = 0; i < 30; i++)
{
   new Thread(() => threadManager.Start(Process)).Start();
}

static void Process(System.Threading.Semaphore semaphore)
{
    Console.WriteLine("Waiting");
    semaphore.WaitOne();
    Console.WriteLine("I am Processing some code");
    Thread.Sleep(1000);
    Console.WriteLine("Releasing...............");
    semaphore.Release();
}



