using DBContextApp.DAL.Repositories;
using DBContextApp.BLL.Models;
using DBContextApp.BLL.Exceptions;
using System.Numerics;

namespace DBContextApp.BLL.Services
{
    public class UserService : BaseService<User>
    {
        UserRepository userRepository;

        public UserService(DBContextApp.DAL.AppContext appContext) : base(appContext)
        {

            userRepository = new UserRepository(appContext);
        }

    }
}
