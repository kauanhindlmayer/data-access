using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.RoleScreens
{
  public static class CreateRoleScreen
  {
    public static void Load()
    {
      Console.WriteLine("Novo Perfil");
      Console.WriteLine("-----------");

      Console.WriteLine("Name: ");
      var name = Console.ReadLine();

      Console.WriteLine("Slug: ");
      var slug = Console.ReadLine();
      Create(new Role {
        Name = name,
        Slug = slug
      });
      Console.ReadKey();
      MenuRoleScreen.Load();
    }

    public static void Create(Role role)
    {
      try {
        var repository = new Repository<Role>();
        repository.Create(role);
        Console.WriteLine("Perfil criado com sucesso!");
      } 
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível salvar o perfil!");
        Console.WriteLine(ex.Message);
      }
    }
  }
}