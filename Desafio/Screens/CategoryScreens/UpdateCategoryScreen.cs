using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.CategoryScreens
{
  public static class UpdateCategoryScreen
  {
    public static void Load()
    {
      Console.WriteLine("Atualizando uma Categoria");
      Console.WriteLine("-------------------------");

      Console.WriteLine("Id: ");
      var id = Console.ReadLine();

      Console.WriteLine("Name: ");
      var name = Console.ReadLine();

      Console.WriteLine("Slug: ");
      var slug = Console.ReadLine();
      Update(new Category
      {
        Id = int.Parse(id),
        Name = name,
        Slug = slug,
        Posts = new List<Post>()
      });
      Console.ReadKey();
      MenuCategoryScreen.Load();
    }

    public static void Update(Category category)
    {
      try
      {
        var repository = new Repository<Category>();
        repository.Update(category);
        Console.WriteLine("Categoria atualizada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível atualizar a categoria!");
        Console.WriteLine(ex.Message);
      }
    }
  }
}