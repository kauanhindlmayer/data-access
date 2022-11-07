using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.TagScreens
{
  public static class CreateTagScreen
  {
    public static void Load()
    {
      Console.WriteLine("Nova tag");
      Console.WriteLine("-------------");

      Console.WriteLine("Name: ");
      var name = Console.ReadLine();

      Console.WriteLine("Slug: ");
      var slug = Console.ReadLine();
      Create(new Tag {
        Name = name,
        Slug = slug
      });
      Console.ReadKey();
      MenuTagScreen.Load();
    }

    public static void Create(Tag tag)
    {
      try {
        var repository = new Repository<Tag>();
        repository.Create(tag);
        Console.WriteLine("Tag criada com sucesso!");
      } 
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível salvar a tag!");
        Console.WriteLine(ex.Message);
      }
    }
  }
}