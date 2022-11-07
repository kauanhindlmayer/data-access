using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.UserScreens
{
  public static class DeleteUserScreen
  {
    public static void Load()
    {
      Console.WriteLine("Deletar um usuário");
      Console.WriteLine("-------------");

      Console.WriteLine("Qual o Id do usuário deseja excluir? ");
      var id = Console.ReadLine();
      
      Delete(int.Parse(id));
      Console.ReadKey();
      MenuUserScreen.Load();
    }

    public static void Delete(int id)
    {
      try
      {
        var repository = new Repository<User>();
        repository.Delete(id);
        Console.WriteLine("Usuário deletado com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível deletar o usuário!");
        Console.WriteLine(ex.Message);
      }
    }
  }
}