using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTimer
{
    class Program
    {
        static void Main(string[] args)
        {

            var test = new AsyncTimer();
            //test.OnPollEvent += Blah;
            test.Start();

            Console.ReadKey();

            Console.WriteLine("Cancelling...");

            test.Stop();

            Console.ReadKey();
        }

        public static async Task Blah(object sender, EventArgs args)
        {
            Console.WriteLine("Waiting for 5 secs.");
            await Task.Delay(5000);
            Console.WriteLine("Completed event handler.");
        }
    }
}
