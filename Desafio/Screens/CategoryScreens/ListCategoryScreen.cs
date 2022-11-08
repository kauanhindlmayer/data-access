using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.CategoryScreens
{
  public static class ListCategoryScreen
  {
    public static void Load()
    {
      Console.WriteLine("Lista de Categorias");
      Console.WriteLine("-------------------");
      List();
      Console.ReadKey();
      MenuCategoryScreen.Load();
    }

    private static void List()
    {
      var repository = new Repository<Category>();
      var tags = repository.Get();

      foreach (var item in tags)
        Console.WriteLine($"{item.Name} ({item.Slug})");
    }
  }
}