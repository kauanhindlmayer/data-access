using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.RoleScreens
{
  public static class DeleteRoleScreen
  {
    public static void Load()
    {
      Console.WriteLine("Excluir um Perfil");
      Console.WriteLine("-----------------");

      Console.WriteLine("Qual o Id do perfil que deseja excluir? ");
      var id = Console.ReadLine();
      
      Delete(int.Parse(id));
      Console.ReadKey();
      MenuRoleScreen.Load();
    }

    public static void Delete(int id)
    {
      try
      {
        var repository = new Repository<Role>();
        repository.Delete(id);
        Console.WriteLine("Perfil deletado com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível deletar o perfil!");
        Console.WriteLine(ex.Message);
      }
    }
  }
}