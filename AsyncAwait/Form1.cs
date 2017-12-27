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
			var task1 = _mainService.HotTask1(cancellationTokenSource);
			var task2 = _mainService.HotTask2(cancellationTokenSource);
			var task3 = _mainService.HotTask3(cancellationTokenSource);

			await Task.WhenAll(task1, task2, task3);
			MessageBox.Show(@"End!");
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			var cancellationTokenSource = new CancellationTokenSource();
			var task1 = _mainService.TaskCompletitionSource1(cancellationTokenSource);
			var task2 = _mainService.TaskCompletitionSource2(cancellationTokenSource);
			var task3 = _mainService.TaskCompletitionSource3(cancellationTokenSource);

			await Task.WhenAll(task1, task2, task3);
			MessageBox.Show(@"End!");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var cancellationTokenSource = new CancellationTokenSource();
			var task1 = _mainService.TaskWait(cancellationTokenSource);
			var result = task1.Result;
			MessageBox.Show(@"End!");
		}
	}
}
