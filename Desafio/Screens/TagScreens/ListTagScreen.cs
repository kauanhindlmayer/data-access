using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.TagScreens
{
  public static class ListTagScreen
  {
    public static void Load()
    {
      Console.WriteLine("Lista de tags");
      Console.WriteLine("-------------");
      List();
      Console.ReadKey();
    }

    private static void List()
    {
      var repository = new Repository<Tag>();
      var tags = repository.Get();

      foreach (var item in tags)
        Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
    }
  }
}