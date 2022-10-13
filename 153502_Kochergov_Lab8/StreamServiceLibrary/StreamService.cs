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
		private Semaphore _semaphore = new(1, 1);

		private IProgress<double> _WTSProgress;
		private IProgress<double> _CFSProgress;

		private ProgressBar _WTSProgressBar;
		private ProgressBar _CFSProgressBar;

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

			await Task.Run(_semaphore.WaitOne);
			int n = data.Count();
			double i = 1;
			double k = 12;
			foreach (var element in data)
			{
				for (int j = 0; j < 1e4; j++)
				{
					k /= 1.0;
				}
				string serialized = JsonSerializer.Serialize(element);
				byte[] objBytes = Encoding.Default.GetBytes(serialized);
				byte[] lenBytes = BitConverter.GetBytes(objBytes.Length);
				await stream.WriteAsync(lenBytes, 0, lenBytes.Length);
				await stream.WriteAsync(objBytes, 0, objBytes.Length);
				double q = i++ * 1.0 / n;
				if (q > 1.0)
					k /= 1.0;
				_WTSProgress.Report(q);
			}

			k /= 1;
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
			List<T> data = new();
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
				}
			}
			return data.Aggregate(0, (result, element) => result + (filter(element) ? 1 : 0));
		}
	}
}
