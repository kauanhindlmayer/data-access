using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.TagScreens
{
  public static class UpdateTagScreen
  {
    public static void Load()
    {
      Console.WriteLine("Atualizando uma tag");
      Console.WriteLine("-------------");

      Console.WriteLine("Id: ");
      var id = Console.ReadLine();

      Console.WriteLine("Name: ");
      var name = Console.ReadLine();

      Console.WriteLine("Slug: ");
      var slug = Console.ReadLine();
      Update(new Tag
      {
        Id = int.Parse(id),
        Name = name,
        Slug = slug
      });
      Console.ReadKey();
      MenuTagScreen.Load();
    }

    public static void Update(Tag tag)
    {
      try {
        var repository = new Repository<Tag>();
        repository.Update(tag);
        Console.WriteLine("Tag atualizada com sucesso!");
      } 
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível atualizar a tag!");
        Console.WriteLine(ex.Message);
      }
    }
  }
}