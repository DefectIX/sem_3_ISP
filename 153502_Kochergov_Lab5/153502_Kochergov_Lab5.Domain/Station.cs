using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kochergov_Lab5.Domain
{
	public class Station
	{
		public LuggageOffice LuggageOffice { get; }

		public Station(LuggageOffice luggageOffice)
		{
			LuggageOffice = luggageOffice;
		}

		public override string ToString()
		{
			return
				$"Luggage office:\t" +
				$"ContainersNumber:{LuggageOffice.ContainersNumber}, " +
				$"PhoneNumber:{LuggageOffice.PhoneNumber}, " +
				$"WorkersNumber:{LuggageOffice.WorkersNumber}";
		}
	}
}
