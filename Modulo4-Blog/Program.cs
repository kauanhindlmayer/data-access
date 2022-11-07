using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
  public class Program
  {
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
    public static void Main(string[] args)
    {
      var connection = new SqlConnection(CONNECTION_STRING);
      connection.Open();
      ReadUsers(connection);
      // CreateUser(connection);
      connection.Close();
    }

    public static void ReadUsers(SqlConnection connection)
    {
      var repository = new Repository<User>(connection);
      var items = repository.Get();

      foreach (var item in items)
      {
        Console.WriteLine(item.Name);
        foreach(var role in item.Roles)
        {
          Console.WriteLine($" - {role.Name}");
        }
      }
    }

    public static void CreateUser(SqlConnection connection)
    {
      var user = new User {
        Name = "Kauan",
        Email = "kauan@gmail.com",
        PasswordHash = "1qrs4iw8402#",
        Bio = "Alguma coisa",
        Image = "dasndas",
        Slug = "kauan"
      };

      var repository = new Repository<User>(connection);
      repository.Create(user);
      Console.WriteLine($"Usuário {user.Name} criado com sucesso!");
    }
  }
}