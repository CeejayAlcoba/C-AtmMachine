using AtmMachine.Interface;
using AtmMachine.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AtmMachine.Services
{
    public class UserService : IUserService
    {
        private Context _context;
        public UserService(Context context)
        {
            _context = context;
        }
        public User AddUser(User user)
        {
            var users = _context.Set<User>().ToList();
            var userByEmail = users.Where(c => c.username == user.username).FirstOrDefault();
            if (userByEmail == null)
            {
                var newMoney = new Money() { money = 0 };
                var salt = GenerateSalt(user.password);
                var hash = GenerateHashPassword(user.password, salt);
                var newUser = new User()
                {
                    name = user.name,
                    username = user.username,
                    salted = salt,
                    hashed = hash,
                    money = newMoney,
                };


                _context.Add<User>(newUser);
                _context.SaveChanges();

                return newUser;
            }
            else return null;
            
        }
        public User UpdateUser(User user)
        {
            var updateUser = _context.Find<User>(user.userId);
            updateUser.name = user.name;
            updateUser.username = user.username;
            updateUser.salted = GenerateSalt(user.password);
            updateUser.hashed = GenerateHashPassword(user.password, GenerateSalt(user.password));

            _context.Update<User>(updateUser);
            _context.SaveChanges();

            return updateUser;
        }
        public void RemoveUser(int userId)
        {
            var user = _context.Find<User>(userId);
            var money = _context.Find<Money>(user.userId);
            _context.Remove<User>(user);
            _context.Remove<Money>(money);
            _context.SaveChanges();
        }
        public User LogInUser(User user)
        {
            var users = _context.Set<User>().ToList();
            var userByEmail = users.Where(c => c.username == user.username).FirstOrDefault();
            if (userByEmail != null)
            {
                if (userByEmail.hashed == GenerateHashPassword(user.password, userByEmail.salted))
                {
                    return userByEmail;
                }
                else return null;
            }
            else return null;
        }
        public byte[] GenerateSalt(string password)
        {
            var salt = new byte[128 / 8];

            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            return salt;
        }

        public string GenerateHashPassword(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
