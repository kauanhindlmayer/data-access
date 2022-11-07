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
      // ReadUsers(connection);
      // CreateUser(connection);
      ReadWithRoles(connection);
      connection.Close();
    }

    public static void ReadUsers(SqlConnection connection)
    {
      var repository = new Repository<User>(connection);
      var items = repository.Get();

      foreach (var item in items)
      {
        Console.WriteLine(item.Name);
        foreach (var role in item.Roles)
        {
          Console.WriteLine($" - {role.Name}");
        }
      }
    }

    public static void CreateUser(SqlConnection connection)
    {
      var user = new User()
      {
        Name = "Name",
        Email = "email@balta.io",
        Bio = "bio",
        Image = "image",
        PasswordHash = "hash",
        Slug = "slug"
      };
      var repository = new Repository<User>(connection);
    }

    private static void ReadWithRoles(SqlConnection connection)
    {
      var repository = new UserRepository(connection);
      var users = repository.ReadWithRole();

      foreach (var user in users)
      {
        Console.WriteLine(user.Email);
        foreach (var role in user.Roles) Console.WriteLine($" - {role.Slug}");
      }
    }
  }
}