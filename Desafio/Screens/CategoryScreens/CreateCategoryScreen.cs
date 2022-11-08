using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.CategoryScreens
{
  public static class CreateCategoryScreen
  {
    public static void Load()
    {
      Console.WriteLine("Nova Categoria");
      Console.WriteLine("--------------");

      Console.WriteLine("Name: ");
      var name = Console.ReadLine();

      Console.WriteLine("Slug: ");
      var slug = Console.ReadLine();
      Create(new Category {
        Name = name,
        Slug = slug,
        Posts = new List<Post>()
      });
      Console.ReadKey();
      MenuCategoryScreen.Load();
    }

    public static void Create(Category category)
    {
      try {
        var repository = new Repository<Category>();
        repository.Create(category);
        Console.WriteLine("Categoria criada com sucesso!");
      } 
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível salvar a categoria!");
        Console.WriteLine(ex.Message);
      }
    }
  }
}