using DBContextApp.DAL.Repositories;
using DBContextApp.BLL.Models;
using DBContextApp.BLL.Exceptions;
using System.Numerics;

namespace DBContextApp.BLL.Services
{
    public class UserService0
    {
        UserRepository userRepository;

        public UserService0(DBContextApp.DAL.AppContext appContext)
        {
            userRepository = new UserRepository(appContext);
        }

        public User FindById(int id)
        {
            var findUser = userRepository.FindById(id);
            if (findUser is null) throw new ItemNotFoundException();

            return findUser;
        }

        public List<User> FindAll()
        {
            return userRepository.FindAll();
        }

        public void Add(string name, string email)
        {
            var newUser = new User()
            {
                Name = name,
                Email = email,
            };
            userRepository.Add(newUser);
        }

        public void RemoveById(int userId)
        {
            var findUser = FindById(userId);
            if (findUser != null)
            {
                userRepository.Remove(findUser);
            }
            else
            {
                Console.WriteLine("Пользователь с таким Id не найден!");
            }

        }
    }
}
