using Net5Api.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5Api.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
    }
}