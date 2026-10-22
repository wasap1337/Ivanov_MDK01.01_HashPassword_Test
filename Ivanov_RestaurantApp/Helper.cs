using RestaurantModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ivanov_RestaurantApp
{
    /// <summary>
    /// Вспомогательный класс для работы с базой данных «Ресторан».
    /// </summary>
    internal class Helper
    {
        /// <summary>
        /// Статическая приватная переменная для хранения контекста модели данных.
        /// </summary>
        private static RestaurantEntities _context;

        /// <summary>
        /// Метод для получения контекста данных, необходимого для подключения к БД.
        /// </summary>
        /// <returns>Контекст данных типа RestaurantEntities.</returns>
        public static RestaurantEntities GetContext()
        {
            if (_context == null)
            {
                _context = new RestaurantEntities();
            }
            return _context;
        }

        /// <summary>
        /// Метод для добавления новой записи о пользователе в таблицу Users базы данных.
        /// </summary>
        /// <param name="user">Объект типа Users, содержащий информацию о новом пользователе.</param>
        public void CreateUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Метод для проверки существования пользователя с указанным логином.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <returns>True, если пользователь с таким логином уже существует.</returns>
        public bool IsLoginExists(string login)
        {
            return _context.Users.Any(x => x.LoginUser == login);
        }

        /// <summary>
        /// Метод для получения списка всех пользователей с наименованием их роли.
        /// </summary>
        /// <returns>Список пользователей.</returns>
        public List<Users> GetAllUsers()
        {
            return _context.Users.Include(x => x.Roles).ToList();
        }

        /// <summary>
        /// Метод для получения списка ролей.
        /// </summary>
        /// <returns>Список ролей.</returns>
        public List<Roles> GetAllRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
