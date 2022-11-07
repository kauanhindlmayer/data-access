using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.TagScreens
{
  public static class DeleteTagScreen
  {
    public static void Load()
    {
      Console.WriteLine("Excluir uma tag");
      Console.WriteLine("-------------");

      Console.WriteLine("Qual o Id da tag que deseja excluir? ");
      var id = Console.ReadLine();
      
      Delete(int.Parse(id));
      Console.ReadKey();
      MenuTagScreen.Load();
    }

    public static void Delete(int id)
    {
      try
      {
        var repository = new Repository<Tag>();
        repository.Delete(id);
        Console.WriteLine("Tag deletada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível deletar a tag!");
        Console.WriteLine(ex.Message);
      }
    }
  }
}