using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.UserScreens
{
  public static class UpdateUserScreen
  {
    public static void Load()
    {
      Console.WriteLine("Atualizando um Usuário");
      Console.WriteLine("----------------------");

      Console.WriteLine("Id: ");
      var id = Console.ReadLine();

      Console.WriteLine("Name: ");
      var name = Console.ReadLine();

      Console.WriteLine("E-mail: ");
      var email = Console.ReadLine();

      Console.WriteLine("Senha: ");
      var password = Console.ReadLine();

      Console.WriteLine("Bio: ");
      var bio = Console.ReadLine();

      Console.WriteLine("Slug: ");
      var slug = Console.ReadLine();

      Update(new User
      {
        Id = int.Parse(id),
        Name = name,
        Email = email,
        PasswordHash = password,
        Bio = bio,
        Image = "image",
        Slug = slug
      });
      Console.ReadKey();
      MenuUserScreen.Load();
    }

    public static void Update(User user)
    {
      try
      {
        var repository = new Repository<User>();
        repository.Update(user);
        Console.WriteLine("Usuário atualizado com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível atualizar o usuário!");
        Console.WriteLine(ex.Message);
      }
    }
  }
}