using System.Threading;
using System.Threading.Tasks;
using AsyncProgramming.Services;
using NUnit.Framework;

namespace AsyncProgrammingTest
{
	[TestFixture]
	public class MainServiceTests
	{
		private MainService _mainService;

		[SetUp]
		public void Setup()
		{
			_mainService = new MainService();
		}

		[Test]
		public async Task HotTasksAreCompleted()
		{
			var cancellationTokenSource = new CancellationTokenSource();
			var task1 = _mainService.Task1(cancellationTokenSource);
			var task2 = _mainService.Task2(cancellationTokenSource);
			var task3 = _mainService.Task3(cancellationTokenSource);

			await Task.WhenAll(task1, task2, task3);

			Assert.That(task1.IsCompleted);
			Assert.That(task2.IsCompleted);
			Assert.That(task3.IsCompleted);
		}

		[Test]
		public async Task HotTasksAreInterrupted()
		{
			var cancellationTokenSource = new CancellationTokenSource();
			var task1 = _mainService.Task1(cancellationTokenSource);
			var task2 = _mainService.Task2(cancellationTokenSource);
			var task3 = _mainService.Task3(cancellationTokenSource);
			cancellationTokenSource.CancelAfter(3000);

			await Task.WhenAll(task1, task2, task3).ContinueWith(t =>
			 {
				 Assert.That(t.IsCompleted);
				 Assert.That(t.IsCanceled);
			 });
		}

		[Test]
		public void TaskWaitIsCompleted()
		{
			var cancellationTokenSource = new CancellationTokenSource();
			var task1 = _mainService.TaskWait(cancellationTokenSource);
			var result = task1.Result;

			Assert.That(task1.IsCompleted);
			Assert.That(result);
		}

		[Test]
		public async Task TaskCompletitionSourceAreCompleted()
		{
			var cancellationTokenSource = new CancellationTokenSource();
			var task1 = _mainService.TaskCompletitionSource1(cancellationTokenSource);
			var task2 = _mainService.TaskCompletitionSource2(cancellationTokenSource);
			var task3 = _mainService.TaskCompletitionSource3(cancellationTokenSource);

			await Task.WhenAll(task1, task2, task3);

			Assert.That(task1.IsCompleted);
			Assert.That(task2.IsCompleted);
			Assert.That(task3.IsCompleted);
		}
	}
}
