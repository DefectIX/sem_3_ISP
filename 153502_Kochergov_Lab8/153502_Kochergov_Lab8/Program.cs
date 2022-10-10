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

			//ConsoleWriter.StartRefreshCycleAsync();

			StreamService<FoodItemData> service = new();
			List<FoodItemData> items = new();
			for(int i = 0; i < 100000; i++)
				items.Add(FoodItemData.GetRandomItem());

			MemoryStream stream = new();
			var task1 = service.WriteToStreamAsync(stream, items);
			Thread.Sleep(10);
			var task2 = service.CopyFromStreamAsync(stream, fileName);
			await Task.WhenAll(task2);

			ConsoleWriter.AddLines(12);
			var a = FoodItemData.GetRandomItem();
			ConsoleWriter.SetLine(5, a.ToString());
			//if(File.Exists(fileName)) File.Delete(fileName);
			ConsoleWriter.StopRefreshCycle();
		}
	}
}
