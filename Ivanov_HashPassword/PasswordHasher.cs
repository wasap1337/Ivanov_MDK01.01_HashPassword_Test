using System;
using System.Security.Cryptography;
using System.Text;

namespace Ivanov_HashPassword
{
    /// <summary>
    /// Класс для хеширования паролей алгоритмом SHA256.
    /// </summary>
    public static class PasswordHasher
    {
        /// <summary>
        /// Получает хеш пароля по алгоритму SHA256.
        /// </summary>
        /// <param name="password">Строковое значение пароля, введенного пользователем.</param>
        /// <returns>Строковое значение хеша пароля в шестнадцатеричном виде.</returns>
        public static string GetPasswordHash(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Пароль не может быть пустым.", nameof(password));
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                StringBuilder hashBuilder = new StringBuilder();
                foreach (byte hashByte in hashBytes)
                {
                    hashBuilder.Append(hashByte.ToString("x2"));
                }
                return hashBuilder.ToString();
            }
        }
    }
}
