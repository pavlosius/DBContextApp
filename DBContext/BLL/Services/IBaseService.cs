using DBContextApp.DAL.Repositories;
using DBContextApp.BLL.Models;
using DBContextApp.BLL.Exceptions;
using System.Numerics;

namespace DBContextApp.BLL.Services
{
    public interface IEFBaseService<TEntity> : IEFBaseRepository<TEntity> where TEntity : class 
    {


    }
}
