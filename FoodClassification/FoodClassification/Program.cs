using System;

namespace FoodClassification
{
	class Program
	{
		static void Main(string[] args)
		{
			var populate = PopulateFood.Execute();
			Console.WriteLine(populate);
		}
	}
}
