using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.RoleScreens
{
  public static class ListRoleScreen
  {
    public static void Load()
    {
      Console.WriteLine("Lista de Perfis");
      Console.WriteLine("---------------");
      List();
      Console.ReadKey();
      MenuRoleScreen.Load();
    }

    private static void List()
    {
      var repository = new Repository<Role>();
      var tags = repository.Get();

      foreach (var item in tags)
        Console.WriteLine($"{item.Name} ({item.Slug})");
    }
  }
}