using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming.Services
{
	public class MainService
	{
		public Task<int> Task1(CancellationTokenSource cancellationTokenSource)
		{
			return Task.Run(async () =>
			{
				if (cancellationTokenSource == null)
					throw new ArgumentNullException(nameof(cancellationTokenSource));

				await Task.Delay(1000, cancellationTokenSource.Token);
				return Thread.CurrentThread.ManagedThreadId;
			});
		}

		public Task<int> Task2(CancellationTokenSource cancellationTokenSource)
		{
			return Task.Run(async () =>
			{
				if (cancellationTokenSource == null)
					throw new ArgumentNullException(nameof(cancellationTokenSource));

				await Task.Delay(2000, cancellationTokenSource.Token);
				return Thread.CurrentThread.ManagedThreadId;
			});
		}

		public Task<int> Task3(CancellationTokenSource cancellationTokenSource)
		{
			return Task.Run(async () =>
			{
				if (cancellationTokenSource == null)
					throw new ArgumentNullException(nameof(cancellationTokenSource));

				await Task.Delay(5000, cancellationTokenSource.Token);
				return Thread.CurrentThread.ManagedThreadId;
			});
		}

		public Task<int> TaskCompletitionSource1(CancellationTokenSource cancellationTokenSource)
		{
			var tcs = new TaskCompletionSource<int>();

			Task.Run(async () =>
			{
				var threadId = await Task1(cancellationTokenSource);
				tcs.SetResult(threadId);
			});

			return tcs.Task;
		}

		public Task<int> TaskCompletitionSource2(CancellationTokenSource cancellationTokenSource)
		{
			var tcs = new TaskCompletionSource<int>();

			Task.Run(async () =>
			{
				var threadId = await Task2(cancellationTokenSource);
				tcs.SetResult(threadId);
			});

			return tcs.Task;
		}

		public Task<int> TaskCompletitionSource3(CancellationTokenSource cancellationTokenSource)
		{
			var tcs = new TaskCompletionSource<int>();

			Task.Run(async () =>
			{
				var threadId = await Task3(cancellationTokenSource);
				tcs.SetResult(threadId);
			});

			return tcs.Task;
		}

		public Task<bool> TaskWait(CancellationTokenSource cancellationTokenSource)
		{
			return Task.Run(() =>
			{
				Task1(cancellationTokenSource).Wait();
				return true;
			});
		}
	}
}
