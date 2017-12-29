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

			textBox1.Text = Thread.CurrentThread.ManagedThreadId.ToString();
			textBox2.Text = (await task1).ToString();
			textBox3.Text = (await task2).ToString();
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

		private void button2_Click(object sender, EventArgs e)
		{
			var cancellationTokenSource = new CancellationTokenSource();
			var task1 = _mainService.TaskWait(cancellationTokenSource);
			var result = task1.Result;
			MessageBox.Show(@"End!");
		}
	}
}
