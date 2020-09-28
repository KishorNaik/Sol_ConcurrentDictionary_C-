using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Sol_Demo
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ConcurrentDictionary<int, String> keyValuePairs = new ConcurrentDictionary<int, string>();

            keyValuePairs.GetOrAdd(1, (value1) => "Kishor");
            keyValuePairs.GetOrAdd(2, (value2) => "Mahesh");
            keyValuePairs.GetOrAdd(3, (value3) => "Eshaan");

            foreach (var keyValue in keyValuePairs)
            {
                Console.WriteLine($"Key :{keyValue.Key} | Value:{keyValue.Value}");
            }

            // Using Task : Note : Concurrent Dictionary class in thread safe.
            ConcurrentDictionary<int, String> keyValuePairsTask = new ConcurrentDictionary<int, String>();
            Task task1 = Task.Run(() =>
            {
                keyValuePairsTask.TryAdd(1, "Kishor");
                Task.Delay(500);
            });

            Task task2 = Task.Run(() =>
            {
                keyValuePairsTask.TryAdd(2, "Mahesh");
                Task.Delay(300);
            });

            Task task3 = Task.Run(() =>
            {
                keyValuePairsTask.TryAdd(3, "Eshaan");
                Task.Delay(400);
            });

            await Task.WhenAll(task1, task2, task3);

            foreach (var keyValue in keyValuePairsTask)
            {
                Console.WriteLine($"Key :{keyValue.Key} | Value:{keyValue.Value}");
            }
        }
    }
}