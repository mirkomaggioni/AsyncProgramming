using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming.Services
{
	public class MainService
	{
		public Task HotTask1(CancellationTokenSource cancellationTokenSource)
		{
			return Task.Run(async () =>
			{
				if (cancellationTokenSource == null)
					throw new ArgumentNullException(nameof(cancellationTokenSource));

				await Task.Delay(1000, cancellationTokenSource.Token);
			});
		}

		public Task HotTask2(CancellationTokenSource cancellationTokenSource)
		{
			return Task.Run(async () =>
			{
				if (cancellationTokenSource == null)
					throw new ArgumentNullException(nameof(cancellationTokenSource));

				await Task.Delay(2000, cancellationTokenSource.Token);
			});
		}

		public Task HotTask3(CancellationTokenSource cancellationTokenSource)
		{
			return Task.Run(async () =>
			{
				if (cancellationTokenSource == null)
					throw new ArgumentNullException(nameof(cancellationTokenSource));

				await Task.Delay(5000, cancellationTokenSource.Token);
			});
		}

		public Task TaskCompletitionSource1(CancellationTokenSource cancellationTokenSource)
		{
			var tcs = new TaskCompletionSource<bool>();

			Task.Run(async () =>
			{
				if (cancellationTokenSource == null)
					throw new ArgumentNullException(nameof(cancellationTokenSource));

				await Task.Delay(1000, cancellationTokenSource.Token);
				tcs.SetResult(true);
			});

			return tcs.Task;
		}

		public Task TaskCompletitionSource2(CancellationTokenSource cancellationTokenSource)
		{
			var tcs = new TaskCompletionSource<bool>();

			Task.Run(async () =>
			{
				if (cancellationTokenSource == null)
					throw new ArgumentNullException(nameof(cancellationTokenSource));

				await Task.Delay(2000, cancellationTokenSource.Token);
				tcs.SetResult(true);
			});

			return tcs.Task;
		}

		public Task TaskCompletitionSource3(CancellationTokenSource cancellationTokenSource)
		{
			var tcs = new TaskCompletionSource<bool>();

			Task.Run(async () =>
			{
				if (cancellationTokenSource == null)
					throw new ArgumentNullException(nameof(cancellationTokenSource));

				await Task.Delay(5000, cancellationTokenSource.Token);
				tcs.SetResult(true);
			});

			return tcs.Task;
		}

		public Task<bool> TaskWait(CancellationTokenSource cancellationTokenSource)
		{
			return Task.Run(() =>
			{
				if (cancellationTokenSource == null)
					throw new ArgumentNullException(nameof(cancellationTokenSource));

				Task.Delay(1000, cancellationTokenSource.Token).Wait();
				return true;
			});
		}
	}
}
