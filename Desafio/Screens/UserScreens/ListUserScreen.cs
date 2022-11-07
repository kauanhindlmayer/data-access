using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.UserScreens
{
  public static class ListUserScreen
  {
    public static void Load()
    {
      Console.WriteLine("Lista de Usuários");
      Console.WriteLine("-----------------");
      List();
      Console.ReadKey();
      MenuUserScreen.Load();
    }

    public static void List()
    {
      var repository = new Repository<User>();
      var users = repository.Get();

      foreach (var user in users)
        Console.WriteLine($"{user.Id} - {user.Name} ({user.Email})");
    }
  }
}