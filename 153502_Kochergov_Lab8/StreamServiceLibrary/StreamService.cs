//
// ReSharper disable ConvertToUsingDeclaration
// ReSharper disable MustUseReturnValue
using System;
using System.Collections.Generic;
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
		private static Mutex mutex = new();

		public async Task WriteToStreamAsync(Stream stream, IEnumerable<T> data) // записывает коллекцию data в поток stream
		{
			await Task.Run(mutex.WaitOne);
			foreach (var element in data)
			{
				string serialized = JsonSerializer.Serialize(element);
				byte[] objBytes = Encoding.Default.GetBytes(serialized);
				byte[] lenBytes = BitConverter.GetBytes(objBytes.Length);
				await stream.WriteAsync(lenBytes);
				Console.WriteLine("qwe");
				await stream.WriteAsync(objBytes, 0, objBytes.Length);
			}
			mutex.ReleaseMutex();
			//await stream.WriteAsync(dataBytes.ToArray(), 0, dataBytes.Count);
		}

		public async Task CopyFromStreamAsync(Stream stream, string fileName) // копирует информацию из потока stream в файл с именем fileName
		{
			await Task.Run(mutex.WaitOne);
			Console.WriteLine("asd");
			stream.Position = 0;
			byte[] temp = new byte[stream.Length];
			await stream.ReadAsync(temp, 0, temp.Length);
			if (!File.Exists(fileName)) File.Create(fileName);
			await Task.Delay(10);
			await File.WriteAllBytesAsync(fileName, temp);
			await Task.Run(mutex.ReleaseMutex);
		}

		public async Task<int> GetStatisticsAsync(string fileName, Func<T, bool> filter) // считывает объекты типа Т из файла с именем filename 
		{                                                                                //и возвращает количество объектов, удовлетворяющих условию filter
			//byte[] lenBytes = new byte[sizeof(int)];
			//await stream.ReadAsync(lenBytes, 0, lenBytes.Length);
			//int len = BitConverter.ToInt32(lenBytes, 0);
			//byte[] objBytes = new byte[len];
			//await stream.ReadAsync(objBytes, 0, len);
			//string serialized = objBytes.Aggregate("", (result, b) => result + (char) b);
			//data.Add(JsonSerializer.Deserialize<T>(serialized));
			return 1;
		}
	}
}
