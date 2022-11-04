using System;
using Dapper;
using Microsoft.Data.SqlClient;
using Modulo2.Models;

namespace Modulo2
{
	class Program
  {
    static void Main(string[] args)
    {
      const string connectionString = "Server=localhost,1433;Database=baltaDB;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

      using (var connection = new SqlConnection(connectionString))
      {
        var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
        foreach (var category in categories)
        {
          Console.WriteLine($"{category.Id} - {category.Title}");
        }
      }

      Console.WriteLine("Hello, World!");
    }
  }
}