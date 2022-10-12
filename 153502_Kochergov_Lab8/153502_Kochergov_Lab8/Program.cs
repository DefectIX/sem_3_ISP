using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using StreamServiceLibrary;

namespace _153502_Kochergov_Lab8
{
	class Program
	{
		static async Task Main(string[] args)
		{
			string fileName = "file";

			ConsoleWriter.StartRefreshCycleAsync();

			StreamService<FoodItemData> service = new();
			List<FoodItemData> items = new();
			for (int i = 0; i < 10000; i++)
				items.Add(FoodItemData.GetRandomItem());

			MemoryStream stream = new();
			ConsoleWriter.AddLines(1);
			ConsoleWriter.SetLine(0, "WriteToStreamAsync progress:");
			var task1 = service.WriteToStreamAsync(stream, items);
			ConsoleWriter.AddLines(3);
			ConsoleWriter.SetLine(3, "CopyFromStreamAsync progress:");
			Thread.Sleep(150);
			var task2 = service.CopyFromStreamAsync(stream, fileName);
			task2.Wait();

			var task3 = service.GetStatisticsAsync(fileName, item => item.ExpirationDate < DateTime.Today);
			task3.Wait();
			//ConsoleWriter.AddLines(12);
			//int c = 0;
			//items.ForEach((item => c += item.ExpirationDate < DateTime.Today ? 1 : 0));
			//ConsoleWriter.SetLine(0, $"Actual: {c}");
			//ConsoleWriter.SetLine(1, $"Obtained: {task3.Result}");
			//var a = FoodItemData.GetRandomItem();
			//ConsoleWriter.SetLine(5, a.ToString());
			//if(File.Exists(fileName)) File.Delete(fileName);
			ConsoleWriter.StopRefreshCycle();
		}
	}
}
