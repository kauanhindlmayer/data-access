using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.RoleScreens
{
  public static class UpdateRoleScreen
  {
    public static void Load()
    {
      Console.WriteLine("Atualizando um Perfil");
      Console.WriteLine("---------------------");

      Console.WriteLine("Id: ");
      var id = Console.ReadLine();

      Console.WriteLine("Name: ");
      var name = Console.ReadLine();

      Console.WriteLine("Slug: ");
      var slug = Console.ReadLine();
      Update(new Role
      {
        Id = int.Parse(id),
        Name = name,
        Slug = slug
      });
      Console.ReadKey();
      MenuRoleScreen.Load();
    }

    public static void Update(Role role)
    {
      try
      {
        var repository = new Repository<Role>();
        repository.Update(role);
        Console.WriteLine("Perfil atualizado com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível atualizar o perfil!");
        Console.WriteLine(ex.Message);
      }
    }
  }
}