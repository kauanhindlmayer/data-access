﻿using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Modulo3.Models;

namespace Modulo3
{
  class Program
  {
    static void Main(string[] args)
    {
      const string connectionString = "Server=localhost,1433;Database=baltaDB;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

      using (var connection = new SqlConnection(connectionString))
      {
        // CreateCategory(connection);
        // UpdateCategory(connection);
        // CreateManyCategories(connection);
        // ListCategories(connection);
        // ExecuteProcedure(connection);
        // ExecuteReadProcedure(connection);
        ExecuteScalar(connection);
      }
    }

    static void ListCategories(SqlConnection connection)
    {
      var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
      foreach (var item in categories)
      {
        Console.WriteLine($"{item.Id} - {item.Title}");
      }
    }

    static void CreateCategory(SqlConnection connection)
    {
      var category = new Category();
      category.Id = Guid.NewGuid();
      category.Title = "Amazon AWS";
      category.Url = "amazon";
      category.Description = "Categoria destinada a serviços AWS";
      category.Order = 8;
      category.Summary = "AWS Cloud";
      category.Featured = false;

      var insertSql = @"
      INSERT INTO 
        [Category] 
      VALUES(
        @Id, 
        @Title, 
        @Url, 
        @Summary, 
        @Order, 
        @Description, 
        @Featured
      )";

      var rows = connection.Execute(insertSql, new
      {
        category.Id,
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Featured
      });

      Console.WriteLine($"{rows} linhas inseridas");
    }

    static void UpdateCategory(SqlConnection connection)
    {
      var updateQuery = "UPDATE [Category] SET [Title]=@title WHERE [Id]=@id";
      var rows = connection.Execute(updateQuery, new
      {
        id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
        title = "Frontend 2022"
      });

      Console.WriteLine($"{rows} registros atualizados");
    }

    static void CreateManyCategories(SqlConnection connection)
    {
      var category = new Category();
      category.Id = Guid.NewGuid();
      category.Title = "Amazon AWS";
      category.Url = "amazon";
      category.Description = "Categoria destinada a serviços AWS";
      category.Order = 8;
      category.Summary = "AWS Cloud";
      category.Featured = false;

      var category2 = new Category();
      category2.Id = Guid.NewGuid();
      category2.Title = "Nova Categoria";
      category2.Url = "categoria-nova";
      category2.Description = "Nova categoria";
      category2.Order = 9;
      category2.Summary = "Categoria";
      category2.Featured = true;

      var insertSql = @"
      INSERT INTO 
        [Category] 
      VALUES(
        @Id, 
        @Title, 
        @Url, 
        @Summary, 
        @Order, 
        @Description, 
        @Featured
      )";

      var rows = connection.Execute(insertSql, new[]{
        new
        {
          category.Id,
          category.Title,
          category.Url,
          category.Summary,
          category.Order,
          category.Description,
          category.Featured
        },
        new
        {
          category2.Id,
          category2.Title,
          category2.Url,
          category2.Summary,
          category2.Order,
          category2.Description,
          category2.Featured
        }
      });
      Console.WriteLine($"{rows} linhas inseridas");
    }

    static void ExecuteProcedure(SqlConnection connection)
    {
      var procedure = "[spDeleteStudent]";
      var pars = new { StudentId = "fb439ab4-0a92-4caf-a274-5eb19050eca5" };
      var affectedRows = connection.Execute(
        procedure, 
        pars, 
        commandType: CommandType.StoredProcedure
      );

      Console.WriteLine($"{affectedRows} linhas afetadas.");
    }

    static void ExecuteReadProcedure(SqlConnection connection)
    {
      var procedure = "[spGetCoursesByCategory]";
      var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
      var courses = connection.Query(
        procedure, 
        pars, 
        commandType: CommandType.StoredProcedure
      );

      foreach (var item in courses)
      {
        Console.WriteLine(item.Id);
      }
    }

    static void ExecuteScalar(SqlConnection connection)
    {
      var category = new Category();
      category.Title = "Amazon AWS";
      category.Url = "amazon";
      category.Description = "Categoria destinada a serviços AWS";
      category.Order = 8;
      category.Summary = "AWS Cloud";
      category.Featured = false;

      var insertSql = @"
      INSERT INTO 
        [Category] 
      OUTPUT inserted.[Id]
      VALUES(
        NEWID(), 
        @Title, 
        @Url, 
        @Summary, 
        @Order, 
        @Description, 
        @Featured
      )";

      var id = connection.ExecuteScalar<Guid>(insertSql, new
      {
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Featured
      });

      Console.WriteLine($"A categoria inserida foi: {id}");
    }
  }
}