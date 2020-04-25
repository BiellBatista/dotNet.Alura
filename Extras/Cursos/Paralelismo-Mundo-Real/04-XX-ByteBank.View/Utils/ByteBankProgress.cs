using System;
using System.Threading;
using System.Threading.Tasks;

namespace _04_XX_ByteBank.View.Utils
{
    public class ByteBankProgress<T> : IProgress<T>
    {
        private readonly Action<T> _handler;
        private readonly TaskScheduler _taskSchedulerGui;

	// handler significa manipulador
        public ByteBankProgress(Action<T> handler)
        {
            _taskSchedulerGui = TaskScheduler.FromCurrentSynchronizationContext();
            _handler = handler;
        }

        public void Report(T value)
        {
            Task.Factory.StartNew(
                () => _handler(value),
                CancellationToken.None,
                TaskCreationOptions.None,
                _taskSchedulerGui
                );
        }
    }
}
