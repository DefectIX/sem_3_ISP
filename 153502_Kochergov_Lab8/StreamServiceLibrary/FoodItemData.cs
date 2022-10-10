using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamServiceLibrary
{
	public class FoodItemData
	{
		private static long _idCounter = 1;

		public FoodItemData()
		{
		}

		public FoodItemData(long id, string name, DateTime expirationDate)
		{
			Id = id;
			Name = name;
			ExpirationDate = expirationDate;
		}

		public long Id { get; set; }
		public string Name { get; set; }
		public DateTime ExpirationDate { get; set; }

		public static FoodItemData GetRandomItem()
		{
			return new FoodItemData
			{
				Id = _idCounter++,
				//ExpirationDate = DateTime.Today.AddDays(-1),
				ExpirationDate = GetRandomDay(),
				Name = $"Name{_idCounter}"
			};
		}

		private static DateTime GetRandomDay()
		{
			DateTime start = DateTime.Today;
			Random gen = new Random();
			int min = -1000;
			int max = 1000;
			int rand = gen.Next(max - min) + min;
			return start.AddDays(rand);
		}

		public override string ToString()
		{
			return $"Id:{Id} Name:{Name} ExpirationDate:{ExpirationDate.ToShortDateString()}";
		}
	}
}
