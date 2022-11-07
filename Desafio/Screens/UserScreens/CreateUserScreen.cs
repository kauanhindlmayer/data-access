using System;
using Desafio.Models;
using Desafio.Repositories;

namespace Desafio.Screens.UserScreens
{
  public static class CreateUserScreen
  {
    public static void Load()
    {
      Console.WriteLine("Novo Usuário");
      Console.WriteLine("------------");

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

      Create(new User {
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

    public static void Create(User user)
    {
      try {
        var repository = new Repository<User>();
        repository.Create(user);
        Console.WriteLine("Usuário criado com sucesso!");
      } 
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível criar a usuário!");
        Console.WriteLine(ex.Message);
      }
    }
  }
}