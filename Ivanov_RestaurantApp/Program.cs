using Ivanov_HashPassword;
using RestaurantModel;
using System;

namespace Ivanov_RestaurantApp
{
    /// <summary>
    /// Точка входа консольного приложения регистрации пользователя.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper helper = new Helper();
            Helper.GetContext();

            Console.WriteLine("Регистрация пользователя в системе «Ресторан»");
            Console.WriteLine("----------------------------------------------");

            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            // Проверка уникальности логина в БД
            if (helper.IsLoginExists(login))
            {
                Console.WriteLine("Ошибка: пользователь с таким логином уже существует.");
                Console.ReadLine();
                return;
            }

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            // Выбор роли из справочника
            Console.WriteLine("Доступные роли:");
            foreach (Roles role in helper.GetAllRoles())
            {
                Console.WriteLine($"{role.IdRole}. {role.NameRole}");
            }
            Console.Write("Выберите номер роли: ");
            int idRole = int.Parse(Console.ReadLine());

            // Хеширование пароля библиотечным методом перед записью в БД
            string passwordHash = PasswordHasher.GetPasswordHash(password);

            Users newUser = new Users
            {
                LoginUser = login,
                PasswordHash = passwordHash,
                IdRole = idRole
            };

            helper.CreateUser(newUser);
            Console.WriteLine("Пользователь успешно зарегистрирован!");

            // Вывод всех пользователей (макет из рисунка 2)
            Console.WriteLine();
            Console.WriteLine("Список пользователей:");
            foreach (Users user in helper.GetAllUsers())
            {
                Console.WriteLine($"Логин: {user.LoginUser}, Роль: {user.Roles.NameRole}");
                Console.WriteLine($"Хеш пароля: {user.PasswordHash}");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
