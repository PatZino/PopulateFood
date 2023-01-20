using System;
using System.Data.SqlClient;
using System.IO;
using FoodClassification.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FoodClassification
{
	public static class PopulateFood
    {
        public static string Execute()
        {
            var conn = DatabaseConnection.Connection();
            var filePath = @"C:\PProjects\FoodClassification\FoodClassification\Utilities\FoodType.json";
            var myJsonString = File.ReadAllText(filePath);
            var myJObject = JObject.Parse(myJsonString).ToString();
            var foodList = JsonConvert.DeserializeObject<RootObject>(myJObject);

            foreach (var item in foodList.FoodTypes)
            {
                Console.WriteLine(item.Category);
                var category = item.Category;

                foreach (var food in item.Foods)
                {
                    Console.WriteLine(food);
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO Food (Name, Category) VALUES (@0, @1)", conn);
                    insertCommand.Parameters.Add(new SqlParameter("0", food));
                    insertCommand.Parameters.Add(new SqlParameter("1", category));
                    insertCommand.ExecuteNonQuery();
                }
                Console.WriteLine($"-----End of Category {category}----");
                Console.WriteLine();
            }
            return "done";
        }
    }
}
