using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTimer
{
    public class AsyncTimer
    {
        public Func<object, EventArgs, Task> OnPollEvent;

        private CancellationTokenSource cancellation = new CancellationTokenSource();

        public AsyncTimer() {

        }

        public void Start()
        {
            Task.Run(() => RepeatActionEvery(TimeSpan.FromSeconds(1), cancellation.Token));
        }

        public void Stop()
        {
            cancellation.Cancel();
        }

        public async Task RepeatActionEvery(TimeSpan interval, CancellationToken cancellationToken)
        {
            while (true)
            {
                
                try
                {
                    Console.WriteLine("Repeat action every.");

                    if (OnPollEvent != null)
                    {
                        await OnPollEvent?.Invoke(this, EventArgs.Empty);
                    }
                    
                    //await Task.Run(() => OnPollEvent(this, EventArgs.Empty));

                    Console.WriteLine("Waiting for 1 seconds..");
                    await Task.Delay(interval, cancellationToken);
                    Console.WriteLine("Finished waiting, running again.");

                }
                catch (TaskCanceledException)
                {
                    Console.WriteLine("Cancelling the current tracker.");
                    return;
                }
                
            }
        }
    }
}
