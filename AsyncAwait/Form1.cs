using AsyncProgramming.Services;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncProgramming
{
	public partial class Form1 : Form
	{
		private MainService _mainService;

		public Form1()
		{
			_mainService = new MainService();
			InitializeComponent();
		}

		private async void button3_Click(object sender, EventArgs e)
		{
			var cancellationTokenSource = new CancellationTokenSource();
			var task1 = _mainService.Task1(cancellationTokenSource);
			var task2 = _mainService.Task2(cancellationTokenSource);
			var task3 = _mainService.Task3(cancellationTokenSource);
			await Task4(cancellationTokenSource);

			textBox1.Text = Thread.CurrentThread.ManagedThreadId.ToString();
			textBox2.Text = (await task1).ToString();
			textBox3.Text = (await task2).ToString();
			textBox4.Text = (await task3).ToString();
			textBox4.Text = (await task3).ToString();

			MessageBox.Show(@"End!");
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			var cancellationTokenSource = new CancellationTokenSource();
			var task1 = _mainService.TaskCompletitionSource1(cancellationTokenSource);
			var task2 = _mainService.TaskCompletitionSource2(cancellationTokenSource);
			var task3 = _mainService.TaskCompletitionSource3(cancellationTokenSource);

			textBox1.Text = Thread.CurrentThread.ManagedThreadId.ToString();
			textBox2.Text = (await task1).ToString();
			textBox3.Text = (await task2).ToString();
			textBox4.Text = (await task3).ToString();

			MessageBox.Show(@"End!");
		}

		private async Task Task4(CancellationTokenSource cancellationTokenSource)
		{
			string threadId1 = "", threadId2 = "", threadId3 = "";

			await Task.Run(async () =>
			{
				if (cancellationTokenSource == null)
					throw new ArgumentNullException(nameof(cancellationTokenSource));

				threadId1 = Thread.CurrentThread.ManagedThreadId.ToString();
				await Task.Yield();
				threadId2 = Thread.CurrentThread.ManagedThreadId.ToString();
				await Task.Delay(1000, cancellationTokenSource.Token);
				threadId3 = Thread.CurrentThread.ManagedThreadId.ToString();
			});

			textBox5.Text = threadId1;
			textBox6.Text = threadId2;
			textBox7.Text = threadId3;
		}
	}
}
