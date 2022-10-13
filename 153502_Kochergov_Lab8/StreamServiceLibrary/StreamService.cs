//
// ReSharper disable ConvertToUsingDeclaration
// ReSharper disable MustUseReturnValue
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable InconsistentNaming
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace StreamServiceLibrary
{
	public class StreamService<T>
	{
		private const int progressBarsRefreshTimeout = 10;

		private Semaphore _semaphore = new(1, 1);

		private IProgress<double> _WTSProgress;
		private IProgress<double> _CFSProgress;
		private IProgress<double> _GSProgress;

		private ProgressBar _WTSProgressBar;
		private ProgressBar _CFSProgressBar;
		private ProgressBar _GSProgressBar;

		private void UpdateProgressBar(ProgressBar bar, double newProgress)
		{
			bar.Progress = newProgress;
			ConsoleWriter.SetLine(bar.LineIndex, bar.ToString());
		}

		public async Task WriteToStreamAsync(Stream stream, IEnumerable<T> data)
		{

			ConsoleWriter.AddLines(1);
			_WTSProgressBar = new(0, ConsoleWriter.LinesCount - 1);
			_WTSProgress = new Progress<double>((progress) => UpdateProgressBar(_WTSProgressBar, progress));

			var start = DateTime.Now.Millisecond;

			await Task.Run(_semaphore.WaitOne);
			int n = data.Count();
			double i = 1;
			double qweqweq = 1;
			foreach (var element in data)
			{
				for (int j = 0; j < 1e3; j++) //Delay
					qweqweq /= 1.0;			  //
				
				string serialized = JsonSerializer.Serialize(element);
				byte[] objBytes = Encoding.Default.GetBytes(serialized);
				byte[] lenBytes = BitConverter.GetBytes(objBytes.Length);
				await stream.WriteAsync(lenBytes, 0, lenBytes.Length);
				await stream.WriteAsync(objBytes, 0, objBytes.Length);

				//if (DateTime.Now.Millisecond -start < progressBarsRefreshTimeout)
				//	continue;
				
				double progress = i++ * 1.0 / n;
				_WTSProgress.Report(progress);
				start = DateTime.Now.Millisecond;
			}
			_WTSProgress.Report(1.0);

			_semaphore.Release();
		}

		public async Task CopyFromStreamAsync(Stream stream, string fileName)
		{
			ConsoleWriter.AddLines(1);
			_CFSProgressBar = new(0, ConsoleWriter.LinesCount - 1);
			_CFSProgress = new Progress<double>((progress) => UpdateProgressBar(_CFSProgressBar, progress));


			_CFSProgress.Report(0);
			await Task.Run(_semaphore.WaitOne);
			if (File.Exists(fileName)) File.Delete(fileName);
			stream.Position = 0;
			await using (var fileStream = File.Open(fileName, FileMode.Create, FileAccess.Write))
			{
				//Thread.Sleep(500);
				await stream.CopyToAsync(fileStream);
				_CFSProgress.Report(1.0);
			}
			_semaphore.Release();
		}

		public async Task<int> GetStatisticsAsync(string fileName, Func<T, bool> filter)
		{
			ConsoleWriter.AddLines(1);
			_GSProgressBar = new(0, ConsoleWriter.LinesCount - 1);
			_GSProgress = new Progress<double>((progress) => UpdateProgressBar(_GSProgressBar, progress));

			List<T> data = new();
			_GSProgress.Report(0.0);
			var start = DateTime.Now.Millisecond;

			await using (var fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read))
			{
				while (fileStream.Position != fileStream.Length)
				{
					byte[] lenBytes = new byte[sizeof(int)];
					await fileStream.ReadAsync(lenBytes, 0, lenBytes.Length);
					int len = BitConverter.ToInt32(lenBytes, 0);
					byte[] objBytes = new byte[len];
					await fileStream.ReadAsync(objBytes, 0, len);
					string serialized = objBytes.Aggregate("", (result, b) => result + (char)b);
					data.Add(JsonSerializer.Deserialize<T>(serialized));

					//if (DateTime.Now.Millisecond - start <= 10) 
					//	continue;

					_GSProgress.Report((fileStream.Position + 1.0) / fileStream.Length);
					start = DateTime.Now.Millisecond;
				}
				//ConsoleWriter.SetLine(0, counter.ToString());
			}
			_GSProgress.Report(1.0);
			return data.Aggregate(0, (result, element) => result + (filter(element) ? 1 : 0));
		}
	}
}
