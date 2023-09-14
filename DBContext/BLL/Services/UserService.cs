using DBContextApp.DAL.Repositories;
using DBContextApp.BLL.Models;
using DBContextApp.BLL.Exceptions;
using System.Numerics;

namespace DBContextApp.BLL.Services
{
    public class UserService
    {
        EFBaseRepository<User> userRepository;

        public UserService(DBContextApp.DAL.AppContext appContext)
        {
            //userRepository = new EFBaseRepository<User>(new DBContextApp.DAL.AppContext());
            userRepository = new EFBaseRepository<User>(appContext);
        }

        public User FindById(int id)
        {
            var findUser = userRepository.FindById(id);
            if (findUser is null) throw new UserNotFoundException();

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
