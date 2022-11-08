using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.CategoryScreens
{
  public static class DeleteCategoryScreen
  {
    public static void Load()
    {
      Console.WriteLine("Excluir uma Categoria");
      Console.WriteLine("---------------------");

      Console.WriteLine("Qual o Id da categoria que deseja excluir? ");
      var id = Console.ReadLine();
      
      Delete(int.Parse(id));
      Console.ReadKey();
      MenuCategoryScreen.Load();
    }

    public static void Delete(int id)
    {
      try
      {
        var repository = new Repository<Category>();
        repository.Delete(id);
        Console.WriteLine("Categoria deletada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível deletar a categoria!");
        Console.WriteLine(ex.Message);
      }
    }
  }
}